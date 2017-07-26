using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cat : Femile
{
    private string breed;
    public string Breed { get { return this.breed; } set { this.breed = value; } }

    public Cat(string animalType, string animalName, double animalWeight, string animalLivingRegion,string breed)
        : base(animalType, animalName, animalWeight, animalLivingRegion)
    {
        this.Breed = breed;
    }


    public override void Eat(Food food)
    {
        base.FoodEaten = food.Quantity;
    }

    public override void MakeSound()
    {
        Console.WriteLine("Meowwww");
    }

    public override string ToString()
    {
        return $"{base.AnimalType}[{base.AnimalName}, {this.Breed}, {base.AnimalWeight}, {base.AnimalLivingRegion}, {base.FoodEaten}]";
    }
}
