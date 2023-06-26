using Microsoft.AspNetCore.Mvc;
using PPP___ProjekatPokusaj2.Core;
using PPP___ProjekatPokusaj2.Infrastructure.Interface;

namespace PPP___ProjekatPokusaj2.Controllers
{
    public class KorisnickiNalogController : Controller
    {
        private readonly IKorisnickiNalogRepository _nalogRepo;

        public KorisnickiNalogController(IKorisnickiNalogRepository nalogRepo)
        {
            _nalogRepo = nalogRepo;
        }

        public async Task<IActionResult> Index()
        {
            var nalog = await _nalogRepo.GetAll();
            return View(nalog);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
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
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(KorisnickiNalogBO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Id == 0)
                    {
                        _nalogRepo.Add(model);
                        TempData["successMessage"] = "Product created successfully!";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        await _nalogRepo.Update(model);
                        TempData["successMessage"] = "Product details updated successfully!"; return RedirectToAction(nameof(Index));

                    }
                    return RedirectToAction(nameof(Index));


                }
                else
                {
                    TempData["errorMessage"] = "Model state is invalid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();


            }

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
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
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(KorisnickiNalogBO model)
        {
            try
            {
                await _nalogRepo.Delete(model.Id);
                TempData["successMessage"] = "Product deleted successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
