using Microsoft.AspNetCore.Mvc;
using VillaBookingApp.Application.Common.Interfaces;
using VillaBookingApp.Domain.Entities;

namespace VillaBookingApp.Web.Controllers
{
    public class VillaController(IVillaRepository villaRepository) : Controller
    {
        private readonly IVillaRepository _villaRepository = villaRepository;
        public IActionResult Index()
        {
            var villas = _villaRepository.GetAll(null);  
            return View(villas);
        }

        public IActionResult Details(int? villaId)
        {
            if (villaId == null || villaId == 0)
            {
                TempData["error"] = "Villa ID is required";
                return RedirectToAction("Index");
            }

            Villa? villa = _villaRepository.Get(u => u.Id == villaId);

            if (villa == null)
            {
                TempData["error"] = $"Villa with ID {villaId} not found";
                return RedirectToAction("Index");  // ← Redirect to villa list, not error page
            }

            return View("Details/Index", villa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("CustomError", "The Description cannot be the same as Name");
            }

            if (ModelState.IsValid)
            {
                _villaRepository.Add(obj);
                _villaRepository.Save();
                TempData["success"] = "Villa created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var villaFromDb = _villaRepository.Get(u => u.Id == id);
            if (villaFromDb == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaFromDb);
        }

        [HttpDelete]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _villaRepository.Get(u => u.Id == obj.Id);
            if (objFromDb == null)
            {
                return NotFound();
            }
            _villaRepository.Remove(obj);
            _villaRepository.Save();
            TempData["success"] = "Villa deleted successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? villaId)
        {
            Villa? obj = _villaRepository.Get(u => u.Id == villaId);

            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(obj);
        }



        [HttpPost]
        public IActionResult Update(Villa obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("CustomError", "The Description cannot be the same as Name");
            }
            if (ModelState.IsValid)
            {
                _villaRepository.Update(obj);
                _villaRepository.Save();
                TempData["success"] = "Villa updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
