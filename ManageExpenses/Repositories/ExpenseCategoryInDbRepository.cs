using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManageExpenses.Entities;
using ManageExpenses.Inftrastructure;
using ManageExpenses.Models;

namespace ManageExpenses.Repositories
{
    public class ExpenseCategoryInDbRepository : IExpenseCategoryRepository
    {
        public void Add(AddExpenseCategoryModel model)
        {
            using (var ctx = new ManageExpensesContext2())
            {
                ExpenseCategory category = new ExpenseCategory
                {
                 
                    Name = model.Name
                };

                ctx.ExpenseCategiries.Add(category);
                ctx.SaveChanges();
            }
        }

        public void Edit(EditExpenseCategoryModel model)
        {
            using (var ctx = new ManageExpensesContext2())
            {
                
                ExpenseCategory category = ctx.ExpenseCategiries.SingleOrDefault(c => c.Id == model.Id);
                if (category != null)
                {
                    category.Name = model.Name;
                }
                ctx.SaveChanges();
            }

           
        }

     
        public IEnumerable<ExpenseCategory> GetAllCategories()
        {
                using (var ctx = new ManageExpensesContext2())
                {
                    return ctx.ExpenseCategiries.ToList();
                }
        }
       

        public EditExpenseCategoryModel GetCategoryById(long id)
        {
            using (var ctx = new ManageExpensesContext2())
            {
                return ctx.ExpenseCategiries.Where(c => c.Id == id)
               .Select(c => new EditExpenseCategoryModel
               {
                   Id = c.Id,
                   Name = c.Name

               }).Single();
            }
        }
        public void Update(EditExpenseCategoryModel model)
        {
                using (var ctx = new ManageExpensesContext2())
                {
                   var category = ctx.ExpenseCategiries.Where(c => c.Id == model.Id).Single();

                  category.Name = model.Name;
                  ctx.SaveChanges();

                }
        }
    }
}