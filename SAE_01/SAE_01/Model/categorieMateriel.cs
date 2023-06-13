using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_01.Model
{
    public class categorieMateriel
    {
        public categorieMateriel(int idcategorie, string nomcategorie)
        {
            Idcategorie = idcategorie;
            Nomcategorie = nomcategorie;
        }

        public categorieMateriel()
        {
            
        }

        public int Idcategorie { get; set; }
        public string Nomcategorie { get; set; }

        public ObservableCollection<categorieMateriel> FindAll()
        {
            ObservableCollection<categorieMateriel> lesEtudiants = new ObservableCollection<categorieMateriel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select id, nom, prenom from etudiants ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    categorieMateriel e = new categorieMateriel(int.Parse(row["idcategorie"].ToString()), (String)row["nomcategorie"]);
                    lesEtudiants.Add(e);
                }
            }
            return lesEtudiants;
        }
    }
}
