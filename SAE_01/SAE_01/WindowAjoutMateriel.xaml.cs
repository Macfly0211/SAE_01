﻿using SAE_01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SAE_01
{
    /// <summary>
    /// Logique d'interaction pour WindowAjoutMateriel.xaml
    /// </summary>
    public enum Mode { Insert, Update };
    public partial class WindowAjoutMateriel : Window
    {
        int IdMateriel;
        public WindowAjoutMateriel(int idMateriel, Materiel cons, Mode mode)
        {

            this.IdMateriel = idMateriel;
            this.DataContext = cons;
            InitializeComponent();
            if (mode == Mode.Update)
            {
                btCreer.Content = "Modifier";
                this.Title = "Modification Personnel";
            }
            else if (mode == Mode.Insert)
            {
                btCreer.Content = "Ajouter";
                this.Title = "Ajout Personnel";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // ferme automatiquement la fenêtre
        }

        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.IdMateriel)).Nommateriel = tbNom.Text;
            ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.IdMateriel)).Update();

            ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.IdMateriel)).Referenceconstructeurmateriel = tbConstructeur.Text;
            ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.IdMateriel)).Update();

            ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.IdMateriel)).Codebarreinventaire = tbBarre.Text;
            ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.IdMateriel)).Update();


        }
    }
}
