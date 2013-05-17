using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTraining.Web.Models
{
	public class UserLogin
	{
		[Required(ErrorMessage="You must login with a valid email address"), 
		 Display(Name="Email Address")]
		public string Username { get; set; }
		[Required(ErrorMessage="Please enter a password."),
		 MinLength(6, ErrorMessage="Your password must be at least 6 characters long.")]
		public string Password { get; set; }
	}

	public class UserLoginCreate : UserLogin
	{
		[Compare("Password", ErrorMessage="Confirmation password much match password.")]
		public string ConfirmPassword { get; set; }
	}
}