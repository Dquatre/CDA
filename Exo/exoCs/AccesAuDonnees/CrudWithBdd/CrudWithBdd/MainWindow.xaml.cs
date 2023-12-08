﻿using CrudWithBdd.Controller;
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
        private BatimentsController _controller;
        public MainWindow()
        {
            InitializeComponent();
            _context = new ComplexDbContext();
            _controller = new BatimentsController(_context);
            dtgSalle.ItemsSource = _controller.getAllBatiments();
        }
    }
}
