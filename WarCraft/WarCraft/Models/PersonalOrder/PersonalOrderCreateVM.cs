using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WarCraft.Infrastructure.Data.Entities;
using WarCraft.Models.Category;

namespace WarCraft.Models.PersonalOrder
{
    public class PersonalOrderCreateVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Order Date")]

        public DateTime OrderDate { get; set; }

        [Required]
        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual List<CategoryPairVM> Categories { get; set; } = new List<CategoryPairVM>();

        [Required]
        [MaxLength(40)]
        [Display(Name = "Name of product")]
        public string NameOfProduct { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        [Required]
        [Range(1, 50)]
        public int Quantity { get; set; }
    }
}
