
using AutoMapper;
using CrudPersistant.Controller;
using CrudPersistant.Models;
using CrudPersistant.Models.Data;
using CrudPersistant.Models.Dtos;
using CrudPersistant.Models.Profiles;
using CrudPersistant.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

namespace CrudPersistant.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {

            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<ProductDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddTransient<ProductsServices>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers().AddNewtonsoftJson();

            builder.Services.AddControllers();
            

            InitializeComponent();

            dgdProd.ItemsSource = CreerListe();
        }

        private List<ProductDtoOut> CreerListe( )
        {
            List<ProductDtoOut> liste = new List<ProductDtoOut>();
            //@"c:\temp\Personne.json"
            return liste;
        }

        private void ButtonAjout_Click(object sender, RoutedEventArgs e)
        {
            FenetreGestion fg = new FenetreGestion(this);
            fg.ShowDialog();
        }
    }
}
