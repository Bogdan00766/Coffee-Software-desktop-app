using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Coffee.Uwp.Views.Cart;
using Coffee.Uwp.Views.Payment;
using Coffee.Uwp.Views.Settings;
using Coffee.Uwp.Views.Home;
using Coffee.Uwp.Views.Saved;
using Coffee.Uwp.Views.Login;
using Coffe.Domain;
using Coffee.Uwp.Views.Catalog;

namespace Coffee.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            UpdateButtons();
            frame.Navigate(typeof(Home));
        }

        public void UpdateUserInfo()
        {
            if (CurrentUser.isGuest == true) currentUserText.Text = "You are: Guest";
            else currentUserText.Text = "You are: " + CurrentUser.Username;
        }

        public void UpdateButtons()
        {
            if (CurrentUser.isGuest == true)
            {
                loginNav.Visibility = Visibility.Visible;
                logoutNav.Visibility = Visibility.Collapsed;
                savedNav.Visibility = Visibility.Collapsed;             
                cartNav.Visibility = Visibility.Collapsed;
                settingsNav.Visibility = Visibility.Collapsed;


            }
            else
            {
                loginNav.Visibility = Visibility.Collapsed;
                logoutNav.Visibility = Visibility.Visible;
                savedNav.Visibility = Visibility.Visible;               
                cartNav.Visibility = Visibility.Visible;
                settingsNav.Visibility = Visibility.Visible;
            }
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            UpdateButtons();
            UpdateUserInfo();
            NavigationViewItem nvi = (NavigationViewItem)args.InvokedItemContainer;
            if (nvi != null)
            {
                switch (nvi.Tag.ToString())
                {
                    case "home":
                        frame.Navigate(typeof(Home));
                        break;                   
                    case "card":
                        frame.Navigate(typeof(Card));
                        break;
                    case "catalog":
                        frame.Navigate(typeof(Catalog));
                        break;
                    case "saved":
                        frame.Navigate(typeof(Saved));
                        break;
                    case "cart":
                        frame.Navigate(typeof(Cart));
                        break;
                    case "login":
                        frame.Navigate(typeof(Login));
                        break;
                    case "settings":
                        frame.Navigate(typeof(Settings));
                        break;
                    case "properties":
                        frame.Navigate(typeof(Settings));
                        break;
                    case "logout":
                        CurrentUser.Logout();
                        frame.Navigate(typeof(Home));
                        break;

                }
            }
        }
    }
}
