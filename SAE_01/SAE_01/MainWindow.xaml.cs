﻿using SAE_01;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //foreach (Materiel materiel in applicationData.LesMateriel)
            //{
            //    lvMateriel.Items.Add(new ListViewItem()
            //    {
            //        Content = materiel.Nommateriel,
            //        Name = $"materiel{materiel.Idmateriel}"

            //    });
            //}
            //foreach (Personnel personnel in applicationData.LesPersonnel)
            //{
            //    lvPersonnel.Items.Add(new ListViewItem()
            //    {
            //        Content = personnel.Nompersonnel,
            //        Name = $"personnel{personnel.Idpersonnel}"



            //    });
            //}
            
        }

        //============MENU============
        //Crée une nouvelle fenêtre et assigne la bonne fenêtre
        //Ferme la fenêtre actuellement ouverte 
        //Ouvre la nouvelle fenetre
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

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            //Verification des champs non vide
            if (dpDate.Text == null || lvPersonnel.SelectedItem == null || lvMateriel.SelectedItem == null || lvCategorie == null)
            {
                MessageBox.Show("Champs obligatoires", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                EstAttribue attribution =  new EstAttribue((Personnel)lvPersonnel.SelectedItem, (Materiel)lvMateriel.SelectedItem, (DateTime)dpDate.SelectedDate, tbCommentaire.Text);
                attribution.Create();
                this.applicationData.LesAttribution.Add(attribution);
                this.DG_Main.Items.Refresh();
                MessageBox.Show("Nouvelle attribution créée", "Attribution", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                lvPersonnel.SelectedItem = null;
                lvMateriel.SelectedItem = null;
                lvCategorie.SelectedItem = null;
                dpDate.Text= null;
                tbCommentaire.Text= null;

            }
        }


        public void ReloadData()
        {
            applicationData.reloadAppData();
            this.DG_Main.ItemsSource = applicationData.LesAttribution;
        }

        private void btnSupp_Click(object sender, RoutedEventArgs e)
        {
            //Verification de la selection pour supprimer 
            if (DG_Main.SelectedItem == null)
            {
                MessageBox.Show("Erreur ! Selectionner une attribution.");
            }
            else
            {
                MessageBoxResult res = MessageBox.Show("Attention l'attribution sélectionné va être supprimé", "Suppression", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);

                switch (res)
                {
                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.OK:
                        foreach (EstAttribue latribution in DG_Main.SelectedItems)
                        {
                            latribution.Delete();
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


            if (DG_Main.SelectedItem == null)
            {
                MessageBox.Show("Erreur ! Selectionner une catégorie.");
                //message d'erreur
            }
            else
            {

                WindowModifAttribution modif = new WindowModifAttribution(((EstAttribue)DG_Main.SelectedItem).fk_idMateriel,((EstAttribue)DG_Main.SelectedItem).fk_idPerso);
                modif.ShowDialog();



                this.ReloadData();
            }
        }
    }
}
