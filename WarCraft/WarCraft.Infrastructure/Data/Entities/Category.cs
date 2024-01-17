using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft.Infrastructure.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Planes { get; set; } = null!;
        public string Tanks { get; set; } = null!;
        public string Ship { get; set; } = null!;
    }
}
