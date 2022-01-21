
﻿using Coffe.Domain;
using Coffe.Domain.Models;
using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Infrastructure.Repositories
{
    class OrderListProductRepository : Repository<OrderListProduct>, IOrderListProductRepository
    {
        public OrderListProductRepository(CoffeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> AssignId()
        {
            var lastRecord = _dbContext.OrderListProduct.OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastRecord != null)
            {
                return Task.FromResult(lastRecord.Id + 1);
            }
            else return Task.FromResult(1);
        }

        public Task<bool> CheckIfExist(int productId, int listId)
        {
            bool output = true;
            try
            {
                _dbContext.OrderListProduct.Where(x => x.ProductId == productId).Where(y => y.OrderListId == listId).First();
            }
            catch(Exception e)
            {
                output = false;
                return Task.FromResult(output); 

            }
            output = true;
            return Task.FromResult(output);
        }

        public new OrderListProduct Create(OrderListProduct list)
        {
            var existinglist = _dbContext.OrderListProduct
                .Where(x => x.OrderListId == list.OrderListId)
                .Where(x => x.ProductId == list.ProductId)
                .FirstOrDefault();
            if (existinglist == null)
            {
                _dbContext.Add(list);
                return list;
            }
            else
            {
                return existinglist;
            }


        }
    }
}

