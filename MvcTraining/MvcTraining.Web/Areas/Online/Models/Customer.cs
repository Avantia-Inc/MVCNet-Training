using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTraining.Web.Areas.Online.Models
{
	public class Customer
	{
		[Key,
		 DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		[Required(ErrorMessage="First name is required."),
		 StringLength(25)]
		public string FirstName { get; set; }
		[Required(ErrorMessage="Last name is required."),
		 StringLength(35)]
		public string LastName { get; set; }
		[Required(ErrorMessage="Email is required."),
		 EmailAddress(ErrorMessage="Please enter a valid email address"),
		 StringLength(150)]
		public string Email { get; set; }
		[Phone(ErrorMessage="Please enter a valid telephone number."),
		 StringLength(20)]
		public string Telephone { get; set; }
		//Billing Address
		[Required(ErrorMessage="Billing street address is required."),
		 StringLength(50)]
		public string BillingStreet { get; set; }
		[StringLength(50)]
		public string BillingApartment { get; set; }
		[Required(ErrorMessage="Billing city is required."),
		 StringLength(50)]
		public string BillingCity { get; set; }
		[Required(ErrorMessage="Billing state is required."),
		 StringLength(2)]
		public string BillingState { get; set; }
		[Required(ErrorMessage="Billing zip code is required."),
		 StringLength(5)]
		public string BillingZip { get; set; }
		//Shipping Address
		public bool UseBillingAddress { get; set; }
		[StringLength(50)]
		public string ShippingStreet { get; set; }
		[StringLength(50)]
		public string ShippingApartment { get; set; }
		[StringLength(50)]
		public string ShippingCity { get; set; }
		[StringLength(2)]
		public string ShippingState { get; set; }
		[StringLength(5)]
		public string ShippingZip { get; set; }
	}
}