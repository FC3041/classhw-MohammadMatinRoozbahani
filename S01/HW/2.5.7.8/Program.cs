namespace avgsquares;

class Program
{
    static double Avgs(int n){
        var s = 0;
        for (int i = 1; i < n+1; i++){
            s += i*i;
        }
        return s/n;
    }
    static void Main(string[] args)
    {
        double avg = Avgs(10);
        Console.WriteLine(avg);
    }
}
