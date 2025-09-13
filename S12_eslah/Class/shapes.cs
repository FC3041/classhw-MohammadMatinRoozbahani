using System;

namespace CoreConceptsDemo
{
    public interface IGeometricShape
    {
        double CalculateArea();
        double CalculatePerimeter();
    }

    public class Quad : IGeometricShape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Quad(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public double CalculateArea() => Length * Width;
        public double CalculatePerimeter() => 2 * (Length + Width);
    }

    public class Disc : IGeometricShape
    {
        public double Radius { get; set; }

        public Disc(double radius)
        {
            Radius = radius;
        }

        public double CalculateArea() => Math.PI * Radius * Radius;
        public double CalculatePerimeter() => 2 * Math.PI * Radius;
    }
}