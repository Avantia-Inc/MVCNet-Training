using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTraining.Web.Controllers
{
    public class HomeController : Controller
    {

		protected override void Initialize(System.Web.Routing.RequestContext requestContext)
		{
			string action = (requestContext.RouteData.Values["action"] ?? "index").ToString();
			if (!string.Equals(action, "index", StringComparison.InvariantCultureIgnoreCase))
			{
				requestContext.RouteData.Values.Add("view", action);
				requestContext.RouteData.Values["action"] = "RouteTo";				
			}

			base.Initialize(requestContext);
		}
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

		public ActionResult RouteTo(string view)
		{
			if (Request.IsAjaxRequest())
			{
#if DEBUG
				//tell browser to not cache page while in development
				Response.Cache.SetExpires(DateTime.Now);
				Response.Cache.SetLastModified(DateTime.Now); 
#endif
				return PartialView(view);
			}
			else
				return View(view);
		}
    }
}
