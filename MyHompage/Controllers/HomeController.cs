using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyHompage.Models;

namespace MyHompage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Home()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult DownloadLebenslauf()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "Lebenslauf_Tim_Kleinelsen.pdf");
            var contentType = "application/pdf";
            var fileName = "Lebenslauf_Tim_Kleinelsen.pdf";

            return PhysicalFile(filePath, contentType, fileName);
        }
        public IActionResult Project()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Links()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Kontakt(KontaktViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
            {
                // Hier kann eine Funktion hinzugefügt werden das ich die Nachrich als Mail bekomme 

                TempData["Message"] = "Vielen Dank für Ihre Nachricht!";
                return RedirectToAction("Kontakt");
            }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Fehler beim Senden der Nachricht: " + ex.Message);
            }
            return View(model);
        }

        public IActionResult Impressum()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
