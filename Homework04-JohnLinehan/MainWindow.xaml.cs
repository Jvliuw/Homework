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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework04_JohnLinehan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            SubmitRules();
        }

        private void uxZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uxZipCode.Text.Length < 5)
            {
                uxSubmit.IsEnabled = false;
            }
            else
            {
                uxSubmit.IsEnabled = true;
            }
        }

        bool isNumber(string text)
        {
            Regex regex = new Regex(@"[0-9-]");
            return regex.IsMatch(text);
        }
        bool isCapLetter(string text)
        {
            Regex regex = new Regex(@"[A-Z-]");
            return regex.IsMatch(text);
        }

        bool isHyphen(string text)
        {
            Regex regex = new Regex(@"[\-]");
            return regex.IsMatch(text);
        }

        bool isSpace(string text)
        {
            Regex regex = new Regex(@"[\s]");
            return regex.IsMatch(text);
        }
        private void SubmitRules()
        {
            string zipCode = uxZipCode.Text;
            bool canadian = false;
            bool american = false;
            if (isCapLetter((zipCode[0].ToString()))) //check first digit to see if it is letter
            {
                if (isNumber(zipCode[1].ToString()))//check to see if the second and 5th digits are numbers
                {
                    if (isNumber(zipCode[5].ToString()))
                    {
                        if (isSpace(zipCode[3].ToString())) //check if 4th digit is a space
                        {
                            for (int i = 0; i < zipCode.Length; i += 2) //iterate through remaining characters and check if letters
                            {
                                if (isCapLetter((zipCode[i].ToString())))
                                {
                                    canadian = true;
                                }
                            }//for
                        }
                    }
                }
            }

            if (zipCode.Length == 5) //if short zip code
            {
                for (int i = 0; i < zipCode.Length; i++)
                {
                    if (isNumber((zipCode[i].ToString())))
                    {
                        american = true;
                    }
                    else
                    {
                        american = false;
                    }
                }
            }
            else if (zipCode.Length == 10)
            {
                for (int i = 0; i < zipCode.Length; i++)
                {
                    if (isNumber((zipCode[i].ToString())))
                    {
                        american = true;
                    }
                    else
                    {
                        american = false;
                    }
                }
            }
           else
            {
                american = false;
            }

            if (canadian)
            {
                MessageBox.Show("CAN Zip code " + uxZipCode.Text + " entered.");
            }
            else if (american)
            {
                MessageBox.Show("USA Zip code " + uxZipCode.Text + " entered.");
            }
            else
            {
                uxSubmit.IsEnabled = false;
                uxZipCode.Text = "Enter valid zip code";
            }
        }

    }
}
