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
    public class RayonTests
    {
        private const string id = "00001";
        private const string libelle = "BD";
        private readonly Rayon rayonTest = new Rayon(id, libelle);

        [TestMethod()]
        public void RayonTest()
        {
            Assert.AreEqual(id, rayonTest.Id);
            Assert.AreEqual(libelle, rayonTest.Libelle);
        }
    }
}