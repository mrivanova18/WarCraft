using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarCraft.Core.Contracts;
using WarCraft.Core.Services;
using WarCraft.Infrastructure.Data.Entities;
using WarCraft.Models.ContactUs;
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
            List<ContactUsVM> message = _contactUsService.GetMessage()
                .Select(item => new ContactUsVM()
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
        public ActionResult Create()
        {            
            return View();
        }

        // POST: ContactUsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ContactUsVM item)
        {
            if (ModelState.IsValid)
            {
                _contactUsService.Create(item.FirstName,item.LastName,item.Email,item.Message);
                return RedirectToAction("Success");                
            }
            return View(item);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}
