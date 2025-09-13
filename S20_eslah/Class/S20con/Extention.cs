using System.Linq;

public static class StringHelper
{
    public static string ToProperCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        char firstChar = char.ToUpper(input[0]);
        string rest = input.Length > 1 ? input.Substring(1).ToLower() : "";
        return firstChar + rest;
    }

    public static int CountNumericChars(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return 0;
        }
        return input.Count(char.IsDigit);
    }
}