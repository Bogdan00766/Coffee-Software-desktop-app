using Coffe.Domain;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Coffee.Uwp.Views.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
       
        public Settings()
        {
            this.InitializeComponent();
            UpdateUserInfo();
        }

        private void UpdateUserInfo()
        {
            if (!CurrentUser.isGuest)
            {
                usernameText.Text = "Username: " + CurrentUser.Username;
                emailText.Text = "Email: " + CurrentUser.Email;
                changePasswordButton.Visibility = Visibility.Visible;
            }
            else
            {
                usernameText.Text = "Username: You are Guest";
                emailText.Visibility = 0;
                changePasswordButton.Visibility = Visibility.Collapsed;

            }
        }

        private void changePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ChangePassword));
        }
    }
}
