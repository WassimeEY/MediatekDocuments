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
    public class LivreTests
    {
        private const string id = "12345";
        private const string titre = "Le Test";
        private const string image = "un chemin vers une image";
        private const string isbn = "978-2-206-11088-2";
        private const string auteur = "Auteur du livre";
        private const string collection = "Education";
        private const string idGenre = "00004";
        private const string genre = "Education";
        private const string idPublic = "00002";
        private const string lePublic = "Adulte";
        private const string idRayon = "00005";
        private const string rayon = "BD";
        private readonly Livre livreTest = new Livre(id, titre, image, isbn, auteur, collection, idGenre, genre, idPublic, lePublic, idRayon, rayon);

        [TestMethod()]
        public void LivreTest()
        {
            Assert.AreEqual(id, livreTest.Id);
            Assert.AreEqual(titre, livreTest.Titre);
            Assert.AreEqual(image, livreTest.Image);
            Assert.AreEqual(isbn, livreTest.Isbn);
            Assert.AreEqual(auteur, livreTest.Auteur);
            Assert.AreEqual(collection, livreTest.Collection);
            Assert.AreEqual(idGenre, livreTest.IdGenre);
            Assert.AreEqual(genre, livreTest.Genre);
            Assert.AreEqual(idPublic, livreTest.IdPublic);
            Assert.AreEqual(lePublic, livreTest.Public);
            Assert.AreEqual(idRayon, livreTest.IdRayon);
            Assert.AreEqual(rayon, livreTest.Rayon);
        }
    }
}