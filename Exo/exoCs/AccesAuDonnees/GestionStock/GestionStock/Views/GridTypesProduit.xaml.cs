using GestionStock.Controller;
using GestionStock.Models.Dtos;
using GestionStock.Models;
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

namespace GestionStock.Views
{
    /// <summary>
    /// Logique d'interaction pour GridTypesProduit.xaml
    /// </summary>
    public partial class GridTypesProduit : Window
    {
        private GestionStockDbContext _context;
        private TypesproduitsController _controller;

        public GridTypesProduit(GestionStockDbContext context)
        {
            InitializeComponent();
            _context = context;
            _controller = new TypesproduitsController(_context);

            FillGrid();

        }
        private void FillGrid()
        {
            dtgCentre.ItemsSource = _controller.GetAllTypesproduits();
        }


        private void ButtonAction_Click(object sender, RoutedEventArgs e)
        {
            TypesproduitsDtoOut itemDto;

            if (((Button)sender).Name == "btnAjouter")
            {
                itemDto = new TypesproduitsDtoOut();
            }
            else
            {
                itemDto = (TypesproduitsDtoOut)dtgCentre.SelectedItem;
            }

            Window w = new GestionTypesProduit(itemDto, this, (string)((Button)sender).Content, _controller, _context);
            w.ShowDialog();
            FillGrid();
        }

        private void Row_DoubleClick(object sender, EventArgs e)
        {
            TypesproduitsDtoOut itemDto = (TypesproduitsDtoOut)((DataGridRow)sender).Item;

            Window w = new GestionTypesProduit(itemDto, this, "Modifier", _controller, _context);
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

        private void ButtonGestTpProd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
