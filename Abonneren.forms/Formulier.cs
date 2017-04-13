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
using System.DirectoryServices.AccountManagement;


namespace Concorderen
{
    public partial class Formulier : Form
    {
        // Selectielijst
        public Abonnementen abo = new Abonnementen();
        public List<SelectiePunt> selectiepunten = new List<SelectiePunt>();

        // Active Directory gegevens
        string username = Environment.UserName;

        public Formulier()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // stel het formulier in
            treeMappen.LabelEdit = true;

            // lees selectielijst uit XML bestanden
            SelectieLijst selectielijst = Tools.ReadSelectielijst(@"selectielijst.xml");
            if (selectielijst == null) { Tools.ToonFout("Fout in lezen selectielijst"); Application.Exit(); }
            selectiepunten = selectielijst.Selectiepunten;

            // lees dienstmappen/concordanties
            abo.ReadDiensten();

            foreach(Dienst d in abo.Concordanties.Diensten)
            {
                lstDiensten.Items.Add(d.id);
            }

            treeSelectiepunten.Nodes.Clear();

            toonSelectielijst(selectiepunten);
            toonDienstmappen();
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

        // toon mappenlijst van huidig geselecteerde dienst
        private void toonDienstmappen()
        {
            treeMappen.Nodes.Clear();
            if (lstDiensten.SelectedItem != null)
            {
                Dienst dienst = GetDienst(lstDiensten.SelectedItem.ToString(),abo);

                foreach(Map map in dienst.Mappen)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = map;
                    tn.Text = map.id;
                    treeMappen.Nodes.Add(tn);
                    _maakdienstmappen(tn, map.Mappen);

                }
            }
        }
        private void _maakdienstmappen(TreeNode treenode, List<Map> mappen)
        {
            // !!!! ONEINDIGE LUS !!!!!
            foreach(Map map in mappen)
            {
                TreeNode newnode = new TreeNode();
                newnode.Tag = map;
                newnode.Text = map.id;
                treenode.Nodes.Add(newnode);
                if(map.Mappen.Count > 0)
                    _maakdienstmappen(newnode, map.Mappen);
            }
        }

        // toon selectiepunt in treeSelectielijst
        private void treeSelectielijst_ToonPunt(string puntid)
        {
            var pt = selectiepunten.First(o => o.id == puntid);
            SelectiePunt punt = (SelectiePunt)pt;
            treeSelectielijst_ToonPunt(punt);
        }

        private void treeSelectielijst_ToonPunt(SelectiePunt p)
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

        private TreeNode GetRootNode(TreeNode tn)
        {
            while (tn.Parent != null)
                tn = tn.Parent;
            return tn;
        }

        private Dienst GetDienst(string s, Abonnementen c)
        {
            foreach (Dienst dm in abo.Concordanties.Diensten)
            {
                if (dm.id == s)
                {
                    return dm;
                }
            }
            return null;
        }

        #region event handlers
        private void frmAbonneren_FormClosing(object sender, FormClosingEventArgs e)
        {
            abo.WriteDiensten();
        }

        private void toonSelectielijst(List<SelectiePunt> lijst)
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
            treeSelectielijst_ToonPunt(p);
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

            if (e.KeyCode == Keys.Delete)
            {
                TreeNode node = treeMappen.SelectedNode;
                Map map = (Map)node.Tag;

                if (map.Parent != null)
                    map.Parent.Mappen.Remove(map);
                else
                    map.Dienst.Mappen.Remove(map);

                node.Remove();

            }
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
            if (lstDiensten.SelectedItem != null)
            {
                Dienst dienst = GetDienst(lstDiensten.SelectedItem.ToString(), abo);

                if (dienst != null)
                {
                    TreeNode srcNode;

                    // als er een treeNode op wordt gedropt
                    if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
                    {
                        // haal de source treenode op
                        srcNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

                        // haal de destination TreeNode op.
                        Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                        TreeNode dstNode = ((TreeView)sender).GetNodeAt(pt);

                        // ITEM UIT DE SELECTIELIJST
                        if (srcNode.TreeView == treeSelectiepunten)
                        {
                            // als op node wordt gedropt
                            if (dstNode == null)
                            {
                                Map map = new Map();
                                map.Parent = null;
                                map.Dienst = abo.GetDienst(lstDiensten.SelectedItem.ToString());
                                map.id = srcNode.Text;
                                map.SelectiepuntID = ((SelectiePunt)srcNode.Tag).GetPuntID;

                                TreeNode newNode = (TreeNode)srcNode.Clone();
                                newNode.Nodes.Clear();          // verwijder child nodes
                                newNode.Tag = map;              // zorg dat het selectiepunt eraan blijft hangen
                                dienst.Mappen.Add(map);
                                treeMappen.Nodes.Add(newNode);
                                //dstNode.Expand();
                            }
                            else
                            {
                                Map map = new Map();
                                map.Parent = (Map)dstNode.Tag;
                                map.Dienst = abo.GetDienst(lstDiensten.SelectedItem.ToString());
                                map.id = srcNode.Text;
                                map.SelectiepuntID = ((SelectiePunt)srcNode.Tag).GetPuntID;

                                TreeNode newNode = (TreeNode)srcNode.Clone();
                                newNode.Nodes.Clear();          // verwijder child nodes
                                newNode.Tag = map;              // zorg dat het selectiepunt eraan blijft hangen

                                map.Parent.Mappen.Add(map);
                                dstNode.Nodes.Add(newNode);
                                // treeMappen.Nodes.Add(newNode);
                            }
                        }

                        // ITEM UIT DE MAPPENLIJST
                        if (srcNode.TreeView == treeMappen && srcNode != dstNode)
                        {
                            // ALS OP ROOT WORDT GEDROPT
                            if (dstNode == null)
                            {
                                TreeNode newNode = (TreeNode)srcNode.Clone();

                                // bouw nieuwe map
                                Map map = (Map)srcNode.Tag;
                                map.Dienst.Mappen.Remove(map);
                                srcNode.Remove();

                                newNode.Tag = map;              // zorg dat het selectiepunt eraan blijft hangen
                                dienst.Mappen.Add(map);
                                treeMappen.Nodes.Add(newNode);
                                //dstNode.Expand();

                            }
                            else  // MAPITEM OP MAPITEM DROPPEN ... DIT WERKT NOG NIET
                            {
                                
                                TreeNode newNode = (TreeNode)srcNode.Clone();

                                Map map = (Map)srcNode.Tag;

                                // MAPITEMS DIE IN DE ROOT STAAN                                {
                                if (map.Parent == null)
                                {
                                    map.Dienst.Mappen.Remove(map);
                                    srcNode.Remove();

                                    // srcNode.Parent.Nodes.Remove(srcNode);
                                    newNode.Tag = map;              // zorg dat het selectiepunt eraan blijft hangen
                                    dstNode.Nodes.Add(newNode);

                                    ((Map)dstNode.Tag).Mappen.Add(map);
                                }
                                else
                                // MAPITEMS DIE IN DE ROOT STAAN
                                {
                                    map.Parent.Mappen.Remove(map);
                                    srcNode.Remove();

                                    // srcNode.Parent.Nodes.Remove(srcNode);
                                    newNode.Tag = map;              // zorg dat het selectiepunt eraan blijft hangen
                                    dstNode.Nodes.Add(newNode);

                                    ((Map)dstNode.Tag).Mappen.Add(map);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void lstDiensten_SelectedIndexChanged(object sender, EventArgs e)
        {
            toonDienstmappen();
        }

        #endregion

        private void treeMappen_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}

