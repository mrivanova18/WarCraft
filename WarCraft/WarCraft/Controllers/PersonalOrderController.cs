using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Globalization;
using System.Security.Claims;
using WarCraft.Core.Contracts;
using WarCraft.Core.Services;
using WarCraft.Infrastructure.Data.Entities;
using WarCraft.Models.Category;
using WarCraft.Models.PersonalOrder;
using WarCraft.Models.Product;

namespace WarCraft.Controllers
{
    public class PersonalOrderController : Controller
    {
        private readonly IPersonalOrderService _personalOrderService;
        private readonly ICategoryService _categoryService;

        public PersonalOrderController(IPersonalOrderService personalOrderService, ICategoryService categoryService)
        {
            _personalOrderService = personalOrderService;
            _categoryService = categoryService;
        }

        // GET: PersonalOrderController
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            List<PersonalOrderIndexVM> orders = _personalOrderService.GetOrders()
                .Select(x => new PersonalOrderIndexVM()
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.CategoryName,
                    NameOfProduct = x.NameOfProduct,
                    Image = x.Image,
                    Quantity = x.Quantity
                }).ToList();
            return View(orders);
        }

        // GET: PersonalOrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonalOrderController/Create
        public ActionResult Create()
        {
            var order = new PersonalOrderCreateVM();
            order.Categories = _categoryService.GetCategories()
                .Select(x => new CategoryPairVM()
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                }).ToList();
            return View(order);
        }

        // POST: PersonalOrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalOrderCreateVM bindingModel)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == null)
            {
                return RedirectToAction("Denied", "PersonalOrder");
            }
            if (ModelState.IsValid)
            {
                _personalOrderService.Create(currentUserId,bindingModel.CategoryId,bindingModel.NameOfProduct, bindingModel.Image, bindingModel.Quantity);
            }
            return RedirectToAction("Success", "PersonalOrder");
        }
        public ActionResult Denied()
        {
            return View();
        }
        public ActionResult Success()
        {
            return View();
        }

        // GET: PersonalOrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonalOrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonalOrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonalOrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
