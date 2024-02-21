using GestionStock.Controller;
using GestionStock.Models;
using GestionStock.Models.Dtos;
using GestionStock.Views;
using Microsoft.AspNetCore.Mvc;
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

namespace GestionStock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GestionStockDbContext _context;
        private ArticlesController _controller;
        public MainWindow()
        {
            InitializeComponent();
            _context = new GestionStockDbContext();
            _controller = new ArticlesController(_context);
            FillGrid();
        }
        private void FillGrid()
        {
            dtgCentre.ItemsSource = _controller.GetAllArticles();
        }

        private void ButtonAction_Click(object sender, RoutedEventArgs e)
        {
            ArticlesDtoOut itemDto;

            if (((Button)sender).Name == "btnAjouter")
            {
                itemDto = new ArticlesDtoOut();
            }
            else
            {
                itemDto = (ArticlesDtoOut)dtgCentre.SelectedItem;
            }

            Window w = new GestionArticle(itemDto, this, (string)((Button)sender).Content, _controller, _context);
            w.ShowDialog();
            FillGrid();
        }

        private void Row_DoubleClick(object sender, EventArgs e)
        {
            ArticlesDtoOut itemDto = (ArticlesDtoOut)((DataGridRow)sender).Item;

            Window w = new GestionArticle(itemDto, this, "Modifier", _controller, _context);
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

        private void ButtonGestCat_Click(object sender, RoutedEventArgs e)
        {
            Window w = new GridCategory(_context);
            w.ShowDialog();
            FillGrid();
        }
    }
}
