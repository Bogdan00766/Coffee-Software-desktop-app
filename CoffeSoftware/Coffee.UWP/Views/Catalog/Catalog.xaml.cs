﻿using Coffe.Domain;
using Coffe.Domain.Models;
using Coffe.Infrastructure;
using Coffee.Uwp.ViewsModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Coffee.Uwp.Views.Catalog
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Catalog : Page
    {
        public ProductViewModel ProductViewModel { get; set; }
        public Catalog()
        {
            this.InitializeComponent();

            ProductViewModel = new ProductViewModel();

        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ProductViewModel.LoadAllAsync();
        }

        private async void AddCartButton_Click(object sender, RoutedEventArgs e)
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
                    var user = await uow.UserRepository.FindByEmailAsync(CurrentUser.Email);
                    OrderList list = new OrderList();
                    var obj = (Product)listOfProducts.SelectedItem;
                    list.Name = obj.Name;
                    list.CreationTime = "34";
                    list.User = user;
                    list = uow.OrderListRepository.Create(list);
                   
                    OrderListProduct listProduct = new OrderListProduct();
                    listProduct.OrderListId = list.Id;
                    listProduct.ProductId = obj.Id;
                    uow.OrderListProductRepository.Create(listProduct);
                    await uow.SaveAsync();
                }
            }
        }

        private async void AddFacoriteButton_Click(object sender, RoutedEventArgs e)
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
                    var user = await uow.UserRepository.FindByEmailAsync(CurrentUser.Email);
                    var obj = (Product)listOfProducts.SelectedItem;

                    Favorite favoriteProduct = new Favorite();
                    favoriteProduct.User = user;
                    favoriteProduct.ProductId = obj.Id;
                    uow.FavoriteRepository.Create(favoriteProduct);
                    await uow.SaveAsync();
                }
            }

        }
    }
}