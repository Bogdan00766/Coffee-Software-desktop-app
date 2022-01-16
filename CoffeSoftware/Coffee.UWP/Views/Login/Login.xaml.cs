using Coffe.Domain;
using Coffe.Infrastructure;
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

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Coffee.Uwp.Views.Login
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
           this.Frame.Navigate(typeof(Register));
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e) 
        {
            if (emailText.Text == String.Empty)
            {
                infoText.Text = "Email cannot be empty";
            }
            else
            {
                if (passwordText.Text == String.Empty)
                {
                    infoText.Text = "Password cannot be empty";
                }
                else
                {
                    IUnitOfWork uow = new UnitOfWork();
                    if (await uow.UserRepository.isRegisteredAsync(emailText.Text))
                    {

                        infoText.Text = "";
                    }
                    else
                    {
                        infoText.Text = "User is not found!";
                    }
                }
            }

        }
    }
}
