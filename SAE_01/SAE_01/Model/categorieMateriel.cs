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
    public class CategorieMateriel : Crud<CategorieMateriel>
    {
        //constructeur
        public CategorieMateriel(int idcategorie, string nomcategorie)
        {
            Idcategorie = idcategorie;
            Nomcategorie = nomcategorie;
        }

        public CategorieMateriel()
        {
            
        }

        //champs
        public int Idcategorie { get; set; }
        public string Nomcategorie { get; set; }

        //FindAll = remonte les données
        public ObservableCollection<CategorieMateriel> FindAll()
        {
            ObservableCollection<CategorieMateriel> lesCategorieMateriel = new ObservableCollection<CategorieMateriel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idcategorie, nomcategorie from categorie_materiel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    CategorieMateriel cm = new CategorieMateriel(int.Parse(row["idcategorie"].ToString()), (String)row["nomcategorie"]);
                    lesCategorieMateriel.Add(cm);
                }
            }
            return lesCategorieMateriel;
        }

        //Create = méthode de création de nouveau personnels
        public void Create()
        {
            new DataAccess().SetData($"insert into categorie_materiel (nomcategorie) values ('{this.Nomcategorie}');");
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }



        //Delete = méthode de suppression de personnels
        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            
                if (accesBD.OpenConnection())
                {
                    String requete = $"DELETE from categorie_materiel where" + $" idcategorie={this.Idcategorie}" + $" and nomcategorie = '{this.Nomcategorie}';";
                    accesBD.SetData(requete);
                    accesBD.CloseConnection();

                }
           
        }

        public ObservableCollection<CategorieMateriel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }    
    
}

