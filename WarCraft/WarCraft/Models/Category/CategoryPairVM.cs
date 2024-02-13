using System.ComponentModel.DataAnnotations;

namespace WarCraft.Models.Category
{
    public class CategoryPairVM
    {
        public int Id { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; } = null!;
       // [Display(Name = "Type")]
      //  public string Type { get; set; } = null!;
    }
}
