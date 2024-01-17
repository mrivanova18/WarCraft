﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft.Infrastructure.Data.Entities
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(40)]
        public string LastName { get; set; } = null!;
        [Required]
        [MaxLength(40)]
        public string Address { get; set; } = null!;
    }
}
