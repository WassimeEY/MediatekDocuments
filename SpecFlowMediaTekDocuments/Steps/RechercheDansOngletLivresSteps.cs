using MediaTekDocuments.view;
using NUnit.Framework;
using System;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace SpecFlowMediaTekDocuments.Steps
{
    [Binding]
    public class RechercheDansOngletLivresSteps
    {
        public readonly FrmMediatek frmMediatek = new FrmMediatek("00003");

        [BeforeScenario]
        public void BeforeScenario()
        {
            frmMediatek.Visible = true;
            TabControl tabOngletsApplication = (TabControl)frmMediatek.Controls["tabOngletsApplication"];
            tabOngletsApplication.SelectedTab = tabOngletsApplication.TabPages["tabLivres"];
        }

            [Given(@"je saisis le titre (.*)")]
        public void GivenJeSaisisLeTitre(string titre)
        {
            TextBox txbLivresTitreRecherche = (TextBox)frmMediatek.Controls["tabOngletsApplication"].Controls["tabLivres"].Controls["grpLivresRecherche"].Controls["txbLivresTitreRecherche"];
            txbLivresTitreRecherche.Text = titre;
            Console.WriteLine("Étape GivenJeSaisisLeTitre atteinte. Titre : " + titre);
        }
        

        [Then(@"la liste ne contient plus qu'un seul livre, et son titre est (.*)")]
        public void ThenLaListeContientUnSeulLivreAvecLeTitre(string resultat)
        {
            DataGridView dgvLivresListe = (DataGridView)frmMediatek.Controls["tabOngletsApplication"].Controls["tabLivres"].Controls["grpLivresRecherche"].Controls["dgvLivresListe"];
            Assert.IsTrue(dgvLivresListe.Rows.Count > 0, "Aucun livre trouvé");
            string titrePremierLivreTrouve = dgvLivresListe.Rows[0].Cells["titre"].Value.ToString() ?? "";
            Assert.AreEqual(resultat, titrePremierLivreTrouve); 
        }
    }
}
