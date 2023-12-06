using Crud_Multipage.Models.Data;
using Crud_Multipage.Models.Services;
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
using System.Windows.Shapes;

namespace Crud_Multipage
{
    /// <summary>
    /// Logique d'interaction pour Gestion.xaml
    /// </summary>
    public partial class Gestion : Window
    {
        public bool TxtNameValide { get; set; } = false;
        public bool TxtPriceValide { get; set; } = false;
        public bool TxtQuiatityValide { get; set; } = false;

        public string Mode { get; set; }

        public Gestion()
        {
            
        }

        public Gestion(Product p, MainWindow mainWindow, string mode)
        {
            InitializeComponent();
            Mode = mode;
            btnVal.Content = Mode;
            RemplissageChamp(p);
        }

        public void RemplissageChamp(Product p)
        {
            if (Mode != "Ajouter")
            {
                idProduct.Content = p.IdProduct.ToString();
                txtName.Text = p.NameProduct;
                txtPrice.Text = p.Price.ToString();
                txtQuatity.Text = p.Quantity.ToString();
            }
            else
            {
                btnVal.IsEnabled = false;
                idProduct.Content = "0";
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(txtName.Text, @"^\w{3,}$"))
            {
                TxtNameValide = true;
            }
            else
            {
                TxtNameValide = false;
            }
            verifChampRemplis();
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(txtPrice.Text, @"^\d+(,\d{1,2})?$"))
            {
                TxtPriceValide = true;
            }
            else
            {
                TxtPriceValide = false;
            }
            verifChampRemplis();
        }

        private void txtQuatity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(txtQuatity.Text, @"^\d{1,10}$"))
            {
                TxtQuiatityValide = true;
            }
            else
            {
                TxtQuiatityValide = false;
            }
            verifChampRemplis();
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

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product(Int32.Parse((string)idProduct.Content), txtName.Text, Double.Parse(txtPrice.Text), Int32.Parse(txtQuatity.Text) , Int32.Parse(cbxCat.Text));
            switch (Mode)
            {
                case "Ajouter": ProductsServices.AddProduct(p); break;
                case "Modifier": ProductsServices.UpdateProduct(p); break;
                case "Supprimer": ProductsServices.DeleteProduct(p); break;
            }
            this.Close();
        }
        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
