using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Writer
	{
        [Key]
        public int WriterID { get; set; }
		public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterImage { get; set; }

        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }

        public bool WriterStatus { get; set; }

		public List<Blog> Blogs { get; set; }        //bir yazarın birden fazla blogu olabilir

        public virtual ICollection<Message2> WriterSender { get; set; }  //entitylerle oluşturduğumuz crosstable entitysi ile bire çok ilişki kurmak //writerın birden fazla mesajı var
        public virtual ICollection<Message2> WriterReceiver { get; set; }   //witerın birden fazla mesajı var -- writer üzerinden alıcıları sorguluyorum
    }
}
