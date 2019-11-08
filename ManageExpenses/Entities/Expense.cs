namespace ManageExpenses.Entities
{
	public class Expense
	{
		public long Id { get; set; }
		public string Name { get; set; }

        //kompozycja
		public ExpenseCategory Category { get; set; }

		public User User { get; set; }
		public decimal Value { get; set; }
	}
}