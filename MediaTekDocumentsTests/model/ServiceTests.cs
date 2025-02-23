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
    public class ServiceTests
    {
        private const string id = "00003";
        private const string libelle = "Administratif";
        private readonly Service serviceTest = new Service(id, libelle);

        [TestMethod()]
        public void ServiceTest()
        {
            Assert.AreEqual(id, serviceTest.Id);
            Assert.AreEqual(libelle, serviceTest.Libelle);
        }
    }
}