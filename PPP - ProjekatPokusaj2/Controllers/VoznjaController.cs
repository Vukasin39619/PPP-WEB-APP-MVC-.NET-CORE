using Microsoft.AspNetCore.Mvc;
using PPP___ProjekatPokusaj2.Core;
using PPP___ProjekatPokusaj2.Infrastructure.Interface;

namespace PPP___ProjekatPokusaj2.Controllers
{
    public class VoznjaController : Controller
    {
        private readonly IVoznjaRepository _voznjaRepo;

        public VoznjaController(IVoznjaRepository voznjaRepo)
        {
            _voznjaRepo = voznjaRepo;
        }

        public async Task<IActionResult> Index()
        {
            var voznja = await _voznjaRepo.GetAll();

            return View(voznja);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new VoznjaBO());
            }
            else
            {
                try
                {
                    VoznjaBO voznja = await _voznjaRepo.GetById(id);
                    if (voznja != null)
                    {
                        return View(voznja);
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
        public async Task<IActionResult> CreateOrEdit(VoznjaBO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Id_voznje == 0)
                    {
                        _voznjaRepo.Add(model);
                        TempData["successMessage"] = "Product created successfully!";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        await _voznjaRepo.Update(model);
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
                VoznjaBO voznja = await _voznjaRepo.GetById(id);
                if (voznja != null)
                {
                    return View(voznja);
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
        public async Task<IActionResult> DeleteConfirmed(VoznjaBO model)
        {
            try
            {
                await _voznjaRepo.Delete(model.Id_voznje);
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

