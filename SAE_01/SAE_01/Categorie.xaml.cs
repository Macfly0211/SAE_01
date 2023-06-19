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

        //============MENU============
        //Crée une nouvelle fenêtre et assigne la bonne fenêtre
        //Ferme la fenêtre actuellement ouverte 
        //Ouvre la nouvelle fenetre

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
        /// <summary>
        /// Bouton qui ajoute una catégorie
        /// message box qui explique si il y a un problème ou non
        /// </summary>
        /// <return>ajoute une catégorie matériel </return>
        /// <exception cref="ArgumentException"> Si le nom n'est pas renseigné</exception>
        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            //condition  vérification de la texte box 
            if (tbNom.Text == "")
            {
                MessageBox.Show("Champs nom obligatoires", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                tbNom.Text = null;
            }
            else
            {
                CategorieMateriel categorie = new CategorieMateriel(0, tbNom.Text);
                categorie.Create();
                this.applicationData.LesCategorieMateriel.Add(categorie);
                this.DG_categorie.Items.Refresh();                
                tbNom.Text= null;
                MessageBox.Show("Nouvelle catégorie crée", "Validation", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }

        }

        /// <summary>
        /// Bouton modifie una catégorie
        /// message box qui explique si il y a un problème ou non
        /// </summary>
        /// <return>modifie une catégorie matériel </return>
        /// <exception cref="ArgumentException"> Si aucune catégorie n'est sélectionné</exception>
        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (DG_categorie.SelectedItem == null)
            {
                MessageBox.Show("Erreur ! Selectionner une catégorie.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                //message d'erreur
            }
            else
            {

                WindowModifCategorie modif = new WindowModifCategorie(((CategorieMateriel)DG_categorie.SelectedItem).Idcategorie);
                modif.ShowDialog();



                this.ReloadData();
            }
        }

        /// <summary>
        /// Bouton qui supprime una catégorie
        /// message box qui explique si il y a un problème ou non
        /// </summary>
        /// <return>supprime une catégorie matériel </return>
        /// <exception cref="ArgumentException"> Si aucune catégorie n'est sélectionné</exception>
        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            //vérification sélection dans la datagrid
            if (DG_categorie.SelectedItem == null)
            {
                MessageBox.Show("Erreur ! Selectionner une categorie.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        /// <summary>
        /// Reload appelle Application data pour reload les données
        /// </summary>
        /// <return>reload les données</return>
        public void ReloadData ()
        {
            //Permet de recharger la page apres un clic au moment ou on l'appel  
            applicationData.reloadAppData();
            this.DG_categorie.ItemsSource = applicationData.LesCategorieMateriel;
        }

        /// <summary>
        /// filtre des données
        /// </summary>
        /// <return>flitre les données </return>
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
