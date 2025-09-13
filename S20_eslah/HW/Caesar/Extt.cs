using System.Text;

public static class CipherExtensions
{
    public static string ApplyCipher(this string text)
    {
        if (text == null) return null;
        
        var result = new StringBuilder();
        foreach (char c in text)
        {
            char upperChar = char.ToUpper(c);
            switch (upperChar)
            {
                case 'X':
                case 'Y':
                case 'Z':
                    result.Append((char)(c - 23));
                    break;
                default:
                    result.Append((char)(c + 3));
                    break;
            }
        }
        return result.ToString();
    }

    public static string RemoveCipher(this string cipherText)
    {
        if (cipherText == null) return null;

        var result = new StringBuilder();
        foreach (char c in cipherText)
        {
            char upperChar = char.ToUpper(c);
            switch (upperChar)
            {
                case 'A':
                case 'B':
                case 'C':
                    result.Append((char)(c + 23));
                    break;
                default:
                    result.Append((char)(c - 3));
                    break;
            }
        }
        return result.ToString();
    }
}