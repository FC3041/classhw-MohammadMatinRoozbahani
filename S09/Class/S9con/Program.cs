namespace S9con;

class Program
{
    static void Main(string[] args)
    {
        int x = int.Parse("534");
        int y = 5;
        y.CompareTo(x);
        Console.WriteLine(y.ToString());

        int i = 5;
        object o = i;
        int n = (int)o;

        Student s = new Student(
            name:"Hami Jafari",
            stdid:40351243,
            natid:0151586589,
            credits:18,
            active:true);
        string str = "Hami Jafari,40351243,151586589,18,True";
        Student ss = Student.Parse(str);

        Console.WriteLine(ss.Equals(s));

        File.WriteAllLines("test.csv",new string[]{s.ToString(), ss.ToString()});
        // string[] lines = File.ReadAllLines("test.csv");
    }
}
