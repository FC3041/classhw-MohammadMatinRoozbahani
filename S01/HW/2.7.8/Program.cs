namespace date;

class Program
{
    static int m_date(int n){
        if (n <= 6){
            return 31;
        }
        else if (n == 12){
            return 29;
        }
        return 30;
    }
    static void Main(string[] args)
    {
        Console.WriteLine(m_date(2));
    }
}
