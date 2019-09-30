using System;
using System.ComponentModel.DataAnnotations;

namespace ContactsAPI
{
	public class Person
	{
		[Required(ErrorMessage = " required field missing or empty")]
		public Int32 Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		[Required( ErrorMessage  = " required field missing or empty")]
		public string Email { get; set; }

	}
}
