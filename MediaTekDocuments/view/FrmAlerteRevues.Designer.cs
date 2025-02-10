
namespace MediaTekDocuments.view
{
    partial class FrmAlerteRevues
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
            this.grpAlerteRevuesAboExpire = new System.Windows.Forms.GroupBox();
            this.dgvAlerteRevuesAboExpire = new System.Windows.Forms.DataGridView();
            this.grpAlerteRevuesAboExpire.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerteRevuesAboExpire)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAlerteRevuesAboExpire
            // 
            this.grpAlerteRevuesAboExpire.Controls.Add(this.dgvAlerteRevuesAboExpire);
            this.grpAlerteRevuesAboExpire.Location = new System.Drawing.Point(13, 13);
            this.grpAlerteRevuesAboExpire.Name = "grpAlerteRevuesAboExpire";
            this.grpAlerteRevuesAboExpire.Size = new System.Drawing.Size(407, 385);
            this.grpAlerteRevuesAboExpire.TabIndex = 0;
            this.grpAlerteRevuesAboExpire.TabStop = false;
            this.grpAlerteRevuesAboExpire.Text = "Les abonnements de ces revues vont bientôt expirer";
            // 
            // dgvAlerteRevuesAboExpire
            // 
            this.dgvAlerteRevuesAboExpire.AllowUserToAddRows = false;
            this.dgvAlerteRevuesAboExpire.AllowUserToDeleteRows = false;
            this.dgvAlerteRevuesAboExpire.AllowUserToResizeColumns = false;
            this.dgvAlerteRevuesAboExpire.AllowUserToResizeRows = false;
            this.dgvAlerteRevuesAboExpire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlerteRevuesAboExpire.Location = new System.Drawing.Point(6, 19);
            this.dgvAlerteRevuesAboExpire.MultiSelect = false;
            this.dgvAlerteRevuesAboExpire.Name = "dgvAlerteRevuesAboExpire";
            this.dgvAlerteRevuesAboExpire.ReadOnly = true;
            this.dgvAlerteRevuesAboExpire.RowHeadersVisible = false;
            this.dgvAlerteRevuesAboExpire.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlerteRevuesAboExpire.Size = new System.Drawing.Size(395, 360);
            this.dgvAlerteRevuesAboExpire.TabIndex = 5;
            // 
            // FrmAlerteRevues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 410);
            this.Controls.Add(this.grpAlerteRevuesAboExpire);
            this.Name = "FrmAlerteRevues";
            this.Text = "Alerte";
            this.Load += new System.EventHandler(this.FrmAlerteRevues_Load);
            this.grpAlerteRevuesAboExpire.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerteRevuesAboExpire)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAlerteRevuesAboExpire;
        private System.Windows.Forms.DataGridView dgvAlerteRevuesAboExpire;
    }
}