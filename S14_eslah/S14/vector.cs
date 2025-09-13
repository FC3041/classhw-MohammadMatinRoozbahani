using System.Numerics;

public interface IVector<T> where T: INumber<T>
{
    T Magnitude {get;}
    Vector<T> Add(IVector<T> o);
    T X {get; set;}
    T Y {get; set;}
}

public class Anglevec<T> : IComparable<Anglevec<T>> , IEquatable<Anglevec<T>> , IVector<T>  where T: INumber<T> {
    public Anglevec(T x, T y, T angle)
    {
        this.X = x;
        this.Y = y;
        this.Angle = angle;
    }
    
    public T X { get; set; }
    public T Y { get; set; }
    public T Angle { get; set; }
    
    public T Magnitude => X*X + Y*Y;
    public Vector<T> Add(IVector<T> other ) => new Vector<T>(X +other.X ,Y+other.Y);

    public int CompareTo(Anglevec<T> other)
    {
        return this.Magnitude.CompareTo(other.Magnitude);
    }

    public bool Equals(Anglevec<T> other)
    {
        if (other==null){
            return false ;
        }
        else{
            return (other.X == this.X) && (other.Y == this.Y);
        }
    }
}

public class Vector<T> :IEquatable<Vector<T>> , IComparable<Vector<T>> where T: INumber<T>
{
    public Vector(T x2 , T y2){    

        this.X =x2;
        this.Y =y2; 
    }
    public T X{get;set;}
    public T Y{get ; set;}

    public T Magnitude =>X*X +Y*Y;




    public Vector<T> Add(Vector<T> v) => new Vector<T>(X + v.X ,Y +v.Y);
    public override bool Equals(object obj)
    {
        Vector<T> v = obj as Vector<T>;
        string s = obj as string ; 
        if(v!=null){
            return (v.X == this.X) && (v.Y ==this.Y);}
    
        else{
            return false; 
        }

    }

   

    public bool Equals(Vector<T> other)
    {
        if(other==null){
            return false ; 
        }
        return (other.X == this.X) && (other.Y==this.Y);
    }

    public int CompareTo(Vector<T> other)
    {
        return this.Magnitude.CompareTo(other.Magnitude);
    }

    public override int GetHashCode()
    {
       
        return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }
}