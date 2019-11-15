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
        private IList<ExpenseCategory> _categories = new List<ExpenseCategory>()
        {
            new ExpenseCategory
            {
                Id =1,
                Name = "pierwsza kategiria"
            },

            new ExpenseCategory
            {
                Id =2,
                Name = "druga kategiria"
            }
        };
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
            if(category != null)
            {
                category.Name = model.Name;
            }
            
        }

        public ExpenseCategory Get(long categoryId)
        {
            return _categories.SingleOrDefault(c => c.Id == categoryId);
        }

        public IEnumerable<ExpenseCategory> GetAllCategories()
        {
            return _categories;
        }

        public EditExpenseCategoryModel GetCategoryById(long id)
        {
            return _categories.Where(c => c.Id == id)
                .Select(c => new EditExpenseCategoryModel
                {
                    Id = c.Id,
                    Name = c.Name

                }).Single();

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