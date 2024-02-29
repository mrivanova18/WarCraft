using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WarCraft.Infrastructure.Data.Entities;

namespace WarCraft.Models.PersonalOrder
{
    public class PersonalOrderIndexVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Order Date")]

        public string OrderDate { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public string User { get; set; } = null!;

        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; } = null!;

        [Required]
        [MaxLength(40)]
        [Display(Name = "Name of product")]
        public string NameOfProduct { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }
    }
}

