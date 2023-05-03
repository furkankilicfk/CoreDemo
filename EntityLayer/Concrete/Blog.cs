using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Blog
	{
        [Key]
        public int BlogID { get; set; }

        public string BlogTitle { get; set; }

        public string BlogContent { get; set; }

        public string BlogThumbnail { get; set; }

        public string BlogImage { get; set; }       //resimleri sunucuda çok yer kaplayacağını varsayarak dosya yoluyla tutacağım

        public string BlogCreateDate { get; set; }

        public bool BlogStatus { get; set; }

        public int CategoryID { get; set; }      //isim aynı

        public Category Category { get; set; }       //ilişki içine alınacak olan tablo türünde bir property belirttik

        public List<Comment> Comment { get; set; }      //bir blogda birden fazla yorum olabilir
    }
}
