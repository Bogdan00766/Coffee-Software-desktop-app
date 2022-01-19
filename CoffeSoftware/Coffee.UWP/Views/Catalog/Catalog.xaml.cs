using Coffe.Domain;
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
    }
}
