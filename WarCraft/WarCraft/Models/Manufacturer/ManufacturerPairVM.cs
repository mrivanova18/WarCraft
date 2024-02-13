using System.ComponentModel.DataAnnotations;

namespace WarCraft.Models.Manufacturer
{
    public class ManufacturerPairVM
    {
        public int Id { get; set; }

        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; } = null!;

      //  [Display(Name = "Country of origin")]
      //  public string CountryOfOrigin { get; set; } = null!;
    }
}
