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
using QuickyCalc.Pages;
using Microsoft.Phone.Shell;
using System.IO;
using System.IO.IsolatedStorage;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using ControlTiltEffect;


namespace QuickyCalc
{
    public partial class MainPage : PhoneApplicationPage
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        //........Variables.......

        #region Variables

        //holds the next value to be parsed from string form this just allows our parser to handle things simply.
        private string tmpValue = string.Empty; 

        //holds all the numbers input into our calculator
        private List<double> values = new List<double>();

        //holds a list of instructions
        private List<StandardOperator> operators = new List<StandardOperator>();

        //holds our total value, just makes things easier
        private double totals;

        //Check if equal button has being pressed
        bool EqualButtonCheck = false;

        #endregion

        //........Constructor......

        #region Constructor

        public MainPage()
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

        #endregion

        //.........Helpers.........

        #region Helpers

        public enum StandardOperator
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Inverse,
            Sqrt,
            Percentage,
            Reciprocal
        }

        public static class NumericalHelper
        {
            public static double Add(double a, double B)
            {
                return (a + B);
            }
            public static double Subtract(double a, double B)
            {
                return (a - B);
            }
            public static double Multiply(double a, double B)
            {
                return (a * B);
            }
            public static double Divide(double a, double B)
            {
                return (a / B);
            }
            public static double SquareRoot(double a)
            {
                return ((double)Math.Sqrt((double)a));
            }
            public static double Reciprocate(double a)
            {
                return (1 / a);
            }
            public static double Negate(double a)
            {
                return (a * -1);
            }
            public static double Percent(double a, double percent)
            {
                return ((a / 100) * percent);
            }
        }

        #endregion

        //.........Digits..........

        #region Digits

        private void num0_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "0")
                return;

            if (EqualButtonCheck == true)
            {
                historyTxtBlock.Text = "";
                resultTxtBlock.Text = "0";
            }
            else
                resultTxtBlock.Text += "0";

            tmpValue = resultTxtBlock.Text;

            EqualButtonCheck = false;
        }

        private void num1_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "0" && historyTxtBlock.Text == "" || EqualButtonCheck == true)
            {
                historyTxtBlock.Text = "";
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "1";
            }
            else if (resultTxtBlock.Text == "0" || EqualButtonCheck == true)
            {
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "1";
            }
            else
            {
                resultTxtBlock.Text += "1";
            }

            tmpValue = resultTxtBlock.Text;

            EqualButtonCheck = false;
        }

        private void num2_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "0" && historyTxtBlock.Text == "" || EqualButtonCheck == true)
            {
                historyTxtBlock.Text = "";
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "2";
            }
            else if (resultTxtBlock.Text == "0" || EqualButtonCheck == true)
            {
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "2";
            }
            else
            {
                resultTxtBlock.Text += "2";
            }

            tmpValue = resultTxtBlock.Text;

            EqualButtonCheck = false;
        }

        private void num3_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "0" && historyTxtBlock.Text == "" || EqualButtonCheck == true)
            {
                historyTxtBlock.Text = "";
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "3";
            }
            else if (resultTxtBlock.Text == "0" || EqualButtonCheck == true)
            {
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "3";
            }
            else
            {
                resultTxtBlock.Text += "3";
            }

            tmpValue = resultTxtBlock.Text;

            EqualButtonCheck = false;
        }

        private void num4_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "0" && historyTxtBlock.Text == "" || EqualButtonCheck == true)
            {
                historyTxtBlock.Text = "";
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "4";
            }
            else if (resultTxtBlock.Text == "0" || EqualButtonCheck == true)
            {
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "4";
            }
            else
            {
                resultTxtBlock.Text += "4";
            }

            tmpValue = resultTxtBlock.Text;

            EqualButtonCheck = false;
        }

        private void num5_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "0" && historyTxtBlock.Text == "" || EqualButtonCheck == true)
            {
                historyTxtBlock.Text = "";
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "5";
            }
            else if (resultTxtBlock.Text == "0" || EqualButtonCheck == true)
            {
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "5";
            }
            else
            {
                resultTxtBlock.Text += "5";
            }

            tmpValue = resultTxtBlock.Text;

            EqualButtonCheck = false;
        }

        private void num6_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "0" && historyTxtBlock.Text == "" || EqualButtonCheck == true)
            {
                historyTxtBlock.Text = "";
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "6";
            }
            else if (resultTxtBlock.Text == "0" || EqualButtonCheck == true)
            {
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "6";
            }
            else
            {
                resultTxtBlock.Text += "6";
            }

            tmpValue = resultTxtBlock.Text;

            EqualButtonCheck = false;
        }

        private void num7_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "0" && historyTxtBlock.Text == "" || EqualButtonCheck == true)
            {
                historyTxtBlock.Text = "";
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "7";
            }
            else if (resultTxtBlock.Text == "0" || EqualButtonCheck == true)
            {
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "7";
            }
            else
            {
                resultTxtBlock.Text += "7";
            }

            tmpValue = resultTxtBlock.Text;

            EqualButtonCheck = false;
        }

        private void num8_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "0" && historyTxtBlock.Text == "" || EqualButtonCheck == true)
            {
                historyTxtBlock.Text = "";
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "8";
            }
            else if (resultTxtBlock.Text == "0" || EqualButtonCheck == true)
            {
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "8";
            }
            else
            {
                resultTxtBlock.Text += "8";
            }

            tmpValue = resultTxtBlock.Text;

            EqualButtonCheck = false;
        }

        private void num9_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "0" && historyTxtBlock.Text == "" || EqualButtonCheck == true)
            {
                historyTxtBlock.Text = "";
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "9";
            }
            else if (resultTxtBlock.Text == "0" || EqualButtonCheck == true)
            {
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "9";
            }
            else
            {
                resultTxtBlock.Text += "9";
            }

            tmpValue = resultTxtBlock.Text;

            EqualButtonCheck = false;
        }

        private void period_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text.Contains(".") || historyTxtBlock.Text.Contains("√"))
                return;

            if (resultTxtBlock.Text == "" || EqualButtonCheck == true)
            {
                resultTxtBlock.Text = "";
                resultTxtBlock.Text += "0.";
            }
            else if (resultTxtBlock.Text == "0")
            {
                resultTxtBlock.Text += ".";
            }
            else
            {
                resultTxtBlock.Text += ".";
            }

            tmpValue = resultTxtBlock.Text;

            EqualButtonCheck = false;
        }

        #endregion

        //.........Operations.........

        #region Operations

        private void addition_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "" || resultTxtBlock.Text == "0")
                return;

            if (historyTxtBlock.Text.Contains("√"))
                historyTxtBlock.Text += " + ";
            else
                historyTxtBlock.Text += tmpValue + " + ";

            resultTxtBlock.Text = "";
            values.Add(double.Parse(tmpValue));
            tmpValue = string.Empty;
            operators.Add(StandardOperator.Add);

            EqualButtonCheck = false;
        }

        private void subtraction_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "" || resultTxtBlock.Text == "0")
                return;

            if (historyTxtBlock.Text.Contains("√"))
                historyTxtBlock.Text += " - ";
            else
                historyTxtBlock.Text += tmpValue + " - ";

            resultTxtBlock.Text = "";
            values.Add(double.Parse(tmpValue));
            tmpValue = string.Empty;
            operators.Add(StandardOperator.Subtract);

            EqualButtonCheck = false;
        }

        private void multiplication_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "" || resultTxtBlock.Text == "0")
                return;

            if (historyTxtBlock.Text.Contains("√"))
                historyTxtBlock.Text += " x ";
            else
                historyTxtBlock.Text += tmpValue + " x ";

            resultTxtBlock.Text = "";
            values.Add(double.Parse(tmpValue));
            tmpValue = string.Empty;
            operators.Add(StandardOperator.Multiply);

            EqualButtonCheck = false;
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "" || resultTxtBlock.Text == "0")
                return;

            if (historyTxtBlock.Text.Contains("√"))
                historyTxtBlock.Text += " ÷ ";
            else
                historyTxtBlock.Text += tmpValue + " ÷ ";

            resultTxtBlock.Text = "";
            values.Add(double.Parse(tmpValue));
            tmpValue = string.Empty;
            operators.Add(StandardOperator.Divide);

            EqualButtonCheck = false;
        }

        private void inverse_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "" || resultTxtBlock.Text == "0")
                return;

            if (resultTxtBlock.Text.Contains("-"))
            {
                resultTxtBlock.Text = resultTxtBlock.Text.Remove(0, 1);
                tmpValue = tmpValue.Remove(0, 1);
            }
            else
            {
                resultTxtBlock.Text = "-" + resultTxtBlock.Text;
                tmpValue = "-" + tmpValue;
            }
        }

        private void percent_Click(object sender, RoutedEventArgs e)
        {
            if (historyTxtBlock.Text == "" || resultTxtBlock.Text == "")
                return;

            if (operators.Count > 0)
            {
                values.Add(double.Parse(tmpValue));
                resultTxtBlock.Text += "%";
                double t = NumericalHelper.Percent(values[0], values[1]);
                totals = t;
                tmpValue = string.Empty;
                resultTxtBlock.Text = totals.ToString() + "%";
                tmpValue = resultTxtBlock.Text.Remove(resultTxtBlock.Text.Length - 1);
                values.Clear();
                historyTxtBlock.Text = "";

                EqualButtonCheck = true;
            }
        }

        private void squareRoot_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text == "" || resultTxtBlock.Text == "0" || historyTxtBlock.Text.Contains("√"))
                return;

            double rec = double.Parse(tmpValue);
            totals = NumericalHelper.SquareRoot(rec);
            resultTxtBlock.Text = totals.ToString();
            historyTxtBlock.Text = "√(" + tmpValue + ")";
            tmpValue = resultTxtBlock.Text;

            EqualButtonCheck = true;
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            if (historyTxtBlock.Text == "" || resultTxtBlock.Text == "0" || resultTxtBlock.Text == "")
                return;

            if (operators.Count > 0)
            {
                //add the last value, 'cause it won't have been already
                values.Add(double.Parse(tmpValue));
                //we start by performing the first operator on the first TWO values
                if (operators[0] == StandardOperator.Add)
                    totals = NumericalHelper.Add(values[0], values[1]);
                else if (operators[0] == StandardOperator.Subtract)
                    totals = NumericalHelper.Subtract(values[0], values[1]);
                else if (operators[0] == StandardOperator.Multiply)
                    totals = NumericalHelper.Multiply(values[0], values[1]);
                else if (operators[0] == StandardOperator.Divide)
                    totals = NumericalHelper.Divide(values[0], values[1]);
            }

            if (operators.Count > 1 && values.Count > 2)
            {
                for (int i = 1; i < operators.Count; i++)
                {
                    if (operators[i] == StandardOperator.Add)
                        totals = NumericalHelper.Add(totals, values[i + 1]);
                    else if (operators[i] == StandardOperator.Subtract)
                        totals = NumericalHelper.Subtract(totals, values[i + 1]);
                    else if (operators[i] == StandardOperator.Multiply)
                        totals = NumericalHelper.Multiply(totals, values[i + 1]);
                    else if (operators[i] == StandardOperator.Divide)
                        totals = NumericalHelper.Divide(totals, values[i + 1]);
                }
            }

            resultTxtBlock.Text = totals.ToString();
            tmpValue = totals.ToString();
            historyTxtBlock.Text = "";
            values.Clear();
            operators.Clear();

            EqualButtonCheck = true;
        }

        #endregion

        //.......Clear, Clear Entry and BackSpace..........

        #region Clear & Backspace

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            totals = 0;
            values.Clear();
            operators.Clear();
            tmpValue = string.Empty;
            resultTxtBlock.Text = "0";
            historyTxtBlock.Text = "";
            EqualButtonCheck = false;
        }

        private void backspace_Click(object sender, RoutedEventArgs e)
        {
            if (resultTxtBlock.Text.Length > 0)
            {
                if (resultTxtBlock.Text == "0")
                    return;
                else
                    resultTxtBlock.Text = resultTxtBlock.Text.Remove(resultTxtBlock.Text.Length - 1);

                if (tmpValue != "")
                    tmpValue = tmpValue.Remove(tmpValue.Length - 1);
                else
                    return;

                if (resultTxtBlock.Text.Length == 0 || historyTxtBlock.Text == "")
                    resultTxtBlock.Text = "";
            }
            else if (resultTxtBlock.Text == "")
            {
                return;
            }
        }

        #endregion

        //..................Application Bar..........................

        #region Application Bar & Settings

        private void appBar_TipCalc_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/TipCalcPage.xaml", UriKind.Relative));
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

        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            #region Exit Setting Option

            bool exit;

            if (settings.Contains("ExitSettings"))
            {
                if (settings.TryGetValue<bool>("ExitSettings", out exit))
                {
                    if (exit == true)
                    {
                        if (MessageBox.Show("Do you want to exit the application?", "Exit", 
                            MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                            e.Cancel = true;
                    }
                    else
                    {

                    }
                }
            }

            #endregion

            // ...!!!...Clear IsolatedStorageSettings...!!!...
            settings.Remove("Amount");
            settings.Remove("Tips");
            settings.Remove("Split"); 
        }
       
        #endregion

    }
}