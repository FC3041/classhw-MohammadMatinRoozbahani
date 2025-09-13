using System;
using System.Collections.Generic;

namespace CoreConceptsDemo
{
    class MainApp
    {
        private static void GenericSort<T>(T[] items) where T : IComparable<T>
        {
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = i + 1; j < items.Length; j++)
                {
                    if (items[i].CompareTo(items[j]) > 0)
                    {
                        (items[i], items[j]) = (items[j], items[i]);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- Generic Sort Demo (Undergrads) ---");
            var undergrads = new Undergrad[]
            {
                new Undergrad("Nima", "Yousefi", 1233),
                new Undergrad("Tara", "Mohammadi", 1531),
                new Undergrad("Kian", "Rostami", 1009)
            };
            GenericSort(undergrads);
            foreach(var s in undergrads) Console.WriteLine(s);
            
            Console.WriteLine("\n--- Geometric Shapes Demo ---");
            var shapes = new IGeometricShape[] { new Quad(5, 4), new Disc(10) };
            double totalArea = 0;
            foreach(var shape in shapes) totalArea += shape.CalculateArea();
            Console.WriteLine($"Total area of all shapes: {totalArea:F2}");

            Console.WriteLine("\n--- Code Timer Demo ---");
            using (new CodeTimer("Simple Loop"))
            {
                long total = 0;
                for (int i = 0; i < 10000000; i++) total += i;
            }
        }
    }
}