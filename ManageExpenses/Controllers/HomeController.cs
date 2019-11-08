using ManageExpenses.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageExpenses.Controllers
{
	public class HomeController : Controller
	{
		private IUserRepository _repository = new UserInDbRepository();

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}