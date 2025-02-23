using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model.Tests
{
    [TestClass()]
    public class CommandeDocumentTests
    {
        private const string id = "12345";
        private static readonly DateTime dateCommande = new DateTime(2024, 12, 1, 0, 0, 0, DateTimeKind.Utc);
        private const double montant = 77.2f;
        private const int nbExemplaire = 55;
        private const string idLivreDvd = "00037";
        private const string idEtapeSuivi = "00001";
        private const string etapeSuiviLibelle = "en cours";
        private readonly CommandeDocument commandeDocTest = new CommandeDocument(id, dateCommande, montant, nbExemplaire, idLivreDvd, idEtapeSuivi, etapeSuiviLibelle);


        [TestMethod()]
        public void CommandeDocumentTest()
        {
            Assert.AreEqual(id, commandeDocTest.Id);
            Assert.AreEqual(dateCommande, commandeDocTest.DateCommande);
            Assert.AreEqual(montant, commandeDocTest.Montant);
            Assert.AreEqual(nbExemplaire, commandeDocTest.NbExemplaire);
            Assert.AreEqual(idLivreDvd, commandeDocTest.IdLivreDvd);
            Assert.AreEqual(idEtapeSuivi, commandeDocTest.IdEtapeSuivi);
            Assert.AreEqual(etapeSuiviLibelle, commandeDocTest.EtapeSuiviLibelle);
        }
    }
}