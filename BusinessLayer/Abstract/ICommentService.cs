﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService
	{
		void CommentAdd(Comment comment);

		//void CategoryUpdate(Category category);

		//void CategoryDelete(Category category);

		List<Comment> GetList(int id);

		//Category GetById(int id);
		//igenericdal'da işlemi gören alttaki metodu-manager'da iblogservicetekini
	}
}
