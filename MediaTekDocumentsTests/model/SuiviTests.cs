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
    public class SuiviTests
    {
        private const string id = "00001";
        private const string libelle = "en cours";
        private readonly Suivi suiviTest = new Suivi(id, libelle);

        [TestMethod()]
        public void SuiviTest()
        {
            Assert.AreEqual(id, suiviTest.Id);
            Assert.AreEqual(libelle, suiviTest.Libelle);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Console.WriteLine(libelle + suiviTest.ToString());
            Assert.AreEqual(libelle, suiviTest.ToString());
        }
    }
}