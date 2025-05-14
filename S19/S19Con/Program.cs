namespace S19Con;

class Program
{
    public delegate void Logfn (string msg);
    public delegate int Binaryop (int a, int b);


    private static Logfn Log = System.Console.WriteLine;



    static int[] Apply(int[] nums1, int[] nums2, Binaryop op){
        int[] result = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++){
            result[i] = op(nums1[i], nums2[i]);
        }
        return result;
    }

    static int add(int a, int b) => a+b;
    static int mul(int a, int b) => a*b;

    static void Main(string[] args)
    {
        int[] nums1 = new int[4]{1,2,3,4};
        int[] nums2 = new int[4]{2,3,4,5};
        int[] result = Apply(nums1, nums2, add);

        foreach (var r in result){
            Log?.Invoke(r.ToString());
        }
    }
}
