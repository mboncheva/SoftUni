using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Truck : Vehicles
{
    private const double Consumation = 1.6;
    private const double FuelLost = 0.95;
    public Truck(double fuelQuantity, double litersPerKm) : base(fuelQuantity, litersPerKm)
    {

    }

    public override void Refuel(double quantity)
    {
        base.FuelQuantity += (quantity * 0.95);
    }

    public override void TryTravelDistance(double distance)
    {
        var maxDistance = base.FuelQuantity / base.LitersPerKm;
        if (maxDistance >= distance)
        {
            Console.WriteLine($"Truck travelled {distance} km");
            base.FuelQuantity -= base.LitersPerKm * distance;
        }
        else
        {
            Console.WriteLine("Truck needs refueling");
        }
    }

    public override string ToString()
    {
        return "Truck: " + base.ToString();
    }
}
