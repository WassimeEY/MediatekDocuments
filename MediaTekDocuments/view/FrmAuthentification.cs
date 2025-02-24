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
    /// Classe d'affichage de l'authentification.
    /// </summary>
    public partial class FrmAuthentification : Form
    {
        private readonly FrmAuthentificationController controller;
        private Utilisateur utilisateur;
        const string SERVICECULTURE = "00001";

        /// <summary>
        /// Constructeur : création du contrôleur lié à ce formulaire
        /// </summary>
        internal FrmAuthentification()
        {
            InitializeComponent();
            this.controller = new FrmAuthentificationController();
        }

        /// <summary>
        /// Lance la tentative d'authentification si tous les champs sont remplis.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuthentification_Click(object sender, EventArgs e)
        {
            string login = txtbLogin.Text;
            string mdp = txtbMdp.Text;
            if (login != "" && mdp != "")
            {
                utilisateur = controller.GetUtilisateurSiValide(new Utilisateur(null, login, mdp, null, null));
                if (utilisateur != null)
                {
                    if(utilisateur.IdService == SERVICECULTURE)
                    {
                        MessageBox.Show("Vous n'êtes pas habilité à utiliser cette application.", "Information");
                        Application.Exit();
                    }
                    else
                    {
                        FrmMediatek nouvelleForm = new FrmMediatek(utilisateur.IdService);
                        nouvelleForm.Show(this);
                        this.Hide();
                    }
                    
                }
                else
                {
                    MessageBox.Show("L'authentification a échoué", "Information");
                }
            }
            else
            {
                MessageBox.Show("Le login et le mot de passe sont requis.", "Information");
            }
            
        }
    }
}
