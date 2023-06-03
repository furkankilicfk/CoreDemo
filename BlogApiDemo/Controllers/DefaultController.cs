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
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new Context();
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var employee =c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(employee);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var c = new Context();
            var emp = c.Employees.Find(employee.ID);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.Name = employee.Name;  //güncellenecek olan satırdaki değere karşılık parametreden gelen değeri al
                c.Update(emp);
                c.SaveChanges();
                return Ok();
            }
        }       //Oluşturmuş olduğum api üzerindeki tabloma bir presentation katmanı üzerinden ulaşmak istiyorum ve bu katman üzerinden ulaşmış olduğum tabloda crud işlemleri gerçekleştirmek istiyorum.
    }
}
