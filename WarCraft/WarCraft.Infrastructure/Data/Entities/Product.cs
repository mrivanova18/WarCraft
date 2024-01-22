using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft.Infrastructure.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        [Required]
        [MaxLength(40)]
        public string Type { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(10,1000)]
        public decimal Price { get; set; }

        [Required]
        [Range(0,2000)]
        public int QuantityAvailable { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        public int Discount { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
