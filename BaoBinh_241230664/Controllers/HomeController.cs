using BaoBinh_241230664.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BaoBinh_241230664.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNhaSachContext db;
        public HomeController(QLNhaSachContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            ViewBag.TieuDe = "Bao Binh";
            var ds = db.Saches.Where(s => s.Gia != null && s.Gia >= 100).ToList();
            return View(ds);
        }
        public IActionResult SachTheoTheLoai(int id)
        {
            var tl = db.TheLoais.Find(id);
            ViewBag.TieuDe = tl?.TenTl;
            var ds = db.Saches.Where(s => s.MaTl == id).ToList();
            return PartialView("BaoBinh_MainContent", ds);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DsTheLoai = new SelectList(db.TheLoais, "MaTl", "TenTl");
            return View();
        }
        [HttpPost]
        
        public IActionResult Create([Bind("MaTl,TenSach,Gia,Anh")] Sach sach)
        {
            ModelState.Remove("MaTlNavigation");
            if (ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DsTheLoai = new SelectList(db.TheLoais, "MaTl", "TenTl", sach.MaTl);
            return View(sach);
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
