namespace S20Con;

class Program
{
    public static Tuple<double,double,double> CalcTuple(List<double> nums){
        nums.Sort();
        return new Tuple<double, double, double>(nums[0], nums[nums.Count-1], nums.Average());
    }
    
    static void Main(string[] args){
        Tuple<string, int> t1 = new Tuple<string, int> ("Hami", 19);
        System.Console.WriteLine(t1.Item1);

        var t2 = new Tuple<string, int, int> ("ahmagh", 19, 0);

        var t3 = Tuple.Create<string, int> ("samin", 17);

        List<double> nums = new List<double>{2,1,3,4,54,5};
        System.Console.WriteLine($"{CalcTuple(nums).Item1},{CalcTuple(nums).Item2},{CalcTuple(nums).Item3}");
    }




    static void Main2(string[] args){
        string name = "computer";
        string name2 = name.TitleCase();
        System.Console.WriteLine(name2);
    }

    // TODO
    //write a method for string to implement cesar encoding and decoding
    // Use an Extension of string class 



    static void Main1(string[] args){
        int x = 5;
        double y = 6.8;

        y = x;  // implicit
        x = (int)y;  // explicit

        ComplexNumber c1 = new ComplexNumber(3,6);
        ComplexNumber c2 = new ComplexNumber(2,3.5);

        y = c1; //implicit
        c2 = y;
    }




    static void Main0(string[] args)
    {
        ComplexNumber c1 = new ComplexNumber(3,6);
        ComplexNumber c2 = new ComplexNumber(2,3.5);
        c1.Print_CN();

        ComplexNumber c_sum = c1 + c2;
        System.Console.WriteLine(c_sum[true]);
    }
}
