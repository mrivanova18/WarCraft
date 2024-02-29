using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCraft.Infrastructure.Data.Entities;

namespace WarCraft.Core.Contracts
{
    public interface IPersonalOrderService
    {
        bool Create(string userId, int categoryId, string name, string image, int quantity);
        List<PersonalOrder> GetOrders();
        List<PersonalOrder> GetOrdersByUser(string userId);
        PersonalOrder GetOrderById(int orderId);
        bool RemoveById(int orderId);
        bool Update(int productId, string userId, int categoryId, string name, string image, int quantity);
    }
}
