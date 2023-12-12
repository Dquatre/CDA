using GestionStock.Controller;
using GestionStock.Models;
using GestionStock.Models.Data;
using GestionStock.Models.Dtos;
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
using System.Windows.Shapes;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace GestionStock.Views
{
    /// <summary>
    /// Logique d'interaction pour GestionCategory.xaml
    /// </summary>
    public partial class GestionCategory : Window
    {
        public string Mode { get; set; }
        public bool TxtLibelleValide { get; set; } = false;
        public CategoriesController Controller { get; set; }
        public TypesproduitsController TpController { get; set; }
        public GestionCategory(CategoriesDtoOut itemDto, GridCategory gridpage, string mode, CategoriesController controller,GestionStockDbContext context)
        {
            InitializeComponent();
            Mode = mode;
            btnVal.Content = Mode;
            Controller = controller;
            TpController = new TypesproduitsController(context);
            cbbTypeProd.SelectedValuePath = "Key";
            cbbTypeProd.DisplayMemberPath = "Value";
            foreach (var item in TpController.GetAllTypesproduits())
            {
                cbbTypeProd.Items.Add(new KeyValuePair<int, string>(item.IdTypeProduit, item.LibelleTypeProduit));
            }
            RemplissageChamp(itemDto);
        }

        public void RemplissageChamp(CategoriesDtoOut itemDto)
        {
            if (Mode != "Ajouter")
            {
                idCategorie.Content = itemDto.IdCategorie.ToString();
                txtLibelle.Text = itemDto.LibelleCategorie;
                cbbTypeProd.SelectedValue = itemDto.IdTypeProduit;

            }
            else
            {
                btnVal.IsEnabled = false;
                idCategorie.Content = "0";
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

        private void verifChampRemplis()
        {
            if (TxtLibelleValide)
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
            CategoriesDtoOut itemDto = new CategoriesDtoOut(Int32.Parse((string)idCategorie.Content), txtLibelle.Text, (int)cbbTypeProd.SelectedValue);
            switch (Mode)
            {
                case "Ajouter": Controller.CreateCategory(itemDto); break;
                case "Modifier": Controller.UpdateCategory(itemDto.IdCategorie, itemDto); break;
                case "Supprimer": Controller.DeleteCategory(itemDto.IdCategorie); break;
            }
            this.Close();
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
