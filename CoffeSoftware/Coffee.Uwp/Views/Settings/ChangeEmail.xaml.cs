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

namespace Coffee.Uwp.Views.Settings
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class ChangeEmail : Page
    {
        public ChangeEmail()
        {
            this.InitializeComponent();
        }

        private async void changeEmailButton_Click(object sender, RoutedEventArgs e)
        {
            if (!newEmailText.Text.Contains('@')) infoText.Text = "Wrong email!";
            else
            {
                infoText.Text = "";
                IUnitOfWork uow = new UnitOfWork();
                if(await uow.UserRepository.isRegisteredAsync(CurrentUser.Email))
                {
                    var user = await uow.UserRepository.FindByEmailAsync(CurrentUser.Email);
                    user.Email = newEmailText.Text;
                    uow.UserRepository.Update(user);
                    await uow.SaveAsync();
                    CurrentUser.Email = newEmailText.Text;

                    ContentDialog ChangeEmailSuccessDialog = new ContentDialog()
                    {
                        Title = "Success!",
                        Content = "Your email is changed!",
                        CloseButtonText = "Ok!"
                    };

                    this.Frame.Navigate(typeof(Settings)); ;
                    await ChangeEmailSuccessDialog.ShowAsync();

                }
                else infoText.Text = "Error. Log in once again, please";
            }
        }
    }
}
