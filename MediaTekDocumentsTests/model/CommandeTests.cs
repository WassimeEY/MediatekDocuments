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
    public class CommandeTests
    {
        private const string id = "12345";
        private static readonly DateTime dateCommande = new DateTime(2024, 12, 1, 0, 0, 0, DateTimeKind.Utc);
        private const double montant = 54.2f;
        private readonly Commande commandeTest = new Commande(id, dateCommande, montant);

        [TestMethod()]
        public void CommandeTest()
        {
            Assert.AreEqual(id, commandeTest.Id);
            Assert.AreEqual(dateCommande, commandeTest.DateCommande);
            Assert.AreEqual(montant, commandeTest.Montant);
        }
    }
}