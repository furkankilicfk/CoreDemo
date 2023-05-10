using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]		//proje seviyesinde tanımlamış olduğum bütün kurallardan muaf ol
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public IActionResult Index(Writer p)
		{	
			Context c = new Context();
			var datavalue = c.Writers.FirstOrDefault(x=>x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
			if(datavalue != null)
			{
				HttpContext.Session.SetString("username", p.WriterMail);  //key, value
				return RedirectToAction("Index", "Writer");
			}
			else
			{
				return View();
			}
			
		}

	}
}
