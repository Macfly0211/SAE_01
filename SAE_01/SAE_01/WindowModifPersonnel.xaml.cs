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

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            ((Personnel)applicationData.LesPersonnel.Single(x => x.Idpersonnel == this.idPersonnel)).Nompersonnel = tbNom.Text;
            ((Personnel)applicationData.LesPersonnel.Single(x => x.Idpersonnel == this.idPersonnel)).Update();

            ((Personnel)applicationData.LesPersonnel.Single(x => x.Idpersonnel == this.idPersonnel)).Prenompersonnel = tbPrenom.Text;
            ((Personnel)applicationData.LesPersonnel.Single(x => x.Idpersonnel == this.idPersonnel)).Update();

            ((Personnel)applicationData.LesPersonnel.Single(x => x.Idpersonnel == this.idPersonnel)).Emailpersonnel = tbMail.Text;
            ((Personnel)applicationData.LesPersonnel.Single(x => x.Idpersonnel == this.idPersonnel)).Update();

            this.Close();
        }

        private void BtAnnuler_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
