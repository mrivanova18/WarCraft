using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarCraft.Core.Contracts;
using WarCraft.Core.Services;
using WarCraft.Infrastructure.Data.Entities;
using WarCraft.Models.ContactUs;
using WarCraft.Models.Order;
using WarCraft.Models.Product;

namespace WarCraft.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        // GET: ContactUsController
        public ActionResult Index()
        {
            List<ContactUsIndexVM> message = _contactUsService.GetMessage()
                .Select(item => new ContactUsIndexVM()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Message = item.Message
                }).ToList();
            return View(message);
        }

        // GET: ContactUsController/Create
        public ActionResult Create(int id)
        {            
            return View();
        }

        // POST: ContactUsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ContactUsCreateVM item)
        {
            if (ModelState.IsValid)
            {
                var createdId = _contactUsService.Create(item.FirstName,item.LastName,item.Email,item.Message);
                if (createdId)
                {
                    return RedirectToAction("Success");
                }
            }
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}
