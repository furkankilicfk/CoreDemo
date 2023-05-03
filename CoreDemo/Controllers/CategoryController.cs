using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class CategoryController : Controller
	{
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());		//icatdal'ı karşılayacak olan bir değer göndermem gerekiyor
		public IActionResult Index()
		{
			var values = cm.GetList();		//cm sayesinde bütün catman metotlarına erişim sağlayabiliyorum
			return View(values);
		}
	}
}
