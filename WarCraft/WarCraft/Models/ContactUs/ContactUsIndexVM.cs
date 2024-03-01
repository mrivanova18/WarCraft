using System.ComponentModel.DataAnnotations;

namespace WarCraft.Models.ContactUs
{
    public class ContactUsIndexVM
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Display(Name = "Message")]
        public string Message { get; set; } = null!;
    }
}
