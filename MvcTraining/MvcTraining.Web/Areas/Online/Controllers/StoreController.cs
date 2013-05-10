using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTraining.Web.Models;

namespace MvcTraining.Web.Areas.Online.Controllers
{
    public class StoreController : Controller
    {
		private MvcTrainingContext _context;

		public StoreController()
		{
			_context = new MvcTrainingContext();
		}

        //
        // GET: /Online/Store/

        public ActionResult Index()
        {
            return View(_context.Products);
        }

    }
}
