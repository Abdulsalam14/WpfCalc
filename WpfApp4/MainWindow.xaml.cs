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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        decimal num1 = 0;
        decimal num2 = 0;
        char op = ' ';
        string lbltxt = "";
        bool ksr = false;
        bool num1ornum2 = false;
        bool menfi = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            char d = ' ';
            Button? click = (sender as Button);
            if (click != null) d = Convert.ToChar(click.Content);
            if ((d == '-' && num1 == 0))
            {
                menfi = true;
                label1.Content = d.ToString();
            }
            else if ((d < 58 && d > 47))
            {
                lbltxt += d;
                if (!num1ornum2)
                {
                    num1 = Convert.ToDecimal(lbltxt);
                    if (menfi) num1 = (-num1);
                    label1.Content = num1.ToString();
                }
                else
                {
                    num2 = Convert.ToDecimal(lbltxt);
                    label1.Content = num2.ToString();
                }
            }
            else if (d == ',' && !ksr)
            {
                lbltxt = num1ornum2 ? num2.ToString() : num1.ToString();
                lbltxt += '.';
                label1.Content = lbltxt;
                if (!num1ornum2) num1 = Convert.ToDecimal(lbltxt);
                else num2 = Convert.ToDecimal(lbltxt);
                ksr = true;
            }
            else if (d == '-' || d == '÷' || d == 'x' || d == '+')
            {
                label1.Content = d.ToString();
                num1ornum2 = true;
                ksr = false;
                lbltxt = "";
                op = d;
                menfi = true;
            }
            else if (d == 61)
            {
                switch (op)
                {
                    case '-': label1.Content = (num1 -= num2).ToString(); break;
                    case '+': label1.Content = (num1 += num2).ToString(); break;
                    case 'x': label1.Content = (num1 *= num2).ToString(); break;
                    case '÷': label1.Content = num2 == decimal.Zero ? "Cannot Zero" : (num1 /= num2).ToString(); break;
                    default:
                        break;
                }
                op = ' ';
                num2 = 0;
                lbltxt = "";
                ksr = false;
            }
            else if (d == 'C')
            {
                op = ' ';
                num1 = 0;
                num2 = 0;
                lbltxt = "";
                ksr = false;
                num1ornum2 = false;
                menfi = false;
                label1.Content = num1.ToString();
            }
            else if(click?.Name=="btn17")
            {
                if (lbltxt.Length > 1)
                {
                    lbltxt = lbltxt.Remove(lbltxt.Length - 1, 1);
                    label1.Content = lbltxt;
                    if (num1ornum2) num2 = Convert.ToDecimal(lbltxt);
                    else num1 = Convert.ToDecimal(lbltxt);
                }
                else
                {
                    label1.Content = "0";
                    num1 = 0;
                    num2 = 0;
                    lbltxt = "";
                    op = ' ';
                    ksr = false;
                    num1ornum2 = false;
                    menfi = false;
                }
            }
            else label1.Content = lbltxt;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button? click = sender as Button;
            label1.Content = "This func not working";
        }
    }
}
