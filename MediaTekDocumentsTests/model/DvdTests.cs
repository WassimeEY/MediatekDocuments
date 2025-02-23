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
    public class DvdTests
    {
        private const string id = "12345";
        private const string titre = "Le Test";
        private const string image = "un chemin vers une image";
        private const int duree = 2;
        private const string realisateur = "Christopher Nolan";
        private const string synopsis = "Chef d'oeuvre.";
        private const string idGenre = "00004";
        private const string genre = "Horreur";
        private const string idPublic = "00002";
        private const string lePublic = "Adulte";
        private const string idRayon = "00005";
        private const string rayon = "BD";
        private readonly Dvd dvdTest = new Dvd(id, titre, image, duree, realisateur, synopsis, idGenre, genre, idPublic, lePublic, idRayon, rayon);

        [TestMethod()]
        public void DvdTest()
        {
            Assert.AreEqual(id, dvdTest.Id);
            Assert.AreEqual(titre, dvdTest.Titre);
            Assert.AreEqual(image, dvdTest.Image);
            Assert.AreEqual(duree, dvdTest.Duree);
            Assert.AreEqual(realisateur, dvdTest.Realisateur);
            Assert.AreEqual(synopsis, dvdTest.Synopsis);
            Assert.AreEqual(idGenre, dvdTest.IdGenre);
            Assert.AreEqual(genre, dvdTest.Genre);
            Assert.AreEqual(idPublic, dvdTest.IdPublic);
            Assert.AreEqual(lePublic, dvdTest.Public);
            Assert.AreEqual(idRayon, dvdTest.IdRayon);
            Assert.AreEqual(rayon, dvdTest.Rayon);
        }
    }
}