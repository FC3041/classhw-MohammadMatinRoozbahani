namespace ln;

class Program
{
    static double exp(double x, int terms = 20){
        double sum = 1;
        double term = 1;
        for (int i = 1; i <= terms; i++){
            term *= x / i;
            sum += term;
        }
        return sum;
    }
    static double Ln(double x, double precision = 1e-10){
        if (x == 1){
            return 0;
        }
        double low = 0, high = x;
        while (high - low > precision){
            double mid = (low + high) / 2;
            if (exp(mid) < x){
                low = mid;
            }
            else{
                high = mid;
            }
        }    
        return (low + high) / 2;
    }
    static void Main()
    {
        Console.WriteLine(Ln(5));
    }
}
