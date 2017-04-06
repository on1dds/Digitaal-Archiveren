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

namespace Abonneren.forms
{
    public partial class Formulier : Form
    {
        DataSet dataset = new DataSet();
        string username = Environment.UserName;
        SelectieLijst selectielijst = new SelectieLijst();
        List<SelectiePunt> plattelijst = new List<SelectiePunt>();
        List<string> diensten = new List<string>();
        AbonnementenLijst abonnementen = new AbonnementenLijst();

        public Formulier()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // test
            dataset.ReadXml(@"selectielijst.xml");

            foreach(DataTable t in dataset.Tables)
            {
                t.EndLoadData();
                string i = "";
            }


            chkMijnDiensten.Checked = true;
            diensten = getADDiensten();
            lstDiensten.SelectedIndex = 0;

            // lees selectielijst en abonnementen van bestand
            selectielijst = Tools.ReadSelectielijst(@"selectielijst.xml");
            plattelijst = selectielijst.Selectiepunten;
            abonnementen = Tools.ReadAbonnementen(@"abonnementen.xml");

            // selectielijst naar TreeView
            treeSelectielijst.Nodes.Clear();
            FillTree(plattelijst);
            //treeSelectielijst.SelectedNode = treeSelectielijst.Nodes[0];

            UpdateAbonnementen();
        }

        private void FillTree(List<SelectiePunt> lijst)
        {
            TreeNodeCollection tnc = treeSelectielijst.Nodes;
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

        private void UpdateAbonnementen()
        {
            var pt = abonnementen.Lijst.Where(o => o.Dienst == lstDiensten.SelectedItem.ToString());
            List<Abonnement> lijst = pt.ToList();
            lstAliassen.Items.Clear();
            txtAliasnaam.Text = "";
            foreach (Abonnement a in pt)
                lstAliassen.Items.Add(a.Alias);

        }

        private void ToonPunt(string puntid)
        {

            var pt = plattelijst.First(o => o.id == puntid);
            SelectiePunt punt = (SelectiePunt)pt;
            ToonPunt(punt);
        }

        private void ToonPunt(SelectiePunt p)
        {
            var pt = plattelijst.First(o => o.id == p.id);
            txtPuntID.Text = p.GetPuntID;
            txtPuntinfo2.Text = p.Identificatie;

            var result = treeSelectielijst.Nodes.Find(p.id, true);
            if (result.Length > 0)
            {
                TreeNode r = result[0];
                treeSelectielijst.SelectedNode = r;
                treeSelectielijst.Select();
            }
        }

        private void lstAliassen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAliassen.SelectedIndex > 0)
            {
                var pt = abonnementen.Lijst.Where(o => o.Alias == lstAliassen.SelectedItem.ToString());
                List<Abonnement> lst = pt.ToList();
                var pt2 = lst.First(o => o.Dienst == lstDiensten.SelectedItem.ToString());
                Abonnement abo = pt2;
                ToonPunt(pt2.PuntID);
            } 
        }

        private void lstDiensten_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAbonnementen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Abonnement abo = new Abonnement();
            abo.Alias = txtAliasnaam.Text.Trim();
            if (abo.Alias != "")
            {
                SelectiePunt p = (SelectiePunt)treeSelectielijst.SelectedNode.Tag;
                abo.Dienst = lstDiensten.SelectedItem.ToString();
                abo.PuntID = p.id;
                abonnementen.Lijst.Add(abo);
                UpdateAbonnementen();
                txtAliasnaam.Text = "";
            }
        }

        private void treeSelectielijst_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            SelectiePunt p = (SelectiePunt)treeSelectielijst.SelectedNode.Tag;
            ToonPunt(p);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tools.WriteAbonnementen(@"abonnementen.xml", abonnementen);
        }

        private void btnAfmelden_Click(object sender, EventArgs e)
        {
            string dienst = lstDiensten.Text;
            string alias = lstAliassen.Text;

            for (int i = 0; i < abonnementen.Lijst.Count; i++)
            {
                if (abonnementen.Lijst[i].Dienst == dienst && abonnementen.Lijst[i].Alias == alias)
                {
                    abonnementen.Lijst.RemoveAt(i);
                }
            }
            UpdateAbonnementen();

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
    }
}
