using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{		//bütün repository'yi çağırmak yerine sadece ilgili entity'ye ait repository'yi çağırıp onunla işlem yapayım(constructor metot)
	public class CategoryManager : ICategoryService
	{
		ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;		//bu field ile bu property'yi neden eşliyoruz?

			//constructor içinde devamlı newleme işlemi yapıyoruz ama diğer constructor'ı kullanırsak interfacein referans özelliğinden faydalanmış oluyoruz galiba

			//EfCategoryRepository'i kullanmamızdaki dezavantaj Entity Framework'e bağımlı olmamız.
			//İlerde başka bir teknoloji geldiğinde projeyi ona geçirmek için neredeyse bütün katmanlardaki kodları tek tek değiştirmemiz gerekir ama interface kullanarak bu bağımlılığı yok eder ve istersek ileride daha farklı teknolojilere geçebiliriz.
			//Avantaj olaraksa kısa vadede daha az kod yazıp daha kısa sürede projeyi bitirebiliriz.
		}

		//EfCategoryRepository efCategoryRepository;

		////üzerinde çalıştığım catmanag sınıfı üzerinden atama yapabilmem için constr metoda iht var
		//      public CategoryManager()
		//      {
		//	//yapıcı metot içerisinde newleme işlemini gerçekleştirmiş oldum
		//          efCategoryRepository = new EfCategoryRepository();

		//	//genericrepository'yi kullanıyor aynı zamanda ICatDal'ı kullanıyor.IcatDal'daIGenericDal'ı kullanıyor. Böylece tanımlamış olduğum generic yapıların hepsini kullanmış oluyorum
		//      }		//EntityFramework'e çok ciddi bir bağımlılığım var. Interface'ler üzerinden contr metot oluşturacağım. dep inj'e daha uygun
		//public void CategoryAdd(Category category)
		//{
		//	_categoryDal.Insert(category);
		//}

		//public void CategoryDelete(Category category)
		//{
		//	_categoryDal.Delete(category);
		//}

		//public void CategoryUpdate(Category category)
		//{
		//	_categoryDal.Update(category); 
		//}

		public Category GetById(int id)
		{
			return _categoryDal.GetById(id);
		}

		public List<Category> GetList()
		{
			return _categoryDal.GetListAll();
		}

		public void TAdd(Category t)
		{
			_categoryDal.Insert(t);
		}

		public void TDelete(Category t)
		{
			_categoryDal.Delete(t);
		}

		public void TUpdate(Category t)
		{
			_categoryDal.Update(t);
		}
	}
}
