using System.Windows.Controls;

namespace WpfApp.ValidationRules
{
    public class StringToIntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out var i))
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, "Please enter a valid integer value.");
        }
    }

}