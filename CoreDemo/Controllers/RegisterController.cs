using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Writer p)
		{
			WriterValidator wv = new WriterValidator();
			ValidationResult results = wv.Validate(p); //writervalidator içindekileri (validate) kontrol edeceksin p den gelen değerler   
			if(results.IsValid)
			{
				p.WriterStatus = true;
				p.WriterAbout = "deneme test";

				wm.WriterAdd(p);

				return RedirectToAction("Index", "Blog");//index aksiyonuna git. o nerde blogcontrollerın
			}
			else
			{
				foreach(var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();

	 
		}
	}
}

//ekleme işlemi yapılırken httpget ve httppost attributelerinin tanımlandığı metodların isimleri aynı olmak zorundadır.

//Httpget sayfa yüklenince
//HttpPost sayfada buton tetiklenince

//attribute'ler bir metoda görev yüklemek amacıyla kullanılan komutlardır. Kısıtlayıcı olarak da kullanılabilir. Propertylerde de kullanılabilir 

//diyelimn ürün kaydı yapacağız kategori listelememiz gerekiyor. Get ile