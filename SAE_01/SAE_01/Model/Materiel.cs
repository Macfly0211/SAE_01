using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAE_01.Model
{
    public class Materiel : Crud<Materiel>
    {
        public int fk_idCategorie { get => fk_idCategorie; set => fk_idCategorie = value; }

        public Materiel()
        {
        }

        public Materiel(int idmateriel, int idcategorie, string nommateriel, string referenceconstructeurmateriel, string codebarreinventaire)
        {
            this.Idmateriel = idmateriel;
            this.fk_idcategorie = idcategorie;
            this.Nommateriel = nommateriel;
            this.Referenceconstructeurmateriel = referenceconstructeurmateriel;
            this.Codebarreinventaire = codebarreinventaire;
        }

        private CategorieMateriel uneCategorie;

        public int Idmateriel { get; set; }
        public int fk_idcategorie { get; set; }
        public int Idcategorie { get; set; }
        public string Nommateriel { get; set; }
        public string Referenceconstructeurmateriel { get; set; }
        public string Codebarreinventaire { get; set; }

        public CategorieMateriel UneCategorie
        {
            get
            {
                return uneCategorie;
            }

            set
            {
                uneCategorie = value;
            }
        }

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

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            
            
                if (accesBD.OpenConnection())
                {
                      //MessageBoxResult res = MessageBox.Show($"DELETE from materiel where" + $" idmateriel={this.Idmateriel}" + $" idcategorie={this.Idcategorie}" + $" and nommateriel = '{this.Nommateriel}'" + $" referenceconstructeurmateriel='{this.Referenceconstructeurmateriel}'" + $" codebarreinventaire = '{this.Codebarreinventaire};", "Suppression", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);

                     String requete = $"DELETE from materiel where idmateriel={this.Idmateriel};";
                     accesBD.SetData(requete);
                     accesBD.CloseConnection();

                }
            
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Materiel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    } 
}
