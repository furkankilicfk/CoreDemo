using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IGenericDal<T> where T : class  //DIşarıdan entity parametresi gönderebilmem gerekiyor<T> -- T değeri bir class'a ait bütün değerleri kullanacak
	{
		//Cat ve Blog'a ait intefleri tanımladığım gibi burada da metotları tanımlamam gerekiyor

		void Insert(T t);

		void Update(T t);

		void Delete(T t);

		List<T> GetListAll();

		T GetById(int id);
	}
}
