using FestivalCompanion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FestivalCompanion.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
