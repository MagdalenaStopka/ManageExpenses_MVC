using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManageExpenses.Entities;
using ManageExpenses.Models;

namespace ManageExpenses.Repositories
{
    public class ExpenseInMemoryRepository : IExpenseRepository
    {
        private IUserRepository _userRepository;
        private IExpenseCategoryRepository _categoryRepository;


        public ExpenseInMemoryRepository(IUserRepository userRepository,
            IExpenseCategoryRepository categoryRepository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }
        private IList<Expense> _expenses = new List<Expense>();

        public void Add(AddExpenseModel model)
        {
            ExpenseCategory category = _categoryRepository.Get(model.CategoryId);
            Expense expense = new Expense()
            {
                Id = GetId(),
                User = _userRepository.Get(model.UserId),
                Category = category,
                Name = model.Name,
                Value = model.Value


            };
            _expenses.Add(expense);
        }

        public void Remove(long id)
        {
           var expenseToRemove = _expenses.SingleOrDefault(e => e.Id == id);
            if(expenseToRemove != null)
            {
                _expenses.Remove(expenseToRemove);
            }
        }

        private long GetId()
        {
            if (_expenses.Count > 0)
            {
                return _expenses.Max(x => x.Id) + 1;

        
            }

            return 1;
        }
    }
}