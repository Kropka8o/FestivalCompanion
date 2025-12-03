using FestivalCompanion.Data;
using FestivalCompanion.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestivalCompanion.Controllers
{
    public class AccountController : Controller
    {

        // GET: AcountController
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginViewModel accountLoginModel)
        {
            BloodhoundContextDB bloodhoundContext = new BloodhoundContextDB();
            var data = bloodhoundContext.Gebruiker
                .Where(g => g.Email == accountLoginModel.Email && g.Wachtwoord == accountLoginModel.Password)
                .FirstOrDefault();

            HttpContext.Session.SetInt32("UserID", data.Gebruiker_ID);
            return RedirectToAction("Index", "Home", new { area = "Home" });
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel accountRegisterModel)
        {
            BloodhoundContextDB bloodhoundContext = new BloodhoundContextDB();
            User newUser = new User
            {
                Naam = accountRegisterModel.Name,
                Email = accountRegisterModel.Email,
                Leeftijd = accountRegisterModel.DateOfBirth,
                Wachtwoord = accountRegisterModel.Password,
            };
            bloodhoundContext.Gebruiker.Add(newUser);
            bloodhoundContext.SaveChanges();
            return RedirectToAction("Login");
        }

        public async Task<ActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Map", "Map");
        }


        // GET: AcountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AcountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AcountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AcountController/Edit/5
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

        // GET: AcountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AcountController/Delete/5
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
    }
}
