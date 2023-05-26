using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]     //böylelikle category controllerda oluşturmuş olduğum actionların admin areadan gelmiş olduğunu programıma bildirdim
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page = 1)
        {
            var values = cm.GetList().ToPagedList(page,3);  //pageyi viewda kullanacağız
            return View(values);
        }

        [HttpGet]
         public IActionResult AddCategory() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p); //categoryvalidator içindekileri (validate) kontrol edeceksin p den gelen değerler   
            if (results.IsValid)
            {
                p.CategoryStatus = true;
              
                cm.TAdd(p);

                return RedirectToAction("Index", "Category");//index aksiyonuna git. o nerde blogcontrollerın
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult CategoryDelete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
