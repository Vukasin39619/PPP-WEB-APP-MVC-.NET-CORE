    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using PPP___ProjekatPokusaj2.Core;
    using PPP___ProjekatPokusaj2.Infrastructure.Interface;
    using PPP___ProjekatPokusaj2.Models;
    using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;


namespace PPP___ProjekatPokusaj2.Controllers
    {
    [Authorize]
        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;
            private readonly IClanRepository clanRepository;
            private readonly IRacunRepository racunRepository;
            private readonly IKnjigaRepository knjigaRepository;

        public HomeController(ILogger<HomeController> logger, IKnjigaRepository knjigaRepository, IClanRepository clanRepository, IRacunRepository racunRepository)
            {
                _logger = logger;
            clanRepository = clanRepository;
            racunRepository = racunRepository;
            knjigaRepository = knjigaRepository;
            }
            public async Task<IActionResult> Index()
            {
                var nalog = await clanRepository.GetAll();
                return View(nalog);
            }
            [HttpGet]
            public async Task<IActionResult> Start(int id = 0)
            {
                if (id == 0)
                {
                    return View(new KnjigaBO());
                }
                else
                {
                    try
                    {
                        ClanBO clan = await clanRepository.GetById(id);
                        if (clan != null)
                        {
                           ViewBag.UlicaData = await racunRepository.GetAll(); // Populate the ViewBag.UlicaData with street data
                            return View(clan); 
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
        [HttpPost]
        public async Task<IActionResult> Start(KnjigaBO nalog, int selectedUlicaId)
        {
            try
            {
                // Access the selected street ID using the "selectedUlicaId" parameter

                // Create a new Voznja object
                var knjiga = new ClanBO
                {
                    Id = nalog.Id,
                    // Assign the selected street ID
                    Id_ulice = selectedUlicaId,
                    // Assign other properties of Voznja as needed
                    // For example, you can assign the current time as the VremeVoznjeMin property
                    VremeVoznjeMin = DateTime.Now.ToString("HH:mm:ss")
                };

                // Save the Voznja to the database
                await _voznjaRepo.Add(voznja);

                // Set the success message in TempData
                TempData["successMessage"] = "Voznja successfully created";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            
        }
    }
