public interface IShape{
    public double Area();
    public double Perimeter();
}

class Rectangle : IShape{
    public double L;
    public double W;
    public Rectangle(double ll, double ww){
        L = ll;
        W = ww;
    }
    public double Area(){
        return L*W;
    }
    public double Perimeter(){
        return (L+W)*2;
    }
}

class Circle : IShape{
    public double Radius;
    public Circle(double r){
        Radius = r;
    }
    public double Area(){
        return Math.PI * Radius * Radius;
    }
    public double Perimeter(){
        return 2 * Math.PI * Radius;
    }
}
