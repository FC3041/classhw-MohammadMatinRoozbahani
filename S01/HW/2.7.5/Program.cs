namespace fibonacci;

class Program
{
    static int fibo(int n){
        if ((n==1) || (n==2)){
            return 1;
        }
        int x = 1;
        int y = 1;
        int z = 0;
        for (int i = 0; i < n-2; i++){
            z = x + y;
            x = y;
            y = z;
        }
        return z;
    }
    static int fibo_recursive(int n){
        if ((n == 1)|| (n==2)){
            return 1;
        }
        return fibo_recursive(n-1) + fibo_recursive(n-2);
    }
    static void Main(string[] args)
    {
        Console.WriteLine(fibo(6));
        Console.WriteLine(fibo_recursive(6));
    }
}
