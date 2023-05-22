using Microsoft.AspNetCore.Http;

namespace CoreDemo.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }      //dosyadan veri seçebilmek için kullanacağım-string değeri değiştirdik
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}

//propertydeki değişikliği entity tarafında gerçekleştirmek istemediğim için modeldeki class üzerinden yapacağım 