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

        public ApplicationData()
        {
            Personnel p = new Personnel();
            LesPersonnel = p.FindAll();
        }
    }
}
