using Empower.Web.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace Empower.Web.Controllers
{
    public class ProductController : Controller
    {

        // Mock Data for Products
        private static List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Product A", Price = 100, Quantity = 10, Category = "Category 1", CreatedAt = DateTime.Now },
        new Product { Id = 2, Name = "Product B", Price = 200, Quantity = 20, Category = "Category 2", CreatedAt = DateTime.Now },
        new Product { Id = 3, Name = "Product C", Price = 300, Quantity = 30, Category = "Category 3", CreatedAt = DateTime.Now },
        new Product { Id = 4, Name = "Product D", Price = 400, Quantity = 40, Category = "Category 4", CreatedAt = DateTime.Now },
        new Product { Id = 5, Name = "Product E", Price = 500, Quantity = 50, Category = "Category 1", CreatedAt = DateTime.Now },
        new Product { Id = 6, Name = "Product F", Price = 600, Quantity = 60, Category = "Category 2", CreatedAt = DateTime.Now },
        new Product { Id = 7, Name = "Product G", Price = 700, Quantity = 70, Category = "Category 3", CreatedAt = DateTime.Now },
        new Product { Id = 8, Name = "Product H", Price = 800, Quantity = 80, Category = "Category 4", CreatedAt = DateTime.Now },
    };


        // GET: Index - List, Search, Sort, Page
        public IActionResult Index(string search, string sortOrder, int? page)
        {
            ViewData["CurrentFilter"] = search;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParam"] = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            var productList = Products.AsQueryable();

            // Searching
            if (!string.IsNullOrEmpty(search))
            {
                productList = productList.Where(p => p.Name.Contains(search) || p.Category.Contains(search));
            }

            // Sorting
            switch (sortOrder)
            {
                case "name_desc":
                    productList = productList.OrderByDescending(p => p.Name);
                    break;
                case "price_asc":
                    productList = productList.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    productList = productList.OrderByDescending(p => p.Price);
                    break;
                default:
                    productList = productList.OrderBy(p => p.Name);
                    break;
            }

            // Paging
            int pageSize = 5;
            int pageNumber = page ?? 1;

            return View(productList.ToPagedList(pageNumber, pageSize));
        }

        // POST: CreateOrUpdate
        [HttpPost]
        public IActionResult CreateOrUpdate(Product product)
        {
            if (product.Id == 0) // Add new product
            {
                int newId = Products.Max(p => p.Id) + 1;
                product.Id = newId;
                product.CreatedAt = DateTime.Now;
                Products.Add(product);
            }
            else // Update existing product
            {
                var existingProduct = Products.FirstOrDefault(p => p.Id == product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                    existingProduct.Quantity = product.Quantity;
                    existingProduct.Category = product.Category;
                }
            }
            return Json(new { success = true });
        }

        // POST: Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Products.Remove(product);
            }
            return Json(new { success = true });
        }

    }
}
