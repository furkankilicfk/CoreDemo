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
using System.Reflection.Metadata;
using DataAccessLayer.Abstract;
//using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;

namespace CoreDemo.Controllers
{
    
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
           
            var usermail = User.Identity.Name; //aktif kullanıcının name değerini getirir.
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        { 
            
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
           
            var usermail = User.Identity.Name; //aktif kullanıcının name değerini getirir.
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p); //writervalidator içindekileri (validate) kontrol edeceksin p den gelen değerler   
            if (results.IsValid)
            {
                p.BlogStatus = true;
                //p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
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
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;  //gelen değeri dropdowna taşıyacağım
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var usermail = User.Identity.Name; //aktif kullanıcının name değerini getirir.
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            // var blogToUpdate = bm.TGetById(p.BlogID);
            p.WriterID = writerID;
            //p.BlogCreateDate = c //DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            //return RedirectToAction("BlogListByWriter", "Blog");
            return RedirectToAction("BlogListByWriter");
        }
    }  
}
