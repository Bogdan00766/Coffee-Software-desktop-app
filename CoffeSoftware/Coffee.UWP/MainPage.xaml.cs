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
using Coffee.Uwp.Views.Menu;
using Coffee.Uwp.Views.Saved;
using Coffee.Uwp.Views.Login;
using Coffe.Domain;

namespace Coffee.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool login_bool = true;
        bool logout_bool = true;
        public MainPage()
        {
            this.InitializeComponent();
        }

        public void UpdateUserInfo()
        {
            if (CurrentUser.isGuest == true) currentUserText.Text = "You are: Guest";
            else currentUserText.Text = "You are: " + CurrentUser.Username;
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (CurrentUser.isGuest == true) 
            { 
                login_bool = true;
                logout_bool = false;
            }
            else
            {
                login_bool = false;
                logout_bool = true;
            }
            UpdateUserInfo();
            NavigationViewItem nvi = (NavigationViewItem)args.InvokedItemContainer;
            if (nvi != null)
            {
                switch (nvi.Tag.ToString())
                {
                    case "home":
                        frame.Navigate(typeof(Home));
                        break;
                    case "menu":
                        frame.Navigate(typeof(Menu));
                        break;
                    case "payment":
                        frame.Navigate(typeof(Payment));
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
