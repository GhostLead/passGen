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
        // Letters
        List<string> hungarianAlphabet = new List<string>()
        {
            "a", "á", "b", "c", "d", "e", "é", "f", "g", "h", "i", "í", "j", "k", "l", "m",
            "n", "o", "ó", "ö", "ő", "p", "q", "r", "s", "t", "u", "ú", "ü", "ű", "v", "w",
            "x", "y", "z"
        };

        // Numbers
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

            


            for (int i = 0; i < hossz; i++)
            {
                Random r = new();

                if (lowercaseCheck.IsChecked == true && i != hossz)
                {
                    password += hungarianAlphabet[r.Next(0, hungarianAlphabet.Count)];
                    i++;
                }
                if (uppercaseCheck.IsChecked == true && i != hossz)
                {
                    password += hungarianAlphabet[r.Next(0, hungarianAlphabet.Count)].ToUpper();
                    i++;
                }
                if (numberCheck.IsChecked == true && i != hossz)
                {
                    password += numbers[r.Next(0, numbers.Count)];
                    i++;
                }
                if (symbolCheck.IsChecked == true && i != hossz)
                {
                    password += symbols[r.Next(0, symbols.Count)];
                    i++;
                }


            }
            txtPassword.Text = password;
            
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

        private void Check_click(object sender, RoutedEventArgs e)
        {
            int checkboxCount = 0;

            if (lowercaseCheck.IsChecked == true)
            {
                checkboxCount++;
            }
            if (uppercaseCheck.IsChecked == true)
            {
                checkboxCount++;
            }
            if (numberCheck.IsChecked == true)
            {
                checkboxCount++;
            }
            if (symbolCheck.IsChecked == true)
            {
                checkboxCount++;
            }

            if (checkboxCount == 0)
            {
                uno.Fill = Brushes.White;
                dos.Fill = Brushes.White;
                tres.Fill = Brushes.White;
                quatro.Fill = Brushes.White;
            }
            if (checkboxCount == 1)
            {
                uno.Fill = Brushes.Red;
                dos.Fill = Brushes.White;
                tres.Fill = Brushes.White;
                quatro.Fill = Brushes.White;
            }
            if (checkboxCount == 2)
            {
                uno.Fill = Brushes.Red;
                dos.Fill = Brushes.Red;
                tres.Fill = Brushes.White;
                quatro.Fill = Brushes.White;
            }
            if (checkboxCount == 3)
            {
                uno.Fill = Brushes.Red;
                dos.Fill = Brushes.Red;
                tres.Fill = Brushes.Red;
                quatro.Fill = Brushes.White;
            }
            if (checkboxCount == 4)
            {
                uno.Fill = Brushes.Red;
                dos.Fill = Brushes.Red;
                tres.Fill = Brushes.Red;
                quatro.Fill = Brushes.Red;
            }
        }
    }
}
