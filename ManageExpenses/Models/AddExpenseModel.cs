﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageExpenses.Models
{
	public class AddExpenseModel
	{
		public string Name { get; set; }
		public long CategoryId { get; set; }
		public long UserId { get; set; }
		public decimal Value { get; set; }
	}
}