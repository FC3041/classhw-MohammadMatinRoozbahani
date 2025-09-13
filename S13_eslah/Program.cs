using System;

public class Program
{
    private static void SortItems<T>(IPerson<T>[] collection, IComparer<IPerson<T>> strategy)
    {
        int n = collection.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (strategy.Compare(collection[j], collection[j + 1]) > 0)
                {
                    (collection[j], collection[j + 1]) = (collection[j + 1], collection[j]);
                }
            }
        }
    }

    private static void PrintList<T>(IPerson<T>[] items)
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public static void Main(string[] args)
    {
        Student[] students = new Student[]
        {
            new Student { FirstName = "Nima", LastName = "Yousefi", GPA = 18, ID = 12 },
            new Student { FirstName = "Tara", LastName = "Mohammadi", GPA = 20, ID = 5 },
            new Student { FirstName = "Kian", LastName = "Rostami", GPA = 17, ID = 4 }
        };

        Console.WriteLine("Original:");
        PrintList(students);
        
        Console.WriteLine("\nSorted by ID:");
        SortItems(students, SortStrategy.ById());
        PrintList(students);
        
        Console.WriteLine("\nSorted by Name:");
        SortItems(students, SortStrategy.ByName());
        PrintList(students);
    }
}