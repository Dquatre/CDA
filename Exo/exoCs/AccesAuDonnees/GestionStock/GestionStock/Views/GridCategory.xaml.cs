using GestionStock.Controller;
using GestionStock.Models;
using GestionStock.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    /// Logique d'interaction pour GridCategory.xaml
    /// </summary>
    public partial class GridCategory : Window
    {
        private GestionStockDbContext _context;
        private CategoriesController _controller;

        public GridCategory(GestionStockDbContext context)
        {
            InitializeComponent();
            _context = context;
            _controller = new CategoriesController(_context);

            FillGrid();

        }
        private void FillGrid()
        {
            dtgCentre.ItemsSource = _controller.GetAllCategories();
        }


        private void ButtonAction_Click(object sender, RoutedEventArgs e)
        {
            CategoriesDtoOut itemDto;

            if (((Button)sender).Name == "btnAjouter")
            {
                itemDto = new CategoriesDtoOut();
            }
            else
            {
                itemDto = (CategoriesDtoOut)dtgCentre.SelectedItem;
            }

            Window w = new GestionCategory(itemDto, this, (string)((Button)sender).Content, _controller, _context);
            w.ShowDialog();
            FillGrid();
        }

        private void Row_DoubleClick(object sender, EventArgs e)
        {
            CategoriesDtoOut itemDto = (CategoriesDtoOut)((DataGridRow)sender).Item;

            Window w = new GestionCategory(itemDto, this, "Modifier", _controller,_context);
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
