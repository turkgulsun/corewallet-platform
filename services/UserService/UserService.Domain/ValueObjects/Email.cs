using System.Text.RegularExpressions;

namespace UserService.Domain.ValueObjects;

public record Email
{
    public string Value { get; }

    private static readonly Regex EmailRegex = 
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    public Email(string value)
    {
        if (!EmailRegex.IsMatch(value))
            throw new ArgumentException("Invalid email format", nameof(value));

        Value = value;
    }

    public override string ToString() => Value;
}