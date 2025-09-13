namespace closeness;

class Program
{
    static bool is_close(double a, double b){
        if (((a-0.001 <= b) && (b <= a+0.001)) || ((b-0.001 <= a) && (a <= b+0.001))){
            return true;
        }
        return false;
    }
    static void Main(string[] args)
    {
        double a = 10;
        double b = 10.002;
        Console.WriteLine(is_close(a,b));
    }
}
