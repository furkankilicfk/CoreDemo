using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
	public class WriterMessageNotification:ViewComponent
	{
		public IViewComponentResult Invoke(int id)
		{
			
			return View();
		}
	}
}
