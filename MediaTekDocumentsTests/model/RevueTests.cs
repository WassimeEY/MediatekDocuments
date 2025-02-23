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
    public class RevueTests
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
        private const string periodicite = "MS";
        private const int delaiMiseADispo = 52;
        private readonly Revue revueTest = new Revue(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon, periodicite, delaiMiseADispo);

        [TestMethod()]
        public void RevueTest()
        {
            Assert.AreEqual(id, revueTest.Id);
            Assert.AreEqual(titre, revueTest.Titre);
            Assert.AreEqual(image, revueTest.Image);
            Assert.AreEqual(idGenre, revueTest.IdGenre);
            Assert.AreEqual(genre, revueTest.Genre);
            Assert.AreEqual(idPublic, revueTest.IdPublic);
            Assert.AreEqual(lePublic, revueTest.Public);
            Assert.AreEqual(idRayon, revueTest.IdRayon);
            Assert.AreEqual(rayon, revueTest.Rayon);
            Assert.AreEqual(periodicite, revueTest.Periodicite);
            Assert.AreEqual(delaiMiseADispo, revueTest.DelaiMiseADispo);
        }
    }
}