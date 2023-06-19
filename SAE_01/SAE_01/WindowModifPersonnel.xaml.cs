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
using System.Windows.Shapes;

namespace SAE_01
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class WindowModifPersonnel : Window
    {
        int idPersonnel;
        public WindowModifPersonnel(int idPersonnel)
        {
            InitializeComponent();
            this.idPersonnel = idPersonnel;
        }

        /// <summary>
        /// Bouton qui modifie un personnel
        /// message box qui explique si il y a un problème ou non
        /// </summary>
        /// <return>modifie un personnel </return>
        /// <exception cref="ArgumentException"> Si nom, prenom, mail vide </exception>
        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (tbNom.Text == "" || tbPrenom.Text == "" || tbMail.Text == "")
            {
                MessageBox.Show("Champs obligatoires", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                //message d'erreur

            }
            else if (tbMail.Text.Length > 30)
            {
                MessageBox.Show("30 caractères maximum pour l'email", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {

                ((Personnel)applicationData.LesPersonnel.Single(x => x.Idpersonnel == this.idPersonnel)).Nompersonnel = tbNom.Text;
                ((Personnel)applicationData.LesPersonnel.Single(x => x.Idpersonnel == this.idPersonnel)).Update();

                ((Personnel)applicationData.LesPersonnel.Single(x => x.Idpersonnel == this.idPersonnel)).Prenompersonnel = tbPrenom.Text;
                ((Personnel)applicationData.LesPersonnel.Single(x => x.Idpersonnel == this.idPersonnel)).Update();

                ((Personnel)applicationData.LesPersonnel.Single(x => x.Idpersonnel == this.idPersonnel)).Emailpersonnel = tbMail.Text;
                ((Personnel)applicationData.LesPersonnel.Single(x => x.Idpersonnel == this.idPersonnel)).Update();

                this.Close();
            }
        }

        /// <summary>
        /// annule et ferme la fenetre
        /// </summary>
        /// <return>ferme la fenetre</return>
        private void BtAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
