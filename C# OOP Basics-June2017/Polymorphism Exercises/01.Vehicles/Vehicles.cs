using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Vehicles
{
    private double fuelQuantity;
    private double litersPerKm;
    private double tankCapacity;

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            this.fuelQuantity = value; }
    }
    public double LitersPerKm { get { return this.litersPerKm; } set { this.litersPerKm = value; } }
    public double TankCapacity { get { return this.tankCapacity; } set { this.tankCapacity = value; } }

    public Vehicles(double fuelQuantity, double litersPerKm,double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.LitersPerKm = litersPerKm;
        this.TankCapacity = tankCapacity;
    }

    public abstract void TryTravelDistance(double distance);
    public abstract void Refuel(double quantity);
    public override string ToString()
    {
        return $"{this.FuelQuantity:f2}";
    }
}
