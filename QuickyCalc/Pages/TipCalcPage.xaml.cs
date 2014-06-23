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
using System.IO.IsolatedStorage;
using Microsoft.Phone.Shell;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace QuickyCalc.Pages
{
    public partial class TipCalcPage : PhoneApplicationPage
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        //------Varirables------>

        string Amount;
        string Tip;
        string Split;
        string resultRounded;

        double TotalAmount;
        double TotalTip;
        double TotalSplit;
        double total;
        double totalRoundedAmount;


        public TipCalcPage()
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

        //------Buttons----->

        private void enterAmountButton_Click(object sender, RoutedEventArgs e)
        {
            if (!settings.Contains("AmountButton"))
            {
                settings.Add("AmountButton", "Item001");

                NavigationService.Navigate(new Uri("/Pages/DigitsPage.xaml", UriKind.Relative));
            }
            else
            {
                return;
            }
        }

        private void enterTipButton_Click(object sender, RoutedEventArgs e)
        {
            if (!settings.Contains("TipButton"))
            {
                settings.Add("TipButton", "Item002");

                NavigationService.Navigate(new Uri("/Pages/DigitsPage.xaml", UriKind.Relative));
            }
            else
            {
                return;
            }
        }

        private void enterSplitButton_Click(object sender, RoutedEventArgs e)
        {
            if (!settings.Contains("SplitButton"))
            {
                settings.Add("SplitButton", "Item003");

                NavigationService.Navigate(new Uri("/Pages/DigitsPage.xaml", UriKind.Relative));
            }
            else
            {
                return;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Amount = enterAmountButton.Content.ToString().Replace("$", "");
                Tip = enterTipButton.Content.ToString().Replace("%", "");
                Split = enterSplitButton.Content.ToString();

                TotalTip = double.Parse(Amount) * double.Parse(Tip) / 100;
                TotalAmount = double.Parse(Amount) + TotalTip;

                if (Split == "0" || ((String)enterSplitButton.Content) == "")
                    Split = "1";

                TotalSplit = TotalAmount / double.Parse(Split);

                TotalBillTxtBlock.Text = "";
                TipBillTxtBlock.Text = "";
                SplitAmountTxtBlock.Text = "";

                TotalBillTxtBlock.Text = "Total Bill: $" + TotalAmount.ToString("N2");
                TipBillTxtBlock.Text = "Tip Amount: $" + TotalTip.ToString("N2");
                SplitAmountTxtBlock.Text = "Split Total: $" + TotalSplit.ToString("N2");

                settings.Remove("Amount");
                settings.Remove("Tips");
                settings.Remove("Split");
            }

            catch (Exception)
            {
                var amountButtonString = enterAmountButton.Content as string;
                var enterTipButtonString = enterTipButton.Content as string;
                var enterSplitButtonString = enterSplitButton.Content as string;

                if (String.IsNullOrEmpty(amountButtonString))
                    MessageBox.Show("Please enter the total bill amount.");
                else if (String.IsNullOrEmpty(enterTipButtonString))
                    MessageBox.Show("Please enter the tip % amount.");
                else if (String.IsNullOrEmpty(enterSplitButtonString))
                    MessageBox.Show("Please enter the amount in which you will like to split the total bill.");
            }

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            enterAmountButton.Content = "";
            enterTipButton.Content = "";
            enterSplitButton.Content = "";

            settings.Remove("Amount");
            settings.Remove("Tips"); 
            settings.Remove("Split"); 

            TotalBillTxtBlock.Text = "Total Bill: $0.00";
            TipBillTxtBlock.Text = "Tip Amount: $0.00";
            SplitAmountTxtBlock.Text = "Split Total: $0.00";

            TotalAmount = 0;
            TotalTip = 0;
            TotalSplit = 0;

            resultRounded = "";
            total = 0;


            roundSwitch.IsChecked = false;

        }


        //------ApplicationBar & Settings------>

        private void appBar_Calc_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void appBarMenu_About_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AboutPage.xaml", UriKind.Relative));
        }

        private void appBarMenu_Settings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SettingsPage.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            settings.Remove("AmountButton");
            settings.Remove("TipButton");
            settings.Remove("SplitButton");

            double amount;
            string tips;
            string split;

            if (settings.TryGetValue<double>("Amount", out amount))
            {
                enterAmountButton.Content = "$" + amount.ToString("N2");
            }
            if (settings.TryGetValue<string>("Tips", out tips))
            {
                enterTipButton.Content = tips + "%";
            }
            if (settings.TryGetValue<string>("Split", out split))
            {
                enterSplitButton.Content = split;
            }
        }

        private void roundSwitch_Checked(object sender, RoutedEventArgs e)
        {
            if (TotalBillTxtBlock.Text == "Total Bill: $0.00")
            {
                MessageBox.Show("Please fill in all amounts.");

                TotalAmount = 0;
                TotalTip = 0;
                TotalSplit = 0;

                roundSwitch.IsChecked = false;
            }
            else
            {
                resultRounded = TotalSplit.ToString("N2");
                resultRounded = resultRounded.Remove(resultRounded.Length - 1, 1);
                resultRounded = resultRounded.Remove(resultRounded.Length - 1, 1);
                total = double.Parse(resultRounded) + 1;
                totalRoundedAmount = total * double.Parse(Split);

                TotalBillTxtBlock.Text = "Total Bill: $" + totalRoundedAmount.ToString("N2");
                SplitAmountTxtBlock.Text = "Split Total: $" + total.ToString("N2");
            }
        }

        private void roundSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            TotalBillTxtBlock.Text = "Total Bill: $" + TotalAmount.ToString("N2");
            TipBillTxtBlock.Text = "Tip Amount: $" + TotalTip.ToString("N2");
            SplitAmountTxtBlock.Text = "Split Total: $" + TotalSplit.ToString("N2");
        }

    }
}