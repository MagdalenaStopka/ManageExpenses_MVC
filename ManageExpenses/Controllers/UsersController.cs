using ManageExpenses.Models;
using ManageExpenses.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageExpenses.Controllers
{
	public class UsersController : Controller
	{
		private IUserRepository _repository;

		public UsersController(IUserRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public ActionResult Add()
		{
			AddUserModel model = new AddUserModel();

			return View(model);
		}

		[HttpPost]
		public ActionResult Add(AddUserModel model)
		{

			if(ModelState.IsValid)
			{
				_repository.Add(model);

				return RedirectToAction("List");
			}
			else
			{
				return View(model);
			}
		}

		[HttpGet]
		public ActionResult Delete(long id)
		{
			var model = new DeleteUserModel
			{
				Id = id
			};

			return View(model);
		}

		[HttpPost]
		public ActionResult Delete(DeleteUserModel model)
		{
			_repository.Delete(model.Id);

			//return View(model);

			return RedirectToAction("List");
		}

		

		[HttpGet]
		public ActionResult Edit(long id)
		{
			EditUserModel model = _repository.GetUserById(id);

			return View(model);
		}

		[HttpPost]
		public ActionResult Edit(EditUserModel model)
		{
			_repository.Update(model);

			//return View(model);

			return RedirectToAction("List");
		}

		[HttpGet]
		public ActionResult List()
		{
			var usersLists = _repository.GetAllUsers();

			return View(usersLists);
		}
	}
}