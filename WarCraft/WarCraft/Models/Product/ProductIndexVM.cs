using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WarCraft.Infrastructure.Data.Entities;
using WarCraft.Models.Category;

namespace WarCraft.Models.Product
{
    public class ProductIndexVM
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; } = null!;

        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Available Quantity")]
        public int QuantityAvailable { get; set; }

        public int ManufacturerId { get; set; }
        [Display(Name = "Manufacturer")]
        public string ManufacturerName { get; set; } = null!;

        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

        [Display(Name = "Image")]
        public string Image { get; set; } = null!;

        [Display(Name = "Discount")]
        public int Discount { get; set; }
    }
}