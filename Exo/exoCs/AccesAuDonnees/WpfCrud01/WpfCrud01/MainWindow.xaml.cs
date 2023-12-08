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
using WpfCrud01.Models.Services;

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
            dtgCentre.ItemsSource = _controller.GetAllLivres();
        }
    }
}
