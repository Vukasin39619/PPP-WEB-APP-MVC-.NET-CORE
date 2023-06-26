using Microsoft.AspNetCore.Mvc;
using PPP___ProjekatPokusaj2.Core;
using PPP___ProjekatPokusaj2.Infrastructure.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Controllers
{
    public class LoginController : Controller
    {
        private readonly IKorisnickiNalogRepository _nalogRepository;

        public LoginController(IKorisnickiNalogRepository nalogRepository)
        {
            _nalogRepository = nalogRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            // Authenticate the user based on the provided username and password
            var user = await _nalogRepository.GetByUsernameAndPassword(username, password);

            if (user == null)
            {
                // Invalid username or password
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }

            // Store the user information in a session or cookie for future requests
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Username", user.Username);

            // Redirect to the appropriate controller based on the user role
            if (user.Username == "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Voznja");
            }
        }
    }
}
