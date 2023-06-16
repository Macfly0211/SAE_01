using SAE_01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SAE_01
{
    /// <summary>
    /// Logique d'interaction pour WindowAjoutMateriel.xaml
    /// </summary>
    public enum Mode { Insert, Update };
    public partial class WindowAjoutMateriel : Window
    {
        public WindowAjoutMateriel(Materiel cons, Mode mode)
        {

            this.DataContext = cons;
            InitializeComponent();
            if (mode == Mode.Update)
            {
                btCreer.Content = "Modifier";
                this.Title = "Modification concessionnaire";
            }
            else if (mode == Mode.Insert)
            {
                btCreer.Content = "Ajouter";
                this.Title = "Ajout concessionnaire";
            }
        }
    }
}
