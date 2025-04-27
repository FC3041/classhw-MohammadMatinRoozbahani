namespace S18Con;

class Program
{
    delegate T fn_int_2int<T>(T a, T b);

    // static void apply<T>(T[] nums1, T[] nums2, T[] result, fn_int_2int<T> fn){
    //     for (int i = 0; i < nums1.Length; i++){
    //         result[i] = fn(nums1[i], nums2[i]);
    //     }
    // }
    static void apply<T>(T[] nums1, T[] nums2, T[] result, Func<T, T, T> fn){
        for (int i = 0; i < nums1.Length; i++){
            result[i] = fn(nums1[i], nums2[i]);
        }
    }
    static int Add(int a, int b){
        return a+b;
    }
    static int Mul(int a, int b){
        return a * b;
    }
    static void dodo<T>(T[] values, Action<T> a){
        foreach (var v in values){
            a(v);
        }
    }

    static void w2f<T>(T v){
        string filename = "a.txt";
        if (v != null){
            File.AppendAllText(filename, v.ToString() + "\n");
        }
    }

    static void Main(string[] args)
    {
        // Func<int, int> f1;
        // Action<int> f2;
        Func<int, int, int> f = (a, b) => a * b + a - 2;

        int[] n1 = new int[3] {1,2,3};
        int[] n2 = new int[3] {-1,-2,-3};
        int[] res = new int[3];

        apply(n1,n2,res,Mul);
        // foreach (var i in res){
        //     System.Console.WriteLine(i);
        // }
        dodo(res, System.Console.WriteLine);
        dodo(res, w2f);
    }
}
