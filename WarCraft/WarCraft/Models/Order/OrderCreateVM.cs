using System.ComponentModel.DataAnnotations;

namespace WarCraft.Models.Order
{
    public class OrderCreateVM
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int QuantityInStock { get; set; }
        public string? Image { get; set; }
        [Range(1, 50)]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
