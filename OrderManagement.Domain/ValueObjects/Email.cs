using System.Text.RegularExpressions;

namespace OrderManagement.Domain.ValueObjects
{
    public sealed class Email
    {
        public string Value { get; }
        private Email(string value)
        {
            Value = value;
        }

        public static Email Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty.");

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Invalid email format.");

            return new Email(value);
        }

        private static bool IsValidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public override string ToString() => Value;
    }
}
