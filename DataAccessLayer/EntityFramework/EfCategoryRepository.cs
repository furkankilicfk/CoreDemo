using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfCategoryRepository:GenericRepository<Category>, ICategoryDal 
	{ //hem generic repository içindeki metotları alacak hem de ICatDal'a erişim sağlayacak ve bunu constructor metotta kullanılacak
	}
}
