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

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
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

        private void BtAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
