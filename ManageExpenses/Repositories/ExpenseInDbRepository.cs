using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManageExpenses.Entities;
using ManageExpenses.Inftrastructure;
using ManageExpenses.Models;

namespace ManageExpenses.Repositories
{
    public class ExpenseInDbRepository : IExpenseRepository
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        public ExpenseInDbRepository(ICurrentUserProvider currentUserProvider)
        {
            _currentUserProvider = currentUserProvider;
        }
        public void Add(AddExpenseModel model)
        {
            using (var ctx = new ManageExpensesContext2())
            {
                var currentUserId = _currentUserProvider.GetCurrentUserId();
                var user = ctx.Users.Find(currentUserId);

                ExpenseCategory category = ctx.ExpenseCategiries.SingleOrDefault(ec => ec.Id == model.CategoryId);
                //User user = ctx.Users.SingleOrDefault(u => u.Id == model.UserId);


               Expense expense = new Expense()
                {
                    
                    User =user,
                    Category = category,
                    Name = model.Name,
                    Value = model.Value


                };
                ctx.Expenses.Add(expense);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<ExpenseListItemModel> GetExpensesForCurrentUser()
        {
            using (var ctx = new ManageExpensesContext2())
            {
                return ctx.Expenses.Select(e => new ExpenseListItemModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    CategoryName = e.Category.Name,
                    Value = e.Value
                }).ToList();
            }
        }

        public IEnumerable<ExpenseListItemModel> GetExpensesForCurrentUser(long categoryId)
        {
            using (var ctx = new ManageExpensesContext2())
            {
                return ctx.Expenses.Where(e => e.Category.Id == categoryId).Select(e => new ExpenseListItemModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    CategoryName = e.Category.Name,
                    Value = e.Value
                }).ToList();
            }
        }

        public void Remove(long id)
        {
            using (var ctx = new ManageExpensesContext2())
            {
                var expenseToRemove = ctx.Expenses.SingleOrDefault(e => e.Id == id);
                if (expenseToRemove != null)
                {
                    ctx.Expenses.Remove(expenseToRemove);
                }

                ctx.SaveChanges();
            }
        }
    }
}