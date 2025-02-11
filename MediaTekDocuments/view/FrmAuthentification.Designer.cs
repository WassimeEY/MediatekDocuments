
namespace MediaTekDocuments.view
{
    partial class FrmAuthentification
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
            this.txtbLogin = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbMdp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAuthentification = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbLogin
            // 
            this.txtbLogin.Location = new System.Drawing.Point(94, 42);
            this.txtbLogin.Name = "txtbLogin";
            this.txtbLogin.Size = new System.Drawing.Size(172, 20);
            this.txtbLogin.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAuthentification);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtbMdp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtbLogin);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 172);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accès à l\'application";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login";
            // 
            // txtbMdp
            // 
            this.txtbMdp.Location = new System.Drawing.Point(94, 68);
            this.txtbMdp.Name = "txtbMdp";
            this.txtbMdp.PasswordChar = '•';
            this.txtbMdp.Size = new System.Drawing.Size(172, 20);
            this.txtbMdp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mot de passe";
            // 
            // btnAuthentification
            // 
            this.btnAuthentification.Location = new System.Drawing.Point(20, 125);
            this.btnAuthentification.Name = "btnAuthentification";
            this.btnAuthentification.Size = new System.Drawing.Size(246, 23);
            this.btnAuthentification.TabIndex = 4;
            this.btnAuthentification.Text = "S\'authentifier";
            this.btnAuthentification.UseVisualStyleBackColor = true;
            this.btnAuthentification.Click += new System.EventHandler(this.btnAuthentification_Click);
            // 
            // FrmAuthentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 196);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAuthentification";
            this.Text = "Authentification";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtbLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAuthentification;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbMdp;
        private System.Windows.Forms.Label label1;
    }
}