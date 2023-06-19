using SAE_01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class WindowModifMateriel : Window
    {
        int idMateriel;
        public WindowModifMateriel(int idMateriel)
        {

           
            InitializeComponent();
            this.idMateriel = idMateriel;
        }
        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // ferme automatiquement la fenêtre
        }

        /// <summary>
        /// Bouton qui modifie un matériel
        /// message box qui explique si il y a un problème ou non
        /// </summary>
        /// <return>modifie un matériel </return>
        /// <exception cref="ArgumentException"> Si nom, codebarre, refConstructeur vide ou si code barre ou ref constructeur pas au bon format</exception>
        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {


            if (tbNom.Text == "" || tbBarre.Text == "" || tbConstructeur.Text == "")
            {
                MessageBox.Show("Champs obligatoires", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                //message d'erreur

            }
            else if (FormeCodeBarre(tbBarre.Text) == false)
            {
                MessageBox.Show("Forme du code barre : 5 lettres 7 chiffres 3 lettres", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (FormeRefConstructeur(tbConstructeur.Text) == false)
            {
                MessageBox.Show("Forme de la référence constructeur : 1 lettres 1 tiret 3 chiffres 6 lettres ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.idMateriel)).Nommateriel = tbNom.Text;
                ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.idMateriel)).Update();

                ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.idMateriel)).Referenceconstructeurmateriel = tbConstructeur.Text.ToUpper();
                ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.idMateriel)).Update();

                ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.idMateriel)).Codebarreinventaire = tbBarre.Text.ToUpper();
                ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.idMateriel)).Update();

                this.Close();
            }

            /// <summary>
            /// Vérifie que le code barre respecte le regex
            /// </summary>
            /// <return>True si le code barre est correcte au regex </return>
            static bool FormeCodeBarre(string codebarre)
            {
                string reg = @"^[A-Za-z]{5}\d{7}[A-Za-z]{3}$";
                return Regex.IsMatch(codebarre, reg);
            }

            /// <summary>
            /// Vérifie que la ref constructeur respecte le regex
            /// </summary>
            /// <return>True si la ref constructeur est correcte au regex </return>
            static bool FormeRefConstructeur(string refconstructeur)
            {
                string reg2 = @"^[A-Za-z]-\d{3}[A-Za-z]{6}$";
                return Regex.IsMatch(refconstructeur, reg2);
            }
        }
    }
}
