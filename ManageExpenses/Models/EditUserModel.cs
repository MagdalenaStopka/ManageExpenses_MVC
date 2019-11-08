using ManageExpenses.Inftrastructure.Validators;
using System.ComponentModel.DataAnnotations;

namespace ManageExpenses.Models
{
	public class EditUserModel
	{
		public long Id { get; set; }

		[Required(ErrorMessage = "Imię jest wymagane")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Nazwisko jest wymagane")]
		public string LastName { get; set; }

		[PasswordStrength(ErrorMessage = "Nowe hasło nie spełnia polityki bezpieczeństwa")]
		public string Password { get; set; }
	}
}