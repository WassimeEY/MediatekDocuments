using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.view.Tests
{
    [TestClass()]
    public class FrmMediatekTests
    {
        DateTime dateParution = new DateTime(2000, 12, 15);
        DateTime dateCommande = new DateTime(2000, 12, 1);
        DateTime dateFinAbonnement = new DateTime(2000, 12, 29);
        [TestMethod()]
        public void ParutionDansAbonnementTest()
        {
            bool test = (dateParution >= dateCommande && dateParution <= dateFinAbonnement);
            Assert.IsTrue(test);
        }
    }
}