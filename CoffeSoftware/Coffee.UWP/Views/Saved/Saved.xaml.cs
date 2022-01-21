using Coffee.Uwp.ViewsModels;
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
using Coffe.Domain;
using Coffe.Infrastructure;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Coffee.Uwp.Views.Saved
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Saved : Page
    {
        public SavedViewModel SavedViewModel { get; set; }
        public Saved()
        {
            this.InitializeComponent();

            SavedViewModel = new SavedViewModel();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await SavedViewModel.FindAllFavoriteAsync(CurrentUser.Id);
            base.OnNavigatedTo(e);
        }

        private async void clearSaved_Click(object sender, RoutedEventArgs e)
        {
            IUnitOfWork uow = new UnitOfWork();
            await uow.ProductRepository.ClearAllFavoriteAsync(CurrentUser.Id);
            await uow.SaveAsync();
            this.Frame.Navigate(typeof(Saved));
        }
    }
}
