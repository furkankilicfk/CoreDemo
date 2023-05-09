using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;

namespace CoreDemo.Controllers
{
	public class AboutController : Controller
	{
		AboutManager abm = new AboutManager (new EfAboutRepository());
		public IActionResult Index()
		{
			var values = abm.GetList();
			return View(values);
		}

		public PartialViewResult SocialMediaAbout()
		{
			return PartialView();
		}
	}
}
