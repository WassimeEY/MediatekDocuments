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
    public class ExemplaireTests
    {
        private const int numero = 25;
        private static readonly DateTime dateAchat = new DateTime(2024, 12, 1, 0, 0, 0, DateTimeKind.Utc);
        private const string photo = "chemin vers photo";
        private const string idEtat = "00001";
        private const string id = "12345";
        private readonly Exemplaire exemplaireTest = new Exemplaire(numero, dateAchat, photo, idEtat, id);

        [TestMethod()]
        public void ExemplaireTest()
        {
            Assert.AreEqual(numero, exemplaireTest.Numero);
            Assert.AreEqual(dateAchat, exemplaireTest.DateAchat);
            Assert.AreEqual(photo, exemplaireTest.Photo);
            Assert.AreEqual(idEtat, exemplaireTest.IdEtat);
            Assert.AreEqual(id, exemplaireTest.Id);
        }
    }
}