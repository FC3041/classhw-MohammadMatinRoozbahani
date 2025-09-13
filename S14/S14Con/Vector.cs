using System.Numerics;

public interface IVector<T> where T:INumber<T>
{
    T Magnitude {get;}
    Vector<T> Add(IVector<T> o);
    T X{get;set;}
    T Y{get;set;}
}

public class AngleVector<T>{
    
}

public class Vector<T> : IEquatable<Vector<T>> , IVector<T> , IComparable<Vector<T>> where T:INumber<T>
{
    public T X {get; set;}
    public T Y {get; set;}
    public T Magnitude {
        get{
            return (X*X + Y*Y);
            //return Math.Sqrt(X*X + Y*Y);
        }
    }
    public Vector(T xx, T yy){
        this.X = xx;
        this.Y = yy;
    }
    // public static Vector<T> Parse(string s){
    //     string[] tokens = s.Split(',');
    //     return new Vector<T>(T.Parse(tokens[0]),T.Parse(tokens[1]));
    // }
    public Vector<T> Add(IVector<T> v) => new Vector<T>(X + v.X, Y + v.Y);
    bool IEquatable<Vector<T>>.Equals(Vector<T> v){
        if (null == v){
            return false;
        }
        return (v.X == this.X ) && (v.Y == this.Y);
    }
    public override bool Equals(object obj)
    {
        Vector<T> v = obj as Vector<T>;
        string s = obj as string;
        if (v != null){
            return Equals(this,v);
        }
        // if (s != null){
        //     v = Vector<T>.Parse(s);
        //     return Equals(this,v);
        // }
        return false;
    }
    public override int GetHashCode()
    {
        return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }

    public int CompareTo(Vector<T> v)
    {
        return this.Magnitude.CompareTo(v.Magnitude);
    }
}