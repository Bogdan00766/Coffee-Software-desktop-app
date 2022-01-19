<<<<<<< HEAD
﻿using Coffe.Domain;
using Coffe.Domain.Models;
using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using Coffe.Domain.Models;
using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
>>>>>>> 2c8a6df80365134ed8e21a964d815fa9ca6d5d58

namespace Coffe.Infrastructure.Repositories
{
    class OrderListProductRepository : Repository<OrderListProduct>, IOrderListProductRepository
    {
        public OrderListProductRepository(CoffeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
<<<<<<< HEAD

       

    }
}
=======
    }
}
>>>>>>> 2c8a6df80365134ed8e21a964d815fa9ca6d5d58
