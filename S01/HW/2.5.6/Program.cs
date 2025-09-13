namespace quadratic;

class Program
{
    static (double, double) quad(double a, double b, double c){
        double s1 = (-b + Math.Sqrt(b*b - 4*a*c))/(2 * a);
        double s2 = (-b - Math.Sqrt(b*b - 4*a*c))/(2 * a);
        return (s1, s2);
    }
    static void Main(string[] args)
    {
        (double s1, double s2) = quad(2, -5, 2);
        Console.WriteLine($"{s1} , {s2}");
    }
}
