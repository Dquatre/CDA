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
using System.Xml.Linq;
using WpfCrud01.Controller;
using WpfCrud01.Models.Dtos;
using WpfCrud01.Models.Services;

namespace WpfCrud01.Views
{
    /// <summary>
    /// Logique d'interaction pour GestionLivre.xaml
    /// </summary>
    public partial class GestionLivre : Window
    {
        public string Mode { get; set; }

        public bool TxtTitreValide { get; set; } = false;
        public bool TxtAuteurValide { get; set; } = false;
        public bool TxtEditeurValide { get; set; } = false;
        public bool TxtNdpValide { get; set; } = false;
        public LivresController Controller { get; set; }

        public GestionLivre(LivresDtoOut lDto, MainWindow mainWindow, string mode ,LivresController controller)
        {
            InitializeComponent();
            Mode = mode;
            btnVal.Content = Mode;
            Controller = controller;
            RemplissageChamp(lDto);
        }

        public void RemplissageChamp(LivresDtoOut lDto )
        {
            if (Mode != "Ajouter")
            {
                idLivre.Content = lDto.IdLivre.ToString();
                txtTitre.Text = lDto.TitreLivre;
                txtAuteur.Text = lDto.Auteur;
                txtEditeur.Text = lDto.Editeur.ToString();
                txtNdp.Text = lDto.NombrePage.ToString();
            }
            else
            {
                btnVal.IsEnabled = false;
                idLivre.Content = "0";
            }
        }

        private void txtTitre_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(txtTitre.Text, @"^\w+( \w+)*$"))
            {
                TxtTitreValide = true;
            }
            else
            {
                TxtTitreValide = false;
            }
            verifChampRemplis();
        }

        private void txtAuteur_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(txtAuteur.Text, @"^\w+( \w+)*$"))
            {
                TxtAuteurValide = true;
            }
            else
            {
                TxtAuteurValide = false;
            }
            verifChampRemplis();
        }

        private void txtEditeur_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(txtEditeur.Text, @"^\w+( \w+)*$"))
            {
                TxtEditeurValide = true;
            }
            else
            {
                TxtEditeurValide = false;
            }
            verifChampRemplis();
        }

        private void txtNdp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(txtNdp.Text, @"^\d{1,}$"))
            {
                TxtNdpValide = true;
            }
            else
            {
                TxtNdpValide = false;
            }
            verifChampRemplis();
        }

        private void verifChampRemplis()
        {
            if (TxtTitreValide && TxtAuteurValide && TxtEditeurValide && TxtNdpValide)
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
            LivresDtoOut lDto = new LivresDtoOut(Int32.Parse((string)idLivre.Content), txtTitre.Text, Int32.Parse(txtNdp.Text), txtAuteur.Text, txtEditeur.Text);
            switch (Mode)
            {
                case "Ajouter": Controller.CreateLivre(lDto); break;
                case "Modifier": Controller.UpdateLivre(lDto.IdLivre,lDto); break;
                case "Supprimer": Controller.DeleteLivre(lDto.IdLivre) ; break;
            }
            this.Close();
        }
        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
