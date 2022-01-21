

﻿using Coffe.Domain;
using Coffe.Domain.Models;
using Coffe.Infrastructure;
using Coffee.Uwp.Views.Payment;
using Coffee.Uwp.ViewsModels;
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

namespace Coffee.Uwp.Views.Cart
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Cart : Page
    {


        public CartViewModel CartViewModel { get; set; }

        public Cart()
        {
            //OrderListProductViewModel = new OrderListProductViewModel();
            CartViewModel = new CartViewModel();
            this.InitializeComponent();

            //CartViewModel = new CartViewModel();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await CartViewModel.LoadAllForUserAsync(CurrentUser.Id);
            sumTextf();
            base.OnNavigatedTo(e);
        }

        float summary()
        {
            float sum = 0;
            foreach (Product prod in CartViewModel.ListProducts)
            {
                if (prod != null)
                {
                    sum += prod.Price;
                }
            }
            return sum;
        }

        void sumTextf()
        {
            float sum = summary();
            sumText.Text = "Full price: " + sum.ToString() + " €";
        }

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            DataBank.Text = summary().ToString();
            this.Frame.Navigate(typeof(Card));
        }

        private async void clearCart_Click(object sender, RoutedEventArgs e)
        {
            IUnitOfWork uow = new UnitOfWork();
            await uow.ProductRepository.ClearAllForUserAsync(CurrentUser.Id);
            await uow.SaveAsync();
            this.Frame.Navigate(typeof(Cart));
        }


        //protected override async void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    await OrderListProductViewModel.LoadAllForUserAsync(CurrentUser.Id);
        //    base.OnNavigatedTo(e);
        //}
    }
}
