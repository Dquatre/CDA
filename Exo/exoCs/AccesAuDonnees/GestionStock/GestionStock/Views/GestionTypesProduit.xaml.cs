using GestionStock.Controller;
using GestionStock.Models.Dtos;
using GestionStock.Models;
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
using GestionStock.Models.Data;

namespace GestionStock.Views
{
    /// <summary>
    /// Logique d'interaction pour GestionTypesProduit.xaml
    /// </summary>
    public partial class GestionTypesProduit : Window
    {
        public string Mode { get; set; }
        public bool TxtLibelleValide { get; set; } = false;
        public TypesproduitsController Controller { get; set; }
        public GestionTypesProduit(TypesproduitsDtoOut itemDto, GridTypesProduit gridpage, string mode, TypesproduitsController controller, GestionStockDbContext context)
        {
            InitializeComponent();
            Mode = mode;
            btnVal.Content = Mode;
            Controller = controller;
            RemplissageChamp(itemDto);
        }

        public void RemplissageChamp(TypesproduitsDtoOut itemDto)
        {
            if (Mode != "Ajouter")
            {
                idTypesproduit.Content = itemDto.IdTypeProduit.ToString();
                txtLibelle.Text = itemDto.LibelleTypeProduit;

            }
            else
            {
                btnVal.IsEnabled = false;
                idTypesproduit.Content = "0";
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
            TypesproduitsDtoOut itemDto = new TypesproduitsDtoOut(Int32.Parse((string)idTypesproduit.Content), txtLibelle.Text);
            switch (Mode)
            {
                case "Ajouter": Controller.CreateTypesproduit(itemDto); break;
                case "Modifier": Controller.UpdateTypesproduit(itemDto.IdTypeProduit, itemDto); break;
                case "Supprimer": Controller.DeleteTypesproduit(itemDto.IdTypeProduit); break;
            }
            this.Close();
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}

