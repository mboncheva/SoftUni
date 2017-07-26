using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Animals
{
    private string animalType;
    private string animalName;
    private double animalWeight;
    private string animalLivingRegion;
    private int foodEaten;

    public Animals(string animalType,string animalName,double animalWeight,string animalLivingRegion)
    {
        this.AnimalType = animalType;
        this.AnimalName = animalName;
        this.AnimalWeight = animalWeight;
        this.AnimalLivingRegion = animalLivingRegion;
    }

    public string AnimalType { get; set; }
    public string AnimalName { get; set; }
    public double AnimalWeight { get; set; }
    public string AnimalLivingRegion { get; set; }
    public int FoodEaten { get; set; }

    public abstract void MakeSound();
    public abstract void Eat(Food food);

    public override string ToString()
    {
        return base.ToString();
    }
}
