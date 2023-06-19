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
    /// stocke 4 informations :
    /// 1 chaines : le commentaire
    /// 2 entier : l'idmateriel, l'idpersonnel
    /// 1 dateTime : dateAttribution
    /// </summary>
    public class EstAttribue : Crud<EstAttribue>
    {
        //constructeur
        public EstAttribue(int idpersonnel, int idmateriel, DateTime dateattribution, string commentaireattribution)
        {
            this.fk_idPerso = idpersonnel;
            this.fk_idMateriel = idmateriel;
            this.Dateattribution = dateattribution;
            this.Commentaireattribution = commentaireattribution;
        }
        public EstAttribue(Personnel p, Materiel m, DateTime dateattribution, string commentaireattribution)
        {
            this.UnPersonnel = p;
            this.UnMateriel = m;
            this.Dateattribution = dateattribution;
            this.Commentaireattribution = commentaireattribution;
        }

        public EstAttribue(Personnel p, Materiel m, DateTime dateattribution)
        {
            this.UnPersonnel = p;
            this.UnMateriel = m;
            this.Dateattribution = dateattribution;

        }

        public EstAttribue()
        {
            
        }

        //champs

        private Personnel unPersonnel;
        private Materiel unMateriel;
        /// <summary>
        /// Obtient l'id personnel
        /// </summary>
        public int fk_idPerso { get; set; }
        /// <summary>
        /// Obtient l'id du materiel
        /// </summary>
        public int fk_idMateriel { get; set; }
        /// <summary>
        /// Obtient la dateAttribution
        /// </summary>
        public DateTime Dateattribution { get; set; }
        /// <summary>
        /// Obtient le commentaire
        /// </summary>
        public string Commentaireattribution { get; set; }

        public Personnel UnPersonnel
        {
            get
            {
                return unPersonnel;
            }
            set
            {
                unPersonnel = value;
            }
        }

        public Materiel UnMateriel
        {
            get
            {
                return unMateriel;
            }

            set
            {
                unMateriel = value;
            }
        }

        //public string Commentaireattribution { get; set; }

        /// <summary>
        ///Remonte les données
        /// </summary>
        /// <return>Remonte les données dans une ObservableCollection (liste) lesAttribution</return>
        public ObservableCollection<EstAttribue> FindAll()
        {
            ObservableCollection<EstAttribue> lesAttribution = new ObservableCollection<EstAttribue>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idpersonnel, idmateriel, dateattribution, commentaireattribution from est_attribue ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    EstAttribue a = new EstAttribue(int.Parse(row["idpersonnel"].ToString()), int.Parse(row["idmateriel"].ToString()), (DateTime)row["dateattribution"], (string)row["commentaireattribution"]);
                    lesAttribution.Add(a);
                }
            }
            return lesAttribution;
        }

        /// <summary>
        /// Créer une attribution
        /// </summary>
        /// <return>Créer une attribution avec une requete sql</return>
        public void Create()
        {

            String sql = $"insert into est_attribue (idpersonnel, idmateriel, dateattribution, commentaireattribution) values ({this.UnPersonnel.Idpersonnel},{this.UnMateriel.Idmateriel},'{this.Dateattribution.Year}-{this.Dateattribution.Month}-{this.Dateattribution.Day}','{this.Commentaireattribution}');";
            new DataAccess().SetData(sql);
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modifie une attribution
        /// </summary>
        /// <return>Modifie une attribution grace a une requete</return>
        public void Update()
        {
            new DataAccess().SetData($"Update est_attribue set dateattribution = '{this.Dateattribution}', commentaireattribution = '{this.Commentaireattribution}' where idpersonnel = {this.UnPersonnel.Idpersonnel} and idmateriel = {this.UnMateriel.Idmateriel}");
        }

        /// <summary>
        /// Supprime une attribution
        /// </summary>
        /// <return>Supprime une attribution matériel avec une requete sql</return>
        public void Delete()
        {
            DataAccess accesBD = new DataAccess();


            if (accesBD.OpenConnection())
            {
                //MessageBoxResult res = MessageBox.Show($"DELETE from materiel where" + $" idmateriel={this.Idmateriel}" + $" idcategorie={this.Idcategorie}" + $" and nommateriel = '{this.Nommateriel}'" + $" referenceconstructeurmateriel='{this.Referenceconstructeurmateriel}'" + $" codebarreinventaire = '{this.Codebarreinventaire};", "Suppression", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);

                String requete = $"DELETE from est_attribue WHERE idmateriel={this.fk_idMateriel} " + $" and idmateriel={this.fk_idMateriel}" + $" and dateattribution='{this.Dateattribution.ToShortDateString()}';";
                accesBD.SetData(requete);
                accesBD.CloseConnection();

            }
        }

        public ObservableCollection<EstAttribue> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
