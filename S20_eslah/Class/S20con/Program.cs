using System;
using System.Collections.Generic;
using System.Linq;

namespace S20_Refactored
{
    public class Pair<TFirst, TSecond>
    {
        public TFirst First;
        public TSecond Second;

        public Pair(TFirst first, TSecond second)
        {
            this.First = first;
            this.Second = second;
        }
    }

    class Demo
    {
        public static (int Min, int Max, double Average) Summarize(List<int> data)
        {
            if (data == null || !data.Any())
                throw new ArgumentException("Input list cannot be null or empty.");

            int min = data.Min();
            int max = data.Max();
            double avg = Math.Round(data.Average(), 2);

            return (min, max, avg);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- Complex Number Demo ---");
            Complex num1 = new Complex(5, 10);
            Complex num2 = new Complex(3, 4);
            Complex sum = num1 + num2;
            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine("\n--- String Helper Demo ---");
            string phrase = "hello world";
            Console.WriteLine(phrase.ToProperCase());
            string data = "abc123def456";
            Console.WriteLine($"'{data}' has {data.CountNumericChars()} digits.");

            Console.WriteLine("\n--- Tuple Demo ---");
            var student = ("Nima", 23);
            Console.WriteLine($"Student: {student.Item1}");
            
            var analysis = Summarize(new List<int> { 10, 20, 5, 15, 30 });
            Console.WriteLine($"Min: {analysis.Min}, Max: {analysis.Max}, Avg: {analysis.Average}");
        }
    }
}