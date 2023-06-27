using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PPP___ProjekatPokusaj2.Controllers
{
    
    public class PorukaController : Controller
    {
        private static List<string> Poruka = new List<string>();

        public IActionResult Index()
        {
            return View(Poruka);
        }

        [HttpPost]
        public IActionResult AddMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                Poruka.Add(message);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ClearMessages()
        {
            Poruka.Clear();
            return RedirectToAction("Index");
        }

    }
}
