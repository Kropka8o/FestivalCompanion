using FestivalCompanion.Data;
using FestivalCompanion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FestivalCompanion.Controllers
{
    public class AccountController : Controller
    {
        private readonly PasswordHasher _hasher;
        private readonly BloodhoundContextDB _db; 

        public AccountController(BloodhoundContextDB db, PasswordHasher hasher)
        {
            _db = db;
            _hasher = hasher;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginViewModel accountLoginModel)
        {
            var user = _db.Gebruiker
                .Where(g => g.Email == accountLoginModel.Email)
                .FirstOrDefault();

            if (user == null || !_hasher.VerifyPassword(accountLoginModel.Password, user.Wachtwoord))
            {
                TempData["Error"] = "Inloggegevens zijn niet correct.";
                return View(accountLoginModel);
            } else
            {
                HttpContext.Session.SetInt32("UserID", user.Gebruiker_ID);
                HttpContext.Session.SetString("Username", user.Naam);
                return RedirectToAction("Map", "Map");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(AccountRegisterViewModel accountRegisterModel)
        {
            if (!ModelState.IsValid)
            {
                return View(accountRegisterModel);
            } else
            {
                var newUser = new User
                {
                    Naam = accountRegisterModel.Name,
                    Email = accountRegisterModel.Email,
                    Leeftijd = accountRegisterModel.DateOfBirth,
                    Wachtwoord = _hasher.HashPassword(accountRegisterModel.Password)
                };

                _db.Gebruiker.Add(newUser);
                _db.SaveChanges();
                return RedirectToAction("Login");
            }
        }
    }
}