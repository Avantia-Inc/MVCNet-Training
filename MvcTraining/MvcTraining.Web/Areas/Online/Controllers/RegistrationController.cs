using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcTraining.Web.Areas.Online.Models;
using MvcTraining.Web.Models;

namespace MvcTraining.Web.Areas.Online.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Online/Registration/
		private MvcTrainingContext _context;

		public RegistrationController()
		{
			_context = new MvcTrainingContext();
		}

		public ActionResult Register()
        {
            return View();
        }

		[HttpPost]
		public ActionResult StartRegistration(Customer customer)
		{
			//clear model state errors
			ModelState.Clear();
			return PartialView("_CustomerAddresses", customer);
		}

		[HttpPost]
		public ActionResult CreateCustomer(Customer customer)
		{
			//save customer
			if (ModelState.IsValid)
			{
				_context.Customers.Add(customer);
				_context.SaveChanges();

				return PartialView("_CustomerPassword", new UserLoginCreate() { Username = customer.Id.ToString() }); 
			}

			return PartialView("_CustomerAddresses", customer);
		}

		[HttpPost]
		public ActionResult CreateCustomerAccount(UserLoginCreate createLogin)
		{
			if (ModelState.IsValid)
			{
				//get saved customer
				Guid id = Guid.Parse(createLogin.Username);
				var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
				if (customer == null) return HttpNotFound();

				//create new user
				MembershipCreateStatus createStatus;
				var user = Membership.CreateUser(createLogin.Username, createLogin.Password, customer.Email, null, null, true, out createStatus);

				if (createStatus == MembershipCreateStatus.Success)
				{
					FormsAuthentication.SetAuthCookie(createLogin.Username, true);
					return PartialView("_Success");
				}
				else
					return PartialView("Error"); 
			}

			return PartialView("_CustomerPassword", createLogin);
		}

		[ChildActionOnly]
		public string GetCustomerName(string username)
		{
			Guid id = Guid.Empty;
			if (Guid.TryParse(username, out id))
			{
				var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
				if (customer != null)
					return string.Format("{0} {1}", customer.FirstName, customer.LastName);
			}

			return string.Empty;
		}
    }
}
