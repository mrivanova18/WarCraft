using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using WarCraft.Core.Contracts;
using WarCraft.Infrastructure.Data.Entities;
using WarCraft.Models.Order;

namespace WarCraft.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        public OrderController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        // GET: OrderController
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            List<OrderIndexVM> orders = _orderService.GetOrders()
                .Select(x => new OrderIndexVM
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    User = x.User.UserName,
                    ProductId = x.ProductId,
                    Product = x.Product.Name,
                    Image = x.Product.Image,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Discount = x.Discount,
                    TotalPrice = x.TotalPrice
                }).ToList();
            return View(orders);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create(int id)
        {
            Product product = _productService.GetProductById(id);
            if (product==null)
            {
                return NotFound();
            }
            OrderCreateVM order = new OrderCreateVM()
            {
                ProductId = product.Id,
                ProductName = product.Name,
                QuantityInStock = product.QuantityAvailable,
                Price = product.Price,
                Discount = product.Discount,
                Image = product.Image
            };
            return View(order);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreateVM bindingModel)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var product = this._productService.GetProductById(bindingModel.ProductId);
            if (currentUserId==null || product==null || product.QuantityAvailable<bindingModel.Quantity || product.QuantityAvailable==0)
            {
                return RedirectToAction("Denied", "Order");
            }
            if (ModelState.IsValid)
            {
                _orderService.Create(bindingModel.ProductId, currentUserId, bindingModel.Quantity);
            }
            return RedirectToAction("Index", "Product");
        }
        public ActionResult Denied()
        {
            return View();
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
        public ActionResult MyOrders()
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<OrderIndexVM> orders = _orderService.GetOrdersByUser(currentUserId)
                .Select(x => new OrderIndexVM
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    ProductId = x.ProductId,
                    Product = x.Product.Name,
                    Image = x.Product.Image,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Discount = x.Discount,
                    TotalPrice = x.TotalPrice
                }).ToList();
            return View(orders);
        }
    }
}
