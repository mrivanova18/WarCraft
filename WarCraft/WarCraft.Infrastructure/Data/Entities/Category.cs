using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft.Infrastructure.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
