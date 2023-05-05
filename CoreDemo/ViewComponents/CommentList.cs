using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemo.ViewComponents
{
	public class CommentList:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var commentValues = new List<UserComment>
			{
				new UserComment
				{
					ID = 1,
					UserName = "Test",
				},
				new UserComment
				{
					ID = 2,
					UserName = "Test 0002",
				},
				new UserComment
				{
					ID = 3,
					UserName="Test 0003",
				}

			};
			return View(commentValues);


			return View();
		}
	}
}
