using Coffe.Domain;
using Coffe.Domain.Models;
using Coffe.Infrastructure;
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

namespace Coffee.Uwp.Views.Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Menu : Page
    {
        public ProductViewModel  ProductViewModel { get; set; }
        public Menu()
        {
            
            ProductViewModel = new ProductViewModel();
            this.InitializeComponent();
            if (CurrentUser.IsAdmin)
            {
                AddButton.Visibility = Visibility.Visible;
            }
            else
            {
                AddButton.Visibility = Visibility.Collapsed;
            }
            
            //add isAdmin check for buttons :) 
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ProductViewModel.LoadAllAsync();
            base.OnNavigatedTo(e);
        }
        private async void DeleteConfirmationButton_Click(object sender, RoutedEventArgs e)
        {
            var product = (Product)productList.SelectedItem;
            IUnitOfWork uow = new UnitOfWork();
            //var prod = await uow.ProductRepository.FindByIdAsync(product.Id);
            uow.ProductRepository.Delete(product);
            await uow.SaveAsync();
            this.Frame.Navigate(typeof(Menu));
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            
            var product = (Product)productList.SelectedItem;
            if (product != null)
            {
                infoText.Text = product.Id + "x" + product.Name + "x" + product.Price;
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
