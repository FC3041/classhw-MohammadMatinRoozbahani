using System.Reflection;
using System.Security.Cryptography;
using S27Con;

namespace Solve.Tests;

[TestClass]
public class ComplexNumberTest
{
    /// <summary>
    /// یک کلاس 
    /// generic
    /// به نام 
    /// ComplexNumber
    /// برای اعداد مختلط تعریف کنید که قسمت حقیقی و موهوم آن بتواند 
    /// یا عدد صحیح باشد یا عدد حقیقی و تست زیر پاس شود
    /// </summary>
    [TestMethod]
    public void Q15_ComplexNumberConstructorTest()
    {
        // Assert.Inconclusive();
        ComplexNumber<double> dcn = new ComplexNumber<double>(1.5, 12.1);
        Assert.AreEqual(dcn.Real, 1.5);
        Assert.AreEqual(dcn.Img, 12.1);
        Assert.AreEqual(dcn.ToString(), "1.5+12.1i");
        Assert.AreEqual(dcn.Real.GetType(), typeof(double));
        Assert.AreEqual(dcn.Img.GetType(), typeof(double));

        ComplexNumber<int> icn = new ComplexNumber<int>(2, 12);
        Assert.AreEqual(icn.Real, 2);
        Assert.AreEqual(icn.Img, 12);
        Assert.AreEqual(icn.ToString(), "2+12i");
        Assert.AreEqual(icn.Real.GetType(), typeof(int));
        Assert.AreEqual(icn.Img.GetType(), typeof(int));
    }


    /// <summary>
    /// عملگر بعلاوه را برای این کلاس پیاده‌سازی کنید بطوریکه تست زیر پاس شود.
    /// </summary>
    [TestMethod]
    public void Q16_ComplexNumberAddTest()
    {
        // Assert.Inconclusive();
        ComplexNumber<double> dcn1 = new ComplexNumber<double>(1.5, 2.5);
        ComplexNumber<double> dcn2 = new ComplexNumber<double>(0.5, 1.5);
        var dcn_sum = dcn1 + dcn2;
        Assert.AreEqual(dcn_sum.Real, 2);
        Assert.AreEqual(dcn_sum.Img, 4);

        ComplexNumber<int> icn1 = new ComplexNumber<int>(1, 2);
        ComplexNumber<int> icn2 = new ComplexNumber<int>(2, 3);
        var icn_sum = icn1 + icn2;
        Assert.AreEqual(icn_sum.Real, 3);
        Assert.AreEqual(icn_sum.Img, 5);
    }
}