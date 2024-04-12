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

namespace WpfAppPasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        List<string> hungarianAlphabet = new List<string>()
        {
            "a", "á", "b", "c", "d", "e", "é", "f", "g", "h", "i", "í", "j", "k", "l", "m",
            "n", "o", "ó", "ö", "ő", "p", "q", "r", "s", "t", "u", "ú", "ü", "ű", "v", "w",
            "x", "y", "z"
        };

        // Number characters
        List<string> numbers = new List<string>()
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };

        // Symbols
        List<string> symbols = new List<string>()
        {
            "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+", "[", "]",
            "{", "}", ";", ":", "|", ",", ".", "/", "<", ">", "?", "~", "`"
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtSliderValue.Content = sliSlider.Value;
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            int hossz = Convert.ToInt32(sliSlider.Value);
            string password = "";

            if (uppercaseCheck.IsChecked == true)
            {
                Random rand = new Random();
                for (int i = 0; i < hossz; i++)
                {
                    password += hungarianAlphabet[rand.Next(0,hungarianAlphabet.Count)].ToUpper();
                }
            }
            else if (lowercaseCheck.IsChecked == true)
            {
                Random rand = new Random();
                for (int i = 0; i < hossz; i++)
                {
                    password += hungarianAlphabet[rand.Next(0, hungarianAlphabet.Count)].ToLower();
                }
            }
            else if (numberCheck.IsChecked == true)
            {
                Random rand = new Random();
                for (int i = 0; i < hossz; i++)
                {
                    password += numbers[rand.Next(0, numbers.Count)];
                }
            }
            else if (symbolCheck.IsChecked == true)
            {
                Random rand = new Random();
                for (int i = 0; i < hossz; i++)
                {
                    password += symbols[rand.Next(0, symbols.Count)];
                }
            }
            else
            {
                MessageBox.Show("Kérem jelöljön meg minimum egy négyzetet!");
            }
            string finalPassword = ShuffleString(password);
            txtPassword.Content = finalPassword;

        }
        static string ShuffleString(string input)
        {
            char[] charArray = input.ToCharArray();

            Random rng = new Random();

            int n = charArray.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                char value = charArray[k];
                charArray[k] = charArray[n];
                charArray[n] = value;
            }

            return new string(charArray);
        }

        private void btnGenerate_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
