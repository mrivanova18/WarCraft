using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft.Infrastructure.Data.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string ManufacturerName { get; set; } = null!;
       // public string CountryOfOrigin { get; set; } = null!;
        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
