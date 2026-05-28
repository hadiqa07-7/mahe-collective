
using Mahe.Data;
using Mahe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Mahe.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
            {
                return RedirectToAction("Login", "Account");
            }
            var orders = _context.Orders
      .Include(o => o.OrderItems)
      .OrderByDescending(o => o.OrderDate)
      .ToList();

            return View(orders);
        }

      

        public IActionResult CreateProduct()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
            {
                return RedirectToAction("Login", "Account");
            }
            _context.Products.Add(product);

            _context.SaveChanges();

            return RedirectToAction("Products");
        }
        [HttpPost]
        public IActionResult UpdateOrderStatus(int orderId,
                                       string status)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
            {
                return RedirectToAction("Login", "Account");
            }
            var order = _context.Orders
                .FirstOrDefault(o => o.Id == orderId);

            if (order != null)
            {
                order.Status = status;

                _context.SaveChanges();
            }

            return RedirectToAction("Dashboard");
        }
        public IActionResult Products()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
            {
                return RedirectToAction("Login", "Account");
            }
            var products = _context.Products.ToList();

            return View(products);
        }
        public IActionResult EditProduct(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
            {
                return RedirectToAction("Login", "Account");
            }

            var product = _context.Products.Find(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
            {
                return RedirectToAction("Login", "Account");
            }
            _context.Products.Update(product);

            _context.SaveChanges();

            return RedirectToAction("Products");
        }
        public IActionResult DeleteProduct(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
            {
                return RedirectToAction("Login", "Account");
            }
            var product = _context.Products.Find(id);

            if (product != null)
            {
                _context.Products.Remove(product);

                _context.SaveChanges();
            }

            return RedirectToAction("Products");
        }
    }
}
