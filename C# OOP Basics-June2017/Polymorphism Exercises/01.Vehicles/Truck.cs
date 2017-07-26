using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Truck : Vehicles
{
    public Truck(double fuelQuantity, double litersPerKm,double tankCapacity) : base(fuelQuantity, litersPerKm,tankCapacity)
    {

    }

    public override void Refuel(double quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

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
