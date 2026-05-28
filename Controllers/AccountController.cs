
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mahe.Data;
using Mahe.Models;

namespace Mahe.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(
string email,
string password,
string returnUrl)
        {
            var user = _context.Users
                .FirstOrDefault(x =>
                    x.Email == email &&
                    x.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString(
                    "User",
                    user.Email);

                HttpContext.Session.SetString(
                    "UserEmail",
                    user.Email);

                HttpContext.Session.SetString(
                    "IsAdmin",
                    user.IsAdmin.ToString());

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction(
                    "Index",
                    "Home");
            }

            ViewBag.Error = "Invalid Email or Password";

            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Signup(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();

            HttpContext.Session.SetString(
                "User",
                user.Email);

            return RedirectToAction(
                "Index",
                "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }
    }
}
