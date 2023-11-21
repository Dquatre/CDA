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

namespace Crud
{
    /// <summary>
    /// Logique d'interaction pour FenetreGestion.xaml
    /// </summary>
    public partial class FenetreGestion : Window
    {
        public MainWindow Mw { get; set; }
        public List<Produit> Liste {  get; set; }
        public FenetreGestion(MainWindow w, List<Produit> liste)
        {
            Mw = w;
            Liste = liste;
            InitializeComponent();
        }

        private void ButtonValide_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != null && txtPrix.Text != null && cbCat.Text != null && txtStock != null)
            {
                Liste.Add(new Produit(Liste.Last().IdProduit + 1, txtName.Text, Convert.ToDouble(txtPrix.Text), cbCat.Text, Convert.ToInt32(txtStock.Text)));
                Mw.dgdProd.ItemsSource = Liste;
                Close();
            }
            
            
        }
    }
}
