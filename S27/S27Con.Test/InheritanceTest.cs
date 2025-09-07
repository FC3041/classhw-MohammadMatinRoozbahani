namespace S27Con.Tests;

[TestClass]
public class InheritanceTest
{
    public class DeveloperTemp : Developer
    {
        public DeveloperTemp(string name, bool isFemale) : base(name, isFemale)
        {
        }

        public override int Salary => 0;
    }
    
    /// <summary>
    /// یک کلاس 
    /// abstract
    /// به نام 
    /// Developer
    /// تعریف کنید به شکلی که تست زیر پاس شود.
    /// </summary>
    [TestMethod]
    public void Q11_ProgrammerTest()
    {
        // Assert.Inconclusive();
        // Programmer should be an abstract class
        Assert.IsTrue(typeof(Developer).IsAbstract);

        // It should not have an empty constructor
        Assert.IsTrue(typeof(Developer).GetConstructor(Type.EmptyTypes) == null);

        Developer p = new DeveloperTemp("سارا محمودی", true);
        Assert.AreEqual(p.Name, "خانم سارا محمودی");
        Assert.AreEqual(p.IsFemale, true);
        p.Name = "زهرا خداداد";
        Assert.AreEqual(p.Name, "خانم زهرا خداداد");

        p = new DeveloperTemp("اردیشیر اصفهانی", false);
        Assert.AreEqual(p.Name, "آقای اردیشیر اصفهانی");
        Assert.AreEqual(p.IsFemale, false);
        p.Name = "علی کردان";
        Assert.AreEqual(p.Name, "آقای علی کردان");
    }

    /// <summary>
    /// کلاس
    /// SeniorDeveloper 
    /// را بگونه‌ای تعریف و پیاده‌سازی کنید که از کلاس
    /// Developer
    /// به ارث برده و 
    /// نرخ پایه حقوق او
    /// (Salary)
    /// ۴.۵ میلیون باشد.
    /// همچنین به ازای هر ساعت کار اضافه ساعتی ۵۰ تومن دریافت می‌کند.
    /// </summary>
    [TestMethod]
    public void Q12_SeniorTest()
    {
        // Assert.Inconclusive();
        // It should not have an empty constructor
        Assert.IsTrue(typeof(SeniorDeveloper).GetConstructor(Type.EmptyTypes) == null);
        // It should inherit from Programmer
        Assert.IsTrue(typeof(Developer).IsAssignableFrom(typeof(SeniorDeveloper)));

        Developer p = new SeniorDeveloper("غزاله عباسی", true);
        Assert.AreEqual(p.Name, "خانم غزاله عباسی");
        Assert.AreEqual(p.IsFemale, true);
        Assert.AreEqual(p.Salary, 4_500_000);

        Assert.AreEqual((p as SeniorDeveloper).CalculateSalary(10), 5_000_000);

        // Student should not override/modify the Name get property.
        Assert.AreNotEqual(
            typeof(SeniorDeveloper).GetMethod("get_Name").DeclaringType,
            typeof(SeniorDeveloper));
    }

    /// <summary>
    /// کلاس
    /// JuniorDeveloper
    /// را هم به شکلی تعریف و پیاده‌سازی کنید که 
    /// از کلاس 
    /// Developer
    ///  به ارث ببرد و حقوق پایه
    /// ۲.۸ میلیون 
    /// داشته باشد.
    /// </summary>
    [TestMethod]
    public void Q13_JuniorTest()
    {
        // Assert.Inconclusive();
        // It should not have an empty constructor
        Assert.IsTrue(typeof(JuniorDeveloper).GetConstructor(Type.EmptyTypes) == null);
        // It should inherit from Programmer
        Assert.IsTrue(typeof(Developer).IsAssignableFrom(typeof(JuniorDeveloper)));

        Developer p = new JuniorDeveloper("امین قسوری", false);
        Assert.AreEqual(p.Name, "آقای امین قسوری");
        Assert.AreEqual(p.IsFemale, false);
        Assert.AreEqual(p.Salary, 2_800_000);

        // Student should not override/modify the Name get property.
        Assert.AreNotEqual(
            typeof(JuniorDeveloper).GetMethod("get_Name").DeclaringType,
            typeof(JuniorDeveloper));
    }

    /// <summary>
    /// کلاس 
    /// FullStackDeveloper
    /// را به گونه‌ای تعریف و پیاده‌سازی کنید که از 
    /// کلاس 
    /// SeniorDeveloper
    /// به ارث بردهو حقوق پایه 
    /// ۷.۵ میلیون
    /// داشته باشد و به ازای هر ساعت اضافه‌کاری
    /// ۷۰ هزار تومان 
    /// دریافت کند.
    /// </summary>
    [TestMethod]
    public void Q14_FullStackTest()
    {
        // Assert.Inconclusive();
        // It should not have an empty constructor
        Assert.IsTrue(typeof(FullStackDeveloper).GetConstructor(Type.EmptyTypes) == null);
        // It should inherit from Programmer
        Assert.IsTrue(typeof(SeniorDeveloper).IsAssignableFrom(typeof(FullStackDeveloper)));

        Developer p = new FullStackDeveloper("پارمیس علایی", true);
        Assert.AreEqual(p.Name, "دکتر پارمیس علایی");
        Assert.AreEqual(p.IsFemale, true);
        Assert.AreEqual(p.Salary, 7_500_000);

        Assert.AreEqual((p as FullStackDeveloper).CalculateSalary(10), 8_200_000);
        Assert.AreEqual((p as SeniorDeveloper).CalculateSalary(10), 8_200_000);
    }
}