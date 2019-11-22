using ManageExpenses.Models;
using ManageExpenses.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageExpenses.Controllers
{
	public class ExpensesController : Controller
	{
        private IExpenseRepository _repository;
        private IExpenseCategoryRepository _categoryRepository;

        public ExpensesController(IExpenseRepository repository, IExpenseCategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }


		[HttpGet]
		public ActionResult Add()
		{
            var categories = _categoryRepository.GetAllCategories();

            AddExpenseModel model = new AddExpenseModel();
            model.Categories = categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();

			return View(model);
		}

		[HttpPost]
		public ActionResult Add(AddExpenseModel model)
		{if(ModelState.IsValid)
            {
                _repository.Add(model);
                return RedirectToAction("List");
            }
            return View(model);
		}

		[HttpGet]
		public ActionResult Delete(long id)
		{
			var model = new DeleteExpenseModel
            { 
				Id = id
			};

			return View(model);
		}

		[HttpPost]
		public ActionResult Delete(DeleteExpenseModel model)
		{
            if (ModelState.IsValid)
            {
                _repository.Remove(model.Id);
                return RedirectToAction("List");
            }
			return View(model);

			//return RedirectToAction("List");
		}

        [HttpGet]
        public ActionResult List()
        {

            var expensesLists = _repository.GetExpensesForCurrentUser();

            return View(expensesLists);

        }
	}
}