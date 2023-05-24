using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();      //solidin ezilmemesi için nasıl tutulmalı? -86

        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name; //aktif kullanıcının name değerini getirir.
            Context c = new Context();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = wm.GetWriterById(writerID); //sisteme authantice olmuş kullanıcının id'si
            return View(values);
        }
    }
}
