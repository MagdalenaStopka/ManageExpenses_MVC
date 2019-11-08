using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageExpenses.Controllers
{
	public class ExpensesController : Controller
	{
		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(object model)
		{
			return View();
		}

		[HttpGet]
		public ActionResult Delete()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Delete(long id)
		{
			return View();
		}
	}
}