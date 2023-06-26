using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PPP___ProjekatPokusaj2.Core;
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
        [HttpGet]
        public async Task<IActionResult> Start(int id=0)
        {
            if (id == 0)
            {
                return View(new KorisnickiNalogBO());
            }
            else
            {
                try
                {
                    KorisnickiNalogBO nalog = await _nalogRepo.GetById(id);
                    if (nalog != null)
                    {
                        return View(nalog);
                    }
                }
                catch (Exception ex)
                {

                    TempData["errorMessage"] = ex.Message;
                    return RedirectToAction("Index");

                }
                TempData["errorMessage"] = $"Product details not found with ID: {id}";
                return RedirectToAction("Index");
            }
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
