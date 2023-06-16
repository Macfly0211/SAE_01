using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_01.Model
{
    public class CategorieMateriel : Crud<CategorieMateriel>
    {
        public CategorieMateriel(int idcategorie, string nomcategorie)
        {
            Idcategorie = idcategorie;
            Nomcategorie = nomcategorie;
        }

        public CategorieMateriel()
        {
            
        }

        public int Idcategorie { get; set; }
        public string Nomcategorie { get; set; }

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

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            try
            {
                if (accesBD.OpenConnection())
                {
                    String requete = $"delete from categorie_materiel where" + $"idcategorie={this.Idcategorie}" + $"nomcategorie={this.Nomcategorie};";
                    accesBD.SetData(requete);
                }
            }
            //si exception
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Emprunte exception delete");
            }
        }

        public ObservableCollection<CategorieMateriel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
     
}

