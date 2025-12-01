using System.Globalization;
using System.Windows.Controls;

namespace TRPO_pr13.Validators
{
    public class PasswordValidation :ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = (value ?? "").ToString().Trim();

            if (input == String.Empty)
                return new ValidationResult(false, "Поле должно быть заполнено");

            if (input.Length < 8)
                return new ValidationResult(false, "Длина не меньше 8 символов");

            if (!input.Any(char.IsDigit))
                return new ValidationResult(false, "Должен содержать цифры");

            if (!input.Any(char.IsSymbol))
                return new ValidationResult(false, "Должен содержать символы");
            
            if (!input.Any(char.IsUpper))
                return new ValidationResult(false, "Должен содержать буквы в верхнем регистре");

            if (!input.Any(char.IsLower))
                return new ValidationResult(false, "Должен содержать буквы в нижнем регистре");


            return ValidationResult.ValidResult;
        }

    }
}
