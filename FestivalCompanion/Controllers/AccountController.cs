using Microsoft.AspNetCore.Mvc;
using FestivalCompanion.Models; // Voor User en PasswordHasher
using Microsoft.EntityFrameworkCore; // Voor FirstOrDefaultAsync
using System.Threading.Tasks;
using FestivalCompanion.Data; // <-- Add this using for BloodhoundContextDB

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
            return View(); // Laadt de Login View
        }

        // POST: Login Logica (Wachtwoord VERIFIËREN)
        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            // 1. Validatie (Inputvalidatie check)
            if (!ModelState.IsValid)
            {
                // Toont de foutmeldingen van de Data Annotations
                return View(model);
            }

            // 2. Zoek de gebruiker
            var user = await _db.Gebruiker.FirstOrDefaultAsync(g => g.Email == model.Email);

            // 3. Verificatie van de hash:
            // Check: 1) Bestaat de gebruiker? OF 2) Klopt het wachtwoord?
            if (user == null || !_hasher.VerifyPassword(model.Password, user.WachtwoordHash))
            {
                // Veilige foutmelding
                TempData["Error"] = "Inloggegevens zijn niet correct.";
                return View(model);
            }

            // 4. Succes: Authentication Ticket toevoegen (Hier voeg je de inlogsessie toe)
            // ... (Jouw code voor het inloggen van de gebruiker) ...

            return RedirectToAction("Index", "Home");
        }

        // GET: AccountController/Register
        public IActionResult Register()
        {
            return View(); // Laadt de Register View
        }

        // POST: Registratie Logica (Wachtwoord HASHSEN)
        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel model)
        {
            // 1. Validatie (Inputvalidatie check)
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // 2. HASHSEN: Roep de Argon2id methode aan
            var user = new User
            {
                Naam = model.Name,
                Email = model.Email,
                Leeftijd = model.DateOfBirth, // Let op: model.DateOfBirth moet overeenkomen met de input
                WachtwoordHash = _hasher.HashPassword(model.Password) // <-- HASHSEN
            };

            // 3. Database opslag
            _db.Gebruiker.Add(user);
            _db.SaveChanges();

            return RedirectToAction("Login");
        }

        // Let op: De standaard CRUD-functies (Details, Create, Edit, Delete) 
        // uit de oude code zijn hier weggelaten omdat je ze niet nodig hebt voor de login/registratie.
    }
}