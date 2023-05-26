using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            //ViewBag.v1 = bm.GetList().Count();
            ViewBag.v1 = c.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            //desc ile z'den a'ya doğru sıralıyorum blogid ye göre listele, listeledikten sonra en alttaki değerin blogtitle'ını seç buradan da sadece bir tane değer al.
            ViewBag.v3 = c.Comments.Count();
            return View();
        }
    }
}
