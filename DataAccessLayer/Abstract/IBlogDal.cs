using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IBlogDal:IGenericDal<Blog>
	{
		//tanımlamış olduğum entitylerin tamamı için birer tane abstract klasörü içinde dataaccesslayer interface'i tanımlayacağım. Böylece hiçbir entity'm çıplak kalmayacak
	}
}
