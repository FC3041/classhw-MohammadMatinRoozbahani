using System.Text.RegularExpressions;
using System.ComponentModel;

namespace S25;

class Program
{
    static void Main(string[] args)
    {
        using var client = new HttpClient();
        
        string result = client.GetStringAsync("https://www.digikala.com/").Result;
        File.WriteAllText("index.html", result);
       
    }
}