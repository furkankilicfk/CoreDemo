using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult>  Index()
        {
            //göndermiş olduğum api adresine istekte bulunacağım ve bu isteği karşılayacak olan değerleri listelemeye çalışacağım.

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44341/api/Default");        //apiyi karşılayacak olan değer -  verileri listelemek için getasync
            var jsonString = await responseMessage.Content.ReadAsStringAsync();  //responsetan gelen mesajın içeriğini karşıla
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);   //jsonString formatında döndür, liste formatında karşıla, emlpoyee u karşılayacak olan geçici classın atanması gerekiyor
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        //Veriyi apiye gönderirken serialize olarak göndeririz.Veriyi alırken deserialize yaparak alırız.
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);  //içeriği serialize ettim, jsona dönüştürdüm
            StringContent content = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44341/api/Default", content); //contentten gelen değerle gidecek
            if(responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }

    public class Class1 
    {       //employee u karşılayacağı için birebir aynı formatta olmalı
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

//BlogApiDemoya bir istek göndereceğim bu isteği karşıladığımda buna göre işlemlerimi gerçekleştiriyor olacağım.