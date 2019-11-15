using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageExpenses.Models
{
    public class EditExpenseCategoryModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage ="Pole nazwa jest wymagane")]
        public string Name { get; set; }
    }
}