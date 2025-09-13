using System.Diagnostics;

public class MyTimer : IDisposable{
    public string name;
    private Stopwatch sw = new Stopwatch();
    public MyTimer(string nm){
        name = nm;
        sw.Start();
    }
    public void printsw(){
        Console.WriteLine($"{this.name}");
    }
    public void Dispose(){
        sw.Stop();
        Console.WriteLine($"{this.name},{this.sw.Elapsed.ToString()}");
    }
}