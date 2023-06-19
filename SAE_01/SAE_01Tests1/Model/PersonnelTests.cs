using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_01.Model;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SAE_01.Model.Tests
{
    [TestClass()]
    public class PersonnelTests
    {
        Personnel Test = new Personnel(0,"TestEmail", "TestNom", "TestPrenom");
        
        
        [TestMethod()]
        public void CreateTest()
        {
            Test.Create();
            bool trouver = false;
            int id = 0;
            foreach(Personnel unPersonnel in Test.FindAll())
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
            Test.Delete();
        }
        [TestMethod()]
        public void DeleteTest()
        {
            Test.Create();
            int id = 0;
            foreach(Personnel unPersonnel in Test.FindAll())
            {
                if(unPersonnel.Nompersonnel == "TestNom" && unPersonnel.Prenompersonnel == "TestPrenom" && unPersonnel.Emailpersonnel == "TestEmail")
                {
                    id = unPersonnel.Idpersonnel;
                    break;
                }
            }

            new Personnel(id,"", "", "").Delete();

            foreach(Personnel unPersonnel in Test.FindAll())
            {
                if(unPersonnel.Nompersonnel == "TestNom" && unPersonnel.Prenompersonnel == "TestPrenom" && unPersonnel.Emailpersonnel == "TestEmail")
                {
                    Assert.Fail();
                }
            }
            Test.Delete();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            Test.Create();
            Test.Nompersonnel = "Nom";
            Test.Prenompersonnel = "Prenom";
            Test.Emailpersonnel = "Email";
            Test.Update();
            Personnel verif = new Personnel();
            DataTable lesDatas = data.GetData($"select idpersonnel, emailpersonnel, nompersonnel, prenompersonnel from personnel");
            foreach(DataRow row in lesDatas.Rows)
            {
                if((int)row["idpersonnel"] == Test.Idpersonnel)
                {
                    verif = new Personnel(((int)row["idpersonnel"]), row["emailpersonnel"].ToString(), row["nompersonnel"].ToString(), row["prenompersonnel"].ToString());
                }
            }
            Assert.AreEqual(verif, Test, "Erreur pendant l'Update");
            Test.Delete();

        }
    }
}