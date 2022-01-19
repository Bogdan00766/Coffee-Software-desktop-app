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
    public class OrderListProductViewModel
    {
        public ObservableCollection<Product> OrderListProducts { get; set; }


        public OrderListProductViewModel()
        {
            OrderListProducts = new ObservableCollection<Product>();
        }

        public async Task LoadAllForUserAsync(int id)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                List<Product> list = await uow.ProductRepository.FindAllForUserAsync(id);
                OrderListProducts.Clear();
                foreach (Product c in list)
                {
                    OrderListProducts.Add(c);
                }
            }
        }
    }
}
