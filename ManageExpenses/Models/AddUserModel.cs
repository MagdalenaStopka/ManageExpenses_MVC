using ManageExpenses.Inftrastructure.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageExpenses.Models
{
	public class AddUserModel
	{
		[Required(ErrorMessage ="Imię jest wymagane")]
		public string FirstName { get; set; }

		[Required(ErrorMessage ="Nazwisko jest wymagane")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Login jest wymagany")]
		public string Login { get; set; }

		//[Required(ErrorMessage = "Hasło jest wymagane")]
		[PasswordStrength(ErrorMessage ="Hasło nie spełnia polityki bezpieczeństwa")]
		public string Password { get; set; }
        [DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }
	}
}