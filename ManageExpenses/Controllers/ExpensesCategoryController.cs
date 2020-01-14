using ManageExpenses.Models;
using ManageExpenses.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageExpenses.Controllers
{
    public class ExpensesCategoryController : Controller
    {
        private IExpenseCategoryRepository _repository;

        public ExpensesCategoryController(IExpenseCategoryRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult Add()
        {
            AddExpenseCategoryModel model = new AddExpenseCategoryModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult Add(AddExpenseCategoryModel model)
        {
            if (ModelState.IsValid)
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
        public ActionResult Edit(long id)
        {
            EditExpenseCategoryModel model = _repository.GetCategoryById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditExpenseCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(model);

                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult List()
        {
            var expenseCategoriesLists = _repository.GetAllCategories();

            return View(expenseCategoriesLists);
        }
    }
}
