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

        public int Idcategorie { get; set; }
        public string Nomcategorie { get; set; }

        public ObservableCollection<Etudiant> FindAll()
        {
            ObservableCollection<Etudiant> lesEtudiants = new ObservableCollection<Etudiant>();
            DataAccess accesBD = new DataAccess();
            String requete = "select id, nom, prenom from etudiants ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Etudiant e = new Etudiant(int.Parse(row["id"].ToString()), (String)row["nom"], (String)row["prenom"]);
                    lesEtudiants.Add(e);
                }
            }
            return lesEtudiants;
        }
    }
}
