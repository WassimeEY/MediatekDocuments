using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace MediaTekDocuments.model.Tests
{
    [TestClass()]
    public class AbonnementTests
    {
        private const string id = "12345";
        private static readonly DateTime dateCommande = new DateTime(2024, 12, 1, 0, 0, 0, DateTimeKind.Utc);
        private const double montant = 54.2f;
        private static readonly DateTime dateFinAbonnement = new DateTime(2025, 12, 1, 0, 0, 0, DateTimeKind.Utc);
        private const string idRevue = "54321";
        private const string titreRevue = "Superbe revue 2";
        private readonly Abonnement abonnementTest = new Abonnement(id, dateCommande, montant, dateFinAbonnement, idRevue, titreRevue);

        [TestMethod()]
        public void AbonnementTest()
        {
            Assert.AreEqual(id, abonnementTest.Id);
            Assert.AreEqual(dateCommande, abonnementTest.DateCommande);
            Assert.AreEqual(montant, abonnementTest.Montant);
            Assert.AreEqual(dateFinAbonnement, abonnementTest.DateFinAbonnement);
            Assert.AreEqual(idRevue, abonnementTest.IdRevue);
            Assert.AreEqual(titreRevue, abonnementTest.TitreRevue);
        }
    }
}