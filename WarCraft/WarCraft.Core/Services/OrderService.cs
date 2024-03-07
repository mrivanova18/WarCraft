﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WarCraft.Core.Contracts;
using WarCraft.Infrastructure.Data;
using WarCraft.Infrastructure.Data.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace WarCraft.Core.Services
{
    public class OrderService:IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(int productId, string userId, int quantity)
        {
            var product = this._context.Products.SingleOrDefault(x => x.Id == productId);
            if (product == null) 
            {
                return false;
            }

            Order item = new Order
            {
                OrderDate = DateTime.Now,
                ProductId = productId,
                UserId = userId,
                Quantity = quantity,
                Price = product.Price,
                Discount = product.Discount
            };
            product.QuantityAvailable -= quantity;
            this._context.Products.Update(product);
            this._context.Orders.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Order GetOrderById(int orderId)
        {
            return _context.Orders.Find(orderId);
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.OrderByDescending(x=>x.OrderDate).ToList();
        }

        public List<Order> GetOrdersByUser(string userId)
        {
            return _context.Orders.Where(x => x.UserId == userId)
                .OrderByDescending(x => x.OrderDate).ToList();
        }

        public bool RemoveById(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            var product = _context.Products.Find(order.ProductId);
            if (product == default(Product))
            {
                return false;
            }            
            product.QuantityAvailable += order.Quantity;
            _context.Update(product);
            _context.Orders.Remove(order);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int orderId, int productId, string userId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}