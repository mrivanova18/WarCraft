using System.ComponentModel.DataAnnotations;

namespace WarCraft.Models.PersonalOrder
{
    public class PersonalOrderDeleteVM
    {
        public int Id { get; set; }

        [Display(Name = "Order Date")]

        public DateTime OrderDate { get; set; }

        public string UserId { get; set; } = null!;
        [Display(Name = "User")]
        public string User { get; set; } = null!;

        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; } = null!;

        [Display(Name = "Name of product")]
        public string NameOfProduct { get; set; } = null!;

        [Display(Name = "Image")]
        public string Image { get; set; } = null!;

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
