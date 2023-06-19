using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_01.Model
{
    /// <summary>
    /// stocke 4 informations :
    /// 3 chaines : le nom, le prenom, l'email
    /// 1 entier : l'idpersonnel
    /// </summary>
    public class Personnel : Crud<Personnel>
    {
        //constructeur
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


        //champs
        /// <summary>
        /// Obtient l'id du personnel
        /// </summary>
        public int Idpersonnel { get; set; }
        /// <summary>
        /// Obtient l'email du personnel
        /// </summary>
        public string Emailpersonnel { get; set; }
        /// <summary>
        /// Obtient le nom du personnel
        /// </summary>
        public string Nompersonnel { get; set; }
        /// <summary>
        /// Obtient le prénom du personnel
        /// </summary>
        public string Prenompersonnel { get; set; }


        /// <summary>
        /// Création de nouveau personnels grace aux email, nompersonnel, prenompersonnel
        /// </summary>
        /// <return> Un nouveau personnel</return>
        public void Create()
        {
            new DataAccess().SetData($"insert into personnel (emailpersonnel, nompersonnel, prenompersonnel) values ('{this.Emailpersonnel}','{this.Nompersonnel}','{this.Prenompersonnel}');");
        }

        /// <summary>
        /// Suppression de personnels 
        /// </summary>
        /// <return> supprime un personnel</return>
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

        public override bool Equals(object? obj)
        {
            return obj is Personnel personnel &&
                   Idpersonnel == personnel.Idpersonnel &&
                   Emailpersonnel == personnel.Emailpersonnel &&
                   Nompersonnel == personnel.Nompersonnel &&
                   Prenompersonnel == personnel.Prenompersonnel;
        }


        /// <summary>
        /// Remonte lse données 
        /// </summary>
        /// <return> ObservableCollection (liste) des personnels</return>
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

        public override int GetHashCode()
        {
            return HashCode.Combine(Idpersonnel, Emailpersonnel, Nompersonnel, Prenompersonnel);
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Met a jours les données
        /// </summary>
        /// <return> Met a jours les données</return>
        public void Update()
        {
            new DataAccess().SetData($"Update personnel set nompersonnel = '{this.Nompersonnel}', prenompersonnel = '{this.Prenompersonnel}', emailpersonnel = '{this.Emailpersonnel}' where idpersonnel = {this.Idpersonnel}");
        }
    }
}
