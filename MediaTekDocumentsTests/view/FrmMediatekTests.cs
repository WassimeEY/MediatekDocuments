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
        readonly DateTime dateParution = new DateTime(2000, 12, 15, 0, 0, 0, DateTimeKind.Utc);
        readonly DateTime dateCommande = new DateTime(2000, 12, 1, 0, 0, 0, DateTimeKind.Utc);
        readonly DateTime dateFinAbonnement = new DateTime(2000, 12, 29, 0, 0, 0, DateTimeKind.Utc);
        [TestMethod()]
        public void ParutionDansAbonnementTest()
        {
            bool test = (dateParution >= dateCommande && dateParution <= dateFinAbonnement);
            Assert.IsTrue(test);
        }
    }
}