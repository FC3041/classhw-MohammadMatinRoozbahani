using System.Diagnostics;

public class MyTimer: IDisposable{
    private string Name;
    private Stopwatch sw;
    public MyTimer(string name){
        this.Name = name;
        this.sw = Stopwatch.StartNew();
    }
    public void Dispose(){
        this.sw.Stop();
        Console.WriteLine(Name + " took " + sw.Elapsed.ToString());
    }
}