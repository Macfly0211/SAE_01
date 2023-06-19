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
    /// <summary>
    /// stocke 2 informations :
    /// 1 chaines : le nom categorie
    /// 1 entier : l'idcategorie
    /// </summary>
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
        /// <summary>
        /// Obtient l'id de la categorie
        /// </summary>
        public int Idcategorie { get; set; }
        /// <summary>
        /// Obtient le nom de la categorie
        /// </summary>
        public string Nomcategorie { get; set; }

        /// <summary>
        ///Remonte les données
        /// </summary>
        /// <return>Remonte les données dans une ObservableCollection (liste) lesCategorieMateriel</return>
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

        /// <summary>
        /// Créer une categorie matériel
        /// </summary>
        /// <return>Créer une catégorie matéreil avec une requete sql</return>
        public void Create()
        {
            new DataAccess().SetData($"insert into categorie_materiel (nomcategorie) values ('{this.Nomcategorie}');");
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modifie une catégorie matériel
        /// </summary>
        /// <return>Modifie une catégorie matériel grace a une requete</return>
        public void Update()
        {
            new DataAccess().SetData($"Update categorie_materiel set nomcategorie = '{this.Nomcategorie}' where idcategorie = {this.Idcategorie}");
        }



        /// <summary>
        /// Supprime une catégorie matériel
        /// </summary>
        /// <return>Supprime une catégorie matériel avec une requete sql</return>
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

