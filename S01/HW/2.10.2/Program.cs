namespace e_general;

class Program
{
    static double factorial(int n){
        double p = 1;
        for (int i = 1; i < n+1; i++){
            p *= i;
        }
        return p;
    }
    static double pow(int a, int b){
        double p = 1;
        for (int i = 0; i < b; i++){
            p *= a;
        }
        return p;
    }
    static double e_gen(int n, int x){
        double sum = 0;
        for (int i = 0; i < n; i++){
            sum += pow(x,i)/factorial(i);
        }
        return sum;
    }
    static void Main(string[] args)
    {
        Console.WriteLine(e_gen(100,1));
    }
}
