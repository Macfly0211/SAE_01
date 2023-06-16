using SAE_01;
using SAE_01.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace SAE_01
{
    /// <summary>
    /// Logique d'interaction pour Categorie.xaml
    /// </summary>
    public partial class Categorie : Window
    {
        public Categorie()
        {
            InitializeComponent();
            
        }

        //MENU

        private void MenuMateriel_Click(object sender, RoutedEventArgs e)
        {
            WindowMateriel materiel = new WindowMateriel();
            this.Close();
            materiel.Show();
        }

        private void MenuPersonnel_Click(object sender, RoutedEventArgs e)
        {
            WindowPersonnel personnel = new WindowPersonnel();
            this.Close();
            personnel.Show();
        }

        private void MenuAttribution_Click(object sender, RoutedEventArgs e)
        {
            Attribution attribution = new Attribution();
            this.Close();
            attribution.Show();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menu = new MainWindow();
            this.Close();
            menu.Show();
        }

        //BOUTON

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (tbNom.Text == "" || tbNom.Text == " ")
            {
                MessageBox.Show("Champs nom obligatoires", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                tbNom.Text = "";
            }
            else
            {
                new CategorieMateriel(0, tbNom.Text).Create();
                this.ReloadData();
                tbNom.Text= "";
                MessageBox.Show("Nouvelle catégorie crée", "Validation", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }

        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            //vérification sélection dans la datagrid
            if (DG_categorie.SelectedItem == null)
            {
                MessageBox.Show("Erreur ! Selectionner une categorie.");
            }
            else
            {
                MessageBoxResult res = MessageBox.Show("Attention la catégorie sélectionné va être supprimé", "Suppression", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);
                //message de confirmation de la suppression

                //Différent cas de réponse
                switch (res)
                {
                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.OK:
                        foreach (CategorieMateriel categorieMateriel in DG_categorie.SelectedItems)
                        {
                            categorieMateriel.Delete();
                            //appelle à la fonction Delete
                        }
                        this.ReloadData();
                        break;
                    case MessageBoxResult.No:
                        break;

                }
                this.ReloadData();
            }
            
        }

        //focntion reload qui appelle ApplicationData
        public void ReloadData ()
        {
            applicationData.reloadAppData();
            this.DG_categorie.ItemsSource = applicationData.LesCategorieMateriel;
        }

        
    }
}
