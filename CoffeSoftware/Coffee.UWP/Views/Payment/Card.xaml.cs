using Coffe.Domain;
using Coffe.Infrastructure;
using Coffe.Domain.Models;
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
using Coffee.Uwp.ViewsModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Coffee.Uwp.Views.Payment
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Card : Page
    {
        public Card()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SumText.Text = DataBank.Text;

        }

        private async void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            bool isRegistered = false;
            using (IUnitOfWork uow = new UnitOfWork())
            {

                if (await uow.UserRepository.isRegisteredAsync(CurrentUser.Email))
                {
                    isRegistered = true;
                }
                else { infoText.Text = "Error. Log in once again, please"; }

                if (isRegistered)
                {
                    if (cardNumberText.Text == String.Empty) infoText.Text = "Card Number cannot be empty!";
                    else if (CVVText.Text == String.Empty) infoText.Text = "String CVV cannot be empty!";
                    else if (cardNameText.Text == String.Empty) infoText.Text = "Card Name cannot be empty!";
                    else if(!int.TryParse(cardNumberText.Text, out _)) infoText.Text = "Wrong card number!";
                    else if (!int.TryParse(CVVText.Text, out _)) infoText.Text = "Wrong CVV number!";
                    else
                    {
                        var user = await uow.UserRepository.FindByEmailAsync(CurrentUser.Email);

                        Coffe.Domain.Models.Payment card = new Coffe.Domain.Models.Payment();
                        card.CardNumber = int.Parse(cardNumberText.Text);
                        card.CVV = int.Parse(CVVText.Text);
                        card.CardName = cardNameText.Text;
                        //////////
                        card.Sum = int.Parse(SumText.Text);
                        card.User = user;
                        uow.PaymentRepository.Create(card);
                        await uow.SaveAsync();

                        ContentDialog ShoppingSuccessDialog = new ContentDialog()
                        {
                            Content = "Congratulations! Your shopping success",
                            CloseButtonText = "Ok!"
                        };
                        this.Frame.Navigate(typeof(Views.Cart.Cart));
                        await ShoppingSuccessDialog.ShowAsync();
                    }
                }
            }
        }
    }
}
