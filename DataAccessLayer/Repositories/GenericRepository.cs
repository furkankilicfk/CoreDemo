using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public void Update(T t)
		{
			using var c = new Context();
			c.Update(t);
			c.SaveChanges();
		}
	}
}
