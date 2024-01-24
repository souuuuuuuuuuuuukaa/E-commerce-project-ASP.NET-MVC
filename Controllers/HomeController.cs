using lunettes.Data;
using lunettes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace lunettes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly lunettesContext _context;
        public HomeController(ILogger<HomeController> logger, lunettesContext context)
        {
            _logger = logger;
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            var lunettesContext = _context.Products.Include(p => p.ProductTypes).Include(p => p.SpecialTags);
            return View(await lunettesContext.ToListAsync());
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
