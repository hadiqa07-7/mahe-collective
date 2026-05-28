using Mahe.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Mahe.Data;
namespace Mahe.Controllers
{
    public class CartController : Controller
    {

        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Add(int id, string size)
        {
            var product = _context.Products
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return RedirectToAction("Products", "Home");
            }

            List<CartItem> cart;

            var sessionCart = HttpContext.Session.GetString("Cart");

            if (sessionCart == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = JsonConvert
                    .DeserializeObject<List<CartItem>>(sessionCart);
            }

            var existingItem = cart.FirstOrDefault(x =>
                x.Product.Id == id &&
                x.Size == size);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    Product = product,
                    Size = size,
                    Quantity = 1
                });
            }

            HttpContext.Session.SetString(
                "Cart",
                JsonConvert.SerializeObject(cart));

            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            List<CartItem> cart;

            var sessionCart = HttpContext.Session.GetString("Cart");

            if (sessionCart == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = JsonConvert
                    .DeserializeObject<List<CartItem>>(sessionCart);
            }

            return View(cart);
        }
        public IActionResult Checkout()
        {
            var user = HttpContext.Session.GetString("User");

            if (user == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account",
                    new { returnUrl = "/Cart/Checkout" });
            }

            List<CartItem> cart;

            var sessionCart = HttpContext.Session.GetString("Cart");

            if (sessionCart == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = JsonConvert
                    .DeserializeObject<List<CartItem>>(sessionCart);
            }

            return View(cart);
        }
    }
}