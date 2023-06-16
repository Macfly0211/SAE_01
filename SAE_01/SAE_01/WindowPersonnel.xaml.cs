using SAE_01;
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
        public WindowPersonnel()
        {
            InitializeComponent();
            
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

        

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            new Personnel(0, tbEmail.Text, tbNom.Text, tbPrenom.Text).Create();
            this.ReloadData();
        }

        public void ReloadData()
        {
            applicationData.reloadAppData();
            this.DG_personnel.ItemsSource = applicationData.LesPersonnel;
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {

            if (DG_personnel.SelectedItem == null)
            {
                MessageBox.Show("Erreur ! Selectionner un personnel.");
            }
            else
            {
                MessageBoxResult res = MessageBox.Show("Attention le personnel va être supprimé", "Suppression", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);

                switch (res)
                {
                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.OK:
                        foreach (Personnel lespersonne in DG_personnel.SelectedItems)
                        {
                            lespersonne.Delete();
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

            WindowAjoutMateriel winAjoutMateriel = new WindowAjoutMateriel((Materiel)DG_personnel.SelectedItem, Mode.Update);
            winAjoutMateriel.Owner = this;

            bool reponse = (bool)winAjoutMateriel.ShowDialog();
            if (reponse == true)
            {
                DG_personnel.Items.Refresh();
            }
        }

        private void DG_personnel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            tbEmail.Text = this.DG_personnel.SelectedItem.ToString();

           


        }
    }
}
