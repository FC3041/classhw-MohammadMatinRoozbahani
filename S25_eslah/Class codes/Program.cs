namespace S25;

class Program333
{
    static double dowork(object m)
    {
        double n = (double)m;
        double d = 1;
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} => {n}");
        for (int i = 1; i < n; i++)
        {
            d = (d * i) %(Math.Pow(10,9) +7);
        }
        return d;
        
    }
    static async Task Main33(string[] args)
    {
        double lastvalue = 1000;
      
        List<Task> tasks = new List<Task>();
        for (int i = 1; i < 20; i++)
        {
            lastvalue = await Task<double>.Factory
                .StartNew(dowork, lastvalue);
   

            ;
        }
   
    }
    static void Main6(string[] args)
    {
        double sum = 0;
        List<Task> tasks = new List<Task>();
        for (int i = 1; i < 20; i++)
        {
            tasks.Add(Task<double>.Factory
            .StartNew(dowork, i * 10_000_000)
            .ContinueWith(t =>
   
            {
                lock (tasks)
                {
                    sum += t.Result;
                }
            }
           
        ));
        }
        Task.WaitAll(tasks);
        System.Console.WriteLine(sum);
       
    }
    static void Main4(string[] args)
    {
        var tasks = new Task<double>[19];
        double sum = 0;
        for (int i = 1; i < 20; i++)
        {
            tasks[i - 1] = Task<double>.Factory.StartNew(dowork, i * 10_000_000);
        }
        Task.WaitAll(tasks);
        foreach (var t in tasks)
        {
            sum += t.Result;
        }
        System.Console.WriteLine(sum);
    }
    static void Main3(string[] args)
    {
        var tasks = new Task<double>[19];
        double sum = 0;
        for (int i = 1; i < 20; i++)
        {
            tasks[i - 1] = Task.Run(
            () => dowork(10_000_000 * i));
         


        }
        Task.WaitAll(tasks);
        foreach (var t in tasks)
        {
            sum += t.Result;
        }
        System.Console.WriteLine(sum);
    }
    static void Main2(string[] args)
    {
        Task<double> t = new Task<double>(
            () =>
            {
                double d = 1;
                for (int i = 1; i < 10_000_000; i++)
                {
                    d = (d * i) % int.MaxValue;
                }
                return d;
            }
        );
        t.Start();
 
        while (true)
        {
            if (t.Status == TaskStatus.RanToCompletion)
            {
                break;
            }
            System.Console.WriteLine("waiting");
            Task td = Task.Delay(10);
            td.Wait();
        }
        System.Console.WriteLine(t.Result);
        
    }
    
}
