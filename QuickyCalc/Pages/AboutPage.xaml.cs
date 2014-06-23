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
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Windows.Threading;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace QuickyCalc.Pages
{
    public partial class AboutPage : PhoneApplicationPage
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        public AboutPage()
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


            changelogTxtblk.Text = "Changelog" + Environment.NewLine +
                                        "\nVersion 2.0.0.5 - December 11, 2011." + Environment.NewLine +
                                        "-Added Rounding up split amount for the TipCalc." + Environment.NewLine +
                                        "Version 2.0.0.4 - December 9, 2011." + Environment.NewLine +
                                        "-Added QuickyApps Twitter's profile." + Environment.NewLine +
                                        "Version 2.0.0.3 - December 7, 2011." + Environment.NewLine +
                                        "-Added transition and button effect." + Environment.NewLine +
                                        "Version 2.0.0.2 - December 6, 2011." + Environment.NewLine +
                                        "-Added support for Mango." + Environment.NewLine +
                                        "Version 2.0.0.1 - December 4, 2011." + Environment.NewLine +
                                        "-Revomed yellow theme and replaced the blue theme." + Environment.NewLine +
                                        "-Integrated Tip Calculator." + Environment.NewLine +
                                        "-Added metro style icons.";



            aboutInfoTxtblk.Text = "This application is a simple calculator & a simple tip calculator with the main functions. " +
                                    "In the future it may contain more functions. I am a new programmer with no programming background. " +
                                    "As I learn, I'll continue implementing features and tweaks. " +
                                    "If you have any ideas or comments, please feel free to reach me via Twitter.";




            WebClient twitter = new WebClient();

            twitter.DownloadStringCompleted += new DownloadStringCompletedEventHandler(twitter_DownloadStringCompleted);
            twitter.DownloadStringAsync(new Uri("https://api.twitter.com/1/statuses/user_timeline.xml?screen_name=" + "quickyapps"));

        }

        void twitter_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
                return;

            XElement xmlTweets = XElement.Parse(e.Result);

            listbox.ItemsSource = from tweet in xmlTweets.Descendants("status")
                                  select new TwitterProfile
                                  {
                                      ImageSource = tweet.Element("user").Element("profile_image_url").Value,
                                      Message = tweet.Element("text").Value,
                                      UserName = tweet.Element("user").Element("screen_name").Value
                                  };
        }

        private void twitterHyperlink_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.URL = "http://mobile.twitter.com/quickyapps";
            webBrowserTask.Show();
        }

        private void emailHyperlink_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.To = "twenty40@live.com";
            emailComposeTask.Body = "";
            emailComposeTask.Cc = "";
            emailComposeTask.Subject = "";
            emailComposeTask.Show();
        }

        private void facebookHyperlink_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.URL = "http://www.facebook.com/twenty40";
            webBrowserTask.Show();
        }

    } 
}