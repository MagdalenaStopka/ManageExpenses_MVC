using ManageExpenses.Entities;
using ManageExpenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageExpenses.Repositories
{
   public interface IExpenseCategoryRepository
    {
        void Add(AddExpenseCategoryModel model);
        void Edit(EditExpenseCategoryModel model);
        void Update(EditExpenseCategoryModel model);
       

        ExpenseCategory Get(long categoryId);
        EditExpenseCategoryModel GetCategoryById(long id);
        IEnumerable<ExpenseCategory> GetAllCategories();
        IEnumerable<ExpenseCategoryListItemModel> GetAllExpenseCategories();
    }
}
