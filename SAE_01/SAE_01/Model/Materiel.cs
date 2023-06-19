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
    /// stocke 5 informations :
    /// 3 chaines : le nom, la reference cosntructeur, le code barre
    /// 2 entier : l'idmateriel, l'idcategorie
    /// </summary>
    public class Materiel : Crud<Materiel>
    {
        //constructeur vide
        public Materiel()
        {
        }

        //constructeur 
        public Materiel(int idmateriel, int idcategorie, string nommateriel, string referenceconstructeurmateriel, string codebarreinventaire)
        {
            this.Idmateriel = idmateriel;
            this.fk_idcategorie = idcategorie;
            this.Nommateriel = nommateriel;
            this.Referenceconstructeurmateriel = referenceconstructeurmateriel;
            this.Codebarreinventaire = codebarreinventaire;
        }

        public Materiel(int idmateriel, CategorieMateriel idcategorie, string nommateriel, string referenceconstructeurmateriel, string codebarreinventaire)
        {
            this.Idmateriel = idmateriel;
            this.UneCategorie = idcategorie;
            this.Nommateriel = nommateriel;
            this.Referenceconstructeurmateriel = referenceconstructeurmateriel;
            this.Codebarreinventaire = codebarreinventaire;
        }

        private CategorieMateriel uneCategorie;

        /// <summary>
        /// Obtient l'id du materiel
        /// </summary>
        public int Idmateriel { get; set; }
        /// <summary>
        /// Obtient l'id de la categorie
        /// </summary>
        public int fk_idcategorie { get; set; }
        public int Idcategorie { get; set; }
        /// <summary>
        /// Obtient le nom du materiel
        /// </summary>
        public string Nommateriel { get; set; }
        /// <summary>
        /// Obtient la référence cosntructeur matériel
        /// </summary>
        /// <exception> Envoyée si la référence ne suit pas le Régex </exception>
        
        public string Referenceconstructeurmateriel { get; set; }
        /// <summary>
        /// Obtient le code barre inventaire
        /// </summary>
        /// <exception> Envoyée si le code barre ne suit pas le Régex </exception>
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
        /// <summary>
        ///Remonte les données
        /// </summary>
        /// <return>Remonte les données dans une ObservableCollection (liste) lesmateriel</return>
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

        /// <summary>
        /// Supprime un matériel
        /// </summary>
        /// <return>Supprime un matériel avec une requete sql</return>
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

        /// <summary>
        /// Créer un matériel
        /// </summary>
        /// <return>Créer un méteriel avec une requete sql</return>
        public void Create()
        {
            new DataAccess().SetData($"insert into materiel (idcategorie, nommateriel, referenceconstructeurmateriel, codebarreinventaire) values ({this.UneCategorie.Idcategorie}, '{this.Nommateriel}','{this.Referenceconstructeurmateriel}','{this.Codebarreinventaire}');");
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modifie un matériel
        /// </summary>
        /// <return>Modifie un matériel grace a une requete</return>
        public void Update()
        {
            new DataAccess().SetData($"Update materiel set nommateriel = '{this.Nommateriel}', referenceconstructeurmateriel = '{this.Referenceconstructeurmateriel}', codebarreinventaire = '{this.Codebarreinventaire}' where idmateriel = {this.Idmateriel}");
        }

        public ObservableCollection<Materiel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    } 
}
