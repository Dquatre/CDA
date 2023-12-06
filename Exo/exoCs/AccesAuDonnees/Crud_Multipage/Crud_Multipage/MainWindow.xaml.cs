using Crud_Multipage.Models.Data;
using Crud_Multipage.Models.Services;
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

namespace Crud_Multipage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillGrid();
        }

        private void FillGrid()
        {
            dtgProd.ItemsSource = ProductsServices.GetAllProducts();
        }

        private void btnActionClick(object sender, EventArgs e)
        {
            Product item;
            if (((Button)sender).Name == "btnAjouter")
            {
                item = new Product();
            }
            else
            {
                item = (Product)dtgProd.SelectedItem;
            }

            Window w = new Gestion(item, this, (string)((Button)sender).Content);
            w.ShowDialog();
            FillGrid();
        }
        private void Row_DoubleClick(object sender, EventArgs e)
        {
            Product item = (Product)((DataGridRow)sender).Item;

            Window w = new Gestion(item, this, "Modifier");
            w.ShowDialog();
            FillGrid();
        }
        private void ActiveButton(object sender, EventArgs e)
        {
            btnSuppr.IsEnabled = true;
        }
        private void DesactiveButton(object sender, EventArgs e)
        {
            btnSuppr.IsEnabled = false;
        }
    }
}
