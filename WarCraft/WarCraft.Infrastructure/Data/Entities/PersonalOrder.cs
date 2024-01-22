using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft.Infrastructure.Data.Entities
{
    public class PersonalOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; } = null!;
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public string NameOfProduct { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
