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
        }


        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
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
                }
            }
        }
    }
}
