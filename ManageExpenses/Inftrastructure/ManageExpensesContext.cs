using ManageExpenses.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManageExpenses.Inftrastructure
{
    public class ManageExpensesContext2 :DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategiries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}