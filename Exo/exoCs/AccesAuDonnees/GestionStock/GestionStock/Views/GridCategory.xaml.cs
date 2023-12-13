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
        private TypesproduitsController _tpController;

        public TypesproduitsDtoOut TypesproduitsDtoOut { get; set; } = null!;
        public GridCategory(GestionStockDbContext context)
        {
            InitializeComponent();
            _context = context;
            _controller = new CategoriesController(_context);
            _tpController = new TypesproduitsController(context);
            cbTypeProduit.SelectedValuePath = "Key";
            cbTypeProduit.DisplayMemberPath = "Value";
            foreach (var item in _tpController.GetAllTypesproduits())
            {
                cbTypeProduit.Items.Add(new KeyValuePair<int, string>(item.IdTypeProduit, item.LibelleTypeProduit));
            }
            FillGrid();
        }

        private void FillGrid()
        {
            if (TypesproduitsDtoOut == null)
            {
                dtgCentre.ItemsSource = _controller.GetAllCategories();
            }
            else
            {
                dtgCentre.ItemsSource = TypesproduitsDtoOut.ListCategories;
            }

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
            Window window = new GridTypesProduit(_context);
            window.ShowDialog();
            FillGrid();
        }

        private void ButtonFermer(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbTypeProduit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypesproduitsDtoOut = _tpController.GetTypesproduitById((int)cbTypeProduit.SelectedValue);
            FillGrid();
        }
    }
}
