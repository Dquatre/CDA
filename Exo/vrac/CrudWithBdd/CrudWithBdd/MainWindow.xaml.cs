using CrudWithBdd.Controller;
using CrudWithBdd.Models;
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

namespace CrudWithBdd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ComplexDbContext _context;
        private BatimentsController _batimentController;
        private SallesController _salleController;
        public MainWindow()
        {
            InitializeComponent();
            _context = new ComplexDbContext();
            _batimentController = new BatimentsController(_context);
            _salleController = new SallesController(_context);
            dtgSalle.ItemsSource = _salleController.getAllSalles();
        }
    }
}
