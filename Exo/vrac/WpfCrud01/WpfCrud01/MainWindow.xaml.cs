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
using WpfCrud01.Controller;
using WpfCrud01.Models;
using WpfCrud01.Models.Dtos;
using WpfCrud01.Models.Services;
using WpfCrud01.Views;

namespace WpfCrud01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LivreDbContext _context;
        private LivresController _controller;
        public MainWindow()
        {
            InitializeComponent();
            _context = new LivreDbContext();
            _controller = new LivresController(_context);
            FillGrid();
        }

        private void FillGrid()
        {
            dtgCentre.ItemsSource = _controller.GetAllLivres();
        }

        private void ButtonAction_Click(object sender, RoutedEventArgs e)
        {
            LivresDtoOut lDto;
            if (((Button)sender).Name == "btnAjouter")
            {
                lDto = new LivresDtoOut();
            }
            else
            {
                lDto = (LivresDtoOut)dtgCentre.SelectedItem;
            }

            Window w = new GestionLivre(lDto,this, (string)((Button)sender).Content, _controller);
            w.ShowDialog();
            FillGrid();
        }

        private void Row_DoubleClick(object sender, EventArgs e)
        {
            LivresDtoOut lDto = (LivresDtoOut)((DataGridRow)sender).Item;

            Window w = new GestionLivre(lDto, this, "Modifier", _controller);
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
