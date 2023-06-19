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
            //Filtre qui sert a rechercher une categorie en fonction du nom
            DG_categorie.ItemsSource = applicationData.LesCategorieMateriel;
            CollectionView viewCategorie = (CollectionView)CollectionViewSource.GetDefaultView(DG_categorie.ItemsSource);
            viewCategorie.Filter = CategorieFilter;
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
            //condition  vérification de la texte box 
            if (tbNom.Text == "" || tbNom.Text == " ")
            {
                MessageBox.Show("Champs nom obligatoires", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                tbNom.Text = "";
            }
            else
            {
                CategorieMateriel categorie = new CategorieMateriel(0, tbNom.Text);
                categorie.Create();
                this.applicationData.LesCategorieMateriel.Add(categorie);
                this.DG_categorie.Items.Refresh();                
                tbNom.Text= "";
                MessageBox.Show("Nouvelle catégorie crée", "Validation", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }

        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            WindowModifCategorie modif = new WindowModifCategorie(((CategorieMateriel)DG_categorie.SelectedItem).Idcategorie);
            modif.ShowDialog();



            this.ReloadData();
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
            //Permet de recharger la page apres un clic au moment ou on l'appel  
            applicationData.reloadAppData();
            this.DG_categorie.ItemsSource = applicationData.LesCategorieMateriel;
        }

        private bool CategorieFilter(object item)
        {
            if (String.IsNullOrEmpty(tbNom.Text))
            {
                return true;
            }
            else
            {
                return ((item as CategorieMateriel).Nomcategorie.IndexOf(tbNom.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Le boutton rechercher qui actionne le filtre 
            CollectionViewSource.GetDefaultView(DG_categorie.ItemsSource).Refresh();
            DG_categorie.SelectedIndex = 0;
        }
    }
}
