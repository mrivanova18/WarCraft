using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCraft.Infrastructure.Data.Entities;

namespace WarCraft.Core.Contracts
{
    public interface IProductService
    {
        bool Create(int categoryId, string name, decimal price, int quantityAvailable,
            int manufacturerId, string description, string image, int discount);
        bool Update(int productId, int categoryId, string name, decimal price, int quantityAvailable,
            int manufacturerId, string description, string image, int discount);
        List<Product> GetProducts();
        Product GetProductById(int productId);
        bool RemoveById(int productId);
        List<Product> GetProducts(string searchStringCategoryName, string searchStringManufacturerName);
    }
}
