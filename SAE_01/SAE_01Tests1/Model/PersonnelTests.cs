using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_01.Model;
using SAE_01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace SAE_01.Model.Tests
{
    [TestClass()]
    public class PersonnelTests
    {
        Personnel TestCreate = new Personnel(0,"TestcEmail", "TestcNom", "TestcPrenom");
        Personnel TestDelete = new Personnel(0,"TestdEmail", "TestdNom", "TestdPrenom");
        Personnel TestUpdate = new Personnel(0,"TestuEmail", "TestuNom", "TestuPrenom");
        
        
        [TestMethod()]
        public void CreateTest()
        {
            TestCreate.Create();
            bool trouver = false;
            int id = 0;
            foreach(Personnel unPersonnel in TestCreate.FindAll())
            {
                if (unPersonnel.Emailpersonnel == "TestEmail" && unPersonnel.Prenompersonnel == "TestPrenom" && unPersonnel.Nompersonnel == "TestNom") ;
                {
                    trouver = true;
                    id = unPersonnel.Idpersonnel;
                    break;
                }
            }

            Assert.IsTrue(trouver);
            new Personnel(id, "", "", "").Delete();
            TestCreate.Delete();
        }
        [TestMethod()]
        public void DeleteTest()
        {
            TestDelete.Create();
            int id = 0;
            foreach(Personnel unPersonnel in TestDelete.FindAll())
            {
                if(unPersonnel.Nompersonnel == "TestNom" && unPersonnel.Prenompersonnel == "TestPrenom" && unPersonnel.Emailpersonnel == "TestEmail")
                {
                    id = unPersonnel.Idpersonnel;
                    break;
                }
            }

            new Personnel(id,"", "", "").Delete();

            foreach(Personnel unPersonnel in TestDelete.FindAll())
            {
                if(unPersonnel.Nompersonnel == "TestNom" && unPersonnel.Prenompersonnel == "TestPrenom" && unPersonnel.Emailpersonnel == "TestEmail")
                {
                    Assert.Fail();
                }
            }
            TestDelete.Delete();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            TestUpdate.Create();
            TestUpdate.Nompersonnel = "Nom";
            TestUpdate.Prenompersonnel = "Prenom";
            TestUpdate.Emailpersonnel = "Email";
            int id = (int)data.GetData($"select idpersonnel from personnel").Rows[0]["idpersonnel"];
            TestUpdate.Idpersonnel = id;
            TestUpdate.Update();
            Personnel verif = new Personnel();
            DataTable lesDatas = data.GetData($"select idpersonnel, emailpersonnel, nompersonnel, prenompersonnel from personnel");
            foreach(DataRow row in lesDatas.Rows)
            {
                if((int)row["idpersonnel"] == id)
                {
                    verif = new Personnel((int)row["idpersonnel"], row["emailpersonnel"].ToString(), row["nompersonnel"].ToString(), row["prenompersonnel"].ToString());
                }
            }
            Assert.AreEqual(verif, TestUpdate, "Erreur pendant l'Update");
            TestUpdate.Delete();

        }
    }
}