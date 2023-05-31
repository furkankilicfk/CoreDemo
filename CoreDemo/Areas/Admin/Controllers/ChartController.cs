using CoreDemo.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemo.Areas.Admin.Controllers
{
    //[Area("Admin")]
    //public class ChartController : Controller
    //{
    //    public IActionResult Index()
    //    {       //kategorilerin grafik üzerinde listeleneceği action olacak
    //        return View();
    //    }

    //    //verilerime statik olarak değer atamamı sağlayan action olacak

    //    public IActionResult CategoryChart()
    //    {
    //        List<CategoryClass> list = new List<CategoryClass>();
    //        list.Add(new CategoryClass 
    //        {
    //            CategoryName="Teknoloji",
    //            CategoryCount=10
    //        });
    //        list.Add(new CategoryClass
    //        {
    //            CategoryName = "Yazılım",
    //            CategoryCount = 14
    //        });
    //        list.Add(new CategoryClass
    //        {
    //            CategoryName = "Spor",
    //            CategoryCount = 5
    //        });
    //        list.Add(new CategoryClass
    //        {
    //            CategoryName = "Sinema",
    //            CategoryCount = 2
    //        });
    //        return Json(new { jsonlist = list });
    //        //chartları json formatında bir scriptle çağıracağım. jsonlist ismini verdik ve list'e atadık. script tarafında kullanacağız

    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 14
            });
            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 5
            });
            list.Add(new CategoryClass
            {
                categoryname = "Sinema",
                categorycount = 2
            });

            return Json(new { jsonlist = list });
        }
    }
}
