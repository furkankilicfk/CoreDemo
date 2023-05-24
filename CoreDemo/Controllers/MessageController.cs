using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        public IActionResult InBox()
        {
            //birincisi bu kişiye atılmış olan mesajların tamamı görüntülenecek
            //ikincisinde ilgili mesaj görüntülenecek yani sadece bir mesaj

            int id = 1;
            var values = mm.GetInboxListByWriter(id);
            return View(values);
            
        }

        
        public IActionResult MessageDetails(int id)         //sayfa yüklendiği zaman sen bana verileri getir
        {
            var value = mm.TGetById(id);
   
            return View(value);
        }
    }
}
