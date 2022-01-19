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
        public ObservableCollection<OrderListProduct> ListProducts { get; set; }
        

        public CartViewModel()
        {
            ListProducts = new ObservableCollection<OrderListProduct>();
        }

        //public async Task LoadAllAsync()
        //{
        //    using (IUnitOfWork uow = new UnitOfWork())
        //    {
        //        List<OrderListProduct> list = await uow.OrderListProduct.FindAllAsync();
        //        ListProducts.Clear();
        //        foreach (OrderListProduct c in list)
        //        {
        //            ListProducts.Add(c);
        //        }
        //        ////////////////////////////////////////////////////////////////////////////////////////////
        //        foreach (OrderListProduct p in db.OrderListProduct.Include(p => p.Product)) { 
        //            foreach (OrderListProduct ol in db.OrderListProduct.Include(ol => ol.OrderList)) {
        //                ListProducts.Add(p);
        //                ListProducts.Add(ol);
        //            }
        //        }
        //        Console.WriteLine("{0} - {1}", pl.Name, pl.Team != null ? pl.Team.Name : "");
        //        Console.WriteLine();
        //        foreach (Team t in db.Teams.Include(t => t.Players))
        //        {
        //            Console.WriteLine("Команда: {0}", t.Name);
        //            foreach (Player pl in t.Players)
        //            {
        //                Console.WriteLine("{0} - {1}", pl.Name, pl.Position);
        //            }
        //            Console.WriteLine();
        //        }


        //    }
        //}
    }
}
