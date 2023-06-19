using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_01.Model.Tests
{
    [TestClass()]
    public class PersonnelTests
    {
        Personnel p1 = new Personnel(1, "1@gmail.com", "p1Nom", "p1Prenom");
        Personnel p2 = new Personnel(1, "2@gmail.com", "p2Nom", "p2Prenom");
        Personnel p3 = new Personnel(1, "3@gmail.com", "p3Nom", "p3Prenom");
        Personnel p4 = new Personnel(1, "4@gmail.com", "p4Nom", "p4Prenom");
        
        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }
    }
}