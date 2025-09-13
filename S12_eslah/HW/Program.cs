using System;

namespace TransportationDemo
{
    class TransportationApp
    {
        static void DisplayTransportInfo(ITransportation transport)
        {
            Console.WriteLine($"--- {transport.GetType().Name} ---");
            Console.WriteLine($"Volume: {transport.CalculateVolume()} m^3");
            Console.WriteLine($"Cost: {transport.GetCostInfo()}");
            Console.WriteLine($"Safety: {transport.GetSafetyRating()}");
            Console.WriteLine($"Environment: {transport.GetEnvironmentalImpact()}");
        }

        // Note: To run this, you would need to set this as the startup project
        // or call this method from the main application.
        static void Main(string[] args)
        {
            var myCar = new Automobile(4.5, 2.0, 1.5);
            var cityBus = new PublicBus(15.0, 5.5, 3.0);
            var airplane = new CommercialPlane(70.0, 60.0, 20.0);

            DisplayTransportInfo(myCar);
            DisplayTransportInfo(cityBus);
            DisplayTransportInfo(airplane);
        }
    }
}