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
    /// <summary>
    /// Classe d'affichage de l'alerte des revues ayant un abonnement qui va bientôt expirer.
    /// </summary>
    public partial class FrmAlerteRevues : Form
    {
        private readonly FrmAlerteRevuesController controller;
        private readonly BindingSource bdgRevues = new BindingSource();
        private List<Abonnement> lesAbonnements;

        /// <summary>
        /// Constructeur : création du contrôleur lié à ce formulaire
        /// </summary>
        internal FrmAlerteRevues()
        {
            InitializeComponent();
            this.controller = new FrmAlerteRevuesController();
            
        }

        /// <summary>
        /// Remplit la dataGridView dgvAlerteRevuesAboExpire avec la liste d'abonnement donné en paramètre.
        /// </summary>
        /// <param name="abonnements">La liste d'abonnement utilisé pour valoriser la dataGridView.</param>
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

        /// <summary>
        /// Récupère les abonnements et remplie dgvAlerteRevuesAboExpire avec ces abonnements.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAlerteRevues_Load(object sender, EventArgs e)
        {
            lesAbonnements = controller.GetAllAbonnementBientotExpire();
            RemplirAbonnementsExpireListe(lesAbonnements);
        }
    }
}
