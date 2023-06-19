using SAE_01;
using SAE_01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour Materiel.xaml
    /// </summary>
    public partial class WindowMateriel : Window
    {
        


        public WindowMateriel()
        {
            InitializeComponent();
            DG_materiel.ItemsSource = applicationData.LesMateriel;
            CollectionView viewMateriel = (CollectionView)CollectionViewSource.GetDefaultView(DG_materiel.ItemsSource);
            viewMateriel.Filter = MaterielFilter;

        }

        //============MENU============
        //Crée une nouvelle fenêtre et assigne la bonne fenêtre
        //Ferme la fenêtre actuellement ouverte 
        //Ouvre la nouvelle fenetre

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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //BOUTONS

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            

            //condition pour les champs non remplis
            if (tbNomMateriel.Text == null || tbRefConstructeur.Text == null || tbCodeBarre.Text == null || lvCategorie.SelectedItem== null)
            {
                MessageBox.Show("Champs obligatoires", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                //message d'erreur

            }
            else if(FormeCodeBarre(tbCodeBarre.Text) == false)
            {
                MessageBox.Show("Forme du code barre : 5 lettres 7 chiffres 3 lettres", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (FormeRefConstructeur(tbRefConstructeur.Text) == false)
            {
                MessageBox.Show("Forme de la référence constructeur : 1 lettres 1 tiret 3 chiffres 6 lettres ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //crée un nouveau personnel 
                Materiel materiel = new Materiel(0, (CategorieMateriel)lvCategorie.SelectedItem, tbNomMateriel.Text, tbRefConstructeur.Text, tbCodeBarre.Text);
                materiel.Create();
                //ajoute lee nouveau personnel a la liste
                this.applicationData.LesMateriel.Add(materiel);
                this.DG_materiel.Items.Refresh();

                //remet à zéro les champs à remplir
                tbNomMateriel.Text = null;
                tbCodeBarre.Text = null;
                tbRefConstructeur.Text = null;
                //message de confirmation de la création d'un personnel
                MessageBox.Show("Nouveau matériel crée", "Validation", MessageBoxButton.OK, MessageBoxImage.Asterisk);



            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            //vérification de la sélection dans la dataGrid
            if (DG_materiel.SelectedItem == null)
            {
                MessageBox.Show("Erreur ! Selectionner un matériel.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBoxResult res = MessageBox.Show("Attention le matériel sélectionné va être supprimé", "Suppression", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);
                //message d'alerte de la suppression

                //résulatats des boutons de la message box
                switch (res)
                {
                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.OK:
                        foreach (Model.Materiel lemateriel in DG_materiel.SelectedItems)
                        {
                           lemateriel.Delete();
                            //appelle de la donction Delete
                        }
                        this.ReloadData();
                        break;
                    case MessageBoxResult.No:
                        break;

                }
                this.ReloadData();
            }

        }

        //ReloadData qui appelle ApplicationData
        public void ReloadData()
        {
            applicationData.reloadAppData();
            this.DG_materiel.ItemsSource = applicationData.LesMateriel;
        }


        //filtre des personnels 
        private bool MaterielFilter(object item)
        {
            if (String.IsNullOrEmpty(tbNomMateriel.Text))
            {
                return true;
            }
            else
            {
                return ((item as Materiel).Nommateriel.IndexOf(tbNomMateriel.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

          
        }



        //bouton de recherche
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            CollectionViewSource.GetDefaultView(DG_materiel.ItemsSource).Refresh();
            DG_materiel.SelectedIndex = 0;
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (DG_materiel.SelectedItem == null)
            {
                MessageBox.Show("Erreur ! Selectionner un matériel.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                //message d'erreur
            }
            else
            {

                WindowModifMateriel modif = new WindowModifMateriel(((Materiel)DG_materiel.SelectedItem).Idmateriel);
                modif.ShowDialog();



                this.ReloadData();
            }
        }

        static bool FormeCodeBarre(string codebarre)
        {
            string reg = @"^[A-Za-z]{5}\d{7}[A-Za-z]{3}$";
            return Regex.IsMatch(codebarre, reg);
        }
       
        static bool FormeRefConstructeur(string refconstructeur)
        {
            string reg2 = @"^[A-Za-z]-\d{3}[A-Za-z]{6}$";
            return Regex.IsMatch(refconstructeur, reg2);
        }
    }
}
