using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcTraining.Web.Models;

namespace MvcTraining.Web.Areas.Online.Views.Account
{
    public class LoginController : Controller
    {
        //
        // GET: /Online/Login/

        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Index(UserLogin login)
		{
			if (ModelState.IsValid)
			{
				var user = Membership.FindUsersByEmail(login.Username).OfType<MembershipUser>().FirstOrDefault();
				if (user != null && Membership.ValidateUser(user.UserName, login.Password))
				{
					FormsAuthentication.SetAuthCookie(user.UserName, true);
					return RedirectToAction("Index", "Store");
				}
				else
					ModelState.AddModelError(string.Empty, "Invalid login. Please try again.");
			}

			return View(login);
		}

		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();

			return RedirectToAction("Index");
		}
    }
}
