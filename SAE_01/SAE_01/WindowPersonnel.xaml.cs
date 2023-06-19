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

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            //condition pour les champs non remplis
            if (tbNom.Text == "" || tbPrenom.Text == "" || tbEmail.Text == "")
            {
                MessageBox.Show("Champs obligatoires", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                //message d'erreur

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

        public void ReloadData()
        {
            applicationData.reloadAppData();
            this.DG_personnel.ItemsSource = applicationData.LesPersonnel;
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            //vérification de la sélection dans la dataGrid
            if (DG_personnel.SelectedItem == null)
            {
                MessageBox.Show("Erreur ! Selectionner un personnel.");
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

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (DG_personnel.SelectedItem == null)
            {
                MessageBox.Show("Erreur ! Selectionner un personnel.");
                //message d'erreur
            }
            else
            {
                WindowModifPersonnel modif = new WindowModifPersonnel(((Personnel)DG_personnel.SelectedItem).Idpersonnel);
                modif.ShowDialog();
                this.ReloadData();

            }
        }

        //filtre des personnels 
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

        //bouton de recherche
        private void btRechercher_Click_1(object sender, RoutedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(DG_personnel.ItemsSource).Refresh();
            DG_personnel.SelectedIndex = 0;
        }

        
    }
}
