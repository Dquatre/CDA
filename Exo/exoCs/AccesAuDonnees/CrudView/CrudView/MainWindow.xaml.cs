using CrudModelControl.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace CrudView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Product> Liste { get; set; } = new List<Product>();
        public bool TxtNameValide { get; set; } = false;
        public bool TxtPriceValide { get; set; } = false;
        public bool TxtQuiatityValide { get; set; } = false;
        public bool ModeModif { get; set; } = false;

        public MainWindow()
        {
            InitializeComponent();
            dgdProd.ItemsSource = CreerListe();
        }

        private List<Product> CreerListe()
        {

            //@"c:\temp\Personne.json"
            Liste = (List<Product>)GestionJson.LireFichierJson(@"c:\temp\Prod.json");
            return Liste;
        }

        private void ButtonValide_Click(object sender, RoutedEventArgs e)
        {
            Product addedProd = new Product();
            addedProd.NameProduct = txtName.Text;
            addedProd.Price = Convert.ToDouble(txtPrix.Text);
            addedProd.Quantity = Convert.ToInt32(txtQuatity.Text);
            if (dpReleseDate.Text != "")
            {
                addedProd.ReleaseDate = Convert.ToDateTime(dpReleseDate.Text);
            }
            Liste.Add(addedProd); 
            GestionJson.EcrireFichierJson(@"c:\temp\Prod.json", Liste);
            dgdProd.ItemsSource = CreerListe();
            btnVal.IsEnabled = false;
            txtName.Text = null; 
            txtPrix.Text = null;
            txtQuatity.Text = null;

        }

        private void Annule_Click(object sender, RoutedEventArgs e)
        {
            btnVal.IsEnabled = false;
            txtName.Text = null;
            txtPrix.Text = null;
            txtQuatity.Text = null;

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(txtName.Text, @"^\w{3,}$"))
            {
                TxtNameValide = true;
                verifChampRemplis();
            }
            else
            {
                TxtNameValide = false;
            }
        }

        private void txtPrix_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(txtPrix.Text, @"^\d+(,\d{1,2})?$"))
            {
                TxtPriceValide = true;
                verifChampRemplis();
            }
            else
            {
                TxtPriceValide = false;
            }
        }

        private void txtQuatity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(txtQuatity.Text, @"^\d{1,10}$"))
            {
                TxtQuiatityValide = true;
                verifChampRemplis();
            }
            else
            {
                TxtQuiatityValide = false;
            }
        }
        private void verifChampRemplis()
        {
            if (TxtNameValide && TxtPriceValide && TxtQuiatityValide)
            {
                btnVal.IsEnabled = true;
            }
            else
            {
                btnVal.IsEnabled = false;
            }
        }

        private void ButtonSuppr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgdProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product prodSelected = (Product)dgdProd.SelectedItem;
            txtName.Text = prodSelected.NameProduct;
            txtPrix.Text = Convert.ToString(prodSelected.Price);
            txtQuatity.Text = Convert.ToString(prodSelected.Quantity);
            dpReleseDate.Text = Convert.ToString(prodSelected.ReleaseDate);
            TxtNameValide = true;
            TxtPriceValide = true;
            TxtQuiatityValide = true;
            ModeModif = true;
        }
    }
}
