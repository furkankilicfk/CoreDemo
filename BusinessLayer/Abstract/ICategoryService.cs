using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICategoryService
	{
		void CategoryAdd(Category category);

		//Business katmanı VALIDATION(GEÇERLİLİK KURALLARI)'ın olduğu yerdir)
		//blog adı boş geçilemez en fazla 50 karakter vs
		//Business katmanında Abstract klasörü içinde yer alan interfaceler Service olarak adlandırılıyor
		//Business katmanında Concrete klasörü içinde yer alan sınıflar Manager olarak adlandırılıyor 

		void CategoryUpdate(Category category);

		void CategoryDelete(Category category);

		List<Category> GetList();

		Category GetById(int id);
	}
}
