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

namespace Caculatrice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool virEnable = false ,nbEnable = true, signEnable = true, egalEnable = false; 
        Double nbr1 = 0, nbr2 = 0;
        String calc;
        public MainWindow()
        {
            InitializeComponent();
            txtResult.Text = "";
            txtExpr.Text = "";
        }

        private void btnNum_Click(object sender, RoutedEventArgs e)
        {
            if (nbEnable)
            {
                txtResult.Text += (String)((Button)sender).Content;
                signEnable = true;
                virEnable = true;
            }
        }

        private void btnVirgule_Click(object sender, RoutedEventArgs e)
        {
            if (virEnable)
            {
                txtResult.Text += (String)((Button)sender).Content;
                virEnable = false;
            }
        }
        private void btnCe_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "";
            if (!nbEnable) nbEnable = true ;
        }
        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "";
            txtExpr.Text = "";
            nbr1 = 0;
            nbr2 = 0;
            if (!nbEnable) nbEnable = true;
        }
        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            nbEnable = true;
            if (signEnable)
            {
                calc = (String)((Button)sender).Content ;
                if (txtResult.Text == "")
                {
                    nbr1 = 0;
                }
                else
                {
                    nbr1 = Convert.ToDouble(txtResult.Text);
                }
                signEnable = false;
                egalEnable = true;
                txtResult.Text = "";
                txtExpr.Text = nbr1+" " + calc + " ";
            }
        }
        private void btnEgal_Click(object sender, RoutedEventArgs e)
        {
            Double res = 0;
            String resAff = "";
            if (egalEnable)
            {
                if (txtResult.Text == "")
                {
                    nbr2 = 0;
                }
                else
                {
                     nbr2 = Convert.ToDouble(txtResult.Text);
                }
               
                switch (calc)
                {
                    case "-":
                        res = nbr1 - nbr2;
                        resAff = Convert.ToString(res);
                        break;
                    case "+":
                        res = nbr1 + nbr2;
                        resAff = Convert.ToString(res);
                        break;
                    case "/":
                        if (nbr2 == 0)
                        {
                            resAff = "DIV PAR 0";
                        }
                        else
                        {
                            res = nbr1 / nbr2;
                            resAff = Convert.ToString(res);
                        }
                        break;
                    case "X":
                        res = nbr1 * nbr2;
                        resAff = Convert.ToString(res);
                        break;
                    case "^":
                        res = Math.Pow(nbr1 , nbr2);
                        resAff = Convert.ToString(res);
                        break;
                    case "√":
                        res = Math.Sqrt(nbr1);
                        resAff = Convert.ToString(res);
                        break;
                    case "!":
                        res = Fact(nbr1);
                        resAff = Convert.ToString(res);
                        break;
                    default: break;
                }
                txtExpr.Text = resAff;
                txtResult.Text = resAff;
                nbr1 = res; 
                virEnable = false;
                nbEnable = false;
                egalEnable = false;
                signEnable = true;
            }
        }
        private Double Fact(Double nb)
        {
            return nb <= 0 ? 1  : nb * Fact(nb-1)  ;
        }
    }
}
