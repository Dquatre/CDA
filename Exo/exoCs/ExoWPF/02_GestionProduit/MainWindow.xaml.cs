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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _02_GestionProduit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Produit> produit = new List<Produit>();
            produit.Add(new Produit(1,"TV 4K","TV","Multimedia"));
            produit.Add(new Produit(2,"Casque Audio 3D", "Casque Audio", "Multimedia"));
            produit.Add(new Produit(5,"Kaiser","Pain","Boulangerie"));
            produit.Add(new Produit(8,"Reeses pieces", "Confiserie", "Confiserie"));
            produit.Add(new Produit(9,"MnM", "Confiserie", "Confiserie"));
            listProduit.ItemsSource = produit;
            
        }
    }
}
