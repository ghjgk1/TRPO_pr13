using System.Globalization;
using System.Windows.Controls;
using TRPO_pr13.Service;

namespace TRPO_pr13.Validators
{

    internal class LoginValidation : ValidationRule
    {
        public UsersServise _service { get; set; } = new();

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            string input = (value ?? "").ToString().Trim();

            if (input == String.Empty)
                return new ValidationResult(false, "Поле должно быть заполнено");

            if (input.Length < 5)
                return new ValidationResult(false, "Длина не меньше 5 символов");

            foreach (var user in _service.Users)
            {
                if (user.Login == input)
                    return new ValidationResult(false, "Логин не уникален");
            }

            return ValidationResult.ValidResult;
        }

    }
}
