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
    public class GenreTests
    {
        private const string id = "00001";
        private const string libelle = "Horreur";
        private readonly Genre genreTest = new Genre(id, libelle);

        [TestMethod()]
        public void GenreTest()
        {
            Assert.AreEqual(id, genreTest.Id);
            Assert.AreEqual(libelle, genreTest.Libelle);
        }
    }
}