namespace S9con.Test;

[TestClass]
public sealed class StudentTest
{
    [TestMethod]
    public void ParseTest()
    {
        Student s = new Student(
            name:"Hami Jafari",
            stdid:40351243,
            natid:0151586589,
            credits:18,
            active:true);
        string str = "Hami Jafari,40351243,151586589,18,True";
        Student ss = Student.Parse(str);

        Assert.AreEqual(s, ss);
    }

}
