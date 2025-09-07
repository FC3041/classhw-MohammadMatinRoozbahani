namespace S23Con;

class Program
{
    static int COUNT = 1000000;
    static int counter = 0;
    static void Main(string[] args)
    {
        Thread t1 = new Thread(() => {
            for (int i = 0; i < COUNT; i++){
                counter++;
            }
        });

        Thread t2 = new Thread(() => {
            for (int i = 0; i < COUNT; i++){
                counter--;
            }
        });

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        System.Console.WriteLine(counter);
    }
}
