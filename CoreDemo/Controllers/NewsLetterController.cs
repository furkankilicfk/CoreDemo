using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class NewsLetterController : Controller
	{
		NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());

		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			//mail bültenine abone olma işlemini buradan gerçekleştireceğiz
			return PartialView();
		}

		[HttpPost]
		public IActionResult SubscribeMail(NewsLetter p)        //entitylayerconcrete
		{   //mail bültenine abone olma işlemini buradan gerçekleştireceğiz

			p.MailStatus = true;
			nm.AddNewsLetter(p);
			return PartialView();
		}


		//[HttpPost]
		//public IActionResult SubscribeMail(NewsLetter p)
		//{
		//	p.MailStatus = true;
		//	nm.AddNewsLetter(p);
		//	Response.Redirect("/Blog/Index/");
		//	return PartialView();
		//}



	}
}
