namespace calendar;

class Program
{
    static string calendarr(int n){
        string[] months = ["january", "february", "march", "april", "may", "june", "july", "august", "september", "october", "november", "december"];
        return months[n-1];
    }
    static void Main(string[] args)
    {
        Console.WriteLine(calendarr(10));
    }
}
