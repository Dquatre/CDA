using GestionStock.Controller;
using GestionStock.Models;
using GestionStock.Models.Data;
using GestionStock.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace GestionStock.Views
{
    /// <summary>
    /// Logique d'interaction pour GestionArticle.xaml
    /// </summary>
    public partial class GestionArticle : Window
    {
        public string Mode { get; set; }
        public bool TxtLibelleValide { get; set; } = false;
        public bool TxtStockValide { get; set; } = false;
        public ArticlesController Controller { get; set; }
        public CategoriesController CatController { get; set; }
        public GestionArticle(ArticlesDtoOut itemDto, MainWindow mainWindow, string mode, ArticlesController controller, GestionStockDbContext context)
        {
            InitializeComponent();
            Mode = mode;
            btnVal.Content = Mode;
            Controller = controller;
            CatController = new CategoriesController(context);
            RemplissageChamp(itemDto);
            CbbCat.SelectedValuePath = "Key" ;
            CbbCat.DisplayMemberPath = "Value";
            foreach (var item in CatController.GetAllCategories())
            {
                CbbCat.Items.Add(new KeyValuePair<int, string>(item.IdCategorie,item.LibelleCategorie));
            }
            
        }
        public void RemplissageChamp(ArticlesDtoOut itemDto)
        {
            if (Mode != "Ajouter")
            {
                idArticle.Content = itemDto.IdArticle.ToString();
                txtLibelle.Text = itemDto.LibelleArticle;
                txtStock.Text = itemDto.QuantiteStockee.ToString();
                CbbCat.SelectedValue = itemDto.IdCategorie;
            }
            else
            {
                btnVal.IsEnabled = false;
                idArticle.Content = "0";
            }
        }


        private void txtLibelle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtLibelle.Text != "")
            {
                TxtLibelleValide = true;
            }
            else
            {
                TxtLibelleValide = false;
            }
            verifChampRemplis();
        }



        private void txtStock_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(txtStock.Text, @"^\d{1,}$"))
            {
                TxtStockValide = true;
            }
            else
            {
                TxtStockValide = false;
            }
            verifChampRemplis();
        }

        private void verifChampRemplis()
        {
            if (TxtLibelleValide && TxtStockValide)
            {
                btnVal.IsEnabled = true;
            }
            else
            {
                btnVal.IsEnabled = false;
            }
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {

            ArticlesDtoOut itemDto = new ArticlesDtoOut(Int32.Parse((string)idArticle.Content),txtLibelle.Text, Int32.Parse((string)txtStock.Text), (int)CbbCat.SelectedValue);
            switch (Mode)
            {
                case "Ajouter": Controller.CreateArticle(itemDto); break;
                case "Modifier": Controller.UpdateArticle(itemDto.IdArticle, itemDto); break;
                case "Supprimer": Controller.DeleteArticle(itemDto.IdArticle); break;
            }
            this.Close();
        }
        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
