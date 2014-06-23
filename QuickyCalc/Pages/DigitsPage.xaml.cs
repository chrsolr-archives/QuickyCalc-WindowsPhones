using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using System.IO.IsolatedStorage;

namespace QuickyCalc.Pages
{
    public partial class DigitsPage : PhoneApplicationPage
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        public DigitsPage()
        {
            InitializeComponent();

            NavigationInTransition navigateInTransition = new NavigationInTransition();
            navigateInTransition.Backward = new SlideTransition { Mode = SlideTransitionMode.SlideLeftFadeIn };
            navigateInTransition.Forward = new SlideTransition { Mode = SlideTransitionMode.SlideRightFadeIn };
            NavigationOutTransition navigateOutTransition = new NavigationOutTransition();
            navigateOutTransition.Backward = new SlideTransition { Mode = SlideTransitionMode.SlideLeftFadeOut };
            navigateOutTransition.Forward = new SlideTransition { Mode = SlideTransitionMode.SlideRightFadeOut };
            TransitionService.SetNavigationInTransition(this, navigateInTransition);
            TransitionService.SetNavigationOutTransition(this, navigateOutTransition);
        }

        private void num0_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlk.Text == "0")
                return;
            else
                resultTxtBlk.Text += "0";
        }

        private void num1_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlk.Text == "0")
            {
                resultTxtBlk.Text = "";
                resultTxtBlk.Text += "1";
            }
            else
            {
                resultTxtBlk.Text += "1";
            }
        }

        private void num2_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlk.Text == "0")
            {
                resultTxtBlk.Text = "";
                resultTxtBlk.Text += "2";
            }
            else
            {
                resultTxtBlk.Text += "2";
            }
        }

        private void num3_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlk.Text == "0")
            {
                resultTxtBlk.Text = "";
                resultTxtBlk.Text += "3";
            }
            else
            {
                resultTxtBlk.Text += "3";
            }
        }

        private void num4_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlk.Text == "0")
            {
                resultTxtBlk.Text = "";
                resultTxtBlk.Text += "4";
            }
            else
            {
                resultTxtBlk.Text += "4";
            }
        }

        private void num5_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlk.Text == "0")
            {
                resultTxtBlk.Text = "";
                resultTxtBlk.Text += "5";
            }
            else
            {
                resultTxtBlk.Text += "5";
            }
        }

        private void num6_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlk.Text == "0")
            {
                resultTxtBlk.Text = "";
                resultTxtBlk.Text += "6";
            }
            else
            {
                resultTxtBlk.Text += "6";
            }
        }

        private void num7_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlk.Text == "0")
            {
                resultTxtBlk.Text = "";
                resultTxtBlk.Text += "7";
            }
            else
            {
                resultTxtBlk.Text += "7";
            }
        }

        private void num8_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlk.Text == "0")
            {
                resultTxtBlk.Text = "";
                resultTxtBlk.Text += "8";
            }
            else
            {
                resultTxtBlk.Text += "8";
            }
        }

        private void num9_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlk.Text == "0")
            {
                resultTxtBlk.Text = "";
                resultTxtBlk.Text += "9";
            }
            else
            {
                resultTxtBlk.Text += "9";
            }
        }

        private void period_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlk.Text.Contains("."))
                return;

            if (resultTxtBlk.Text == "")
            {
                resultTxtBlk.Text = "";
                resultTxtBlk.Text += "0.";
            }
            else if (resultTxtBlk.Text == "0")
            {
                resultTxtBlk.Text += ".";
            }
            else
            {
                resultTxtBlk.Text += ".";
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            resultTxtBlk.Text = "0";
            settings.Remove("Amount");
            settings.Remove("Tips");
            settings.Remove("Split");
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            double result = double.Parse(resultTxtBlk.Text.ToString());

            if (settings.Contains("AmountButton"))
                settings.Add("Amount", result);

            else if (settings.Contains("TipButton"))
                settings.Add("Tips", resultTxtBlk.Text);

            else if (settings.Contains("SplitButton"))
                settings.Add("Split", resultTxtBlk.Text);

            NavigationService.GoBack();
        }

        private void backspace_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlk.Text.Length > 0)
            {
                if (resultTxtBlk.Text == "0")
                    return;
                else
                    resultTxtBlk.Text = resultTxtBlk.Text.Remove(resultTxtBlk.Text.Length - 1);
            }
            else if (resultTxtBlk.Text == "")
            {
                resultTxtBlk.Text = "0";
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            settings.Remove("Amount");
            settings.Remove("Tips");
            settings.Remove("Split");
        }


    }
}