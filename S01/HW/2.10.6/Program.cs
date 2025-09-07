namespace nth_root;

class Program
{
    static double pow(double a, int b){
        double s = 1;
        for (int i = 0; i < b; i++){
            s *= a;
        }
        return s;
    }
    static double n_root(int x, int n){
        if ((x == 0) || (x == 1)){
            return x;
        }
        double low = 0;
        double high = x;
        while (high - low > 0.000001){
            double mid = (low + high) / 2;
            if (pow(mid, n) < x){
                low = mid;
            }
            else{
                high = mid;
            }
        }
        return (low + high) / 2; 
    }
    static void Main(string[] args)
    {
        Console.WriteLine(n_root(5,3));
    }
}
