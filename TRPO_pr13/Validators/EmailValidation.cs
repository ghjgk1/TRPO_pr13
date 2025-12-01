using System.Globalization;
using TRPO_pr13.Service;
using System.Windows.Controls;

namespace TRPO_pr13.Validators
{
    internal class EmailValidation : ValidationRule
    {
        public UsersServise _service { get; set; } = new();

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            string input = (value ?? "").ToString().Trim();

            if (input == String.Empty)
                return new ValidationResult(false, "Поле должно быть заполнено");

            if (!input.Contains('@'))
                return new ValidationResult(false, "Должен содержать @");

            foreach (var user in _service.Users)
            {
                if (user.Email == input)
                    return new ValidationResult(false, "Email не уникален");
            }

            return ValidationResult.ValidResult;
        }
    }
}
