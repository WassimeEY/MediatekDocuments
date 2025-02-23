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
    public class PublicTests
    {
        private const string id = "00001";
        private const string libelle = "Adulte";
        private readonly Public publicTest = new Public(id, libelle);

        [TestMethod()]
        public void PublicTest()
        {
            Assert.AreEqual(id, publicTest.Id);
            Assert.AreEqual(libelle, publicTest.Libelle);
        }
    }
}