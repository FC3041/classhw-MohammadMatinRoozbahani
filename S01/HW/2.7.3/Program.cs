namespace prime;

class Program
{
    static bool is_prime(int n){
        if (n == 1){
            return false;
        }
        for (int i = 2; i < n; i++){
            if (n%i == 0){
                return false;
            }
        }
        return true;
    }
    static void Main(string[] args)
    {
        Console.WriteLine(is_prime(6));
    }
}
