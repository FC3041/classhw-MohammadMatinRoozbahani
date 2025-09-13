using System.Reflection;
using System.Security.Cryptography;

namespace S27Con.Test;

[TestClass]
public class BasicTests
{
    /// <summary>
    /// متد 
    /// Swap
    /// را به شکلی پیاده‌سازی کنید که تست زیر پاس شود
    /// </summary>
    [TestMethod]
    
    public void Q17_SwapTest()
    {
        // Assert.Inconclusive();
        int a = 5;
        int b = 6;
        Basic.Swap(ref a, ref b);
        Assert.AreEqual(a, 6);
        Assert.AreEqual(b, 5);

        double da = 5.1;
        double db = 6.2;
        Basic.Swap(ref da, ref db);
        Assert.AreEqual(da, 6.2);
        Assert.AreEqual(db, 5.1);
    }
}