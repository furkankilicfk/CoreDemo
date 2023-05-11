using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        //Business katmanı VALIDATION(GEÇERLİLİK KURALLARI)'ın olduğu yerdir)
        //blog adı boş geçilemez en fazla 50 karakter vs
        //Business katmanında Abstract klasörü içinde yer alan interfaceler Service olarak adlandırılıyor
        //Business katmanında Concrete klasörü içinde yer alan sınıflar Manager olarak adlandırılıyor 

        List<Blog> GetBlogListWithCategory();

        List<Blog> GetBlogListByWriter(int id);

        
    }
}
