namespace Pharmacie.Forms
{
    partial class Produit_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produit_Form));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stockTxt = new System.Windows.Forms.TextBox();
            this.categCombo = new System.Windows.Forms.ComboBox();
            this.formeCombo = new System.Windows.Forms.ComboBox();
            this.dosageTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.designationTxt = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(93, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 49);
            this.button1.TabIndex = 4;
            this.button1.Text = "Nouveau";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.stockTxt);
            this.groupBox1.Controls.Add(this.categCombo);
            this.groupBox1.Controls.Add(this.formeCombo);
            this.groupBox1.Controls.Add(this.dosageTxt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.designationTxt);
            this.groupBox1.Location = new System.Drawing.Point(8, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 212);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // stockTxt
            // 
            this.stockTxt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockTxt.Location = new System.Drawing.Point(152, 168);
            this.stockTxt.Name = "stockTxt";
            this.stockTxt.Size = new System.Drawing.Size(343, 27);
            this.stockTxt.TabIndex = 15;
            // 
            // categCombo
            // 
            this.categCombo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categCombo.FormattingEnabled = true;
            this.categCombo.Location = new System.Drawing.Point(152, 134);
            this.categCombo.Name = "categCombo";
            this.categCombo.Size = new System.Drawing.Size(343, 25);
            this.categCombo.TabIndex = 14;
            this.categCombo.SelectedIndexChanged += new System.EventHandler(this.categCombo_SelectedIndexChanged);
            // 
            // formeCombo
            // 
            this.formeCombo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formeCombo.FormattingEnabled = true;
            this.formeCombo.Location = new System.Drawing.Point(152, 98);
            this.formeCombo.Name = "formeCombo";
            this.formeCombo.Size = new System.Drawing.Size(343, 25);
            this.formeCombo.TabIndex = 13;
            // 
            // dosageTxt
            // 
            this.dosageTxt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dosageTxt.Location = new System.Drawing.Point(152, 62);
            this.dosageTxt.Name = "dosageTxt";
            this.dosageTxt.Size = new System.Drawing.Size(343, 27);
            this.dosageTxt.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "En stock";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Catégorie";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Forme";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dosage";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Désignation";
            // 
            // designationTxt
            // 
            this.designationTxt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designationTxt.Location = new System.Drawing.Point(152, 25);
            this.designationTxt.Name = "designationTxt";
            this.designationTxt.Size = new System.Drawing.Size(343, 27);
            this.designationTxt.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(253, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(176, 50);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(8, 265);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(514, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(504, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Médicament";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 39);
            this.panel1.TabIndex = 8;
            // 
            // Produit_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(531, 381);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Produit_Form";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produit";
            this.Load += new System.EventHandler(this.Produit_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox designationTxt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dosageTxt;
        private System.Windows.Forms.ComboBox formeCombo;
        private System.Windows.Forms.ComboBox categCombo;
        private System.Windows.Forms.TextBox stockTxt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}