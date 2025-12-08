using FestivalCompanion.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestivalCompanion.Controllers
{
    public class MapController : Controller
    {
        public ActionResult Map()
        {
            var userID = HttpContext.Session.GetInt32("UserID") ?? null;
            if (userID == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                BloodhoundContextDB bloodhoundContext = new BloodhoundContextDB();
                var data = bloodhoundContext.Locatie.Include(l => l.Zone);
                return View(data);
            }
        }
    }
}
