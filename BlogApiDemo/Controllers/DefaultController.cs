using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]  //bunu eklemezsek api ne yapacağını bilmediğinden(ekleme silme güncelleme) çalıştırmaz--attribute şart
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values); //apide başarılı olan isteklerin sonucunda dönecek status kodu
        }

        [HttpPost]
        public IActionResult EmployeeAdd()
        {
            return Ok();
        }
    }
}
