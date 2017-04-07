namespace Abonneren
{
    partial class Formulier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeMappen = new System.Windows.Forms.TreeView();
            this.chkMijnDiensten = new System.Windows.Forms.CheckBox();
            this.btnAfmelden = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstDiensten = new System.Windows.Forms.ListBox();
            this.treeSelectiepunten = new System.Windows.Forms.TreeView();
            this.txtPuntID = new System.Windows.Forms.TextBox();
            this.txtPuntinfo2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAbonneren = new System.Windows.Forms.Button();
            this.txtAliasnaam = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.treeMappen);
            this.groupBox1.Controls.Add(this.chkMijnDiensten);
            this.groupBox1.Controls.Add(this.btnAfmelden);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstDiensten);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 539);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Abonnementen per dienst";
            // 
            // treeMappen
            // 
            this.treeMappen.AllowDrop = true;
            this.treeMappen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeMappen.LabelEdit = true;
            this.treeMappen.Location = new System.Drawing.Point(144, 37);
            this.treeMappen.Margin = new System.Windows.Forms.Padding(2);
            this.treeMappen.Name = "treeMappen";
            this.treeMappen.Size = new System.Drawing.Size(200, 456);
            this.treeMappen.TabIndex = 6;
            this.treeMappen.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeDienstmappen_AfterLabelEdit);
            this.treeMappen.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeDienstmappen_ItemDrag);
            this.treeMappen.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDienstmappen_AfterSelect);
            this.treeMappen.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeDienstmappen_DragDrop);
            this.treeMappen.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeDienstmappen_DragEnter);
            this.treeMappen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeDienstmappen_KeyDown);
            // 
            // chkMijnDiensten
            // 
            this.chkMijnDiensten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMijnDiensten.AutoSize = true;
            this.chkMijnDiensten.Location = new System.Drawing.Point(8, 510);
            this.chkMijnDiensten.Margin = new System.Windows.Forms.Padding(2);
            this.chkMijnDiensten.Name = "chkMijnDiensten";
            this.chkMijnDiensten.Size = new System.Drawing.Size(96, 17);
            this.chkMijnDiensten.TabIndex = 5;
            this.chkMijnDiensten.Text = "Eigen diensten";
            this.chkMijnDiensten.UseVisualStyleBackColor = true;
            this.chkMijnDiensten.CheckedChanged += new System.EventHandler(this.chkMijnDiensten_CheckedChanged);
            // 
            // btnAfmelden
            // 
            this.btnAfmelden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAfmelden.Location = new System.Drawing.Point(144, 506);
            this.btnAfmelden.Margin = new System.Windows.Forms.Padding(2);
            this.btnAfmelden.Name = "btnAfmelden";
            this.btnAfmelden.Size = new System.Drawing.Size(200, 26);
            this.btnAfmelden.TabIndex = 4;
            this.btnAfmelden.Text = "Afmelden";
            this.btnAfmelden.UseVisualStyleBackColor = true;
            this.btnAfmelden.Click += new System.EventHandler(this.btnAfmelden_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dienstmappen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Diensten";
            // 
            // lstDiensten
            // 
            this.lstDiensten.Location = new System.Drawing.Point(9, 37);
            this.lstDiensten.Name = "lstDiensten";
            this.lstDiensten.Size = new System.Drawing.Size(130, 446);
            this.lstDiensten.TabIndex = 7;
            // 
            // treeSelectiepunten
            // 
            this.treeSelectiepunten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeSelectiepunten.Location = new System.Drawing.Point(5, 42);
            this.treeSelectiepunten.Name = "treeSelectiepunten";
            this.treeSelectiepunten.Size = new System.Drawing.Size(428, 382);
            this.treeSelectiepunten.TabIndex = 2;
            this.treeSelectiepunten.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeDienstmappen_ItemDrag);
            this.treeSelectiepunten.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeSelectielijst_AfterSelect);
            this.treeSelectiepunten.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeDienstmappen_DragEnter);
            // 
            // txtPuntID
            // 
            this.txtPuntID.Location = new System.Drawing.Point(5, 18);
            this.txtPuntID.Name = "txtPuntID";
            this.txtPuntID.Size = new System.Drawing.Size(100, 20);
            this.txtPuntID.TabIndex = 1;
            // 
            // txtPuntinfo2
            // 
            this.txtPuntinfo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPuntinfo2.Location = new System.Drawing.Point(7, 430);
            this.txtPuntinfo2.Multiline = true;
            this.txtPuntinfo2.Name = "txtPuntinfo2";
            this.txtPuntinfo2.Size = new System.Drawing.Size(426, 51);
            this.txtPuntinfo2.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.btnAbonneren);
            this.groupBox3.Controls.Add(this.txtAliasnaam);
            this.groupBox3.Location = new System.Drawing.Point(4, 494);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Abonneren";
            // 
            // btnAbonneren
            // 
            this.btnAbonneren.Location = new System.Drawing.Point(169, 15);
            this.btnAbonneren.Name = "btnAbonneren";
            this.btnAbonneren.Size = new System.Drawing.Size(95, 27);
            this.btnAbonneren.TabIndex = 1;
            this.btnAbonneren.Text = "Abonneer";
            this.btnAbonneren.UseVisualStyleBackColor = true;
            this.btnAbonneren.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAliasnaam
            // 
            this.txtAliasnaam.Location = new System.Drawing.Point(7, 19);
            this.txtAliasnaam.Name = "txtAliasnaam";
            this.txtAliasnaam.Size = new System.Drawing.Size(155, 20);
            this.txtAliasnaam.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtPuntinfo2);
            this.groupBox2.Controls.Add(this.txtPuntID);
            this.groupBox2.Controls.Add(this.treeSelectiepunten);
            this.groupBox2.Location = new System.Drawing.Point(2, 3);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(438, 486);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selectielijst";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(803, 545);
            this.splitContainer1.SplitterDistance = 355;
            this.splitContainer1.TabIndex = 6;
            // 
            // Formulier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 549);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Formulier";
            this.Text = "Abonneren";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAbonneren_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstDiensten;
        private System.Windows.Forms.TextBox txtPuntinfo2;
        private System.Windows.Forms.TextBox txtPuntID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAbonneren;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeSelectiepunten;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAfmelden;
        private System.Windows.Forms.TextBox txtAliasnaam;
        private System.Windows.Forms.CheckBox chkMijnDiensten;
        private System.Windows.Forms.TreeView treeMappen;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

