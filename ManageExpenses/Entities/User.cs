using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageExpenses.Entities
{
	public class User
	{
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}