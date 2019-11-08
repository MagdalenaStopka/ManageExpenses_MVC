using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManageExpenses.Entities;
using ManageExpenses.Models;

namespace ManageExpenses.Repositories
{
    public class ExpenseCategoryInMemoryRepository : IExpenseCategoryRepository
    {
        private IList<ExpenseCategory> _categories = new List<ExpenseCategory>();
        public void Add(AddExpenseCategoryModel model)
        {
            ExpenseCategory category = new ExpenseCategory
            {
                Id = GetId(),
                Name = model.Name
            };

            _categories.Add(category);
        }

        public void Edit(EditExpenseCategoryModel model)
        {
            long id = model.Id;
            ExpenseCategory category = _categories.SingleOrDefault(c => c.Id == id);
            
        }

        public ExpenseCategory Get(long categoryId)
        {
            return _categories.SingleOrDefault(c => c.Id == categoryId);
        }
        private long GetId()
        {
            if (_categories.Count > 0)
            {
                return _categories.Max(x => x.Id) + 1;


            }

            return 1;
        }
    }
}