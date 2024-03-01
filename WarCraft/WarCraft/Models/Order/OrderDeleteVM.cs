using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarCraft.Infrastructure.Data.Entities;

namespace WarCraft.Models.Order
{
    public class OrderDeleteVM
    {      
        public int Id { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        
        public int ProductId { get; set; }
        [Display(Name = "Product")]
        public string Product { get; set; } = null!;
        
        public string UserId { get; set; } = null!;
        [Display(Name = "User")]
        public string User { get; set; } = null!;
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
    }
}
