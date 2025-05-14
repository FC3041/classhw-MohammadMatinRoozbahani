using System.Runtime.InteropServices;

namespace S22Con;

class Program
{
    static string L2S(IEnumerable<int> nums){
        return string.Join(" ", nums);
    }

    static bool IsPrime(int n){
        if (n < 2){
            return false;
        }
        for (int i = 2; i < n; i++){
            if (n%i == 0){
                return false;
            }
        }
        return true;
    }

    static void Main(string[] args)
    {
        var nums = Enumerable.Range(1,100).Where(i => IsPrime(i));
        nums.Join(nums, n => n%10 + n/10, k => k/10 + k%10, (n, k) => (n, k)).Where(t => t.n != t.k).ToList().ForEach(w => System.Console.WriteLine(w));

        // Enumerable.Range(0,100).Where(i => i%2 == 1).GroupBy(i => i/10).Select(ig => (ig.Key, ig.Average())).ToList().ForEach(w => System.Console.WriteLine($"{w.Item1} , {w.Item2}"));
    }
}
