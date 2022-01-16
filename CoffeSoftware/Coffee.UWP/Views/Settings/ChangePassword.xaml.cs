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
    public sealed partial class ChangePassword : Page
    {
        public ChangePassword()
        {
            this.InitializeComponent();
        }

        private async void changePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentUser.Password != oldPasswordText.Text)
            {
                infoText.Text = "Wrong Password!";                
            }
            else if(newPasswordText.Text.Length < 5)
            {
                infoText.Text = "New Password is too short!";
            }
            else if (newPasswordText.Text == oldPasswordText.Text)
            {
                infoText.Text = "New and old passwords are the same!";
            }
            else
            {
                infoText.Text = "";
                IUnitOfWork uow = new UnitOfWork();
                var user = await uow.UserRepository.FindByIdAsync(CurrentUser.Id);

                user.Password = newPasswordText.Text;
                uow.UserRepository.Update(user);
                await uow.SaveAsync();
                CurrentUser.Password = newPasswordText.Text;

                ContentDialog ChangePasswordSuccessDialog = new ContentDialog()
                {
                    Title = "Success!",
                    Content = "Your password is changed!",
                    CloseButtonText = "Ok!"
                };

                this.Frame.Navigate(typeof(Settings)); ;
                await ChangePasswordSuccessDialog.ShowAsync();
            }
        }
    }
}
