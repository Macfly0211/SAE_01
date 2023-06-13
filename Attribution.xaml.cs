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

namespace WpfSAE01
{
    /// <summary>
    /// Logique d'interaction pour Attribution.xaml
    /// </summary>
    public partial class Attribution : Window
    {
        public Attribution()
        {
            InitializeComponent();
        }

        private void MenuCategorie_Click(object sender, RoutedEventArgs e)
        {
            Categorie categorie = new Categorie();
            this.Close();
            categorie.Show();

        }

        private void MenuMateriel_Click(object sender, RoutedEventArgs e)
        {
            Materiel materiel = new Materiel();
            this.Close();
            materiel.Show();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menu = new MainWindow();
            this.Close();
            menu.Show();
        }

        private void MenuPersonnel_Click(object sender, RoutedEventArgs e)
        {
            Personnel personnel = new Personnel();
            this.Close();
            personnel.Show();
        }
    }
}
