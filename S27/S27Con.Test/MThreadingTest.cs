using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;

namespace Solve.Tests;

[TestClass]
public class MThreadingTests
{
    /// <summary>
    /// با استفاده از کلاس
    /// Dictionary
    /// یک کلاس جدید به نام 
    /// TSDictionary
    /// پیاده‌سازی کنید که نسبت به استفاده از چند 
    /// thread
    /// مقاوم بوده و درست کار بکند.
    /// </summary>
    [TestMethod]
    public void Q18_ThreadSafeDictoinary()
    {
        Assert.Inconclusive();
        // var tSDictionary = new TSDictionary<int, bool>();
        // ParameterizedThreadStart d1 = (object o) => {
        //     int n = (int)o;
        //     for (int i = 0; i < 1_000_000; i += 2)
        //         tSDictionary[i] = i % n == 0;
        // };
        // ParameterizedThreadStart d2 = (object o) => {
        //     int n = (int)o;
        //     for (int i = 1; i < 1_000_000; i += 2)
        //         tSDictionary[i] = i % n == 0;
        // };

        // var t1 = new Thread(d1);
        // var t2 = new Thread(d2);
        // t1.Start(2);
        // t2.Start(2);
        // t1.Join();
        // t2.Join();
        // for (int i = 0; i < 1_000_000; i++)
        //     Assert.AreEqual(tSDictionary[i], i % 2 == 0);

        // t1 = new Thread(d1);
        // t2 = new Thread(d2);
        // t1.Start(3);
        // t2.Start(3);
        // t1.Join();
        // t2.Join();
        // for (int i = 0; i < 1_000_000; i++)
        //     Assert.AreEqual(tSDictionary[i], i % 3 == 0);
    }

    /// <summary>
    /// متد
    /// async
    /// DataFetcher.FetchDataAsync
    /// را برای شبیه‌سازی گرفتن داده با تاخیر پیاده‌سازی کنید.
    /// این متد باید به اندازه عدد ورودی به میلی ثانیه 
    /// صبر کرده و سپس عبارت خواسته شده در زیر را برگرداند.
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task Q19_AsyncTest()
    {
        Assert.Inconclusive();
        // var sw = Stopwatch.StartNew();
        // int msDelay = 500;
        // string result = await DataFetcher.FetchDataAsync(msDelay);
        // var ms = sw.ElapsedMilliseconds;
        // Assert.AreEqual($"Data fetched afer {msDelay}ms", result);
        // Assert.IsTrue(Math.Abs(ms - msDelay) < 100);

        // msDelay = 700;
        // sw.Restart();
        // result = await DataFetcher.FetchDataAsync(msDelay);
        // ms = sw.ElapsedMilliseconds;
        // Assert.AreEqual($"Data fetched afer {msDelay}ms", result);
        // Assert.IsTrue(Math.Abs(ms - msDelay) < 100);
    }

    /// <summary>
    /// متد 
    /// async
    /// RunTasksConecutively
    /// را به شکلی پیاده‌سازی کنید که 
    /// که تسک‌های ورودی را یکی پس از دیگری اجرا کند
    /// </summary>
    [TestMethod]
    public async Task Q20_RunTasksConecutively()
    {
        Assert.Inconclusive();
        // var wasRun = Enumerable.Repeat(false, 5).ToArray();
        // var tasks = Enumerable.Repeat(100, 5)
        //                       .Select((n,i) => new Task(() => {
        //                           Task.Delay(n).Wait();
        //                           wasRun[i] = true;
        //                       })).ToArray();
        // var sw = Stopwatch.StartNew();
        // await TaskLib.RunTasksConecutively(tasks);
        // var ms = sw.ElapsedMilliseconds;
        // foreach (var wr in wasRun)
        //     Assert.IsTrue(wr);
        // Assert.IsTrue(Math.Abs(ms - 5 * 100) < 100);


        // wasRun = Enumerable.Repeat(false, 3).ToArray();
        // tasks = Enumerable.Repeat(200, 3)
        //                       .Select((n,i) => new Task(() => {
        //                           Task.Delay(n).Wait();
        //                           wasRun[i] = true;
        //                       })).ToArray();        
        // sw = Stopwatch.StartNew();
        // await TaskLib.RunTasksConecutively(tasks);
        // ms = sw.ElapsedMilliseconds;
        // foreach (var wr in wasRun)
        //     Assert.IsTrue(wr);
        // Assert.IsTrue(Math.Abs(ms - 3 * 200) < 100);
    }    

    /// <summary>
    /// متد 
    /// async
    /// RunTasksConecutively
    /// را به شکلی پیاده‌سازی کنید که 
    /// که همه تسک‌های ورودی را بصورت موازی اجرا کند
    /// </summary>
    [TestMethod]
    public async Task Q21_RunTasksInParallel()
    {
        Assert.Inconclusive();
        // var wasRun = Enumerable.Repeat(false, 5).ToArray();
        // var tasks = Enumerable.Repeat(500, 5)
        //                       .Select((n,i) => new Task(() => {
        //                           Task.Delay(n).Wait();
        //                           wasRun[i] = true;
        //                       })).ToArray();
        // var sw = Stopwatch.StartNew();
        // await TaskLib.RunTasksInParallel(tasks);
        // var ms = sw.ElapsedMilliseconds;
        // foreach (var wr in wasRun)
        //     Assert.IsTrue(wr);
        // Assert.IsTrue(ms <  5 * 500 / 2);

        // wasRun = Enumerable.Repeat(false, 3).ToArray();
        // tasks = Enumerable.Repeat(700, 3)
        //                       .Select((n,i) => new Task(() => {
        //                           Task.Delay(n).Wait();
        //                           wasRun[i] = true;
        //                       })).ToArray();        
        // sw = Stopwatch.StartNew();
        // await TaskLib.RunTasksInParallel(tasks);
        // ms = sw.ElapsedMilliseconds;
        // foreach (var wr in wasRun)
        //     Assert.IsTrue(wr);
        // Assert.IsTrue(ms < 700 * 3 / 2);
    }        
}
