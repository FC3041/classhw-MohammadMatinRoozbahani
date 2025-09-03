using System.Numerics;

namespace S15con;

class Program
{
    static void swap<T>(ref T a, ref T b){
        T tmp = a;
        a = b;
        b = tmp;
    }
    static T bigger<T>(T x, T y) where T:IComparable<T>{
        if (x.CompareTo(y) < 0){
            return y;
        }
        return x;
    }
    static T sum<T>(T x, T y) where T:INumber<T>{
        return x+y;
    }
    static T sumList<T>(T[] listt) where T:INumber<T>{
        T sumn = T.Zero;
        for (int i = 0; i < listt.Length; i++){
            sumn += listt[i];
        }
        return sumn;
    }
    static void printItems<T>(IEnumerable<T> items){
        foreach (T item in items){
            System.Console.WriteLine(item);
        }
    }
    static T sumItems<T>(IEnumerable<T> items) where T:INumber<T>{
        T sumt = T.Zero;
        foreach (T item in items){
            sumt += item;
        }
        return sumt;
    }
    static void printItemsMe<T>(IEnumerable<T> items){
        IEnumerator<T> eor = items.GetEnumerator();
        
    }
    static void Main(string[] args)
    {
        // int a = 5;
        // int b = 6;

        // string aa = "ali";
        // string bb = "hami";
        // Student c = bigger<Student>(aa,bb);
        // Student ssa = null,ssb = null;
        // Student c = bigger<Student>(ssa,ssb);
        // System.Console.WriteLine(c);
        // swap<int> (ref a, ref b);
        // System.Console.WriteLine(a);
        // System.Console.WriteLine(b);
        int[] nums = new int[] {3,4,5,6};
        double[] numsd = new double[] {3.5,3.5,5.4,6.8};
        System.Console.WriteLine($"{sumList<int>(nums)} , {sumList<double>(numsd)}");
    }
}
