using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace E3;
public class MyPointType1
{
    public int X { get; set; }
    public int Y { get; set; }
}

public struct MyPointType2
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class Animal
{
    public virtual string MakeSound()
    {
        return "Some generic animal sound";
    }
}
 
public class Dog : Animal
{
    public override string MakeSound()
    {
        return "Woof";
    }
}
public class Comparer<T> where T : IComparable<T>
{
    private readonly T _a;
    private readonly T _b;

    public Comparer(T a, T b)
    {
        _a = a;
        _b = b;
    }

    public T GetLarger()
    {
        return _a.CompareTo(_b) >= 0 ? _a : _b;
    }
}

public class Product : IComparable<Product>
{
    public string Name {get; set;}
    public decimal Price {get ; set;}
    public int CompareTo(Product other)
    {
        if (other == null) return 1;
        return Price.CompareTo(other.Price);

    }
}

public class ResourceManager : IDisposable
{
    public bool IsDisposed { get; private set; }

    public ResourceManager()
    {
        IsDisposed = false;
    }

    public void Dispose()
    {
        IsDisposed = true;
        GC.SuppressFinalize(this);
    }

    ~ResourceManager()
    {
        Dispose();
    }
}



public class Sale
{
    public string Category { get; set; }
    public int Amount { get; set; }
}

public static class LinqProblems
{
    public static IEnumerable<int> FilterAndDouble(IEnumerable<int> numbers)
    {
        return numbers
            .Where(n => n % 2 == 0 && n > 5)
            .Select(n => n * 2);
    }

    public static Dictionary<string, int> GetTotalAmountByCategory(IEnumerable<Sale> sales)
    {
        return sales
            .GroupBy(s => s.Category)
            .ToDictionary(
                g => g.key,
                g => g.Sum(s => s.Amount)
            );
    }
}
public static class LambdaProblems
{
    public static Func<string, int> GetStringLengthCalculator()
    {
        return s => s.Length;
    }
}
public static class Closures
{
    public static Func<int> CreateCounter()
    {
        int count = 0;
        return () =>
        {
            count++;
            return count;
        };
    }
}

public class SafeCounter
{
    private int _count = 0;
    private readonly object _lock = new object();

    public int Count => _count;

    public void Increment()
    {
        lock (_lock)
        {
            _count++;
        }
    }
}

public static class DelegateProblems
{
    public delegate string StringProcessor(string input);

    public static string ProcessString(string input, StringProcessor processor)
    {
        return processor(input);
    }

    public static string ToUpper(string input) => input.ToUpper();

    public static string ToLower(string input) => input.ToLower();
}

// public class Sale
// {
//     public string Category { get; set; }
//     public int Amount { get; set; }
// }

// public static class LinqProblems
// {
//     public static IEnumerable<int> FilterAndDouble(IEnumerable<int> numbers)
//     {
//         return numbers
//             .Where(n => n % 2 == 0 && n > 5)
//             .Select(n => n * 2);
//     }

//     public static Dictionary<string, int> GetTotalAmountByCategory(IEnumerable<Sale> sales)
//     {
//         return sales
//             .GroupBy(s => s.Category)
//             .ToDictionary(
//                 g => g.key,
//                 g => g.Sum(s => s.Amount)
//             );
//     }
// }



// public class Money : IEquatable<Money>
// {
//     public int Amount { get; }
//     public string Currency { get; }

//     public Money(int amount, string currency)
//     {
//         Amount = amount;
//         Currency = currency;
//     }

//     public static Money operator +(Money a, Money b)
//     {
//         if (a.Currency != b.Currency)
//             throw new InvalidOperationException("Cannot add money with different currencies.");
//         return new Money(a.Amount + b.Amount, a.Currency);
//     }

//     public static bool operator ==(Money a, Money b)
//     {
//         if (ReferenceEquals(a, b)) return true;
//         if (a is null || b is null) return false;
//         return a.Equals(b);
//     }

//     public static bool operator !=(Money a, Money b) => !(a == b);

//     public bool Equals(Money other)
//     {
//         if (other is null) return false;
//         return Amount == other.Amount && Currency == other.Currency;
//     }

//     public override bool Equals(object obj) => Equals(obj as Money);

//     public override int GetHashCode() => HashCode.Combine(Amount, Currency);
// }





// public class Sale
// {
//     public string Category { get; set; }
//     public int Amount { get; set; }
// }

// public static class LinqProblems
// {
//     public static IEnumerable<int> FilterAndDouble(IEnumerable<int> numbers)
//     {
//         return numbers
//             .Where(n => n % 2 == 0 && n > 5)
//             .Select(n => n * 2);
//     }

//     public static Dictionary<string, int> GetTotalAmountByCategory(IEnumerable<Sale> sales)
//     {
//         return sales
//             .GroupBy(s => s.Category)
//             .ToDictionary(
//                 g => g.key,
//                 g => g.Sum(s => s.Amount)
//             );
//     }
// }





public class Money : IEquatable<Money>
{
    public int Amount { get; }
    public string Currency { get; }

    public Money(int amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new InvalidOperationException("Cannot add money with different currencies.");
        return new Money(a.Amount + b.Amount, a.Currency);
    }

    public static bool operator ==(Money a, Money b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Money a, Money b) => !(a == b);

    public bool Equals(Money other)
    {
        if (other is null) return false;
        return Amount == other.Amount && Currency == other.Currency;
    }

    public override bool Equals(object obj) => Equals(obj as Money);

    public override int GetHashCode() => HashCode.Combine(Amount, Currency);
}
