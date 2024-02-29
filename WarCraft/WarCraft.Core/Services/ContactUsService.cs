using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCraft.Core.Contracts;
using WarCraft.Infrastructure.Data;
using WarCraft.Infrastructure.Data.Entities;

namespace WarCraft.Core.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly ApplicationDbContext _context;
        public ContactUsService(ApplicationDbContext context) 
        {  
            _context = context; 
        }
        public bool Create(string firstName, string lastName, string email, string message)
        {
            ContactUs contactUs = new ContactUs()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Message = message
            };
            return _context.SaveChanges() != 0;
        }

        public List<ContactUs> GetMessage()
        {
            return _context.ContactUs.ToList();
        }
    }
}
