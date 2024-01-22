using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft.Infrastructure.Data.Entities
{
    public class PersonalOrder
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; } = null!;
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        [Required]
        [MaxLength(40)]
        public string NameOfProduct { get; set; } = null!;
        [Required]
        [MaxLength(40)]
        public string Type { get; set; } = null!;
        [Required]
        public string Image { get; set; } = null!;
    }
}
