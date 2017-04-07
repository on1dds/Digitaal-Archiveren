using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace Abonneren
{
    public partial class Formulier : Form
    {
        // Selectielijst
        List<SelectiePunt> selectiepunten = new List<SelectiePunt>();
        AboLijst abolijst = new AboLijst();

        // Active Directory gegevens
        string username = Environment.UserName;
        List<string> diensten = new List<string>();

        public Formulier()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // stel het formulier in
            chkMijnDiensten.Checked = true;
            diensten = getADDiensten();
            lstDiensten.SelectedIndex = 0;
            treeMappen.LabelEdit = true;

            // lees selectielijst en abonnementen uit XML bestanden
            SelectieLijst lijst = new SelectieLijst();
            lijst = Tools.ReadSelectielijst(@"selectielijstx.xml");
            if (lijst != null)
            {
                selectiepunten = lijst.Selectiepunten;
                abolijst = Tools.ImportAbo(@"abonnementen.xml");

                treeSelectiepunten.Nodes.Clear();
                treeSelectielijst_import(selectiepunten);
                //treeSelectielijst.SelectedNode = treeSelectielijst.Nodes[0];

                toonDienstmappen();
            }
            else
            {
                Tools.ToonFout("Geen selectielijst gevonden!");
                Application.Exit();
            }
        }


        // zoek <TAG> in tree
        private TreeNode GetTreenode(TreeNode tn, string zoek)
        {
            if (tn.Tag.ToString() == zoek)
            {
                return tn;
            } else {
                foreach (TreeNode tn2 in tn.Nodes)
                {
                    GetTreenode(tn2, zoek);
                }
            }
            return new TreeNode();
        }

        // toon mappenlijst van huidig geselecteerde dienst
        private void toonDienstmappen()
        {
            var pt = abolijst.Lijst.Where(o => o.Dienst == lstDiensten.SelectedItem.ToString());
            List<Abonnement> lijst = pt.ToList();
            treeMappen.Nodes.Clear();
            // lstAliassen.Items.Clear();
            txtAliasnaam.Text = "";
            foreach (Abonnement a in pt)
                treeMappen.Nodes.Add(a.Alias);
                // lstAliassen.Items.Add(a.Alias);

        }

        // toon selectiepunt in treeSelectielijst
        private void ToonPunt(string puntid)
        {
            var pt = selectiepunten.First(o => o.id == puntid);
            SelectiePunt punt = (SelectiePunt)pt;
            ToonPunt(punt);
        }

        private void ToonPunt(SelectiePunt p)
        {
            var pt = selectiepunten.First(o => o.id == p.id);
            txtPuntID.Text = p.GetPuntID;
            txtPuntinfo2.Text = p.Identificatie;

            var result = treeSelectiepunten.Nodes.Find(p.id, true);
            if (result.Length > 0)
            {
                TreeNode r = result[0];
                treeSelectiepunten.SelectedNode = r;
                treeSelectiepunten.Select();
            } 
        }


        // zoek en toon het punt in de selectielijst dat overeenkomt met de geselecteerde node
        private void button1_Click(object sender, EventArgs e)
        {
            Abonnement abo = new Abonnement();
            abo.Alias = txtAliasnaam.Text.Trim();
            if (abo.Alias != "")
            {
                SelectiePunt p = (SelectiePunt)treeSelectiepunten.SelectedNode.Tag;
                abo.Dienst = lstDiensten.SelectedItem.ToString();
                abo.PuntID = p.id;
                abolijst.Lijst.Add(abo);
                toonDienstmappen();
                txtAliasnaam.Text = "";
            }
        }

        // Vul de TreeView met de punten uit de selectielijst

        private void btnAfmelden_Click(object sender, EventArgs e)
        {
            string dienst = lstDiensten.Text;
            string alias = treeMappen.SelectedNode.Text;
            // string alias = lstAliassen.Text;

            for (int i = 0; i < abolijst.Lijst.Count; i++)
            {
                if (abolijst.Lijst[i].Dienst == dienst && abolijst.Lijst[i].Alias == alias)
                {
                    abolijst.Lijst.RemoveAt(i);
                }
            }
            toonDienstmappen();

        }


        private void chkMijnDiensten_CheckedChanged(object sender, EventArgs e)
        {
            lstDiensten.Items.Clear();

            if (chkMijnDiensten.Checked == true)
            {
                PrincipalSearchResult<Principal> groups = UserPrincipal.Current.GetGroups();
                IEnumerable<string> groupNames = groups.Select(x => x.SamAccountName);

                foreach (string groep in groupNames)
                {
                    if (groep.Length > 7 && groep.Substring(0, 7) == "dienst_")
                        lstDiensten.Items.Add(groep.Substring(7));
                }
            } else
            {
                foreach (string d in diensten)
                    lstDiensten.Items.Add(d);
            }
            lstDiensten.SelectedIndex = 0;
        }


        private List<String> getADDiensten()
        {
            List<String> lijst = new List<String>();
            // create your domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            GroupPrincipal qbeGroup = new GroupPrincipal(ctx);
            PrincipalSearcher srch = new PrincipalSearcher(qbeGroup);

            foreach (var found in srch.FindAll())
            {
                Principal p = (Principal)found;
                string naam = p.Name;
                if (naam.Length > 7 && naam.Substring(0, 7) == "dienst_")
                    lijst.Add(naam.Substring(7));
            }
            return lijst;
        }

        private TreeNode GetRootNode(TreeNode tn)
        {
            while (tn.Parent != null)
                tn = tn.Parent;
            return tn;
        }

        #region event handlers
        private void frmAbonneren_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tools.ExportAbo(@"abonnementen.xml", abolijst);
        }

        private void treeSelectielijst_import(List<SelectiePunt> lijst)
        {
            TreeNodeCollection tnc = treeSelectiepunten.Nodes;
            foreach (SelectiePunt punt in lijst)
            {
                var result = tnc.Find(punt.SuperIndex, true);
                if (result.Length > 0)
                {
                    TreeNode r = result[0];
                    r = r.Nodes.Add(punt.id, punt.NiveauNummer + ". " + punt.Omschrijving);
                    r.Tag = punt;
                }
                else
                {
                    TreeNode node = new TreeNode();
                    node = tnc.Add(punt.id, punt.NiveauNummer + ". " + punt.Omschrijving);
                    node.Tag = punt;
                }
            }
        }
        private void treeSelectielijst_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectiePunt p = (SelectiePunt)treeSelectiepunten.SelectedNode.Tag;
            ToonPunt(p);
        }

        private void treeDienstmappen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (treeMappen.SelectedNode.IsEditing == false)
                {
                    treeMappen.SelectedNode.BeginEdit();
                }
            }
        }
        private void treeDienstmappen_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

        }
        private void treeDienstmappen_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void treeDienstmappen_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void treeDienstmappen_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TreeNode srcNode;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode dstNode = ((TreeView)sender).GetNodeAt(pt);

                srcNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

                TreeNode newNode = (TreeNode)srcNode.Clone();
                if (srcNode.TreeView == treeSelectiepunten)
                    newNode.Nodes.Clear();

                if (dstNode != srcNode)
                {
                    if (dstNode != null)
                    {
                        dstNode.Nodes.Add(newNode);
                        dstNode.Expand();
                    }
                    else
                    {
                        Abonnement abo = new Abonnement();
                        string t = newNode.Text;
                        t.Trim();
                        if (t.Length > 20) t.Substring(0, 20).Trim();
                        abo.Alias = t;
                        newNode.Text = t;
                        if (abo.Alias != "")
                        {
                            SelectiePunt p = (SelectiePunt)srcNode.Tag;
                            abo.Dienst = lstDiensten.SelectedItem.ToString();
                            abo.PuntID = p.id;
                            abolijst.Lijst.Add(abo);
                            //UpdateAbonnementen();
                            txtAliasnaam.Text = "";
                        }
                        treeMappen.Nodes.Add(newNode);
                    }

                    if (srcNode.TreeView == treeMappen)
                        srcNode.Remove();
                    treeMappen.Sort();
                }
            }
        }
        private void treeDienstmappen_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeMappen.SelectedNode != null)
            {
                var pt = abolijst.Lijst.Where(o => o.Alias == treeMappen.SelectedNode.Text.ToString());
                List<Abonnement> lst = pt.ToList();
                var pt2 = lst.First(o => o.Dienst == lstDiensten.SelectedItem.ToString());
                Abonnement abo = pt2;
                ToonPunt(pt2.PuntID);
            }
        }

        #endregion
    }
}

