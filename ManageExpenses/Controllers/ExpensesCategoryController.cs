using ManageExpenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageExpenses.Controllers
{
    public class ExpensesCategoryController :Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add (AddExpenseCategoryModel model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(EditExpenseCategoryModel model)
        {
            return View();
        }
    }
}