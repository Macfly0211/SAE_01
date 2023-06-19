using SAE_01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.idMateriel)).Nommateriel = tbNom.Text;
            ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.idMateriel)).Update();

            ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.idMateriel)).Referenceconstructeurmateriel = tbConstructeur.Text;
            ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.idMateriel)).Update();

            ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.idMateriel)).Codebarreinventaire = tbBarre.Text;
            ((Materiel)applicationData.LesMateriel.Single(x => x.Idmateriel == this.idMateriel)).Update();

            this.Close();
            


        }
    }
}
