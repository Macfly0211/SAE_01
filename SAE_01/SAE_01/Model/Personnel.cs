using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_01.Model
{
    public class Personnel : Crud<Personnel>
    {
        public Personnel()
        {
        }
        
        public Personnel(int idpersonnel, string emailpersonnel, string nompersonnel, string prenompersonnel)
        {
            this.Idpersonnel = idpersonnel;
            this.Emailpersonnel = emailpersonnel;
            this.Nompersonnel = nompersonnel;
            this.Prenompersonnel = prenompersonnel;
        }

        public int Idpersonnel { get; set; }
        public string Emailpersonnel { get; set; }
        public string Nompersonnel { get; set; }
        public string Prenompersonnel { get; set; }

        public void Create()
        {
            new DataAccess().SetData($"insert into personnel (emailpersonnel, nompersonnel, prenompersonnel) values ('{this.Emailpersonnel}','{this.Nompersonnel}','{this.Prenompersonnel}');");
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();


            if (accesBD.OpenConnection())
            {

                String requete = $"DELETE from personnel where idpersonnel = {this.Idpersonnel};";
                accesBD.SetData(requete);
                accesBD.CloseConnection();

            }
        }

        public ObservableCollection<Personnel> FindAll()
        {
            ObservableCollection<Personnel> lesPersonnel = new ObservableCollection<Personnel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idpersonnel,emailpersonnel, nompersonnel, prenompersonnel from personnel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Personnel p = new Personnel(int.Parse(row["idpersonnel"].ToString()), (String)row["emailpersonnel"], (String)row["nompersonnel"], (String)row["prenompersonnel"]);
                    lesPersonnel.Add(p);
                }
            }
            return lesPersonnel;
        }

        public ObservableCollection<Personnel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            new DataAccess().SetData($"Update personnel '{this.Emailpersonnel}','{this.Nompersonnel}','{this.Prenompersonnel}';");
        }
    }
}
