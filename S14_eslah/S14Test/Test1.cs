namespace S14Test;

[TestClass]
public sealed class VectorTest
{
    [TestMethod]
    public void AddTest()
    {
        Vector<int> v = new Vector<int>(3,4);
        Vector<int> v1 = new Vector<int>(1,2);
        Vector<int> vSum = v.Add(v1);

        Vector<int> VexpectedSum = new Vector<int>(4,6);

        // Assert.AreEqual(vSum.Y , 6);
        // Assert.AreEqual(vSum.X, 4);

        Assert.AreEqual(vSum , VexpectedSum);


        Vector<int> V3 = new Vector<int>(1,1);
        Vector<int> vsum2 = V3.Add(v1);

        Assert.AreEqual(vsum2.X , 2);
        Assert.AreEqual(vsum2.Y , 3);



    }
    [TestMethod]
    public void AddedMoretest(){
        Anglevec<int> v1 = new Anglevec<int>(1, 1, 30);
        Anglevec<int> v2 = new Anglevec<int>(2, 2, 45);
    // Act & Assert
    Assert.IsTrue(v1.CompareTo(v2) < 0);
    Assert.AreEqual(0, v1.CompareTo(v1));
    }
}
