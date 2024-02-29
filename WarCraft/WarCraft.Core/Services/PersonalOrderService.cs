using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCraft.Core.Contracts;
using WarCraft.Infrastructure.Data;
using WarCraft.Infrastructure.Data.Entities;

namespace WarCraft.Core.Services
{
    public class PersonalOrderService : IPersonalOrderService
    {
        private readonly ApplicationDbContext _context;

        public PersonalOrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string userId, int categoryId, string name, string image, int quantity)
        {
            PersonalOrder item = new PersonalOrder
            {
                OrderDate = DateTime.Now,
                UserId = userId,
                Category = _context.Categories.Find(categoryId),
                NameOfProduct = name,
                Image = image,
                Quantity = quantity
            };
            this._context.PersonalOrders.Add(item);
            return _context.SaveChanges() != 0;
        }

        public PersonalOrder GetOrderById(int orderId)
        {
            return _context.PersonalOrders.Find(orderId);
        }

        public List<PersonalOrder> GetOrders()
        {
            return _context.PersonalOrders.OrderByDescending(x => x.OrderDate).ToList();
        }

        public List<PersonalOrder> GetOrdersByUser(string userId)
        {
            return _context.PersonalOrders.Where(x => x.UserId == userId)
                .OrderByDescending(x => x.OrderDate).ToList();
        }

        public bool RemoveById(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order == default(PersonalOrder))
            {
                return false;
            }
            _context.Remove(order);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int productId, string userId, int categoryId, string name, string image, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
