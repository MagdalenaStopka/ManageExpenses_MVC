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
            return View();
        }
        [HttpPost]
        public ActionResult Add(AddExpenseCategoryModel model)
        {
            return View();
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
                _repository.Edit(model);

                return View();
            }
            else
            {
                return View(model);
            }
        }
    }
}
