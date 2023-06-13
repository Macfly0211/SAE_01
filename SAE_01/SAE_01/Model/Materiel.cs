using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_01.Model
{
    class Materiel
    {
        public Materiel()
        {
        }

        public Materiel(int idmateriel, int idcategorie, string nommateriel, string referenceconstructeurmateriel, string codebarreinventaire)
        {
            Idmateriel = idmateriel;
            Idcategorie = idcategorie;
            Nommateriel = nommateriel;
            Referenceconstructeurmateriel = referenceconstructeurmateriel;
            Codebarreinventaire = codebarreinventaire;
        }

        public int Idmateriel { get; set; }
        public int Idcategorie { get; set; }
        public string Nommateriel { get; set; }
        public string Referenceconstructeurmateriel { get; set; }
        public string Codebarreinventaire { get; set; }

        public ObservableCollection<Materiel> FindAll()
        {
            ObservableCollection<Materiel> lesMateriel = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idmateriel, idcategorie, nommateriel, referenceconstructeurmateriel, codebarreinventaire from materiel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel m = new Materiel(int.Parse(row["idmateriel"].ToString()), int.Parse(row["idcategorie"].ToString()),(String)row["nommateriel"], (String)row["referenceconstructeurmateriel"], (String)row["codebarreinventaire"]);
                    lesMateriel.Add(m);
                }
            }
            return lesMateriel;
        }
    } 
}
