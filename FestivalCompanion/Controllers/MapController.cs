using FestivalCompanion.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestivalCompanion.Controllers
{
    public class MapController : Controller
    {
        // GET: MapController
        public ActionResult Map()
        {
            //var userID = HttpContext.Session.GetInt32("UserID") ?? null;
            //if (userID == null)
            //{
            //    return RedirectToAction("Login", "Account");
            //}
            //else
            //{
                BloodhoundContextDB bloodhoundContext = new BloodhoundContextDB();
                var data = bloodhoundContext.Locatie.Include(l => l.Zone);
                return View(data);
            //}
        }

        // GET: MapController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MapController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MapController/Create
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

        // GET: MapController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MapController/Edit/5
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

        // GET: MapController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MapController/Delete/5
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
