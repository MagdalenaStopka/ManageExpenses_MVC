using ManageExpenses.Models;
using System.Collections.Generic;

namespace ManageExpenses.Repositories
{
	public interface IExpenseRepository
	{
		void Add(AddExpenseModel model);
		void Remove(long id);
        IEnumerable<ExpenseListItemModel> GetExpensesForCurrentUser();
	}
}
