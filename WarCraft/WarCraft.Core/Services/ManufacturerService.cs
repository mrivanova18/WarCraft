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
    public class ManufacturerService : IManufacturerService
    {
        private readonly ApplicationDbContext _context;
        public ManufacturerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Manufacturer GetManufacturerById(int manufacturerId)
        {
            return _context.Manufacturers.Find(manufacturerId);
        }

        public List<Manufacturer> GetManufacturers()
        {
            List<Manufacturer> manufacturers = _context.Manufacturers.ToList();
            return manufacturers;
        }

        public List<Product> GetProductsByManufacturer(int manufacturerId)
        {
            return _context.Products
                .Where(x => x.ManufacturerId == manufacturerId).ToList();
        }
    }
}
