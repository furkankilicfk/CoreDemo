using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace CoreDemo.Controllers
{
	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());

		//[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult WriterProfile()
		{
			return View();
		}

		public IActionResult WriterMail()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult Test() 
		{
			return View();
		}

		[AllowAnonymous]
		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}

		[AllowAnonymous]
		public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}

        [AllowAnonymous]
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var writervalues = wm.TGetById(1);
			return View(writervalues);
		}
		[AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
            WriterValidator wl = new WriterValidator();
			ValidationResult results = wl.Validate(p);
			if(results.IsValid)
			{
				wm.TUpdate(p);
				return RedirectToAction("Index", "Dashboard");
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

		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)  //değerini buradan alacaksın
        {
			Writer w = new Writer();
			if(p.WriterImage != null)
			{
				var extension = Path.GetExtension(p.WriterImage.FileName); //klasörün içine kopyalama işlemi yapacağız
				var newimagename = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
				var stream = new FileStream(location, FileMode.Create); //yeni Dosya akışı oluşturacağız. yeni dosya oluştur
				p.WriterImage.CopyTo(stream);  //streamdeki akışa kopyala
				w.WriterImage = newimagename;
                //GUID'in orjinal açılımı “Globally Unique IDentifier” dır.
				//Türkçe kaynaklarda çevirisi “Genel Benzersiz Tanımlayıcı” olarak tanımlanmıştır.
				//Burdaki olayı ekleyeceğimiz resim dosyası adının aynı resim olsa bile arka tarafta farklı isimlerle kaydedilmesini sağlar.
				//Yani resim dosyalarımız karışmasın diye bize benzersiz dosya adları eklememizi sağlar.
            }

			w.WriterMail = p.WriterMail;
			w.WriterName = p.WriterName;
			w.WriterPassword= p.WriterPassword;
			w.WriterStatus = p.WriterStatus;
			w.WriterAbout = p.WriterAbout;
			w.WriterStatus = true;
            wm.TAdd(w);
			return RedirectToAction("Index", "Dashboard");
        }
    }
}
