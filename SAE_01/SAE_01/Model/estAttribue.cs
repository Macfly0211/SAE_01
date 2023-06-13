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
        public EstAttribue(int idpersonnel, int idmateriel, DateTime date, string commentaireattribution)
        {
            this.Idpersonnel = idpersonnel;
            this.Idmateriel = idmateriel;
            this.date = date;
            this.commentaireattribution = commentaireattribution;
        }

        public EstAttribue()
        {
            
        }

        public int Idpersonnel { get; set; }
        public int Idmateriel { get; set; }
        public DateTime date { get; set; }
        public string commentaireattribution { get; set; }

        public ObservableCollection<EstAttribue> FindAll()
        {
            ObservableCollection<EstAttribue> lesAttribution = new ObservableCollection<EstAttribue>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idcategorie, nomcategorie from personnel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    EstAttribue a = new EstAttribue(int.Parse(row["idpersonnel"].ToString()), int.Parse(row["idmateriel"].ToString()), (DateTime)row["date"], (string)row["commentaireattribution"]);
                    lesAttribution.Add(a);
                }
            }
            return lesAttribution;
        }
    }
}
