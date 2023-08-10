using EfCrudCalisma.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace EfCrudCalisma.Controllers
{
    public class SozlukController : Controller
    {
        private readonly SozlukContext db;

        public SozlukController(SozlukContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Girdiler.ToList());
        }

        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Yeni(Girdi girdi)
        {
            if (ModelState.IsValid)
            {
                db.Girdiler.Add(girdi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Sil(int id)
        {
            var girdi = db.Girdiler.Find(id);

            if (girdi == null)
                return NotFound();

            return View(girdi);
        }

        [ActionName("Sil")]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SilOnay(int id)
        {
            var girdi = db.Girdiler.Find(id);

            if (girdi == null)
                return NotFound();

            db.Girdiler.Remove(girdi);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Duzenle(int id)
        {
            var girdi = db.Girdiler.Find(id);

            if (girdi == null)
                return NotFound();

            return View(girdi);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Duzenle(Girdi girdi)
        {
            if (ModelState.IsValid)
            {
                db.Update(girdi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
