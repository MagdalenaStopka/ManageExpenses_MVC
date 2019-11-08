using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ManageExpenses.Inftrastructure.Validators
{
	public class PasswordStrengthAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			string str = value as string;

			if (string.IsNullOrEmpty(str))
				return false;

			if (str.Length < 5 || str.Length > 12)
				return false;

			var specialChars = new[] { '!', '@', '#', '$', '&' };
			
			var res =  str.ToCharArray().Intersect(specialChars).Count() >= 1;

			return res;
		}
	}
}