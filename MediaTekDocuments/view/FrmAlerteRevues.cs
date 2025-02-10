using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaTekDocuments.model;
using MediaTekDocuments.controller;

namespace MediaTekDocuments.view
{
    public partial class FrmAlerteRevues : Form
    {
        private readonly FrmAlerteRevuesController controller;
        private readonly BindingSource bdgRevues = new BindingSource();
        private List<Abonnement> lesAbonnements;

        internal FrmAlerteRevues()
        {
            InitializeComponent();
            this.controller = new FrmAlerteRevuesController();
            
        }

        private void RemplirAbonnementsExpireListe(List<Abonnement> abonnements)
        {
            bdgRevues.DataSource = abonnements;
            dgvAlerteRevuesAboExpire.DataSource = bdgRevues;
            dgvAlerteRevuesAboExpire.Columns["Id"].DisplayIndex = 0; //on affiche bien l'id de l'abonnement pour bien faire la différence entre les abonnements d'une même revue.
            dgvAlerteRevuesAboExpire.Columns["IdRevue"].Visible = false;
            dgvAlerteRevuesAboExpire.Columns["Montant"].Visible = false;
            dgvAlerteRevuesAboExpire.Columns["DateCommande"].Visible = false;
            dgvAlerteRevuesAboExpire.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void FrmAlerteRevues_Load(object sender, EventArgs e)
        {
            lesAbonnements = controller.GetAllAbonnementBientotExpire();
            RemplirAbonnementsExpireListe(lesAbonnements);
        }
    }
}
