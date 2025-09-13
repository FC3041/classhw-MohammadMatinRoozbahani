using System;

namespace TransportationDemo
{
    public interface ITransportation
    {
        string GetCostInfo();
        double CalculateVolume();
        string GetSafetyRating();
        string GetEnvironmentalImpact();
    }

    public abstract class VehicleBase
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        protected VehicleBase(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double CalculateVolume() => Length * Width * Height;
    }

    public class Automobile : VehicleBase, ITransportation
    {
        public Automobile(double l, double w, double h) : base(l, w, h) { }
        public string GetCostInfo() => "High ownership cost (approx. $60,000)";
        public string GetEnvironmentalImpact() => "High CO2 emissions per person.";
        public string GetSafetyRating() => "Moderate (2.5/5)";
    }

    public class PublicBus : VehicleBase, ITransportation
    {
        public PublicBus(double l, double w, double h) : base(l, w, h) { }
        public string GetCostInfo() => "Low trip cost (approx. $7)";
        public string GetEnvironmentalImpact() => "Low emissions per person, overall positive impact.";
        public string GetSafetyRating() => "Good (4/5)";
    }

    public class CommercialPlane : VehicleBase, ITransportation
    {
        public CommercialPlane(double l, double w, double h) : base(l, w, h) { }
        public string GetCostInfo() => "Moderate trip cost (approx. $300)";
        public string GetEnvironmentalImpact() => "High CO2 and NOx emissions per trip.";
        public string GetSafetyRating() => "Very Good (4.3/5)";
    }
}