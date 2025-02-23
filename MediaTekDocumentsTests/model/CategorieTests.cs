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
    public class CategorieTests
    {
        private const string id = "10004";
        private const string libelle = "Historique";
        private readonly Categorie categorieTest = new Categorie(id, libelle);

        [TestMethod()]
        public void CategorieTest()
        {
            Assert.AreEqual(id, categorieTest.Id);
            Assert.AreEqual(libelle, categorieTest.Libelle);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(libelle, categorieTest.ToString());
        }
    }
}