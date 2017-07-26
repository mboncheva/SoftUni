using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Car : Vehicles
{
    public Car(double fuelQuantity, double litersPerKm) : base(fuelQuantity, litersPerKm)
    {
    }

    public override void Refuel(double quantity)
    {
       base.FuelQuantity += quantity;
    }

    public override void TryTravelDistance(double distance)
    {
        var maxDistance = base.FuelQuantity / base.LitersPerKm;

        if (maxDistance >= distance)
        {
            Console.WriteLine($"Car travelled {distance} km");
            base.FuelQuantity -= distance * base.LitersPerKm;
        }
        else
        {
            Console.WriteLine("Car needs refueling");
        }
    }
    public override string ToString()
    {
        return $"Car: " + base.ToString(); 
    }
}
