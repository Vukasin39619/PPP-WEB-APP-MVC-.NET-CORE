using Microsoft.AspNetCore.Mvc;
using PPP___ProjekatPokusaj2.Core;
using PPP___ProjekatPokusaj2.Infrastructure.Interface;

namespace PPP___ProjekatPokusaj2.Controllers
{
    public class UliceController : Controller
    {
        private readonly IUlicaRepository _ulicaRepo;

        public UliceController(IUlicaRepository ulicaRepo)
        {
            _ulicaRepo = ulicaRepo;
        }

        public async Task<IActionResult> Index()
        {
            var ulice =await _ulicaRepo.GetAll();
            return View(ulice);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id=0)
        {
            if(id==0)
            {
                return View(new UlicaBO());
            }
            else
            {
                try
                {
                    UlicaBO Ulica = await _ulicaRepo.GetById(id);
                    if (Ulica != null)
                    {
                        return View(Ulica);
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
        public async Task<IActionResult> CreateOrEdit(UlicaBO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(model.Id_ulice==0)
                     {
                        _ulicaRepo.Add(model);
                        TempData["successMessage"] = "Product created successfully!";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        await _ulicaRepo.Update(model);
                        TempData["successMessage"] = "Product details updated successfully!";                        return RedirectToAction(nameof(Index));

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
                UlicaBO ulica = await _ulicaRepo.GetById(id);
                if (ulica != null)
                {
                    return View(ulica);
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
        public async Task<IActionResult> DeleteConfirmed(UlicaBO model)
        {
            try
            {
                await _ulicaRepo.Delete(model.Id_ulice);
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
