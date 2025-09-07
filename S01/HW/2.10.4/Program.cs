namespace sin;

class Program
{
    static double factorial(int n){
        double p = 1;
        for (int i = 1; i < n+1; i++){
            p *= i;
        }
        return p;
    }
    static double pow(double a, int b){
        double s = 1;
        for (int i = 0; i < b; i++){
            s *= a;
        }
        return s;
    }
    static double sin(double x, int iter){
        double sum = 0;
        for (int i = 0; i < iter; i++){
            sum += pow(-1, i)*pow(x, 2*i+1) / factorial(2*i + 1);
        }
        return sum;
    }
    static void Main(string[] args)
    {
        Console.WriteLine(sin(2,20));
    }
}
