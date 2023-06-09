﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
	{	//metot belirledin implemente et
		public List<Blog> GetListWithCategory()
		{
			using(var c = new Context())
			{
				return c.Blogs.Include(x=> x.Category).ToList();	//hangi entity include edilecek?
			}
		}          //bloga özel olarak kullanacağım metotların içini burada tanımlayacağım

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).Where(x=>x.WriterID==id).ToList();   
            }
        }
    }
}
