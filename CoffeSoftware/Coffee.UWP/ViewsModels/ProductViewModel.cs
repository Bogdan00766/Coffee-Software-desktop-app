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

    public class ProductViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
        

        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>();
        }

        public async Task LoadAllAsync()
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                List<Product> list = await uow.ProductRepository.FindAllAsync();
                Products.Clear();
                foreach (Product c in list)
                {
                    Products.Add(c);
                }
            }
        }
    }
}
