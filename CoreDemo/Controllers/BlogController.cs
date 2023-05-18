using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var values = bm.GetListWithCategoryByWriterBm(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        { 
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                    Text = x.CategoryName,
                                                    Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;  //gelen değeri dropdowna taşıyacağım
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p) 
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p); //writervalidator içindekileri (validate) kontrol edeceksin p den gelen değerler   
            if (results.IsValid)
            {
                p.BlogStatus = true;
                //p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = 1;
                bm.TAdd(p);

                return RedirectToAction("BlogListByWriter", "Blog");//index aksiyonuna git. o nerde blogcontrollerın
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
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)         //sayfa yüklendiği zaman sen bana verileri getir
        {
            var blogvalue = bm.TGetById(id);
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            return RedirectToAction("BlogListByWriter");
        }
    }  
}
