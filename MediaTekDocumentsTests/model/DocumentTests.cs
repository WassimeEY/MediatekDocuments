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
    public class DocumentTests
    {
        private const string id = "12345";
        private const string titre = "Le Test";
        private const string image = "un chemin vers une image";
        private const string idGenre = "00004";
        private const string genre = "Horreur";
        private const string idPublic = "00002";
        private const string lePublic = "Adulte";
        private const string idRayon = "00005";
        private const string rayon = "BD";
        private readonly Document documentTest = new Document(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon);

        [TestMethod()]
        public void DocumentTest()
        {
            Assert.AreEqual(id, documentTest.Id);
            Assert.AreEqual(titre, documentTest.Titre);
            Assert.AreEqual(image, documentTest.Image);
            Assert.AreEqual(idGenre, documentTest.IdGenre);
            Assert.AreEqual(genre, documentTest.Genre);
            Assert.AreEqual(idPublic, documentTest.IdPublic);
            Assert.AreEqual(lePublic, documentTest.Public);
            Assert.AreEqual(idRayon, documentTest.IdRayon);
            Assert.AreEqual(rayon, documentTest.Rayon);
        }
    }
}