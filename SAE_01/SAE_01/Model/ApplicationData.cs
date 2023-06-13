using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_01.Model
{
    internal class ApplicationData
    {


        public ObservableCollection<Personnel> LesPersonnel { get; set; }
        public ObservableCollection<Materiel> LesMateriel { get; set; }
        public ObservableCollection<CategorieMateriel> LesCategorie { get; set; }
        public ObservableCollection<EstAttribue> LesAttribution { get; set; }

        public ApplicationData()
        {
            Personnel p = new Personnel();
            LesPersonnel = p.FindAll();

            Materiel m = new Materiel();
            LesMateriel = m.FindAll();

            CategorieMateriel c = new CategorieMateriel();
            LesCategorie = c.FindAll();

            EstAttribue a = new EstAttribue();
            LesAttribution = a.FindAll();
        }

        

        
    }
}
