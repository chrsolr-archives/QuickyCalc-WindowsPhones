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
using System.IO;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using ControlTiltEffect;

namespace QuickyCalc.Pages
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        public SettingsPage()
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

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            #region Exit Setting Option

            bool exit;

            if (settings.Contains("ExitSettings"))
            {
                if (settings.TryGetValue<bool>("ExitSettings", out exit))
                {
                    if (exit == true)
                    {
                        exitCheckBox.IsChecked = true;
                    }
                    else
                    {
                        exitCheckBox.IsChecked = false;
                    }
                }
            }

            #endregion

        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

            if (!settings.Contains("ExitSettings")) // If settings doesn't contain a file named UserData.
            {
                settings.Add("ExitSettings", exitCheckBox.IsChecked); // Add a file named UserData as a key and what it is in the textbox add it as a value.
            }
            else
            {
                settings["ExitSettings"] = exitCheckBox.IsChecked; // If it does contain a file named Userdata, add what it is in the textbox as a new value.
            }

            settings.Save();
            NavigationService.GoBack();
        }
    }
}