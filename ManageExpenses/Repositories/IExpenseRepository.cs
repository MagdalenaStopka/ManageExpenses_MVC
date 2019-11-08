using ManageExpenses.Models;

namespace ManageExpenses.Repositories
{
	public interface IExpenseRepository
	{
		void Add(AddExpenseModel model);
		void Remove(long id);
	}
}
