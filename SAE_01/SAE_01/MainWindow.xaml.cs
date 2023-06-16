using SAE_01;
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

            //foreach (CategorieMateriel categorie in applicationData.LesCategorieMateriel)
            //{
            //    lvCategorie.Items.Add(new ListViewItem()
            //    {
            //        Content = categorie.Nomcategorie,
            //        Name = $"categorie{categorie.Idcategorie}"
            //    });
            //}
            //foreach (Personnel personnel in applicationData.LesPersonnel)
            //{
            //    lvCategorie.Items.Add(new ListViewItem()
            //    {
            //        Content = personnel.Nompersonnel,
            //        Name = $"categorie{personnel.Idpersonnel}"

                    
            //    });
            //}
            //foreach (CategorieMateriel categorie in applicationData.LesCategorieMateriel)
            //{
            //    lvCategorie.Items.Add(new ListViewItem()
            //    {
            //        Content = categorie.Nomcategorie,
            //        Name = $"categorie{categorie.Idcategorie}"
            //    });
            //}
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
            new EstAttribue(lvPersonnel.SelectedIndex,lvMateriel.SelectedIndex, DateTime.Parse(tbDate.Text), tbCommentaire.Text).Create();
            this.ReloadData();
            DG_Main.DataContext = applicationData.LesAttribution;
        }


        public void ReloadData()
        {
            applicationData.reloadAppData();
            this.DG_Main.ItemsSource = applicationData.LesAttribution;
        }
    }
}
