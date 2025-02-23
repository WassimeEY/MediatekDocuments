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
    public class UtilisateurTests
    {
        private const string id = "00001";
        private const string login = "PeterParker";
        private const string mdp = "motdepasse";
        private const string idService = "00002";
        private const string libelleService = "Prêts";
        private readonly Utilisateur utilisateurTest = new Utilisateur(id, login, mdp, idService, libelleService);

        [TestMethod()]
        public void UtilisateurTest()
        {
            Assert.AreEqual(id, utilisateurTest.Id);
            Assert.AreEqual(login, utilisateurTest.Login);
            Assert.AreEqual(mdp, utilisateurTest.Mdp);
            Assert.AreEqual(idService, utilisateurTest.IdService);
            Assert.AreEqual(libelleService, utilisateurTest.LibelleService);
        }
    }
}