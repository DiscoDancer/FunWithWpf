using System.Windows.Controls;

namespace WpfApp
{
    public class NotEmptyStringRule: ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var s = value?.ToString();
            if (string.IsNullOrEmpty(s))
            {
                return new ValidationResult(false, "Please provide a string value.");
                
            }

            return new ValidationResult(true, null);
        }
    }
}
