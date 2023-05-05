using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class GenericRepository<T> : IGenericDal<T> where T : class      //kuracağım mimari sayesinde dışarıdan gönderdiğim entitylerle bu işlemler gerçekleşsin. Her entity için ayrı ayrı repository oluşturmayayım.
	{
		public void Delete(T t)
		{
			using var c = new Context();
			c.Remove(t);
			c.SaveChanges();
		}

		public T GetById(int id)
		{
			using var c = new Context();
			return c.Set<T>().Find(id);
		}

		public List<T> GetListAll()
		{
			using var c = new Context();
			return c.Set<T>().ToList();
		}

		public void Insert(T t)
		{
			using var c = new Context();
			c.Add(t);
			c.SaveChanges();
		}

		public List<T> GetListAll(Expression<Func<T, bool>> filter)
		{
			using var c = new Context();
			return c.Set<T>().Where(filter).ToList();		//filterdan gelen değerin listelenmesi
		}

		public void Update(T t)
		{
			using var c = new Context();
			c.Update(t);
			c.SaveChanges();
		}
	}
}

//CRUD
//CREATE-READ-UPDATE-DELETE
//.Her bir crud operasyonuna ait bir metot tanımlanacak
//.Metotların imzası olarak interfaceler kullanılacak
//.Abstract üzerinde soyut ifade olarak interfaceleri tanımlar 
//.Concrete üzerinde somut ifade olarak bu interfaceler içinde yer alan metotların içini doldur
//.Generic --> Bütününe uygulanacak 
//.ekleme silme güncelleme --> void t ürü kullanılacak
//.
//.
//.