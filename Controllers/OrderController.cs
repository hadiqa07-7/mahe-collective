using Microsoft.AspNetCore.Mvc;
using Mahe.Data;
using Mahe.Models;
using Mahe.Extensions;
namespace Mahe.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Confirmation(int id)
        {
            var order = _context.Orders
                .FirstOrDefault(o => o.Id == id);

            return View(order);
        }

        [HttpPost]
        public IActionResult PlaceOrder()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart");

            if (cart == null || !cart.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            decimal total = cart.Sum(x => x.Product.Price * x.Quantity);

            var order = new Order
            {
                TotalAmount = total,
                OrderDate = DateTime.Now,
                OrderItems = cart.Select(c => new OrderItem
                {
                    ProductName = c.Product.Name,
                    ProductImage = c.Product.ImageUrl,
                    Price = c.Product.Price,
                    Quantity = c.Quantity,
                    Size = c.Size
                }).ToList()
            };

            _context.Orders.Add(order);

            _context.SaveChanges();

            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Confirmation",
     new { id = order.Id });
        }
    }
}