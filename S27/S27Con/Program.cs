using System.Numerics;
using System.Reflection.Metadata;

public static class Basic
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}

public class ComplexNumber<T> where T : INumber<T>
{
    public T Real;
    public T Img;

    public ComplexNumber(T r, T i)
    {
        this.Real = r;
        this.Img = i;
    }

    public override string ToString()
    {
        return $"{this.Real}+{this.Img}i";
    }

    public static ComplexNumber<T> operator +(ComplexNumber<T> a, ComplexNumber<T> b)
    {
        return new ComplexNumber<T>(a.Real + b.Real, a.Img + b.Img);
    }
}

public abstract class Developer
{
    public string name;
    public bool IsFemale;

    public Developer(string n, bool IsF)
    {
        this.name = n;
        this.IsFemale = IsF;
    }

    public virtual string Name
    {
        get
        {
            return (IsFemale ? "خانم " : "آقای ") + this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public abstract int Salary { get; }
}

public class SeniorDeveloper : Developer
{
    public SeniorDeveloper(string n, bool i) : base(n, i) { }

    public override int Salary => 4_500_000;

    public virtual int CalculateSalary(int hours)
    {
        return Salary + (hours * 50_000);
    }
}


public class JuniorDeveloper : Developer
{
    public JuniorDeveloper(string n, bool i) : base(n, i) { }

    public override int Salary => 2_800_000;

}


public class FullStackDeveloper : SeniorDeveloper
{
    public FullStackDeveloper(string n, bool i) : base(n, i) { }

    public override int Salary => 7_500_000;

    public override int CalculateSalary(int hours)
    {
        return Salary + (hours * 70_000);
    }

    public override string Name
    {
        get
        {
            return ("دکتر ") + this.name;
        }
        set
        {
            this.name = value;
        }
    }

}


public class InflationStat
{
    public string Country;
    public Dictionary<int, double> Values;
    public static string[] Indicators;

    public static InflationStat Parse(string line, string indicatorsLine) => new InflationStat(line, indicatorsLine);

    public InflationStat(string line, string indicatorsLine)
    {
        Indicators ??= indicatorsLine.Split(',')
                                      .Select(e => e.Trim('"', ' '))
                                      .ToArray();
        var values = line.Split(',', StringSplitOptions.RemoveEmptyEntries)
                         .Select(e => e.Trim('"', ' '))
                         .Select(x => x == string.Empty ? "0.0" : x)
                         .ToArray();

        this.Country = values[0];

        Values = values
            .Skip(4)
            .Zip(Indicators.Skip(4))
            .ToDictionary(
                x => int.Parse(x.Second),
                x => Math.Round(double.Parse(x.First), 2)
            );
    }

    public double this[int year] => Values[year]; 

}
class Program
{
    static void Main(string[] args)
    {
    }
}
