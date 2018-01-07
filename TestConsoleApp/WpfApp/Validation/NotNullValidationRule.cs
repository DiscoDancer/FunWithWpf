using System.Windows.Controls;

namespace WpfApp
{
    public class NotNullValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Please provide a value.");

            }

            return new ValidationResult(true, null);
        }
    }
}
