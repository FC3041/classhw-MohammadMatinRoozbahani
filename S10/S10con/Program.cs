using System.Diagnostics;
using System.Text;

namespace S10con;

class Program
{
    static void Main(string[] args){
        Student s = new Student("hami");
        s.set_name("Hami");
        s.Lastname = "jafari";
        Console.WriteLine(s.fullname);
    }
    static void MainTT(string[] args){
        using MyTimer mt = new MyTimer("string add 75000");
        string s = "";
        for (int i = 0; i < 75000; i++){
            s += i.ToString() + ',';
        }
        System.Console.WriteLine(s.Length);
    }
    static void MainT(string[] args){
        if (args.Length == 0){
            using Student s = new Student("Hami");
            Console.WriteLine("in block");
        }
        Console.WriteLine("end main");
    }


    static void Main6(string[] args){
        using StreamWriter writer = new StreamWriter("a.txt");
        writer.WriteLine("Hello");
    }

    static void Main5(string[] args){
        StringBuilder sb = new StringBuilder();
        using (StringWriter sw = new StringWriter(sb)){
            sw.WriteLine("Hello");
        }
        System.Console.WriteLine(sb.ToString());
    }

    static void Main4(string[] args){
        Stopwatch sw = new Stopwatch();
        sw.Start();
        StringBuilder sb = new StringBuilder(500000);
        for (int i = 0; i < 75000; i++){
            sb.Append(i.ToString());
            sb.Append(',');
        }
        System.Console.WriteLine(sb.ToString().Length);
        sw.Stop();
        System.Console.WriteLine(sw.Elapsed.ToString());
    }

    static void Main3(string[] args){
        Stopwatch sw = new Stopwatch();
        sw.Start();
        string s = "";
        for (int i = 0; i < 75000; i++){
            s += i.ToString() + ',';
        }
        System.Console.WriteLine(s.Length);
        sw.Stop();
        System.Console.WriteLine(sw.Elapsed.ToString());
    }

    static void Main2(string[] args)
    {
        // string[] lines = File.ReadAllLines("test.txt");
        // file.writealllines("test.txt", lines);
        if (args.Length > 2 || args.Length < 1){
            Console.WriteLine("Usage: S10con <filename> [outfile]");
            return;
        }
        string outfile = null;
        if (args.Length > 1){
            outfile = args[1];
        }
        int linecount = 0;
        int charcount = 0;
        int wordcount = 0;
        using (StreamReader reader = new StreamReader(args[0])){
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                linecount++;
                charcount += line.Length;
                foreach (string s in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    wordcount++;
                }
            }
        }
        string output =$"{linecount} {wordcount} {charcount}";
        if (outfile != null){
            using (StreamWriter writer = new StreamWriter(outfile)){
                writer.WriteLine(output);
            }
        }
        else{
            Console.WriteLine(output);
        }
    }
}
