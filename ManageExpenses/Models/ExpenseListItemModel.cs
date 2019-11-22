using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageExpenses.Models
{
    public class ExpenseListItemModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CategoryName{get; set;}
        public decimal Value { get; set; }
    }
}