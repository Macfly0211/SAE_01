﻿using SAE_01;
using SAE_01.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logique d'interaction pour Personnel.xaml
    /// </summary>
    public partial class WindowPersonnel : Window
    {
        //============MENU============
        //Crée une nouvelle fenêtre et assigne la bonne fenêtre
        //Ferme la fenêtre actuellement ouverte 
        //Ouvre la nouvelle fenetre
        public WindowPersonnel()
        {
            InitializeComponent();

            DG_personnel.ItemsSource = applicationData.LesPersonnel;
            CollectionView viewPersonnel = (CollectionView)CollectionViewSource.GetDefaultView(DG_personnel.ItemsSource);
            viewPersonnel.Filter = PersonnelFilter;
            
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

        private void MenuMateriel_Click(object sender, RoutedEventArgs e)
        {
            WindowMateriel materiel = new WindowMateriel();
            this.Close();
            materiel.Show();
        }

        private void MenuAttribution_Click(object sender, RoutedEventArgs e)
        {
            Attribution attribution = new Attribution();
            this.Close();
            attribution.Show();
        }

        //BOUTON
        /// <summary>
        /// Bouton qui ajoute un personnel
        /// message box qui explique si il y a un problème ou non
        /// </summary>
        /// <return>ajoute une personnel </return>
        /// <exception cref="ArgumentException"> Si le nom, prenom, mail n'est pas renseigné</exception>
        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            //condition pour les champs non remplis
            if (tbNom.Text == "" || tbPrenom.Text == "" || tbEmail.Text == "")
            {
                MessageBox.Show("Champs obligatoires", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                //message d'erreur

            }
            else if(tbEmail.Text.Length > 30)
            {
                MessageBox.Show("30 caractères maximum pour l'email", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                //crée un nouveau personnel 
                Personnel personnel = new Personnel(0, tbEmail.Text, tbNom.Text, tbPrenom.Text);
                personnel.Create();
                //ajoute lee nouveau personnel a la liste
                this.applicationData.LesPersonnel.Add(personnel);
                this.DG_personnel.Items.Refresh();
                //remet à zéro les champs à remplir
                tbPrenom.Text = null;
                tbNom.Text= null;
                tbEmail.Text = null;
                //message de confirmation de la création d'un personnel
                MessageBox.Show("Nouveau personnel crée", "Validation", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }
        }

        /// <summary>
        /// Reload appelle Application data pour reload les données
        /// </summary>
        /// <return>reload les données</return>
        public void ReloadData()
        {
            applicationData.reloadAppData();
            this.DG_personnel.ItemsSource = applicationData.LesPersonnel;
        }

        /// <summary>
        /// Bouton qui supprime un personnel
        /// message box qui explique si il y a un problème ou non
        /// </summary>
        /// <return>supprime un personnel </return>
        /// <exception cref="ArgumentException"> Si aucun personnel n'est sélectionné</exception>
        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            //vérification de la sélection dans la dataGrid
            if (DG_personnel.SelectedItem == null)
            {
                MessageBox.Show("Erreur ! Selectionner un personnel.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                //message d'erreur
            }
            else
            {
                MessageBoxResult res = MessageBox.Show("Attention le personnel sélectionné va être supprimé", "Suppression", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);
                //message d'alerte de la suppression

                //résulatats des boutons de la message box
                switch (res)
                {
                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.OK:
                        foreach (Personnel lespersonne in DG_personnel.SelectedItems)
                        {
                            lespersonne.Delete();
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

        /// <summary>
        /// Bouton modifie un personnel
        /// message box qui explique si il y a un problème ou non
        /// </summary>
        /// <return>modifie un personnel </return>
        /// <exception cref="ArgumentException"> Si aucun personnel n'est sélectionné</exception>
        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (DG_personnel.SelectedItem == null)
            {
                MessageBox.Show("Erreur ! Selectionner un personnel.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                //message d'erreur
            }
            else
            {
                WindowModifPersonnel modif = new WindowModifPersonnel(((Personnel)DG_personnel.SelectedItem).Idpersonnel);
                modif.ShowDialog();
                this.ReloadData();

            }
        }

        /// <summary>
        /// filtre des données
        /// </summary>
        /// <return>flitre les données </return>
        private bool PersonnelFilter(object item)
        {
            if (String.IsNullOrEmpty(tbRechercheEmail.Text))
            {
                return true;
            }
            else
            {
                return ((item as Personnel).Nompersonnel.IndexOf(tbRechercheEmail.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }

        /// <summary>
        /// Bouton de recherche
        /// </summary>
        /// <return>recherche les données </return>
        private void btRechercher_Click_1(object sender, RoutedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(DG_personnel.ItemsSource).Refresh();
            DG_personnel.SelectedIndex = 0;
        }

        
    }
}
