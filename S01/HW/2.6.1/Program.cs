namespace leapyear;

class Program
{
    static bool leap(int n){
        if ((n%100 != 0) && (n%4 == 0)){
            return true;
        }
        return false;
    }
    static void Main(string[] args)
    {
        Console.WriteLine(leap(1404));
    }
}
