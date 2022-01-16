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
    public sealed partial class Register : Page
    {
        public Register()
        {
            this.InitializeComponent();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            if(emailText.Text == String.Empty)
            {
                infoText.Text = "Email cannot be empty!"; 
            }
            else
            {
                if (usernameText.Text == String.Empty)
                {
                    infoText.Text = "Username cannot be empty!";
                }
                else
                {
                    if (passwordText.Text == String.Empty)
                    {
                        infoText.Text = "Password cannot be empty!";
                    }
                    else
                    {
                        if (streetText.Text == String.Empty)
                        {
                            infoText.Text = "Street cannot be empty!";
                        }
                        else
                        {
                            if (cityText.Text == String.Empty)
                            {
                                infoText.Text = "City cannot be empty!";
                            }
                            else
                            {
                                if (postalCodeText.Text == String.Empty)
                                {
                                    infoText.Text = "Postal code cannot be empty!";
                                }
                                else
                                {
                                    if (!int.TryParse(postalCodeText.Text, out _))
                                    {
                                        infoText.Text = "Postal code has to be a number!";
                                    }
                                    else
                                    {
                                        if (!emailText.Text.Contains('@'))
                                        {
                                            infoText.Text = "Wrong e-mail addres!";
                                        }
                                        else
                                        {
                                            if (passwordText.Text.Length<5)
                                            {
                                                infoText.Text = "Password is to short (at least 5 characters)";
                                            }
                                            else
                                            {
                                                //
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
