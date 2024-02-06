using System;
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
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(int categoryId, string name, decimal price, int quantityAvailable, int manufacturerId, string description, string image, int discount)
        {
            Product item = new Product
            {
                Category = _context.Categories.Find(categoryId),
                Name = name,
                Price = price,
                QuantityAvailable = quantityAvailable,
                Manufacturer = _context.Manufacturers.Find(manufacturerId),
                Description = description,
                Image = image,
                Discount = discount
            };
            _context.Products.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public List<Product> GetProducts()
        {
            List<Product> products = _context.Products.ToList();
            return products;
        }

        public List<Product> GetProducts(string searchStringCategoryName, string searchStringManufacturerName)
        {
            List<Product> products = _context.Products.ToList();
            if (!String.IsNullOrEmpty(searchStringCategoryName) && !String.IsNullOrEmpty(searchStringManufacturerName)) 
            {
                products = products.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName.ToLower())
                    && x.Manufacturer.ManufacturerName.ToLower().Contains(searchStringManufacturerName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringCategoryName))
            {
                products = products.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringManufacturerName))
            {
                products = products.Where(x => x.Manufacturer.ManufacturerName.ToLower().Contains(searchStringManufacturerName.ToLower())).ToList();
            }
            return products;
        }

        public bool RemoveById(int productId)
        {
            var product = GetProductById(productId);
            if (product == default(Product))
            {
                return false;
            }
            _context.Remove(product);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int productId, int categoryId, string name, decimal price, int quantityAvailable, int manufacturerId, string description, string image, int discount)
        {
            var product = GetProductById(productId);
            if (product == default(Product))
            {
                return false;
            }
            product.Category = _context.Categories.Find(categoryId);
            product.Name = name;
            product.Price = price;
            product.QuantityAvailable = quantityAvailable;
            product.Manufacturer = _context.Manufacturers.Find(manufacturerId);
            product.Description = description;
            product.Image = image;
            product.Discount = discount;
            _context.Update(product);
            return _context.SaveChanges() != 0;
        }
    }
}
