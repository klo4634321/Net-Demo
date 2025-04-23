using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _databaseContext;

        public HomeController(ILogger<HomeController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            var comments = _databaseContext.Comment.OrderByDescending(c => c.ID).ToList();
            return View(comments);
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



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _databaseContext.Comment.Add(comment);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var comment = _databaseContext.Comment.FirstOrDefault(c => c.ID == id);
            if (comment == null) return NotFound();

            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var comment = _databaseContext.Comment.FirstOrDefault(c => c.ID == id);
            if (comment != null)
            {
                _databaseContext.Comment.Remove(comment);
                _databaseContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
