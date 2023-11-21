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

namespace ExempleDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private List<Jeux> CreerListe()
        {
            List<Jeux> liste = new List<Jeux>();
            liste.Add(new Jeux(1,"Super Mario Bros.","Nintendo","Nintendo","FC"));
            liste.Add(new Jeux(2, "Super Mario Bros. 2", "Nintendo", "Nintendo", "FDS"));
            liste.Add(new Jeux(3, "Super Mario Bros. 3", "Nintendo", "Nintendo", "FC"));
            liste.Add(new Jeux(4, "Super Mario Bros. USA", "Nintendo", "Nintendo", "FC"));
            liste.Add(new Jeux(5, "Super Mario World", "Nintendo", "Nintendo", "SFC"));
            liste.Add(new Jeux(6, "New Super Mario Bros.", "Nintendo", "Nintendo", "DS"));
            liste.Add(new Jeux(7, "New Super Mario Bros. Wii", "Nintendo", "Nintendo", "Wii"));
            liste.Add(new Jeux(8, "New Super Mario Bros. 2", "Nintendo", "Nintendo", "3DS"));
            liste.Add(new Jeux(9, "New Super Mario Bros. U", "Nintendo", "Nintendo", "Wii U"));
            liste.Add(new Jeux(10, "Super Mario Maker", "Nintendo", "Nintendo", "Wii U"));
            liste.Add(new Jeux(11, "Super Mario Maker 2", "Nintendo", "Nintendo", "Switch"));
            liste.Add(new Jeux(12, "New Super Mario Bros. U Deluxe", "Nintendo", "Nintendo", "Switch"));
            liste.Add(new Jeux(13, "Super Mario Bros. Wonders", "Nintendo", "Nintendo", "Switch"));
            return liste;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dtgJeux.ItemsSource = CreerListe();
        }
    }
}
