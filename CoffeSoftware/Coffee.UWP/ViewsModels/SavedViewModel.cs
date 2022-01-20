using Coffe.Domain;
using Coffe.Domain.Models;
using Coffe.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Uwp.ViewsModels
{
    public class SavedViewModel
    {
        public ObservableCollection<Product> Favorites { get; set; }


        public SavedViewModel()
        {
            Favorites = new ObservableCollection<Product>();
        }

        public async Task LoadAllAsync()
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                List<Product> fav = await uow.ProductRepository.FindAllFavoriteAsync(CurrentUser.Id);
                Favorites.Clear();
                foreach (Product f in fav)
                {
                    Favorites.Add(f);
                } }
        }

        public async Task FindAllFavoriteAsync(int id)
            {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                 List<Product> fav = await uow.ProductRepository.FindAllFavoriteAsync(id);
                Favorites.Clear();
                 foreach (Product f in fav)
                 {
                    Favorites.Add(f);
                 }
            }
                }
                ////////////////////////////////////////////////////////////////////////////////////////////
                //foreach (OrderListProduct p in db.OrderListProduct.Include(p => p.Product))
                //{
                //    foreach (OrderListProduct ol in db.OrderListProduct.Include(ol => ol.OrderList))
                //    {
                //        ListProducts.Add(p);
                //        ListProducts.Add(ol);
                //    }
                //}
    }
}
