﻿using System;
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
        //constructeur

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

        public Materiel(int idmateriel, CategorieMateriel idcategorie, string nommateriel, string referenceconstructeurmateriel, string codebarreinventaire)
        {
            this.Idmateriel = idmateriel;
            this.UneCategorie = idcategorie;
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

        //FindAll = remonte les données
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

        //Delete = méthode de suppression de personnels
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

        //Create = méthode de création de nouveau personnels
        public void Create()
        {
            new DataAccess().SetData($"insert into materiel (idcategorie, nommateriel, referenceconstructeurmateriel, codebarreinventaire) values ({this.UneCategorie.Idcategorie}, '{this.Nommateriel}','{this.Referenceconstructeurmateriel}','{this.Codebarreinventaire}');");
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

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
