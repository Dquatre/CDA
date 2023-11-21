﻿using System;
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

namespace MultiFenetre
{
    /// <summary>
    /// Logique d'interaction pour Fenetre2.xaml
    /// </summary>
    public partial class Fenetre2 : Window
    {
        public String MotRetour { get; set; }
        public Fenetre2(MainWindow w)
        {
            InitializeComponent();
            lblCentre.Content = w.lblSalut.Content;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MotRetour = txtRetour.Text;
        }
    }
}
