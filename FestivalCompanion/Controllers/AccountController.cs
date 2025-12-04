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
        private readonly BloodhoundContextDB _db; // Jouw database context

        // Injecteer de PasswordHasher en de DbContext in de constructor
        public AccountController(BloodhoundContextDB db, PasswordHasher hasher)
        {
            _db = db;
            _hasher = hasher;
        }

        // GET: AccountController/Login
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

            // 3. Verificatie van de hash:
            // Check: 1) Bestaat de gebruiker? OF 2) Klopt het wachtwoord?
            if (user == null || !_hasher.VerifyPassword(accountLoginModel.Password, user.WachtwoordHash))
            {
                // Veilige foutmelding
                TempData["Error"] = "Inloggegevens zijn niet correct.";
                return View(accountLoginModel);
            } else
            {


                HttpContext.Session.SetInt32("UserID", user.Gebruiker_ID);
            return RedirectToAction("Index", "Home", new { area = "Home" });
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // POST: Registratie Logica (Wachtwoord HASHSEN)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(AccountRegisterViewModel accountRegisterModel)
        {
            // 1. Validatie (Inputvalidatie check)
            if (!ModelState.IsValid)
            {
                return View(accountRegisterModel);
            } else
            {


                // 2. HASHSEN: Roep de Argon2id methode aans
                var newUser = new User
                {
                    Naam = accountRegisterModel.Name,
                    Email = accountRegisterModel.Email,
                    Leeftijd = accountRegisterModel.DateOfBirth, // Let op: model.DateOfBirth moet overeenkomen met de input
                    WachtwoordHash = _hasher.HashPassword(accountRegisterModel.Password) // <-- HASHSEN
                };

            // 3. Database opslag
            _db.Gebruiker.Add(newUser);
            _db.SaveChanges();
            return RedirectToAction("Login");
            }
        }
    }
}