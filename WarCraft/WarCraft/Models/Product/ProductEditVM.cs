using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WarCraft.Infrastructure.Data.Entities;
using WarCraft.Models.Category;
using WarCraft.Models.Manufacturer;

namespace WarCraft.Models.Product
{
    public class ProductEditVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual List<CategoryPairVM> Categories { get; set; } = new List<CategoryPairVM>();

        [Required]
        [MaxLength(30)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(10, 1000)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 2000)]
        [Display(Name = "Available Quantity")]
        public int QuantityAvailable { get; set; }

        [Required]
        [ForeignKey("Manufacturer")]
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }
        public virtual List<ManufacturerPairVM> Manufacturers { get; set; } = new List<ManufacturerPairVM>();

        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; } = null!;

        [Display(Name = "Discount")]
        public int Discount { get; set; }
    }
}
