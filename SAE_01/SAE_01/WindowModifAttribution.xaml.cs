using System;
using SAE_01.Model;
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
    /// Logique d'interaction pour WindowModifAttribution.xaml
    /// </summary>
    public partial class WindowModifAttribution : Window
    {
        int idMateriel;
        int idPersonnel;
        public WindowModifAttribution(int idMateriel, int idPersonnel)
        {
            InitializeComponent();
            this.idMateriel = idMateriel;
            this.idPersonnel = idPersonnel;
        }

        /// <summary>
        /// Bouton qui modifie une attribution
        /// message box qui explique si il y a un problème ou non
        /// </summary>
        /// <return>modifie une attribution </return>
        /// <exception cref="ArgumentException"> Si la date est vide</exception>
        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {

            ((EstAttribue)applicationData.LesAttribution.Single(x => x.UnMateriel.Idmateriel == this.idMateriel && x.UnPersonnel.Idpersonnel == this.idPersonnel)).Dateattribution = DateTime.Parse(dpDate.SelectedDate.ToString());
            ((EstAttribue)applicationData.LesAttribution.Single(x => x.UnMateriel.Idmateriel == this.idMateriel && x.UnPersonnel.Idpersonnel == this.idPersonnel)).Update();

            ((EstAttribue)applicationData.LesAttribution.Single(x => x.UnMateriel.Idmateriel == this.idMateriel && x.UnPersonnel.Idpersonnel == this.idPersonnel)).Commentaireattribution = tbCommentaire.Text;
            ((EstAttribue)applicationData.LesAttribution.Single(x => x.UnMateriel.Idmateriel == this.idMateriel && x.UnPersonnel.Idpersonnel == this.idPersonnel)).Update();

            if (dpDate.Text == "" )
            {
                MessageBox.Show("Date obligatoires", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                //message d'erreur

            }
            else
            {


                ((EstAttribue)applicationData.LesAttribution.Single(x => x.UnMateriel.Idmateriel == this.idMateriel && x.UnPersonnel.Idpersonnel == this.idPersonnel)).Dateattribution = DateTime.Parse(dpDate.SelectedDate.ToString());
                ((EstAttribue)applicationData.LesAttribution.Single(x => x.UnMateriel.Idmateriel == this.idMateriel && x.UnPersonnel.Idpersonnel == this.idPersonnel)).Update();

                ((EstAttribue)applicationData.LesAttribution.Single(x => x.UnMateriel.Idmateriel == this.idMateriel && x.UnPersonnel.Idpersonnel == this.idPersonnel)).Commentaireattribution = tbCommentaire.Text;
                ((EstAttribue)applicationData.LesAttribution.Single(x => x.UnMateriel.Idmateriel == this.idMateriel && x.UnPersonnel.Idpersonnel == this.idPersonnel)).Update();

                this.Close();
            }
        }

        /// <summary>
        /// Bouton qui annule et sort de la page
        /// </summary>
        /// <return>sort de la page </return>
        private void BtAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
