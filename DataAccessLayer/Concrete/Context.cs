using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context: DbContext
	{
		//Bağlantı adresimizi tanımlayacağız

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-TJC13CJ;database=CoreBlogDb; integrated security=true;");

			//base.OnConfiguring(optionsBuilder);
		}

        //veritabanına yansıtmak istediğimiz entityleri tek tek yazacağız. referans ile

        //dataaccesslayer içinde sadece crud gerçekleşeceğinden dolayı sadece entity katmanı lazım
        //busineslayerda hem üzerinde çalışacağımentitylere hem de bu entitylerin crud operasyonlarına ait metotlara ihtiyacım var.
        //presentation katmanında ise hem valid controlleri yapılacak(bu yüzden bus.lay. lazım), hem crud(dataaccesslay), hem de parametre vs gibi şeylerden entity lazım.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // Message ile Message2, Writer ile Message2 arasında bire çok ilişki kuruyorum dolaylı yoldan çoka çok ilişki kurulmuş oluyor.
            modelBuilder.Entity<Message2>()
                .HasOne(x => x.SenderUser)  //Message2'de Writer türündeki SenderUserla ilişki kuracağım
                .WithMany(y => y.WriterSender)  //(writer sınıfında)--SenderUser(Writerlar) çoğul olarak message2'ye bağlı olacak haliyle ICollection tipindeki message2 ile çalışan writersender ile bağlantı kuruyorum
                .HasForeignKey(z => z.SenderID)     //Message ile Message2 arasında SenderUser(writer) üzerinden ilişki kurduğumda foreign keyim ne olacak?
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.ReceiverUser)  
                .WithMany(y => y.WriterReceiver)   
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<NewsLetter> NewsLetters { get; set; }

        public DbSet<BlogRating> BlogRatings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Message2> Message2s { get; set; }
    }
}
