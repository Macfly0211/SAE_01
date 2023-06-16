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

        private void MenuMateriel_Click(object sender, RoutedEventArgs e)
        {
            Materiel materiel = new Materiel();
            this.Close();
            materiel.Show();
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

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menu = new MainWindow();
            this.Close();
            menu.Show();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string nom = tbNom.Text;
            DataAccess accesBD = new DataAccess();
            String requete = "insert into categorie_materiel (nomcategorie) values ("+ nom +");";
            accesBD.SetData(requete);
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (DG_categorie.SelectedItem == null)
            {
                MessageBox.Show("Erreur ! Selectionner une categorie.");
            }
            else
            {
                //MessageBox.Show("Voulez vous supprimer " + DG_categorie.SelectedItem.ToString() + " ?");
                MessageBoxResult res = MessageBox.Show("Attention la catégorie va être supprimé", "Suppression", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);
                
                switch (res)
                {
                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.OK:
                        foreach (CategorieMateriel categorieMateriel in DG_categorie.SelectedItems)
                        {
                            categorieMateriel.Delete();
                        }
                        this.ReloadData();
                        break;
                    case MessageBoxResult.No:
                        break;

                }
            }
            
        }

        public void ReloadData ()
        {
            applicationData.reloadAppData();
            this.DG_categorie.ItemsSource = applicationData.LesCategorieMateriel;
        }

        
    }
}
