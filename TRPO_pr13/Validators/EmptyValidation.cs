using System.Globalization;
using System.Windows.Controls;

namespace TRPO_pr13.Validators
{
    class EmptyValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = (value ?? "").ToString().Trim();

            if (input == String.Empty)
                return new ValidationResult(false, "Поле должно быть заполнено");

            return ValidationResult.ValidResult;
        }
    }
}
