using Microsoft.AspNetCore.Mvc;
using VillaBookingApp.Application.Common.Interfaces;
using VillaBookingApp.Domain.Entities;
using VillaBookingApp.Web.ViewModels;

namespace VillaBookingApp.Web.Controllers
{
    public class VillaController(IUnitOfWork unitOfWork) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            var villas = _unitOfWork.Villa.GetAll(null) ?? Enumerable.Empty<Villa>();

            var vmList = villas.Select(v => new VillaVM
            {
                Id = v.Id,
                Name = v.Name,
                Description = v.Description,
                Price = v.Price,
                Sqft = v.Sqft,
                Occupancy = v.Occupancy,
                ImageUrl = v.ImageUrl
            }).ToList();
            return View(vmList);
        }

        public IActionResult Details(int? villaId)
        {
            if (villaId == null || villaId == 0)
            {
                TempData["error"] = "Villa ID is required";
                return RedirectToAction("Index");
            }

            Villa? villa = _unitOfWork.Villa.Get(u => u.Id == villaId, includeProperties: "Amenities");

            if (villa == null)
            {
                TempData["error"] = $"Villa with ID {villaId} not found";
                return RedirectToAction("Error", "Home");
            }

           var vm = new VillaVM
            {
                Id = villa.Id,
                Name = villa.Name,
                Description = villa.Description,
                Price = villa.Price,
                Sqft = villa.Sqft,
                Occupancy = villa.Occupancy,
                ImageUrl = villa.ImageUrl,
                Amenities = villa.Amenities.Select(a => new AmenityItemVM
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description
                }).ToList()
           };

            return View("Details/Index", vm);
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
                _unitOfWork.Villa.Add(obj);
                _unitOfWork.Save();
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
            var villaFromDb = _unitOfWork.Villa.Get(u => u.Id == id);
            if (villaFromDb == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaFromDb);
        }

        [HttpDelete]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _unitOfWork.Villa.Get(u => u.Id == obj.Id);
            if (objFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Villa.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Villa deleted successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? villaId)
        {
            Villa? obj = _unitOfWork.Villa.Get(u => u.Id == villaId);

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
                _unitOfWork.Villa.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Villa updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
