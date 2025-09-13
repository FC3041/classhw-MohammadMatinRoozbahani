using System;

namespace CipherApp
{
    class Runner
    {
        static void Main(string[] args)
        {
            string originalText = "QuickBrownFoxXYZ";
            Console.WriteLine($"Original:  {originalText}");

            string encodedText = originalText.ApplyCipher();
            Console.WriteLine($"Encoded:   {encodedText}");
            
            string decodedText = encodedText.RemoveCipher();
            Console.WriteLine($"Decoded:   {decodedText}");
        }
    }
}