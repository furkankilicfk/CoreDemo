using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {   //yazar listesi için aşağıdaki listeyi değişkene atayıp bunu da Json türüne convert etmem gerekiyor
            var jsonwriters = JsonConvert.SerializeObject(writers);  //dönüştürmek istediğim şey writers nesnesinden gelen değeri. writers aşağıdakileri tutuyor.
            return Json(jsonwriters);
        }

        //parametre olarak gönderilen değerin console'da listelenmesi
        public IActionResult GetWriterByID(int writerid)
        {
            var findwriter = writers.FirstOrDefault(x=> x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findwriter);
            return Json(jsonWriters);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id = 1,
                Name = "Ayşe"
            },
            new WriterClass
            {
                Id = 2,
                Name = "Ahmet"
            },
              new WriterClass
            {
                Id = 3,
                Name = "Buse"
            }
        };

    }
}
