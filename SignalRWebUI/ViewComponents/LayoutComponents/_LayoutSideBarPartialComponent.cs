using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutSideBarPartialComponent: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
 	}
}
