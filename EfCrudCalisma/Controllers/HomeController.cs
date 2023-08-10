using System.Diagnostics;
using EfCrudCalisma.Data;
using EfCrudCalisma.Models;
using Microsoft.AspNetCore.Mvc;

namespace EfCrudCalisma.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SozlukContext _context;

        public HomeController(ILogger<HomeController> logger, SozlukContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Gelin, anasayfa rastgele bir sözcüğü anlamıyla gösterelim
            int adet = _context.Girdiler.Count();
            int skip = new Random().Next(adet);
            var sozcuk = _context.Girdiler.Skip(skip).First();
            return View(sozcuk);
        }

        public IActionResult Privacy()
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