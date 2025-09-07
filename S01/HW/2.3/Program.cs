namespace rocketship;

class Program
{
    static void Body(int w, int h){
        for (int i = 0; i < h; i++){
            Console.WriteLine("+" + new string('*', w - 2) + "+");
        }
        Console.WriteLine("+" + new string('-', w - 2) + "+");
    }
    static void Head(int w){
        Console.WriteLine(new string(' ', w / 2) + "^");
        for (int i = 1; i <= w / 2; i++){
            Console.WriteLine(new string(' ', w / 2 - i) + new string('/', i) + "|" + new string('\\', i));
        }
    }
    static void RocketshipFunction(int w, int h, int n){
        Head(w);
        Console.WriteLine("+" + new string('-', w - 2) + "+");
        for (int i = 0; i < n; i++){
            Body(w, h);
        }
        Head(w);
    }
    static void Main(string[] args){
        RocketshipFunction(7, 5, 3);
    }
}
