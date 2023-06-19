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

        /// <summary>
        /// Bouton qui modifie une catégorie
        /// message box qui explique si il y a un problème ou non
        /// </summary>
        /// <return>modifie une catégorie </return>
        /// <exception cref="ArgumentException"> Si le nom n'est référencié</exception>
        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (tbCategorie.Text == "")
            {
                MessageBox.Show("Champs obligatoires", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                //message d'erreur

            }
            else
            {

                ((CategorieMateriel)applicationData.LesCategorieMateriel.Single(x => x.Idcategorie == this.idCategorie)).Nomcategorie = tbCategorie.Text;
                ((CategorieMateriel)applicationData.LesCategorieMateriel.Single(x => x.Idcategorie == this.idCategorie)).Update();

                this.Close();
            }
        }


        /// <summary>
        /// Bouton qui annule et sort de la page
        /// </summary>
        /// <return>Sort de la page </return>
        private void BtAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
