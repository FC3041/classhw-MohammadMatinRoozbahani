using System;
using System.Collections.Generic;

public interface IPerson<T> : IComparable<IPerson<T>>
{
    T ID { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string FullName { get; }
}

public class Student : IPerson<int>
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double GPA { get; set; }

    public string FullName
    {
        get { return $"{FirstName} {LastName}"; }
    }

    public int CompareTo(IPerson<int> other)
    {
        if (other == null) return 1;
        return this.ID.CompareTo(other.ID);
    }

    public override string ToString()
    {
        return $"{ID}: {FullName}";
    }
}

public static class SortStrategy
{
    public static IComparer<IPerson<int>> ById()
    {
        return new IdComparer();
    }

    public static IComparer<IPerson<int>> ByName()
    {
        return new NameComparer();
    }

    private class IdComparer : IComparer<IPerson<int>>
    {
        public int Compare(IPerson<int> x, IPerson<int> y)
        {
            return x.ID.CompareTo(y.ID);
        }
    }

    private class NameComparer : IComparer<IPerson<int>>
    {
        public int Compare(IPerson<int> x, IPerson<int> y)
        {
            return x.FullName.CompareTo(y.FullName);
        }
    }
}