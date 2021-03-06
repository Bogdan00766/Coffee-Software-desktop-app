using Coffe.Domain;
using Coffe.Domain.Models;
using Coffe.Infrastructure;
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

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Coffee.Uwp.Views.Catalog
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class AddProduct : Page
    {

        public AddProduct()
        {
            this.InitializeComponent();
            
        }
        private async void addProductButton_Click(object sender, RoutedEventArgs e)
        {



            if (productNameText.Text == String.Empty) infoText.Text = "Name cannot be empty!";
            else if (priceText.Text == String.Empty) infoText.Text = "Price cannot be empty!";
            else if (categoryText.Text == String.Empty) infoText.Text = "Category cannot be empty!";
            else if (shopNameText.Text == String.Empty) infoText.Text = "Shop name cannot be empty!";
            else 
            {               
                IUnitOfWork uow = new UnitOfWork();

                Category cat = new Category();
                cat.Name = categoryText.Text;
                cat = uow.CategoryRepository.Create(cat);

                Shop shop = new Shop();
                shop.Name = shopNameText.Text;
                shop = uow.ShopRepository.Create(shop);

                Product product = new Product();
                product.Name = productNameText.Text;
                product.Price = float.Parse(priceText.Text);
                product.Category = cat;
                product.Shop = shop;

                uow.ProductRepository.Create(product);
                await uow.SaveAsync();

                ContentDialog AddProductSuccessDialog = new ContentDialog()
                {
                    Title = "Add product Success!",
                    Content = "Product created sucessfully!",
                    CloseButtonText = "Ok!"
                };

                this.Frame.Navigate(typeof(Catalog));
                await AddProductSuccessDialog.ShowAsync();
            }
        }

        private async void updateProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (productNameText.Text == String.Empty) infoText.Text = "Name cannot be empty!";
            else if (priceText.Text == String.Empty) infoText.Text = "Price cannot be empty!";
            else if (categoryText.Text == String.Empty) infoText.Text = "Category cannot be empty!";
            else if (shopNameText.Text == String.Empty) infoText.Text = "Shop name cannot be empty!";
            else
            {
                IUnitOfWork uow = new UnitOfWork();

                Category cat = new Category();
                cat.Name = categoryText.Text;
                cat = uow.CategoryRepository.Create(cat);

                Shop shop = new Shop();
                shop.Name = shopNameText.Text;
                shop = uow.ShopRepository.Create(shop);

                var product = await uow.ProductRepository.FindByNameAsync(productNameText.Text);

                product.Price = float.Parse(priceText.Text);
                product.Category = cat;
                product.Shop = shop;

                uow.ProductRepository.Update(product);
                await uow.SaveAsync();

                ContentDialog UpdateProductSuccessDialog = new ContentDialog()
                {
                    Title = "Update product Success!",
                    Content = "Product updated sucessfully!",
                    CloseButtonText = "Ok!"
                };

                this.Frame.Navigate(typeof(Catalog));
                await UpdateProductSuccessDialog.ShowAsync();
            }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var prod = (Product)e.Parameter;
            if (prod != null)
            {
                Product prod2;
                using (IUnitOfWork uow = new UnitOfWork())
                {
                    prod2 = await uow.ProductRepository.FindByNameAsync(prod.Name);
                }

                productNameText.Text = prod2.Name;
                priceText.Text = prod2.Price.ToString();
                categoryText.Text = prod2.Category.Name;
                shopNameText.Text = prod2.Shop.Name;

                addProductButton.Visibility = Visibility.Collapsed;
                updateProductButton.Visibility = Visibility.Visible;
                productNameText.IsReadOnly = true;
            }
            //SetProd();
            //if (prod != null)
            //{
            //    productNameText.Text = prod.Name;
            //    priceText.Text = prod.Price.ToString();

            //}
        }

    }
}
