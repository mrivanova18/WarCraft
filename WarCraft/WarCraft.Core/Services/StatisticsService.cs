﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCraft.Core.Contracts;
using WarCraft.Infrastructure.Data;

namespace WarCraft.Core.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _context;
        public StatisticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int CountClients()
        {
            return _context.Users.Count() - 1;
        }

        public int CountOrders()
        {
            return _context.Orders.Count();
        }

        public int CountProducts()
        {
            return _context.Products.Count();
        }

        public decimal SumOrders()
        {
            var sum = _context.Orders.Sum(x => x.Quantity * x.Price - x.Quantity * x.Price * x.Discount / 100);
            return sum;
        }
    }
}
