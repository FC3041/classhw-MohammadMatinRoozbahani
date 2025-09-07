namespace moreasciiart;

class Program
{
    static void asc(int n){
        for (int i = 1; i < n+1; i++){
            if (i%2 == 1){
                for (int j = 0; j < i; j++){
                    Console.Write("%");
                }
                Console.WriteLine();
            }
            else {
                for (int j = 0; j < i; j++){
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
    static void Main(string[] args)
    {
        asc(5);
    }
}
