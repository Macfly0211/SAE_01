using SAE_01;
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
    /// Logique d'interaction pour Materiel.xaml
    /// </summary>
    public partial class Materiel : Window
    {
        


        public Materiel()
        {
            InitializeComponent();
        }

        
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menu = new MainWindow();
            this.Close();
            menu.Show();
        }

        private void MenuCategorie_Click(object sender, RoutedEventArgs e)
        {
            Categorie categorie = new Categorie();
            this.Close();
            categorie.Show();
        }

        private void MenuPersonnel_Click(object sender, RoutedEventArgs e)
        {
            Personnel personnel = new Personnel();
            this.Close();
            personnel.Show();
        }

        private void MenuAttribution_Click(object sender, RoutedEventArgs e)
        {
            Attribution attribution = new Attribution();
            this.Close();
            attribution.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
