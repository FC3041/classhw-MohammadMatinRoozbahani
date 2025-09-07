namespace pythagorean;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 1; i < 99; i++){
            for (int j = i; j < 99; j++){
                for (int k = 1; k < 99; k++){
                    if (i*i + j*j == k*k){
                        Console.WriteLine($"{i}, {j}, {k}");
                    }
                }
            }
        }
    }
}
