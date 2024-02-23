using System.ComponentModel.DataAnnotations;

namespace WarCraft.Models.ContactUs
{
    public class ContactUsVM
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; } = null!;
    }
}
