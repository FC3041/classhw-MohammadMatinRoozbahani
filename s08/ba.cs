using System;

public class StringManipulator
{
    public string ReverseWord(string word)
    {
        string reversedWord = "";
        for (int i = word.Length - 1; i >= 0; i--)
        {
            reversedWord += word[i];
        }
        return reversedWord;
    }

    public string ReverseSentence(string sentence)
    {
        string[] words = sentence.Split(' ');
        string reversedSentence = "";
        for (int i = words.Length - 1; i >= 0; i--)
        {
            reversedSentence += words[i] + " ";
        }
        return reversedSentence;
    }

    public string ReverseSentenceAndWords(string sentence)
    {
        string[] words = sentence.Split(' ');
        string reversedSentenceAndWords = "";
        for (int i = words.Length - 1; i >= 0; i--)
        {
            reversedSentenceAndWords += ReverseWord(words[i]) + " ";
        }
        return reversedSentenceAndWords;
    }
}

class Program
{
    static void Main()
    {
        StringManipulator manipulator = new StringManipulator();

        string word = "hello";
        string reversedWord = manipulator.ReverseWord(word);
        Console.WriteLine($"Reversed word: {reversedWord}");

        string sentence = "i love mom";
        string reversedSentence = manipulator.ReverseSentence(sentence);
        Console.WriteLine($"Reversed sentence: [{reversedSentence}]");

        string reversedSentenceAndWords = manipulator.ReverseSentenceAndWords(sentence);
        Console.WriteLine($"Reversed sentence and words: [{reversedSentenceAndWords}]");
    }
}