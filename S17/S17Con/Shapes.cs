class Vector{
    public int X {get;set;}
    public int Y {get;set;}
    public Vector(int x, int y){
        this.X = x;
        this.Y = y;
    }
    public static Vector operator+ (Vector v1, Vector v2){
        v1.X += v2.X;
        v1.Y += v2.Y;
        return v1;
    }
    public override string ToString()
    {
        return $"{X},{Y}";
    }
}
abstract class Shape{
    private string Name;
    protected Vector[] points;
    public void Move(Vector dir){
        for (int i = 0; i < points.Length; i++){
            points[i] += dir;
        }
    }
    public void Draw(){
        Vector s = points[0];
        for (int i = 1; i < points.Length; i++){
            System.Console.WriteLine($"line({points[i-1]} => {points[i]})");
        }
    }
    public abstract double GetArea();
}
class Square : Shape
{
    public Square(Vector UpperLeft, int len){
        this.points = new Vector[4];
        this.points[0] = UpperLeft;
        this.points[1] = new Vector(UpperLeft.X + len, UpperLeft.Y);
        this.points[2] = new Vector(UpperLeft.X + len, UpperLeft.Y + len);
        this.points[3] = new Vector(UpperLeft.X, UpperLeft.Y + len);

    }
    public override double GetArea()
    {
        return 1;
    }
}