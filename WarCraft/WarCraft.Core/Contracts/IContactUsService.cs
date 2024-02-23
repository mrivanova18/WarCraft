using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCraft.Infrastructure.Data.Entities;

namespace WarCraft.Core.Contracts
{
    public interface IContactUsService
    {
        bool Create(int id, string firstName, string lastName, string email, string message);
        List<ContactUs> GetMessage();
    }
}
