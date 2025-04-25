namespace S14Con.Test;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void AddTest()
    {
        Vector v1 = new Vector(3,4);
        Vector v2 = new Vector(1,2);
        Vector vsum = v1.Add(v2);
        Assert.AreEqual(vsum.X, 4);
        Assert.AreEqual(vsum.Y, 6);

        Vector v3 = new Vector(1,1);
        Vector vsum2 = v3.Add(v2);
        Assert.AreEqual(vsum2.X, 2);
        Assert.AreEqual(vsum2.Y, 3);
    }
}
