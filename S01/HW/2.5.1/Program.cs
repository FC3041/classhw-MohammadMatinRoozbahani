namespace farrenhite;

class Program
{
    static void Main()
    {
        double f = 112.2;
        double c = (f - 32) * (5f / 9f);
        double k = c + 273.15;

        Console.WriteLine($"Celsius : {c:F3}");
        Console.WriteLine($"Kelvin : {k:F3}");
    }
}
