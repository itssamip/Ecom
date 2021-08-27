using Ecom.DataAccess.Repo.IRepo;
using Ecom.Models;
using Ecom.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            IEnumerable<Category> CatList = _unitOfWork.Category.GetAll();

            SubCategoryVM subCategoryVM = new SubCategoryVM()
            {
                SubCategory = new SubCategory(),
                CategoryList = CatList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),

            };

            if (id == null)
            {
                // this is for create
                return View(subCategoryVM);
            }

            // this is for edit
            subCategoryVM.SubCategory = _unitOfWork.SubCategory.Get(id.GetValueOrDefault());
            if (subCategoryVM.SubCategory == null)
            {
                return NotFound();
            }

            return View(subCategoryVM);
        }

        [HttpPost]

        public IActionResult Upsert(SubCategoryVM subCategoryVM)
        {
            if (ModelState.IsValid)
            {
                if (subCategoryVM.SubCategory.Id == 0)
                {
                    _unitOfWork.SubCategory.Add(subCategoryVM.SubCategory);
                }


                else
                {
                    _unitOfWork.SubCategory.Update(subCategoryVM.SubCategory);
                }

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(subCategoryVM);
        }




        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.SubCategory.GetAll(includeProperties: "Category");
            return Json(new { data = allObj });
        }

        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.SubCategory.Get(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting SubCategory";
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.SubCategory.Remove(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = "SubCategory successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
