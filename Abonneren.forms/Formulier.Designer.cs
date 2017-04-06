namespace Abonneren.forms
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
            this.chkMijnDiensten = new System.Windows.Forms.CheckBox();
            this.btnAfmelden = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstAliassen = new System.Windows.Forms.ListBox();
            this.lstDiensten = new System.Windows.Forms.ListBox();
            this.treeSelectielijst = new System.Windows.Forms.TreeView();
            this.txtPuntID = new System.Windows.Forms.TextBox();
            this.txtPuntinfo2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAbonneren = new System.Windows.Forms.Button();
            this.txtAliasnaam = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.chkMijnDiensten);
            this.groupBox1.Controls.Add(this.btnAfmelden);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstAliassen);
            this.groupBox1.Controls.Add(this.lstDiensten);
            this.groupBox1.Location = new System.Drawing.Point(17, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(383, 424);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Abonnementen per dienst";
            // 
            // chkMijnDiensten
            // 
            this.chkMijnDiensten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMijnDiensten.AutoSize = true;
            this.chkMijnDiensten.Location = new System.Drawing.Point(11, 388);
            this.chkMijnDiensten.Name = "chkMijnDiensten";
            this.chkMijnDiensten.Size = new System.Drawing.Size(149, 20);
            this.chkMijnDiensten.TabIndex = 5;
            this.chkMijnDiensten.Text = "Toon enkel diensten";
            this.chkMijnDiensten.UseVisualStyleBackColor = true;
            this.chkMijnDiensten.CheckedChanged += new System.EventHandler(this.chkMijnDiensten_CheckedChanged);
            // 
            // btnAfmelden
            // 
            this.btnAfmelden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAfmelden.Location = new System.Drawing.Point(192, 383);
            this.btnAfmelden.Name = "btnAfmelden";
            this.btnAfmelden.Size = new System.Drawing.Size(183, 32);
            this.btnAfmelden.TabIndex = 4;
            this.btnAfmelden.Text = "Afmelden";
            this.btnAfmelden.UseVisualStyleBackColor = true;
            this.btnAfmelden.Click += new System.EventHandler(this.btnAfmelden_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dienstmappen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Diensten";
            // 
            // lstAliassen
            // 
            this.lstAliassen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAliassen.FormattingEnabled = true;
            this.lstAliassen.ItemHeight = 16;
            this.lstAliassen.Location = new System.Drawing.Point(193, 44);
            this.lstAliassen.Margin = new System.Windows.Forms.Padding(4);
            this.lstAliassen.Name = "lstAliassen";
            this.lstAliassen.Size = new System.Drawing.Size(182, 324);
            this.lstAliassen.TabIndex = 1;
            this.lstAliassen.SelectedIndexChanged += new System.EventHandler(this.lstAliassen_SelectedIndexChanged);
            // 
            // lstDiensten
            // 
            this.lstDiensten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstDiensten.FormattingEnabled = true;
            this.lstDiensten.ItemHeight = 16;
            this.lstDiensten.Location = new System.Drawing.Point(8, 44);
            this.lstDiensten.Margin = new System.Windows.Forms.Padding(4);
            this.lstDiensten.Name = "lstDiensten";
            this.lstDiensten.Size = new System.Drawing.Size(176, 324);
            this.lstDiensten.TabIndex = 0;
            this.lstDiensten.SelectedIndexChanged += new System.EventHandler(this.lstDiensten_SelectedIndexChanged);
            // 
            // treeSelectielijst
            // 
            this.treeSelectielijst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeSelectielijst.Location = new System.Drawing.Point(7, 52);
            this.treeSelectielijst.Margin = new System.Windows.Forms.Padding(4);
            this.treeSelectielijst.Name = "treeSelectielijst";
            this.treeSelectielijst.Size = new System.Drawing.Size(527, 229);
            this.treeSelectielijst.TabIndex = 2;
            this.treeSelectielijst.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeSelectielijst_AfterSelect_1);
            // 
            // txtPuntID
            // 
            this.txtPuntID.Location = new System.Drawing.Point(7, 22);
            this.txtPuntID.Margin = new System.Windows.Forms.Padding(4);
            this.txtPuntID.Name = "txtPuntID";
            this.txtPuntID.Size = new System.Drawing.Size(132, 22);
            this.txtPuntID.TabIndex = 1;
            // 
            // txtPuntinfo2
            // 
            this.txtPuntinfo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPuntinfo2.Location = new System.Drawing.Point(9, 289);
            this.txtPuntinfo2.Margin = new System.Windows.Forms.Padding(4);
            this.txtPuntinfo2.Multiline = true;
            this.txtPuntinfo2.Name = "txtPuntinfo2";
            this.txtPuntinfo2.Size = new System.Drawing.Size(525, 62);
            this.txtPuntinfo2.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.btnAbonneren);
            this.groupBox3.Controls.Add(this.txtAliasnaam);
            this.groupBox3.Location = new System.Drawing.Point(408, 381);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(365, 59);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Abonneren";
            // 
            // btnAbonneren
            // 
            this.btnAbonneren.Location = new System.Drawing.Point(225, 18);
            this.btnAbonneren.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbonneren.Name = "btnAbonneren";
            this.btnAbonneren.Size = new System.Drawing.Size(127, 33);
            this.btnAbonneren.TabIndex = 1;
            this.btnAbonneren.Text = "Abonneer";
            this.btnAbonneren.UseVisualStyleBackColor = true;
            this.btnAbonneren.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAliasnaam
            // 
            this.txtAliasnaam.Location = new System.Drawing.Point(9, 23);
            this.txtAliasnaam.Margin = new System.Windows.Forms.Padding(4);
            this.txtAliasnaam.Name = "txtAliasnaam";
            this.txtAliasnaam.Size = new System.Drawing.Size(205, 22);
            this.txtAliasnaam.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtPuntinfo2);
            this.groupBox2.Controls.Add(this.txtPuntID);
            this.groupBox2.Controls.Add(this.treeSelectielijst);
            this.groupBox2.Location = new System.Drawing.Point(408, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 358);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selectielijst";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 454);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Abonneren";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstAliassen;
        private System.Windows.Forms.ListBox lstDiensten;
        private System.Windows.Forms.TextBox txtPuntinfo2;
        private System.Windows.Forms.TextBox txtPuntID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAbonneren;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeSelectielijst;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAfmelden;
        private System.Windows.Forms.TextBox txtAliasnaam;
        private System.Windows.Forms.CheckBox chkMijnDiensten;
    }
}

