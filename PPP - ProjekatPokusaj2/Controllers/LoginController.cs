﻿using Microsoft.AspNetCore.Mvc;
using PPP___ProjekatPokusaj2.Core;
using PPP___ProjekatPokusaj2.Infrastructure.Interface;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace PPP___ProjekatPokusaj2.Controllers
{
    public class LoginController : Controller
    {
        private readonly IKnjigaRepository _nalogRepository;
        
        public LoginController(IKnjigaRepository nalogRepository)
        {
            _nalogRepository = nalogRepository;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            if (claimuser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Login modelLogin)
        {
            var nalog = await _nalogRepository.GetAll();
            if (modelLogin.Username == "Admin" && modelLogin.Password == "Admin")
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Username),

                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,

                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");

            }
            foreach(KnjigaBO nalozi in nalog)
            {
                if(modelLogin.Username==nalozi.Username && modelLogin.Password==nalozi.Sifra)
                {
                    return RedirectToAction("Index", "Voznja");
                }
            }
            
            ViewData["ValidateMessage"] = "User not found"; 
            return View();
        }


    }
}
