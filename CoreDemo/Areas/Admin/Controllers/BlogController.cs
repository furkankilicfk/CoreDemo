using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]  //Controllerıma bildirmek zorundayım
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())     //Excellde çalışma kitabı olarak geliyor ve sayfa 1 yazan kısım worksheet oluyor
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1,1).Value = "Blog ID";        //1.workshhet sayfasının birinci satır birinci sütununda ne yazsın
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;  //1.satır zaten dolu olacak
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using(var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream); //akış
                    var content = stream.ToArray(); //içerik
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
           
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel {ID=1, BlogName="C# Programlamaya Giriş"},
                new BlogModel {ID=2, BlogName="Tesla Firmasının Araçları"},
                new BlogModel {ID=3, BlogName="2020 Olimpiyatları"}
            };
            return bm;

        }

        //üstteki actionı tetikleyecek, verilerini de GetBlogList metottan alacak
        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())     //Excellde çalışma kitabı olarak geliyor ve sayfa 1 yazan kısım worksheet oluyor
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";        //1.workshhet sayfasının birinci satır birinci sütununda ne yazsın
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;  //1.satır zaten dolu olacak
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream); //akış
                    var content = stream.ToArray(); //içerik
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }
        
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm = new List<BlogModel2>();
            using(var c = new Context())
            {
                bm=c.Blogs.Select(x=>new BlogModel2
                {
                    ID=x.BlogID,
                    BlogName=x.BlogTitle
                }).ToList();
            }
            return bm;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }

}
