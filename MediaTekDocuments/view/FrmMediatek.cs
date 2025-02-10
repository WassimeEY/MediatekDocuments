using System;
using System.Windows.Forms;
using MediaTekDocuments.model;
using MediaTekDocuments.controller;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;

namespace MediaTekDocuments.view

{
    /// <summary>
    /// Classe d'affichage
    /// </summary>
    public partial class FrmMediatek : Form
    {
        #region Commun
        private readonly FrmMediatekController controller;
        private readonly BindingSource bdgGenres = new BindingSource();
        private readonly BindingSource bdgPublics = new BindingSource();
        private readonly BindingSource bdgRayons = new BindingSource();

        /// <summary>
        /// Constructeur : création du contrôleur lié à ce formulaire
        /// </summary>
        internal FrmMediatek()
        {
            InitializeComponent();
            this.controller = new FrmMediatekController();
            FrmAlerteRevues nouvelleForm = new FrmAlerteRevues();
            nouvelleForm.Show(this);
        }

        /// <summary>
        /// Rempli un des 3 combo (genre, public, rayon)
        /// </summary>
        /// <param name="lesCategories">liste des objets de type Genre ou Public ou Rayon</param>
        /// <param name="bdg">bindingsource contenant les informations</param>
        /// <param name="cbb">combobox à remplir</param>
        public void RemplirComboCategorie(List<Categorie> lesCategories, BindingSource bdg, ComboBox cbb)
        {
            bdg.DataSource = lesCategories;
            cbb.DataSource = bdg;
            if (cbb.Items.Count > 0)
            {
                cbb.SelectedIndex = -1;
            }
        }
        #endregion

        #region Onglet Livres
        private readonly BindingSource bdgLivresListe = new BindingSource();
        private List<Livre> lesLivres = new List<Livre>();

        /// <summary>
        /// Ouverture de l'onglet Livres : 
        /// appel des méthodes pour remplir le datagrid des livres et des combos (genre, rayon, public)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabLivres_Enter(object sender, EventArgs e)
        {
            lesLivres = controller.GetAllLivres();
            RemplirComboCategorie(controller.GetAllGenres(), bdgGenres, cbxLivresGenres);
            RemplirComboCategorie(controller.GetAllPublics(), bdgPublics, cbxLivresPublics);
            RemplirComboCategorie(controller.GetAllRayons(), bdgRayons, cbxLivresRayons);
            RemplirLivresListeComplete();
        }

        /// <summary>
        /// Remplit le datagrid avec la liste reçue en paramètre
        /// </summary>
        /// <param name="livres">liste de livres</param>
        private void RemplirLivresListe(List<Livre> livres)
        {
            bdgLivresListe.DataSource = livres;
            dgvLivresListe.DataSource = bdgLivresListe;
            dgvLivresListe.Columns["isbn"].Visible = false;
            dgvLivresListe.Columns["idRayon"].Visible = false;
            dgvLivresListe.Columns["idGenre"].Visible = false;
            dgvLivresListe.Columns["idPublic"].Visible = false;
            dgvLivresListe.Columns["image"].Visible = false;
            dgvLivresListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLivresListe.Columns["id"].DisplayIndex = 0;
            dgvLivresListe.Columns["titre"].DisplayIndex = 1;
        }

        /// <summary>
        /// Recherche et affichage du livre dont on a saisi le numéro.
        /// Si non trouvé, affichage d'un MessageBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLivresNumRecherche_Click(object sender, EventArgs e)
        {
            if (!txbLivresNumRecherche.Text.Equals(""))
            {
                txbLivresTitreRecherche.Text = "";
                cbxLivresGenres.SelectedIndex = -1;
                cbxLivresRayons.SelectedIndex = -1;
                cbxLivresPublics.SelectedIndex = -1;
                Livre livre = lesLivres.Find(x => x.Id.Equals(txbLivresNumRecherche.Text));
                if (livre != null)
                {
                    List<Livre> livres = new List<Livre>() { livre };
                    RemplirLivresListe(livres);
                }
                else
                {
                    MessageBox.Show("numéro introuvable");
                    RemplirLivresListeComplete();
                }
            }
            else
            {
                RemplirLivresListeComplete();
            }
        }

        /// <summary>
        /// Recherche et affichage des livres dont le titre matche acec la saisie.
        /// Cette procédure est exécutée à chaque ajout ou suppression de caractère
        /// dans le textBox de saisie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxbLivresTitreRecherche_TextChanged(object sender, EventArgs e)
        {
            if (!txbLivresTitreRecherche.Text.Equals(""))
            {
                cbxLivresGenres.SelectedIndex = -1;
                cbxLivresRayons.SelectedIndex = -1;
                cbxLivresPublics.SelectedIndex = -1;
                txbLivresNumRecherche.Text = "";
                List<Livre> lesLivresParTitre;
                lesLivresParTitre = lesLivres.FindAll(x => x.Titre.ToLower().Contains(txbLivresTitreRecherche.Text.ToLower()));
                RemplirLivresListe(lesLivresParTitre);
            }
            else
            {
                // si la zone de saisie est vide et aucun élément combo sélectionné, réaffichage de la liste complète
                if (cbxLivresGenres.SelectedIndex < 0 && cbxLivresPublics.SelectedIndex < 0 && cbxLivresRayons.SelectedIndex < 0
                    && txbLivresNumRecherche.Text.Equals(""))
                {
                    RemplirLivresListeComplete();
                }
            }
        }

        /// <summary>
        /// Affichage des informations du livre sélectionné
        /// </summary>
        /// <param name="livre">le livre</param>
        private void AfficheLivresInfos(Livre livre)
        {
            txbLivresAuteur.Text = livre.Auteur;
            txbLivresCollection.Text = livre.Collection;
            txbLivresImage.Text = livre.Image;
            txbLivresIsbn.Text = livre.Isbn;
            txbLivresNumero.Text = livre.Id;
            txbLivresGenre.Text = livre.Genre;
            txbLivresPublic.Text = livre.Public;
            txbLivresRayon.Text = livre.Rayon;
            txbLivresTitre.Text = livre.Titre;
            string image = livre.Image;
            try
            {
                pcbLivresImage.Image = Image.FromFile(image);
            }
            catch
            {
                pcbLivresImage.Image = null;
            }
        }

        /// <summary>
        /// Vide les zones d'affichage des informations du livre
        /// </summary>
        private void VideLivresInfos()
        {
            txbLivresAuteur.Text = "";
            txbLivresCollection.Text = "";
            txbLivresImage.Text = "";
            txbLivresIsbn.Text = "";
            txbLivresNumero.Text = "";
            txbLivresGenre.Text = "";
            txbLivresPublic.Text = "";
            txbLivresRayon.Text = "";
            txbLivresTitre.Text = "";
            pcbLivresImage.Image = null;
        }

        /// <summary>
        /// Filtre sur le genre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbxLivresGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLivresGenres.SelectedIndex >= 0)
            {
                txbLivresTitreRecherche.Text = "";
                txbLivresNumRecherche.Text = "";
                Genre genre = (Genre)cbxLivresGenres.SelectedItem;
                List<Livre> livres = lesLivres.FindAll(x => x.Genre.Equals(genre.Libelle));
                RemplirLivresListe(livres);
                cbxLivresRayons.SelectedIndex = -1;
                cbxLivresPublics.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Filtre sur la catégorie de public
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbxLivresPublics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLivresPublics.SelectedIndex >= 0)
            {
                txbLivresTitreRecherche.Text = "";
                txbLivresNumRecherche.Text = "";
                Public lePublic = (Public)cbxLivresPublics.SelectedItem;
                List<Livre> livres = lesLivres.FindAll(x => x.Public.Equals(lePublic.Libelle));
                RemplirLivresListe(livres);
                cbxLivresRayons.SelectedIndex = -1;
                cbxLivresGenres.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Filtre sur le rayon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbxLivresRayons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLivresRayons.SelectedIndex >= 0)
            {
                txbLivresTitreRecherche.Text = "";
                txbLivresNumRecherche.Text = "";
                Rayon rayon = (Rayon)cbxLivresRayons.SelectedItem;
                List<Livre> livres = lesLivres.FindAll(x => x.Rayon.Equals(rayon.Libelle));
                RemplirLivresListe(livres);
                cbxLivresGenres.SelectedIndex = -1;
                cbxLivresPublics.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Sur la sélection d'une ligne ou cellule dans le grid
        /// affichage des informations du livre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvLivresListe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLivresListe.CurrentCell != null)
            {
                try
                {
                    Livre livre = (Livre)bdgLivresListe.List[bdgLivresListe.Position];
                    AfficheLivresInfos(livre);
                }
                catch
                {
                    VideLivresZones();
                }
            }
            else
            {
                VideLivresInfos();
            }
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des livres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLivresAnnulPublics_Click(object sender, EventArgs e)
        {
            RemplirLivresListeComplete();
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des livres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLivresAnnulRayons_Click(object sender, EventArgs e)
        {
            RemplirLivresListeComplete();
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des livres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLivresAnnulGenres_Click(object sender, EventArgs e)
        {
            RemplirLivresListeComplete();
        }

        /// <summary>
        /// Affichage de la liste complète des livres
        /// et annulation de toutes les recherches et filtres
        /// </summary>
        private void RemplirLivresListeComplete()
        {
            RemplirLivresListe(lesLivres);
            VideLivresZones();
        }

        /// <summary>
        /// vide les zones de recherche et de filtre
        /// </summary>
        private void VideLivresZones()
        {
            cbxLivresGenres.SelectedIndex = -1;
            cbxLivresRayons.SelectedIndex = -1;
            cbxLivresPublics.SelectedIndex = -1;
            txbLivresNumRecherche.Text = "";
            txbLivresTitreRecherche.Text = "";
        }

        /// <summary>
        /// Tri sur les colonnes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvLivresListe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VideLivresZones();
            string titreColonne = dgvLivresListe.Columns[e.ColumnIndex].HeaderText;
            List<Livre> sortedList = new List<Livre>();
            switch (titreColonne)
            {
                case "Id":
                    sortedList = lesLivres.OrderBy(o => o.Id).ToList();
                    break;
                case "Titre":
                    sortedList = lesLivres.OrderBy(o => o.Titre).ToList();
                    break;
                case "Collection":
                    sortedList = lesLivres.OrderBy(o => o.Collection).ToList();
                    break;
                case "Auteur":
                    sortedList = lesLivres.OrderBy(o => o.Auteur).ToList();
                    break;
                case "Genre":
                    sortedList = lesLivres.OrderBy(o => o.Genre).ToList();
                    break;
                case "Public":
                    sortedList = lesLivres.OrderBy(o => o.Public).ToList();
                    break;
                case "Rayon":
                    sortedList = lesLivres.OrderBy(o => o.Rayon).ToList();
                    break;
            }
            RemplirLivresListe(sortedList);
        }
        #endregion

        #region Onglet Dvd
        private readonly BindingSource bdgDvdListe = new BindingSource();
        private List<Dvd> lesDvd = new List<Dvd>();

        /// <summary>
        /// Ouverture de l'onglet Dvds : 
        /// appel des méthodes pour remplir le datagrid des dvd et des combos (genre, rayon, public)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabDvd_Enter(object sender, EventArgs e)
        {
            lesDvd = controller.GetAllDvd();
            RemplirComboCategorie(controller.GetAllGenres(), bdgGenres, cbxDvdGenres);
            RemplirComboCategorie(controller.GetAllPublics(), bdgPublics, cbxDvdPublics);
            RemplirComboCategorie(controller.GetAllRayons(), bdgRayons, cbxDvdRayons);
            RemplirDvdListeComplete();
        }

        /// <summary>
        /// Remplit le datagrid avec la liste reçue en paramètre
        /// </summary>
        /// <param name="Dvds">liste de dvd</param>
        private void RemplirDvdListe(List<Dvd> Dvds)
        {
            bdgDvdListe.DataSource = Dvds;
            dgvDvdListe.DataSource = bdgDvdListe;
            dgvDvdListe.Columns["idRayon"].Visible = false;
            dgvDvdListe.Columns["idGenre"].Visible = false;
            dgvDvdListe.Columns["idPublic"].Visible = false;
            dgvDvdListe.Columns["image"].Visible = false;
            dgvDvdListe.Columns["synopsis"].Visible = false;
            dgvDvdListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDvdListe.Columns["id"].DisplayIndex = 0;
            dgvDvdListe.Columns["titre"].DisplayIndex = 1;
        }

        /// <summary>
        /// Recherche et affichage du Dvd dont on a saisi le numéro.
        /// Si non trouvé, affichage d'un MessageBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDvdNumRecherche_Click(object sender, EventArgs e)
        {
            if (!txbDvdNumRecherche.Text.Equals(""))
            {
                txbDvdTitreRecherche.Text = "";
                cbxDvdGenres.SelectedIndex = -1;
                cbxDvdRayons.SelectedIndex = -1;
                cbxDvdPublics.SelectedIndex = -1;
                Dvd dvd = lesDvd.Find(x => x.Id.Equals(txbDvdNumRecherche.Text));
                if (dvd != null)
                {
                    List<Dvd> Dvd = new List<Dvd>() { dvd };
                    RemplirDvdListe(Dvd);
                }
                else
                {
                    MessageBox.Show("numéro introuvable");
                    RemplirDvdListeComplete();
                }
            }
            else
            {
                RemplirDvdListeComplete();
            }
        }

        /// <summary>
        /// Recherche et affichage des Dvd dont le titre matche acec la saisie.
        /// Cette procédure est exécutée à chaque ajout ou suppression de caractère
        /// dans le textBox de saisie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbDvdTitreRecherche_TextChanged(object sender, EventArgs e)
        {
            if (!txbDvdTitreRecherche.Text.Equals(""))
            {
                cbxDvdGenres.SelectedIndex = -1;
                cbxDvdRayons.SelectedIndex = -1;
                cbxDvdPublics.SelectedIndex = -1;
                txbDvdNumRecherche.Text = "";
                List<Dvd> lesDvdParTitre;
                lesDvdParTitre = lesDvd.FindAll(x => x.Titre.ToLower().Contains(txbDvdTitreRecherche.Text.ToLower()));
                RemplirDvdListe(lesDvdParTitre);
            }
            else
            {
                // si la zone de saisie est vide et aucun élément combo sélectionné, réaffichage de la liste complète
                if (cbxDvdGenres.SelectedIndex < 0 && cbxDvdPublics.SelectedIndex < 0 && cbxDvdRayons.SelectedIndex < 0
                    && txbDvdNumRecherche.Text.Equals(""))
                {
                    RemplirDvdListeComplete();
                }
            }
        }

        /// <summary>
        /// Affichage des informations du dvd sélectionné
        /// </summary>
        /// <param name="dvd">le dvd</param>
        private void AfficheDvdInfos(Dvd dvd)
        {
            txbDvdRealisateur.Text = dvd.Realisateur;
            txbDvdSynopsis.Text = dvd.Synopsis;
            txbDvdImage.Text = dvd.Image;
            txbDvdDuree.Text = dvd.Duree.ToString();
            txbDvdNumero.Text = dvd.Id;
            txbDvdGenre.Text = dvd.Genre;
            txbDvdPublic.Text = dvd.Public;
            txbDvdRayon.Text = dvd.Rayon;
            txbDvdTitre.Text = dvd.Titre;
            string image = dvd.Image;
            try
            {
                pcbDvdImage.Image = Image.FromFile(image);
            }
            catch
            {
                pcbDvdImage.Image = null;
            }
        }

        /// <summary>
        /// Vide les zones d'affichage des informations du dvd
        /// </summary>
        private void VideDvdInfos()
        {
            txbDvdRealisateur.Text = "";
            txbDvdSynopsis.Text = "";
            txbDvdImage.Text = "";
            txbDvdDuree.Text = "";
            txbDvdNumero.Text = "";
            txbDvdGenre.Text = "";
            txbDvdPublic.Text = "";
            txbDvdRayon.Text = "";
            txbDvdTitre.Text = "";
            pcbDvdImage.Image = null;
        }

        /// <summary>
        /// Filtre sur le genre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDvdGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDvdGenres.SelectedIndex >= 0)
            {
                txbDvdTitreRecherche.Text = "";
                txbDvdNumRecherche.Text = "";
                Genre genre = (Genre)cbxDvdGenres.SelectedItem;
                List<Dvd> Dvd = lesDvd.FindAll(x => x.Genre.Equals(genre.Libelle));
                RemplirDvdListe(Dvd);
                cbxDvdRayons.SelectedIndex = -1;
                cbxDvdPublics.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Filtre sur la catégorie de public
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDvdPublics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDvdPublics.SelectedIndex >= 0)
            {
                txbDvdTitreRecherche.Text = "";
                txbDvdNumRecherche.Text = "";
                Public lePublic = (Public)cbxDvdPublics.SelectedItem;
                List<Dvd> Dvd = lesDvd.FindAll(x => x.Public.Equals(lePublic.Libelle));
                RemplirDvdListe(Dvd);
                cbxDvdRayons.SelectedIndex = -1;
                cbxDvdGenres.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Filtre sur le rayon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDvdRayons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDvdRayons.SelectedIndex >= 0)
            {
                txbDvdTitreRecherche.Text = "";
                txbDvdNumRecherche.Text = "";
                Rayon rayon = (Rayon)cbxDvdRayons.SelectedItem;
                List<Dvd> Dvd = lesDvd.FindAll(x => x.Rayon.Equals(rayon.Libelle));
                RemplirDvdListe(Dvd);
                cbxDvdGenres.SelectedIndex = -1;
                cbxDvdPublics.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Sur la sélection d'une ligne ou cellule dans le grid
        /// affichage des informations du dvd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDvdListe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDvdListe.CurrentCell != null)
            {
                try
                {
                    Dvd dvd = (Dvd)bdgDvdListe.List[bdgDvdListe.Position];
                    AfficheDvdInfos(dvd);
                }
                catch
                {
                    VideDvdZones();
                }
            }
            else
            {
                VideDvdInfos();
            }
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des Dvd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDvdAnnulPublics_Click(object sender, EventArgs e)
        {
            RemplirDvdListeComplete();
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des Dvd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDvdAnnulRayons_Click(object sender, EventArgs e)
        {
            RemplirDvdListeComplete();
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des Dvd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDvdAnnulGenres_Click(object sender, EventArgs e)
        {
            RemplirDvdListeComplete();
        }

        /// <summary>
        /// Affichage de la liste complète des Dvd
        /// et annulation de toutes les recherches et filtres
        /// </summary>
        private void RemplirDvdListeComplete()
        {
            RemplirDvdListe(lesDvd);
            VideDvdZones();
        }

        /// <summary>
        /// vide les zones de recherche et de filtre
        /// </summary>
        private void VideDvdZones()
        {
            cbxDvdGenres.SelectedIndex = -1;
            cbxDvdRayons.SelectedIndex = -1;
            cbxDvdPublics.SelectedIndex = -1;
            txbDvdNumRecherche.Text = "";
            txbDvdTitreRecherche.Text = "";
        }

        /// <summary>
        /// Tri sur les colonnes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDvdListe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VideDvdZones();
            string titreColonne = dgvDvdListe.Columns[e.ColumnIndex].HeaderText;
            List<Dvd> sortedList = new List<Dvd>();
            switch (titreColonne)
            {
                case "Id":
                    sortedList = lesDvd.OrderBy(o => o.Id).ToList();
                    break;
                case "Titre":
                    sortedList = lesDvd.OrderBy(o => o.Titre).ToList();
                    break;
                case "Duree":
                    sortedList = lesDvd.OrderBy(o => o.Duree).ToList();
                    break;
                case "Realisateur":
                    sortedList = lesDvd.OrderBy(o => o.Realisateur).ToList();
                    break;
                case "Genre":
                    sortedList = lesDvd.OrderBy(o => o.Genre).ToList();
                    break;
                case "Public":
                    sortedList = lesDvd.OrderBy(o => o.Public).ToList();
                    break;
                case "Rayon":
                    sortedList = lesDvd.OrderBy(o => o.Rayon).ToList();
                    break;
            }
            RemplirDvdListe(sortedList);
        }
        #endregion

        #region Onglet Revues
        private readonly BindingSource bdgRevuesListe = new BindingSource();
        private List<Revue> lesRevues = new List<Revue>();

        /// <summary>
        /// Ouverture de l'onglet Revues : 
        /// appel des méthodes pour remplir le datagrid des revues et des combos (genre, rayon, public)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabRevues_Enter(object sender, EventArgs e)
        {
            lesRevues = controller.GetAllRevues();
            RemplirComboCategorie(controller.GetAllGenres(), bdgGenres, cbxRevuesGenres);
            RemplirComboCategorie(controller.GetAllPublics(), bdgPublics, cbxRevuesPublics);
            RemplirComboCategorie(controller.GetAllRayons(), bdgRayons, cbxRevuesRayons);
            RemplirRevuesListeComplete();
        }

        /// <summary>
        /// Remplit le datagrid avec la liste reçue en paramètre
        /// </summary>
        /// <param name="revues"></param>
        private void RemplirRevuesListe(List<Revue> revues)
        {
            bdgRevuesListe.DataSource = revues;
            dgvRevuesListe.DataSource = bdgRevuesListe;
            dgvRevuesListe.Columns["idRayon"].Visible = false;
            dgvRevuesListe.Columns["idGenre"].Visible = false;
            dgvRevuesListe.Columns["idPublic"].Visible = false;
            dgvRevuesListe.Columns["image"].Visible = false;
            dgvRevuesListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRevuesListe.Columns["id"].DisplayIndex = 0;
            dgvRevuesListe.Columns["titre"].DisplayIndex = 1;
        }

        /// <summary>
        /// Recherche et affichage de la revue dont on a saisi le numéro.
        /// Si non trouvé, affichage d'un MessageBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRevuesNumRecherche_Click(object sender, EventArgs e)
        {
            if (!txbRevuesNumRecherche.Text.Equals(""))
            {
                txbRevuesTitreRecherche.Text = "";
                cbxRevuesGenres.SelectedIndex = -1;
                cbxRevuesRayons.SelectedIndex = -1;
                cbxRevuesPublics.SelectedIndex = -1;
                Revue revue = lesRevues.Find(x => x.Id.Equals(txbRevuesNumRecherche.Text));
                if (revue != null)
                {
                    List<Revue> revues = new List<Revue>() { revue };
                    RemplirRevuesListe(revues);
                }
                else
                {
                    MessageBox.Show("numéro introuvable");
                    RemplirRevuesListeComplete();
                }
            }
            else
            {
                RemplirRevuesListeComplete();
            }
        }

        /// <summary>
        /// Recherche et affichage des revues dont le titre matche acec la saisie.
        /// Cette procédure est exécutée à chaque ajout ou suppression de caractère
        /// dans le textBox de saisie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbRevuesTitreRecherche_TextChanged(object sender, EventArgs e)
        {
            if (!txbRevuesTitreRecherche.Text.Equals(""))
            {
                cbxRevuesGenres.SelectedIndex = -1;
                cbxRevuesRayons.SelectedIndex = -1;
                cbxRevuesPublics.SelectedIndex = -1;
                txbRevuesNumRecherche.Text = "";
                List<Revue> lesRevuesParTitre;
                lesRevuesParTitre = lesRevues.FindAll(x => x.Titre.ToLower().Contains(txbRevuesTitreRecherche.Text.ToLower()));
                RemplirRevuesListe(lesRevuesParTitre);
            }
            else
            {
                // si la zone de saisie est vide et aucun élément combo sélectionné, réaffichage de la liste complète
                if (cbxRevuesGenres.SelectedIndex < 0 && cbxRevuesPublics.SelectedIndex < 0 && cbxRevuesRayons.SelectedIndex < 0
                    && txbRevuesNumRecherche.Text.Equals(""))
                {
                    RemplirRevuesListeComplete();
                }
            }
        }

        /// <summary>
        /// Affichage des informations de la revue sélectionné
        /// </summary>
        /// <param name="revue">la revue</param>
        private void AfficheRevuesInfos(Revue revue)
        {
            txbRevuesPeriodicite.Text = revue.Periodicite;
            txbRevuesImage.Text = revue.Image;
            txbRevuesDateMiseADispo.Text = revue.DelaiMiseADispo.ToString();
            txbRevuesNumero.Text = revue.Id;
            txbRevuesGenre.Text = revue.Genre;
            txbRevuesPublic.Text = revue.Public;
            txbRevuesRayon.Text = revue.Rayon;
            txbRevuesTitre.Text = revue.Titre;
            string image = revue.Image;
            try
            {
                pcbRevuesImage.Image = Image.FromFile(image);
            }
            catch
            {
                pcbRevuesImage.Image = null;
            }
        }

        /// <summary>
        /// Vide les zones d'affichage des informations de la reuve
        /// </summary>
        private void VideRevuesInfos()
        {
            txbRevuesPeriodicite.Text = "";
            txbRevuesImage.Text = "";
            txbRevuesDateMiseADispo.Text = "";
            txbRevuesNumero.Text = "";
            txbRevuesGenre.Text = "";
            txbRevuesPublic.Text = "";
            txbRevuesRayon.Text = "";
            txbRevuesTitre.Text = "";
            pcbRevuesImage.Image = null;
        }

        /// <summary>
        /// Filtre sur le genre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxRevuesGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRevuesGenres.SelectedIndex >= 0)
            {
                txbRevuesTitreRecherche.Text = "";
                txbRevuesNumRecherche.Text = "";
                Genre genre = (Genre)cbxRevuesGenres.SelectedItem;
                List<Revue> revues = lesRevues.FindAll(x => x.Genre.Equals(genre.Libelle));
                RemplirRevuesListe(revues);
                cbxRevuesRayons.SelectedIndex = -1;
                cbxRevuesPublics.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Filtre sur la catégorie de public
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxRevuesPublics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRevuesPublics.SelectedIndex >= 0)
            {
                txbRevuesTitreRecherche.Text = "";
                txbRevuesNumRecherche.Text = "";
                Public lePublic = (Public)cbxRevuesPublics.SelectedItem;
                List<Revue> revues = lesRevues.FindAll(x => x.Public.Equals(lePublic.Libelle));
                RemplirRevuesListe(revues);
                cbxRevuesRayons.SelectedIndex = -1;
                cbxRevuesGenres.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Filtre sur le rayon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxRevuesRayons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRevuesRayons.SelectedIndex >= 0)
            {
                txbRevuesTitreRecherche.Text = "";
                txbRevuesNumRecherche.Text = "";
                Rayon rayon = (Rayon)cbxRevuesRayons.SelectedItem;
                List<Revue> revues = lesRevues.FindAll(x => x.Rayon.Equals(rayon.Libelle));
                RemplirRevuesListe(revues);
                cbxRevuesGenres.SelectedIndex = -1;
                cbxRevuesPublics.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Sur la sélection d'une ligne ou cellule dans le grid
        /// affichage des informations de la revue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRevuesListe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRevuesListe.CurrentCell != null)
            {
                try
                {
                    Revue revue = (Revue)bdgRevuesListe.List[bdgRevuesListe.Position];
                    AfficheRevuesInfos(revue);
                }
                catch
                {
                    VideRevuesZones();
                }
            }
            else
            {
                VideRevuesInfos();
            }
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des revues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRevuesAnnulPublics_Click(object sender, EventArgs e)
        {
            RemplirRevuesListeComplete();
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des revues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRevuesAnnulRayons_Click(object sender, EventArgs e)
        {
            RemplirRevuesListeComplete();
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des revues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRevuesAnnulGenres_Click(object sender, EventArgs e)
        {
            RemplirRevuesListeComplete();
        }

        /// <summary>
        /// Affichage de la liste complète des revues
        /// et annulation de toutes les recherches et filtres
        /// </summary>
        private void RemplirRevuesListeComplete()
        {
            RemplirRevuesListe(lesRevues);
            VideRevuesZones();
        }

        /// <summary>
        /// vide les zones de recherche et de filtre
        /// </summary>
        private void VideRevuesZones()
        {
            cbxRevuesGenres.SelectedIndex = -1;
            cbxRevuesRayons.SelectedIndex = -1;
            cbxRevuesPublics.SelectedIndex = -1;
            txbRevuesNumRecherche.Text = "";
            txbRevuesTitreRecherche.Text = "";
        }

        /// <summary>
        /// Tri sur les colonnes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRevuesListe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VideRevuesZones();
            string titreColonne = dgvRevuesListe.Columns[e.ColumnIndex].HeaderText;
            List<Revue> sortedList = new List<Revue>();
            switch (titreColonne)
            {
                case "Id":
                    sortedList = lesRevues.OrderBy(o => o.Id).ToList();
                    break;
                case "Titre":
                    sortedList = lesRevues.OrderBy(o => o.Titre).ToList();
                    break;
                case "Periodicite":
                    sortedList = lesRevues.OrderBy(o => o.Periodicite).ToList();
                    break;
                case "DelaiMiseADispo":
                    sortedList = lesRevues.OrderBy(o => o.DelaiMiseADispo).ToList();
                    break;
                case "Genre":
                    sortedList = lesRevues.OrderBy(o => o.Genre).ToList();
                    break;
                case "Public":
                    sortedList = lesRevues.OrderBy(o => o.Public).ToList();
                    break;
                case "Rayon":
                    sortedList = lesRevues.OrderBy(o => o.Rayon).ToList();
                    break;
            }
            RemplirRevuesListe(sortedList);
        }
        #endregion

        #region Onglet Parutions
        private readonly BindingSource bdgExemplairesListe = new BindingSource();
        private List<Exemplaire> lesExemplaires = new List<Exemplaire>();
        const string ETATNEUF = "00001";

        /// <summary>
        /// Ouverture de l'onglet : récupère le revues et vide tous les champs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabReceptionRevue_Enter(object sender, EventArgs e)
        {
            lesRevues = controller.GetAllRevues();
            txbReceptionRevueNumero.Text = "";
            AccesReceptionExemplaireGroupBox(false);
        }

        /// <summary>
        /// Remplit le datagrid des exemplaires avec la liste reçue en paramètre
        /// </summary>
        /// <param name="exemplaires">liste d'exemplaires</param>
        private void RemplirReceptionExemplairesListe(List<Exemplaire> exemplaires)
        {
            if (exemplaires != null)
            {
                bdgExemplairesListe.DataSource = exemplaires;
                dgvReceptionExemplairesListe.DataSource = bdgExemplairesListe;
                dgvReceptionExemplairesListe.Columns["idEtat"].Visible = false;
                dgvReceptionExemplairesListe.Columns["id"].Visible = false;
                dgvReceptionExemplairesListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvReceptionExemplairesListe.Columns["numero"].DisplayIndex = 0;
                dgvReceptionExemplairesListe.Columns["dateAchat"].DisplayIndex = 1;
            }
            else
            {
                bdgExemplairesListe.DataSource = null;
            }
        }

        /// <summary>
        /// Recherche d'un numéro de revue et affiche ses informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceptionRechercher_Click(object sender, EventArgs e)
        {
            if (!txbReceptionRevueNumero.Text.Equals(""))
            {
                Revue revue = lesRevues.Find(x => x.Id.Equals(txbReceptionRevueNumero.Text));
                if (revue != null)
                {
                    AfficheReceptionRevueInfos(revue);
                }
                else
                {
                    MessageBox.Show("numéro introuvable");
                }
            }
        }

        /// <summary>
        /// Si le numéro de revue est modifié, la zone de l'exemplaire est vidée et inactive
        /// les informations de la revue son aussi effacées
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbReceptionRevueNumero_TextChanged(object sender, EventArgs e)
        {
            VideReceptionRevueZones();
            RemplirReceptionExemplairesListe(null);
            AccesReceptionExemplaireGroupBox(false);
        }

        /// <summary>
        /// vide les zones de recherche
        /// </summary>
        private void VideReceptionRevueZones()
        {
            txbReceptionRevuePeriodicite.Text = "";
            txbReceptionRevueImage.Text = "";
            txbReceptionRevueDelaiMiseADispo.Text = "";
            txbReceptionRevueGenre.Text = "";
            txbReceptionRevuePublic.Text = "";
            txbReceptionRevueRayon.Text = "";
            txbReceptionRevueTitre.Text = "";
            pcbReceptionRevueImage.Image = null;
        }

        /// <summary>
        /// Affichage des informations de la revue sélectionnée et les exemplaires
        /// </summary>
        /// <param name="revue">la revue</param>
        private void AfficheReceptionRevueInfos(Revue revue)
        {
            // informations sur la revue
            txbReceptionRevuePeriodicite.Text = revue.Periodicite;
            txbReceptionRevueImage.Text = revue.Image;
            txbReceptionRevueDelaiMiseADispo.Text = revue.DelaiMiseADispo.ToString();
            txbReceptionRevueNumero.Text = revue.Id;
            txbReceptionRevueGenre.Text = revue.Genre;
            txbReceptionRevuePublic.Text = revue.Public;
            txbReceptionRevueRayon.Text = revue.Rayon;
            txbReceptionRevueTitre.Text = revue.Titre;
            string image = revue.Image;
            try
            {
                pcbReceptionRevueImage.Image = Image.FromFile(image);
            }
            catch
            {
                pcbReceptionRevueImage.Image = null;
            }
            // affiche la liste des exemplaires de la revue
            AfficheReceptionExemplairesRevue();
        }

        /// <summary>
        /// Récupère et affiche les exemplaires d'une revue
        /// </summary>
        private void AfficheReceptionExemplairesRevue()
        {
            string idDocuement = txbReceptionRevueNumero.Text;
            lesExemplaires = controller.GetExemplairesRevue(idDocuement);
            RemplirReceptionExemplairesListe(lesExemplaires);
            AccesReceptionExemplaireGroupBox(true);
        }

        /// <summary>
        /// Permet ou interdit l'accès à la gestion de la réception d'un exemplaire
        /// et vide les objets graphiques
        /// </summary>
        /// <param name="acces">true ou false</param>
        private void AccesReceptionExemplaireGroupBox(bool acces)
        {
            grpReceptionExemplaire.Enabled = acces;
            txbReceptionExemplaireImage.Text = "";
            txbReceptionExemplaireNumero.Text = "";
            pcbReceptionExemplaireImage.Image = null;
            dtpReceptionExemplaireDate.Value = DateTime.Now;
        }

        /// <summary>
        /// Recherche image sur disque (pour l'exemplaire à insérer)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceptionExemplaireImage_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                // positionnement à la racine du disque où se trouve le dossier actuel
                InitialDirectory = Path.GetPathRoot(Environment.CurrentDirectory),
                Filter = "Files|*.jpg;*.bmp;*.jpeg;*.png;*.gif"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
            txbReceptionExemplaireImage.Text = filePath;
            try
            {
                pcbReceptionExemplaireImage.Image = Image.FromFile(filePath);
            }
            catch
            {
                pcbReceptionExemplaireImage.Image = null;
            }
        }

        /// <summary>
        /// Enregistrement du nouvel exemplaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceptionExemplaireValider_Click(object sender, EventArgs e)
        {
            if (!txbReceptionExemplaireNumero.Text.Equals(""))
            {
                try
                {
                    int numero = int.Parse(txbReceptionExemplaireNumero.Text);
                    DateTime dateAchat = dtpReceptionExemplaireDate.Value;
                    string photo = txbReceptionExemplaireImage.Text;
                    string idEtat = ETATNEUF;
                    string idDocument = txbReceptionRevueNumero.Text;
                    Exemplaire exemplaire = new Exemplaire(numero, dateAchat, photo, idEtat, idDocument);
                    if (controller.CreerExemplaire(exemplaire))
                    {
                        AfficheReceptionExemplairesRevue();
                    }
                    else
                    {
                        MessageBox.Show("numéro de publication déjà existant", "Erreur");
                    }
                }
                catch
                {
                    MessageBox.Show("le numéro de parution doit être numérique", "Information");
                    txbReceptionExemplaireNumero.Text = "";
                    txbReceptionExemplaireNumero.Focus();
                }
            }
            else
            {
                MessageBox.Show("numéro de parution obligatoire", "Information");
            }
        }

        /// <summary>
        /// Tri sur une colonne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvExemplairesListe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string titreColonne = dgvReceptionExemplairesListe.Columns[e.ColumnIndex].HeaderText;
            List<Exemplaire> sortedList = new List<Exemplaire>();
            switch (titreColonne)
            {
                case "Numero":
                    sortedList = lesExemplaires.OrderBy(o => o.Numero).Reverse().ToList();
                    break;
                case "DateAchat":
                    sortedList = lesExemplaires.OrderBy(o => o.DateAchat).Reverse().ToList();
                    break;
                case "Photo":
                    sortedList = lesExemplaires.OrderBy(o => o.Photo).ToList();
                    break;
            }
            RemplirReceptionExemplairesListe(sortedList);
        }

        /// <summary>
        /// affichage de l'image de l'exemplaire suite à la sélection d'un exemplaire dans la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvReceptionExemplairesListe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReceptionExemplairesListe.CurrentCell != null)
            {
                Exemplaire exemplaire = (Exemplaire)bdgExemplairesListe.List[bdgExemplairesListe.Position];
                string image = exemplaire.Photo;
                try
                {
                    pcbReceptionExemplaireRevueImage.Image = Image.FromFile(image);
                }
                catch
                {
                    pcbReceptionExemplaireRevueImage.Image = null;
                }
            }
            else
            {
                pcbReceptionExemplaireRevueImage.Image = null;
            }
        }
        #endregion

        #region Onglets liés à la gestion des commandes
        private List<Suivi> lesSuivis = new List<Suivi>();
        private List<CommandeDocument> lesCommandesDocument = new List<CommandeDocument>();
        const string ETAPESUIVIENCOURS = "00001";
        const string ETAPESUIVILIVREE = "00003";

        private string GetLibelleFromSuiviId(string idRecherche, List<Suivi> listeSuivi)
        {
            foreach (Suivi suivi in listeSuivi)
            {
                if (suivi.Id == idRecherche)
                {
                    return suivi.Libelle;
                }
            }
            return "";
        }

        private string GetSuiviIdFromLibelle(string libelle, List<Suivi> listeSuivi)
        {
            foreach (Suivi suivi in listeSuivi)
            {
                if (suivi.Libelle == libelle)
                {
                    return suivi.Id;
                }
            }
            return "";
        }

        /// <summary>
        /// Remplit le datagrid qui liste les commandes avec la liste reçue en paramètre
        /// </summary>
        /// <param name="commandesDoc">liste de commandes de document</param>
        private void RemplirCommandesDocListe(DataGridView dgvCommandes, BindingSource bdgCommandes, List<CommandeDocument> commandesDoc)
        {
            if (commandesDoc != null)
            {
                bdgCommandes.DataSource = commandesDoc;
                dgvCommandes.DataSource = bdgCommandes;
                dgvCommandes.Columns["id"].Visible = false;
                dgvCommandes.Columns["idLivreDvd"].Visible = false;
                dgvCommandes.Columns["idEtapeSuivi"].Visible = false;
                dgvCommandes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvCommandes.Columns["dateCommande"].DisplayIndex = 0;
                dgvCommandes.Columns["montant"].DisplayIndex = 1;
            }
            else
            {
                bdgCommandes.DataSource = null;
            }
        }

        /// <summary>
        /// Remplit le datagrid qui liste les commandes de revue (abonnements) avec la liste reçue en paramètre
        /// </summary>
        /// <param name="abonnements">liste de commandes de revue</param>
        private void RemplirAbonnementsListe(DataGridView dgvCommandes, BindingSource bdgCommandes, List<Abonnement> abonnements)
        {
            if (abonnements != null)
            {
                bdgCommandes.DataSource = abonnements;
                dgvCommandes.DataSource = bdgCommandes;
                dgvCommandes.Columns["id"].Visible = false;
                dgvCommandes.Columns["idRevue"].Visible = false;
                dgvCommandes.Columns["titreRevue"].Visible = false;
                dgvCommandes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvCommandes.Columns["dateCommande"].DisplayIndex = 0;
                dgvCommandes.Columns["montant"].DisplayIndex = 1;
            }
            else
            {
                bdgCommandes.DataSource = null;
            }
        }

        private List<CommandeDocument> RecupDonneesDgvCommandesDocTriee(DataGridView dgvCommandesDoc, int indexColonneDgvTrie, List<CommandeDocument> listeCommandesDoc)
        {
            string titreColonne = dgvCommandesDoc.Columns[indexColonneDgvTrie].HeaderText;
            List<CommandeDocument> sortedList = new List<CommandeDocument>();
            switch (titreColonne)
            {
                case "NbExemplaire":
                    sortedList = listeCommandesDoc.OrderBy(o => o.NbExemplaire).ToList();
                    break;
                case "DateCommande":
                    sortedList = listeCommandesDoc.OrderBy(o => o.DateCommande).ToList();
                    break;
                case "Montant":
                    sortedList = listeCommandesDoc.OrderBy(o => o.Montant).ToList();
                    break;
                case "EtapeSuivi":
                    sortedList = listeCommandesDoc.OrderBy(o => o.IdEtapeSuivi).ToList();
                    break;
            }
            return sortedList;
        }

        private List<Abonnement> RecupDonneesDgvAbonnementsTriee(DataGridView dgvAbonnements, int indexColonneDgvTrie, List<Abonnement> listeAbonnements)
        {
            string titreColonne = dgvAbonnements.Columns[indexColonneDgvTrie].HeaderText;
            List<Abonnement> sortedList = new List<Abonnement>();
            switch (titreColonne)
            {
                case "DateCommande":
                    sortedList = listeAbonnements.OrderBy(o => o.DateCommande).ToList();
                    break;
                case "Montant":
                    sortedList = listeAbonnements.OrderBy(o => o.Montant).ToList();
                    break;
                case "DateFinAbonnement":
                    sortedList = listeAbonnements.OrderBy(o => o.DateFinAbonnement).ToList();
                    break;
            }
            return sortedList;
        }

        private void RemplirComboCommandeDocEtapeSuivi(List<Suivi> listeSuivi, ComboBox cbb)
        {
            cbb.Items.Clear();
            foreach (Suivi suivi in listeSuivi)
            {
                cbb.Items.Add(suivi.Libelle);
            }
            if (cbb.Items.Count > 0)
            {
                cbb.SelectedIndex = 0;
            }
        }

        private bool VerifValiditeChangementEtapeSuivi(string idAncienneEtapeSuivi, string idNouvelleEtapeSuivi, List<Suivi> listeSuivi)
        {
            List<string> idsListeSuivi = new List<string>();
            int indexAncienneEtapeSuivi;
            int indexNouvelleEtapeSuivi;
            bool validite = true;
            foreach (Suivi suivi in listeSuivi)
            {
                idsListeSuivi.Add(suivi.Id);
            }
            indexAncienneEtapeSuivi = idsListeSuivi.FindIndex(x => x.Equals(idAncienneEtapeSuivi));
            indexNouvelleEtapeSuivi = idsListeSuivi.FindIndex(x => x.Equals(idNouvelleEtapeSuivi));
            if (indexAncienneEtapeSuivi == 2 || indexAncienneEtapeSuivi == 3) //L'index 2 et 3 reviennent aux 3ème et 4ème étapes de suivi "livrée" et "réglée".
            {
                validite = indexNouvelleEtapeSuivi > indexAncienneEtapeSuivi; //Dans ce cas, la nouvelle étape ne peut pas revenir à une étape précédente.
            }
            else if (indexNouvelleEtapeSuivi == 3)
            {
                validite = indexAncienneEtapeSuivi == 2;
            }
            return validite;
        }

        #region Onglet GestionLivreCommandes
        private readonly BindingSource bdgLivreCommandesListe = new BindingSource();

        /// <summary>
        /// Ouverture de l'onglet : récupère les commandes de livre et vide tous les champs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabGestionsCommandesLivres_Enter(object sender, EventArgs e)
        {
            lesLivres = controller.GetAllLivres();
            lesSuivis = controller.GetAllSuivi();
            txtbLivreCommandes_Num.Text = "";
            AccesCommandeLivreGroupBox(false);
            RemplirComboCommandeDocEtapeSuivi(lesSuivis, cbbLivreCommandes_NouvelleEtapeSuivi);
        }

        /// <summary>
        /// Recherche d'un numéro de livre et affiche ses informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLivreCommandesRechercher_Click(object sender, EventArgs e)
        {
            if (!txtbLivreCommandes_Num.Text.Equals(""))
            {
                Livre livre = lesLivres.Find(x => x.Id.Equals(txtbLivreCommandes_Num.Text));
                if (livre != null)
                {
                    AfficheLivreCommandesInfos(livre);
                }
                else
                {
                    MessageBox.Show("numéro introuvable");
                }
            }
        }

        /// <summary>
        /// Si le numéro de livre est modifié, la zone de l'exemplaire est vidée et inactive
        /// les informations de la revue son aussi effacées
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbLivreCommandes_Num_TextChanged(object sender, EventArgs e)
        {
            VideLivreCommandesZones();
            RemplirCommandesDocListe(dgvLivreCommandes, bdgLivreCommandesListe, null);
            AccesCommandeLivreGroupBox(false);
        }

        /// <summary>
        /// Affichage des informations du livre sélectionnée et de ses commandes.
        /// </summary>
        /// <param name="livre">le livre</param>
        private void AfficheLivreCommandesInfos(Livre livre)
        {
            // informations sur le livre
            txtbLivreCommandes_ISBN.Text = livre.Isbn;
            txtbLivreCommandes_Titre.Text = livre.Titre;
            txtbLivreCommandes_Auteur.Text = livre.Auteur;
            txtbLivreCommandes_Collection.Text = livre.Collection;
            txtbLivreCommandes_Genre.Text = livre.Genre;
            txtbLivreCommandes_Public.Text = livre.Public;
            txtbLivreCommandes_Rayon.Text = livre.Rayon;
            txtbLivreCommandes_CheminImg.Text = livre.Image;
            string image = livre.Image;
            try
            {
                pcbLivreCommandes.Image = Image.FromFile(image);
            }
            catch
            {
                pcbLivreCommandes.Image = null;
            }
            // affiche la liste des commandes du livre
            AfficheLivreCommandes();
        }

        /// <summary>
        /// Récupère et affiche les commandes d'un livre
        /// </summary>
        private void AfficheLivreCommandes()
        {
            string idDocument = txtbLivreCommandes_Num.Text;
            lesCommandesDocument = controller.GetCommandesDocument(idDocument);
            RemplirCommandesDocListe(dgvLivreCommandes, bdgLivreCommandesListe, lesCommandesDocument);
            AccesCommandeLivreGroupBox(true);
        }

        /// <summary>
        /// Permet ou interdit l'accès à la gestion de la commande d'un livre
        /// et vide les objets graphiques
        /// </summary>
        /// <param name="acces">true ou false</param>
        private void AccesCommandeLivreGroupBox(bool acces)
        {
            grpLivreCommandes_Gestion.Enabled = acces;
            txtbLivreCommandes_Nouveau_Num.Text = "";
            txtbLivreCommandes_Nouveau_NbExemplaire.Text = "";
            txtbLivreCommandes_Nouveau_Montant.Text = "";
            dtpLivreCommandes_Nouveau_Date.Value = DateTime.Now;
        }



        /// <summary>
        /// Tri sur les colonnes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCommandesLivre_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<CommandeDocument> listeCommandesDocTriee = RecupDonneesDgvCommandesDocTriee(dgvLivreCommandes, e.ColumnIndex, lesCommandesDocument);
            RemplirCommandesDocListe(dgvLivreCommandes, bdgLivreCommandesListe, listeCommandesDocTriee);
        }

        /// <summary>
        /// vide les zones de recherche
        /// </summary>
        private void VideLivreCommandesZones()
        {
            txtbLivreCommandes_ISBN.Text = "";
            txtbLivreCommandes_Titre.Text = "";
            txtbLivreCommandes_Auteur.Text = "";
            txtbLivreCommandes_Collection.Text = "";
            txtbLivreCommandes_Genre.Text = "";
            txtbLivreCommandes_Public.Text = "";
            txtbLivreCommandes_Rayon.Text = "";
            txtbLivreCommandes_CheminImg.Text = "";
            pcbLivreCommandes.Image = null;
        }


        private void btnAjoutLivreCommande_Click(object sender, EventArgs e)
        {
            if (!txtbLivreCommandes_Nouveau_Num.Text.Equals(""))
            {
                try
                {
                    int numero = int.Parse(txtbLivreCommandes_Nouveau_Num.Text);
                    int nbExemplaire = int.Parse(txtbLivreCommandes_Nouveau_NbExemplaire.Text);
                    DateTime dateCommande = dtpLivreCommandes_Nouveau_Date.Value;
                    string idSuivi = ETAPESUIVIENCOURS;
                    string idDocument = txtbLivreCommandes_Num.Text;
                    double montant = double.Parse(txtbLivreCommandes_Nouveau_Montant.Text);
                    CommandeDocument commandeDocument = new CommandeDocument(numero.ToString(), dateCommande, montant, nbExemplaire, idDocument, idSuivi, GetLibelleFromSuiviId(idSuivi, lesSuivis));
                    if (controller.CreerCommandeDocument(commandeDocument))
                    {
                        AfficheLivreCommandes();
                    }
                    else
                    {
                        MessageBox.Show("numéro de commande déjà existant", "Erreur");
                    }
                }
                catch
                {
                    MessageBox.Show("le numéro de commande, le nombre d'exemplaire et le montant doivent êtres numériques (à virgule pour le montant)", "Information");
                    txtbLivreCommandes_Nouveau_Num.Text = "";
                    txtbLivreCommandes_Nouveau_NbExemplaire.Text = "";
                    txtbLivreCommandes_Nouveau_Montant.Text = "";
                    txtbLivreCommandes_Nouveau_Num.Focus();
                }
            }
            else
            {
                MessageBox.Show("numéro de commande obligatoire", "Information");
            }
        }

        private void btnLivreCommandes_Supprimer_Click(object sender, EventArgs e)
        {
            try
            {
                CommandeDocument commandeDocSelectionnee = (CommandeDocument)bdgLivreCommandesListe.List[bdgLivreCommandesListe.Position];
                if (commandeDocSelectionnee.IdEtapeSuivi != ETAPESUIVILIVREE)
                {
                    controller.SupprimerCommande(commandeDocSelectionnee.Id);
                    AfficheLivreCommandes();
                }
                else
                {
                    MessageBox.Show("Vous ne pouvez pas supprimer une commande livrée.", "Information");
                }
            }
            catch
            {
                MessageBox.Show("Veuillez sélectionnez une commande.", "Information");
            }
        }

        private void btnLivreCommandes_ModifierEtapeSuivi_Click(object sender, EventArgs e)
        {
            try
            {
                CommandeDocument commandeDocSelectionnee = (CommandeDocument)bdgLivreCommandesListe.List[bdgLivreCommandesListe.Position];
                string idNouvelleEtapeSuivi = GetSuiviIdFromLibelle(cbbLivreCommandes_NouvelleEtapeSuivi.SelectedItem.ToString(), lesSuivis);
                int.Parse(idNouvelleEtapeSuivi); //Génère une exception si l'id n'est pas valide
                if (VerifValiditeChangementEtapeSuivi(commandeDocSelectionnee.IdEtapeSuivi, idNouvelleEtapeSuivi, lesSuivis))
                {
                    controller.ModifierEtapeSuiviCommandeDocument(commandeDocSelectionnee.Id, idNouvelleEtapeSuivi);
                    AfficheLivreCommandes();
                }
                else
                {
                    MessageBox.Show("Ce changement n'est pas possible.", "Information");
                }
            }
            catch
            {
                MessageBox.Show("La nouvelle étape de suivi n'est pas valide.", "Erreur");
            }
        }
        #endregion

        #region Onglet GestionDvdCommandes
        private readonly BindingSource bdgDvdCommandesListe = new BindingSource();
        
        /// <summary>
        /// Ouverture de l'onglet : récupère les commandes de dvd et vide tous les champs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabGestionsCommandesDVD_Enter(object sender, EventArgs e)
        {
            lesDvd = controller.GetAllDvd();
            lesSuivis = controller.GetAllSuivi();
            txtbDvdCommandes_Num.Text = "";
            AccesCommandeDvdGroupBox(false);
            RemplirComboCommandeDocEtapeSuivi(lesSuivis, cbbDvdCommandes_NouvelleEtapeSuivi);
        }
        
        /// <summary>
        /// Recherche d'un numéro de dvd et affiche ses informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDVDCommandesRechercher_Click(object sender, EventArgs e)
        {
            if (!txtbDvdCommandes_Num.Text.Equals(""))
            {
                Dvd dvd = lesDvd.Find(x => x.Id.Equals(txtbDvdCommandes_Num.Text));
                if (dvd != null)
                {
                    AfficheDvdCommandesInfos(dvd);
                }
                else
                {
                    MessageBox.Show("numéro introuvable");
                }
            }
        }
        

        /// <summary>
        /// Si le numéro de dvd est modifié, la zone de la gestion de commande est vidée et inactive
        /// les informations de la commande sont aussi effacées
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbDVDCommandes_Num_TextChanged(object sender, EventArgs e)
        {
            VideDvdCommandesZones();
            RemplirCommandesDocListe(dgvDvdCommandes, bdgDvdCommandesListe, null);
            AccesCommandeDvdGroupBox(false);
        }
        
        /// <summary>
        /// Affichage des informations du dvd sélectionnée et de ses commandes.
        /// </summary>
        /// <param name="dvd">le DVD</param>
        private void AfficheDvdCommandesInfos(Dvd dvd)
        {
            // informations sur le dvd
            txtbDvdCommandes_Duree.Text = dvd.Duree.ToString();
            txtbDVDCommandes_Titre.Text = dvd.Titre;
            txtbDvdCommandes_Realisateur.Text = dvd.Realisateur;
            txtbDvdCommandes_Synopsis.Text = dvd.Synopsis;
            txtbDvdCommandes_Genre.Text = dvd.Genre;
            txtbDvdCommandes_Public.Text = dvd.Public;
            txtbDvdCommandes_Rayon.Text = dvd.Rayon;
            txtbDvdCommandes_CheminImg.Text = dvd.Image;
            string image = dvd.Image;
            try
            {
                pcbDvdCommandes.Image = Image.FromFile(image);
            }
            catch
            {
                pcbDvdCommandes.Image = null;
            }
            // affiche la liste des commandes du dvd
            AfficheDvdCommandes();
        }
        
        /// <summary>
        /// Récupère et affiche les commandes d'un dvd
        /// </summary>
        private void AfficheDvdCommandes()
        {
            string idDocument = txtbDvdCommandes_Num.Text;
            lesCommandesDocument = controller.GetCommandesDocument(idDocument);
            RemplirCommandesDocListe(dgvDvdCommandes, bdgDvdCommandesListe, lesCommandesDocument);
            AccesCommandeDvdGroupBox(true);
        }

        /// <summary>
        /// Permet ou interdit l'accès à la gestion de la commande d'un dvd
        /// et vide les objets graphiques
        /// </summary>
        /// <param name="acces">true ou false</param>
        private void AccesCommandeDvdGroupBox(bool acces)
        {
            grpDvdCommandes_Gestion.Enabled = acces;
            txtbDvdCommandes_Nouveau_Num.Text = "";
            txtbDvdCommandes_Nouveau_NbExemplaire.Text = "";
            txtbDvdCommandes_Nouveau_Montant.Text = "";
            dtpDvdCommandes_Nouveau_Date.Value = DateTime.Now;
        }
        
        /// <summary>
        /// Tri sur les colonnes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDVDCommandes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<CommandeDocument> listeCommandesDocTriee = RecupDonneesDgvCommandesDocTriee(dgvDvdCommandes, e.ColumnIndex, lesCommandesDocument);
            RemplirCommandesDocListe(dgvDvdCommandes, bdgDvdCommandesListe, listeCommandesDocTriee);
        }

        /// <summary>
        /// vide les zones de recherche
        /// </summary>
        private void VideDvdCommandesZones()
        {
            txtbDvdCommandes_Duree.Text = "";
            txtbDVDCommandes_Titre.Text = "";
            txtbDvdCommandes_Realisateur.Text = "";
            txtbDvdCommandes_Synopsis.Text = "";
            txtbDvdCommandes_Genre.Text = "";
            txtbDvdCommandes_Public.Text = "";
            txtbDvdCommandes_Rayon.Text = "";
            txtbDvdCommandes_CheminImg.Text = "";
            pcbDvdCommandes.Image = null;
        }

        private void btnDvdCommandes_Ajout_Click(object sender, EventArgs e)
        {
            if (!txtbDvdCommandes_Nouveau_Num.Text.Equals(""))
            {
                try
                {
                    int numero = int.Parse(txtbDvdCommandes_Nouveau_Num.Text);
                    int nbExemplaire = int.Parse(txtbDvdCommandes_Nouveau_NbExemplaire.Text);
                    DateTime dateCommande = dtpDvdCommandes_Nouveau_Date.Value;
                    string idSuivi = ETAPESUIVIENCOURS;
                    string idDocument = txtbDvdCommandes_Num.Text;
                    double montant = double.Parse(txtbDvdCommandes_Nouveau_Montant.Text);
                    CommandeDocument commandeDocument = new CommandeDocument(numero.ToString(), dateCommande, montant, nbExemplaire, idDocument, idSuivi, GetLibelleFromSuiviId(idSuivi, lesSuivis));
                    if (controller.CreerCommandeDocument(commandeDocument))
                    {
                        AfficheDvdCommandes();
                    }
                    else
                    {
                        MessageBox.Show("numéro de commande déjà existant", "Erreur");
                    }
                }
                catch
                {
                    MessageBox.Show("le numéro de commande, le nombre d'exemplaire doivent êtres numériques et le montant devrait être flottant.", "Information");
                    txtbDvdCommandes_Nouveau_Num.Text = "";
                    txtbDvdCommandes_Nouveau_NbExemplaire.Text = "";
                    txtbDvdCommandes_Nouveau_Montant.Text = "";
                    txtbDvdCommandes_Nouveau_Num.Focus();
                }
            }
            else
            {
                MessageBox.Show("numéro de commande obligatoire", "Information");
            }
        }

        private void btnDvdCommandes_Supprimer_Click(object sender, EventArgs e)
        {
            try
            {
                CommandeDocument commandeDocSelectionnee = (CommandeDocument)bdgDvdCommandesListe.List[bdgDvdCommandesListe.Position];
                if (commandeDocSelectionnee.IdEtapeSuivi != ETAPESUIVILIVREE)
                {
                    controller.SupprimerCommande(commandeDocSelectionnee.Id);
                    AfficheDvdCommandes();
                }
                else
                {
                    MessageBox.Show("Vous ne pouvez pas supprimer une commande livrée.", "Information");
                }
            }
            catch
            {
                MessageBox.Show("Veuillez sélectionnez une commande.", "Information");
            }
        }

        private void btnDvdCommandes_Modifier_Click(object sender, EventArgs e)
        {
            try
            {
                CommandeDocument commandeDocSelectionnee = (CommandeDocument)bdgDvdCommandesListe.List[bdgDvdCommandesListe.Position];
                string idNouvelleEtapeSuivi = GetSuiviIdFromLibelle(cbbDvdCommandes_NouvelleEtapeSuivi.SelectedItem.ToString(), lesSuivis);
                int.Parse(idNouvelleEtapeSuivi); //Génère une exception si l'id n'est pas valide
                if (VerifValiditeChangementEtapeSuivi(commandeDocSelectionnee.IdEtapeSuivi, idNouvelleEtapeSuivi, lesSuivis))
                {
                    controller.ModifierEtapeSuiviCommandeDocument(commandeDocSelectionnee.Id, idNouvelleEtapeSuivi);
                    AfficheDvdCommandes();
                }
                else
                {
                    MessageBox.Show("Ce changement n'est pas possible.", "Information");
                }
            }
            catch
            {
                MessageBox.Show("La nouvelle étape de suivi n'est pas valide.", "Erreur");
            }
        }
        #endregion

        #region GestionCommandesRevue
        private readonly BindingSource bdgRevueCommandesListe = new BindingSource();
        private List<Abonnement> lesAbonnements = new List<Abonnement>();

        /// <summary>
        /// Ouverture de l'onglet : récupère les commandes de revue et vide tous les champs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabGestionsCommandesRevue_Enter(object sender, EventArgs e)
        {
            lesRevues = controller.GetAllRevues();
            txtbRevueCommandes_Num.Text = "";
            AccesCommandeRevueGroupBox(false);
        }

        /// <summary>
        /// Recherche d'un numéro de revue et affiche ses informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRevueCommandes_Rechercher_Click(object sender, EventArgs e)
        {
            if (!txtbRevueCommandes_Num.Text.Equals(""))
            {
                Revue revue = lesRevues.Find(x => x.Id.Equals(txtbRevueCommandes_Num.Text));
                if (revue != null)
                {
                    AfficheRevueCommandesInfos(revue);
                }
                else
                {
                    MessageBox.Show("numéro introuvable");
                }
            }
        }

        /// <summary>
        /// Si le numéro de revue est modifié, la zone de la gestion de commande est vidée et inactive
        /// les informations de la commande sont aussi effacées
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbRevueCommandes_Num_TextChanged(object sender, EventArgs e)
        {
            VideRevueCommandesZones();
            RemplirAbonnementsListe(dgvRevueCommandes, bdgRevueCommandesListe, null);
            AccesCommandeRevueGroupBox(false);
        }
        
        /// <summary>
        /// Affichage des informations de la revue sélectionnée et de ses commandes.
        /// </summary>
        /// <param name="revue">La revue</param>
        private void AfficheRevueCommandesInfos(Revue revue)
        {
            // informations sur la revue
            txtbRevueCommandes_Titre.Text = revue.Titre;
            txtbRevueCommandes_Periodicite.Text = revue.Periodicite;
            txtbRevueCommandes_DelaiMiseAdispo.Text = revue.DelaiMiseADispo.ToString();
            txtbRevueCommandes_Genre.Text = revue.Genre;
            txtbRevueCommandes_Public.Text = revue.Public;
            txtbRevueCommandes_Rayon.Text = revue.Rayon;
            txtbRevueCommandes_CheminImg.Text = revue.Image;
            string image = revue.Image;
            try
            {
                pcbRevueCommandes.Image = Image.FromFile(image);
            }
            catch
            {
                pcbRevueCommandes.Image = null;
            }
            // affiche la liste des commandes du dvd
            AfficheRevueCommandes();
        }

        /// <summary>
        /// Récupère et affiche les commandes d'une revue
        /// </summary>
        private void AfficheRevueCommandes()
        {
            string idDocument = txtbRevueCommandes_Num.Text;
            lesAbonnements = controller.GetAbonnementsRevue(idDocument);
            RemplirAbonnementsListe(dgvRevueCommandes, bdgRevueCommandesListe, lesAbonnements);
            AccesCommandeRevueGroupBox(true);
        }

        /// <summary>
        /// Permet ou interdit l'accès à la gestion de la commande d'une revue
        /// et vide les objets graphiques
        /// </summary>
        /// <param name="acces">true ou false</param>
        private void AccesCommandeRevueGroupBox(bool acces)
        {
            grpRevueCommandes_Gestion.Enabled = acces;
            txtbRevueCommandes_Nouveau_Num.Text = "";
            txtbRevueCommandes_Nouveau_Montant.Text = "";
            dtpRevueCommandes_Nouveau_DateCommande.Value = DateTime.Now;
            dtpRevueCommandes_Nouveau_DateFinAbonnement.Value = DateTime.Now;
        }


        /// <summary>
        /// Tri sur les colonnes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRevueCommandes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Abonnement> listeAbonnementsTriee = RecupDonneesDgvAbonnementsTriee(dgvRevueCommandes, e.ColumnIndex, lesAbonnements);
            RemplirAbonnementsListe(dgvRevueCommandes, bdgRevueCommandesListe, listeAbonnementsTriee);
        }

        /// <summary>
        /// vide les zones de recherche
        /// </summary>
        private void VideRevueCommandesZones()
        {
            txtbRevueCommandes_Titre.Text = "";
            txtbRevueCommandes_Periodicite.Text = "";
            txtbRevueCommandes_DelaiMiseAdispo.Text = "";
            txtbRevueCommandes_Genre.Text = "";
            txtbRevueCommandes_Public.Text = "";
            txtbRevueCommandes_Rayon.Text = "";
            txtbRevueCommandes_CheminImg.Text = "";
            pcbRevuesImage.Image = null;
        }

        private void btnRevueCommandes_Ajout_Click(object sender, EventArgs e)
        {
            if (!txtbRevueCommandes_Nouveau_Num.Text.Equals(""))
            {
                try
                {
                    int numero = int.Parse(txtbRevueCommandes_Nouveau_Num.Text);
                    DateTime dateCommande = dtpRevueCommandes_Nouveau_DateCommande.Value;
                    DateTime dateFinAbonnement = dtpRevueCommandes_Nouveau_DateFinAbonnement.Value;
                    string idDocument = txtbRevueCommandes_Num.Text;
                    string titreDocument = txtbRevueCommandes_Titre.Text;
                    double montant = double.Parse(txtbRevueCommandes_Nouveau_Montant.Text);
                    Abonnement abonnement = new Abonnement(numero.ToString(), dateCommande, montant, dateFinAbonnement, idDocument, titreDocument);
                    if (controller.CreerAbonnement(abonnement))
                    {
                        AfficheRevueCommandes();
                    }
                    else
                    {
                        MessageBox.Show("numéro de commande déjà existant", "Erreur");
                    }
                }
                catch
                {
                    MessageBox.Show("le numéro de commande doit être numérique et le montant devrait être flottant.", "Erreur");
                    txtbRevueCommandes_Nouveau_Num.Text = "";
                    txtbRevueCommandes_Nouveau_Montant.Text = "";
                    txtbRevueCommandes_Nouveau_Num.Focus();
                }
            }
            else
            {
                MessageBox.Show("numéro de commande obligatoire", "Information");
            }
        }

        private void btnRevueCommandes_Suppression_Click(object sender, EventArgs e)
        {
            try
            {
                Abonnement abonnementSelectionnee = (Abonnement)bdgRevueCommandesListe.List[bdgRevueCommandesListe.Position];
                lesExemplaires = controller.GetExemplairesRevue(txtbRevueCommandes_Num.Text);
                bool suppressionPossible = true;
                foreach(Exemplaire exemplaire in lesExemplaires)
                {
                    if(!ParutionDansAbonnement(abonnementSelectionnee.DateCommande, abonnementSelectionnee.DateFinAbonnement, exemplaire.DateAchat))
                    {
                        suppressionPossible = false;
                    }
                }
                if (suppressionPossible)
                {
                    controller.SupprimerCommande(abonnementSelectionnee.Id);
                    AfficheRevueCommandes();
                }
                else
                {
                    MessageBox.Show("Vous ne pouvez pas supprimer une commande de revue qui est rattaché à l'un de ses exemplaires (comprise dans la durée de l'abonnement).", "Information");
                }
            }
            catch
            {
                MessageBox.Show("Veuillez sélectionnez une commande.", "Information");
            }
        }

        public bool ParutionDansAbonnement(DateTime dateCommande, DateTime dateFinAbonnement, DateTime dateParution)
        {
            return (dateParution >= dateCommande && dateParution <= dateFinAbonnement);
        }
        #endregion
        #endregion

    }
}
