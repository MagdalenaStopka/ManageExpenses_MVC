using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageExpenses.Models
{
	public class UserListItemModel
	{
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Login { get; set; }
	}
}