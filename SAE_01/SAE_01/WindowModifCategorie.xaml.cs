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
    /// Logique d'interaction pour WindowModifCategorie.xaml
    /// </summary>
    public partial class WindowModifCategorie : Window
    {
        int idCategorie;
        public WindowModifCategorie(int idCategorie)
        {
            InitializeComponent();
            this.idCategorie = idCategorie;
        }

        private void btAnnuler_Click()
        {

        }

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            ((CategorieMateriel)applicationData.LesCategorieMateriel.Single(x => x.Idcategorie == this.idCategorie)).Nomcategorie = tbCategorie.Text;
            ((CategorieMateriel)applicationData.LesCategorieMateriel.Single(x => x.Idcategorie == this.idCategorie)).Update();

            this.Close();
        }
    }
}
