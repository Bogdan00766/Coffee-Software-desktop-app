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

    public class CartViewModel
    {
        public ObservableCollection<Product> ListProducts { get; set; }
        

        public CartViewModel()
        {
            ListProducts = new ObservableCollection<Product>();
        }

        public async Task LoadAllForUserAsync(int id)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                List<Product> list = await uow.ProductRepository.FindAllForUserAsync(id);
                ListProducts.Clear();
                foreach (Product c in list)
                {
                    if (c != null)
                    {
                        ListProducts.Add(c);
                    }
                }
            }
        }

        public async Task LoadAllAsync()
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                List<Product> list = await uow.ProductRepository.FindAllAsync();
                ListProducts.Clear();
                foreach (Product c in list)
                {
                    ListProducts.Add(c);
                }
            }
        }
        //public async Task LoadAllAsync()
        //{
        //    using (IUnitOfWork uow = new UnitOfWork())
        //    {
        //        List<OrderListProduct> list = await uow.OrderListProductRepository.FindAllAsync();
        //        ListProducts.Clear();
        //        foreach (OrderListProduct p in list)
        //        {
        //            ListProducts.Add(p);
        //        }
        //        ////////////////////////////////////////////////////////////////////////////////////////////
        //        //foreach (OrderListProduct p in db.OrderListProduct.Include(p => p.Product))
        //        //{
        //        //    foreach (OrderListProduct ol in db.OrderListProduct.Include(ol => ol.OrderList))
        //        //    {
        //        //        ListProducts.Add(p);
        //        //        ListProducts.Add(ol);
        //        //    }
        //        //}
        //    }
        //}
    }
}
