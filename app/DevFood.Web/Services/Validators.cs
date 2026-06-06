using System.Text.RegularExpressions;

namespace DevFood.Web.Services
{
    public class Validators
    {
        private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static readonly Regex DigitsOnlyRegex = new(@"^\d+$", RegexOptions.Compiled);

        public static string? Required(string? value, string fieldName)
            => string.IsNullOrWhiteSpace(value) ? $"{fieldName} is required" : null;

        public static string? MinLength(string? value, int min, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            return value.Trim().Length < min ? $"{fieldName} must be at least {min} characters" : null;
        }

        public static string? Email(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return "Email is required";
            return EmailRegex.IsMatch(value) ? null : "Email is not valid";
        }

        public static string? Phone(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return "Phone is required";
            var digits = new string(value.Where(char.IsDigit).ToArray());
            if (digits.Length < 8) return "Phone must contain at least 8 digits";
            return null;
        }

        public static string? Document(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return "Document is required";
            var digits = new string(value.Where(char.IsDigit).ToArray());
            if (digits.Length < 5) return "Document is not valid";
            return null;
        }

        public static string? BirthDate(DateTime? value)
        {
            if (value is null) return "Birth date is required";
            var today = DateTime.Today;
            if (value.Value.Date >= today) return "Birth date must be in the past";
            if (value.Value.Year < today.Year - 120) return "Birth date is not valid";
            var age = today.Year - value.Value.Year;
            if (value.Value.Date > today.AddYears(-age)) age--;
            if (age < 18) return "Must be at least 18 years old";
            return null;
        }

        public static string? PositiveDecimal(decimal value, string fieldName)
            => value <= 0 ? $"{fieldName} must be greater than zero" : null;

        public static string? NonNegativeDecimal(decimal value, string fieldName)
            => value < 0 ? $"{fieldName} cannot be negative" : null;

        public static string? OptionalUrl(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            return Uri.TryCreate(value, UriKind.Absolute, out var uri)
                   && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
                ? null
                : "Photo URL must be a valid http(s) URL";
        }

        public static string? AtLeastOne<T>(IEnumerable<T>? values, string fieldName)
            => values is null || !values.Any() ? $"Select at least one {fieldName}" : null;
    }
}
