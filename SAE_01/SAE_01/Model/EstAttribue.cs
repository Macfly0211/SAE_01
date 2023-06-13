using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_01.Model
{
    public class EstAttribue
    {
        public EstAttribue(int idpersonnel, int idmateriel, DateTime dateattribution, string commentaireattribution)
        {
            this.fk_idPerso = idpersonnel;
            this.fk_idMateriel = idmateriel;
            this.Dateattribution = dateattribution;
            this.Commentaireattribution = commentaireattribution;
        }

        public EstAttribue()
        {
            
        }
        private Personnel unPersonnel;
        private Materiel unMateriel;
        public int fk_idPerso { get; set; }
        public int fk_idMateriel { get; set; }
        public DateTime Dateattribution { get; set; }
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

        internal Materiel UnMateriel
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
    }
}
