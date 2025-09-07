namespace S25Con;

class Program
{
    static void Main(string[] args)
    {
        using var client = new HttpClient();
        string result = client.GetStringAsync("https://www.tabnak.ir").Result;

        System.Console.WriteLine(result);
    }
}