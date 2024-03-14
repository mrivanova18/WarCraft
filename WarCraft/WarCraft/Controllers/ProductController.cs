using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarCraft.Core.Contracts;
using WarCraft.Infrastructure.Data.Entities;
using WarCraft.Models.Category;
using WarCraft.Models.Manufacturer;
using WarCraft.Models.Product;

namespace WarCraft.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IManufacturerService _manufacturerService;

        public ProductController(IProductService productService, ICategoryService categoryService, IManufacturerService manufacturerService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _manufacturerService = manufacturerService;
        }

        // GET: ProductController
        [AllowAnonymous]
        public ActionResult Index(string searchStringCategoryName, string searchStringManufacturerName)
        {
            List<ProductIndexVM> products = _productService.GetProducts(searchStringCategoryName, searchStringManufacturerName)
                .Select(product => new ProductIndexVM()
                {
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.CategoryName,
                    Name = product.Name,
                    Price = product.Price,
                    QuantityAvailable = product.QuantityAvailable,
                    ManufacturerId = product.ManufacturerId,
                    ManufacturerName = product.Manufacturer.ManufacturerName,
                    Description = product.Description,
                    Image = product.Image,
                    Discount = product.Discount
                }).ToList();

            return this.View(products);
        }

        // GET: ProductController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }
            ProductDetailsVM product = new ProductDetailsVM()
            {
                Id = item.Id,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.CategoryName,
                Name = item.Name,
                Price = item.Price,
                QuantityAvailable = item.QuantityAvailable,
                ManufacturerId = item.ManufacturerId,
                ManufacturerName = item.Manufacturer.ManufacturerName,
                Description = item.Description,
                Image = item.Image,
                Discount = item.Discount
            };
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var product = new ProductCreateVM();
            product.Categories=_categoryService.GetCategories()
                .Select(x => new CategoryPairVM()
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                }).ToList();
            product.Manufacturers = _manufacturerService.GetManufacturers()
                .Select(x => new ManufacturerPairVM()
                {
                    Id = x.Id,
                    ManufacturerName = x.ManufacturerName,
                }).ToList();
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ProductCreateVM product)
        {
            if (ModelState.IsValid)
            {
                var createdId = _productService.Create(product.CategoryId, product.Name, product.Price,
                    product.QuantityAvailable, product.ManufacturerId, product.Description, product.Image, product.Discount);
                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            ProductEditVM updatedProduct = new ProductEditVM()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Price = product.Price,
                QuantityAvailable = product.QuantityAvailable,
                ManufacturerId = product.ManufacturerId,
                Description = product.Description,
                Image = product.Image,
                Discount = product.Discount,

            };

            updatedProduct.Categories = _categoryService.GetCategories()
                .Select(c => new CategoryPairVM()
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                }).ToList();
            updatedProduct.Manufacturers = _manufacturerService.GetManufacturers()
                .Select(c => new ManufacturerPairVM()
                {
                    Id = c.Id,
                    ManufacturerName = c.ManufacturerName,
                }).ToList();
            return View(updatedProduct);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEditVM product)
        {
            if (ModelState.IsValid)
            {
                var updated = _productService.Update(id, product.CategoryId, product.Name, product.Price,
                    product.QuantityAvailable, product.ManufacturerId, product.Description, product.Image, product.Discount);

                if (updated)
                {
                    return this.RedirectToAction("Index");
                }
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }
            ProductDeleteVM product = new ProductDeleteVM()
            {
                Id = item.Id,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.CategoryName,
                Name = item.Name,
                Price = item.Price,
                QuantityAvailable = item.QuantityAvailable,
                ManufacturerId = item.ManufacturerId,
                ManufacturerName = item.Manufacturer.ManufacturerName,
                Description = item.Description,
                Image = item.Image,
                Discount = item.Discount
            };
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _productService.RemoveById(id);
            if (deleted)
            {
                return RedirectToAction("Success");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
