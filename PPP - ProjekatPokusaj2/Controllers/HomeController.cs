using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PPP___ProjekatPokusaj2.Infrastructure.Interface;
using PPP___ProjekatPokusaj2.Models;
using System.Diagnostics;

namespace PPP___ProjekatPokusaj2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKorisnickiNalogRepository _nalogRepo;

        public HomeController(ILogger<HomeController> logger, IKorisnickiNalogRepository nalogRepo)
        {
            _logger = logger;
            _nalogRepo = nalogRepo;
        }

        public async Task<IActionResult> Index()
        {
            var nalog = await _nalogRepo.GetAll();
            return View(nalog);
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
