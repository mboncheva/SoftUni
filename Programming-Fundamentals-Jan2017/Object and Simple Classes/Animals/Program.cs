using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Dog
{
    public string Name { get; set; }

    public int Age { get; set; }

    public int NumberOfLegs { get; set; }

    public void ProduceSound()
    {
        Console.WriteLine("I'm a Distinguishedog, and I will now produce a distinguished sound! Bau Bau.");
    }
}

class Cat
{
    public string Name { get; set; }

    public int Age { get; set; }

    public int IntelligenceQuotient { get; set; }

    public void ProduceSound()
    {
        Console.WriteLine("I'm an Aristocat, and I will now produce an aristocratic sound! Myau Myau.");
    }

}

class Snake
{
    public string Name { get; set; }

    public int Age { get; set; }

    public int CrueltyCoefficient { get; set; }

    public void ProduceSound()
    {
        Console.WriteLine("I'm a Sophistisnake, and I will now produce a sophisticated sound! Honey, I'm home.");
    }
}

namespace _03.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dogsParam = new Dictionary<string,Dog>();
            var catParam = new Dictionary<string,Cat>();
            var snakeParam = new Dictionary<string,Snake>();


            while (input != "I'm your Huckleberry")
            {
                var currentInput = input.Split(' ');
                var animal = currentInput[0];

                if (animal == "talk")
                {
                    var animalName = currentInput[1];
                    if (dogsParam.ContainsKey(animalName))
                    {
                        dogsParam[animalName].ProduceSound();
                    }
                    else if (catParam.ContainsKey(animalName))
                    {
                        catParam[animalName].ProduceSound();
                    }
                    else if (snakeParam.ContainsKey(animalName))
                    {
                        snakeParam[animalName].ProduceSound();
                    }
                }
                else
                {
                    var animalName = currentInput[1];
                    var animalAge = int.Parse(currentInput[2]);
                    var animalParam = int.Parse(currentInput[3]);

                    switch (animal)
                    {
                        case "Dog":
                            var Dogs = new Dog
                            {
                                Name = animalName,
                                Age = animalAge,
                                NumberOfLegs = animalParam
                            };
                            dogsParam.Add(animalName,Dogs);
                            break;
                        case "Cat":
                            var Cats = new Cat
                            {
                                Name = animalName,
                                Age = animalAge,
                                IntelligenceQuotient = animalParam
                            };
                            catParam.Add(animalName,Cats);
                            break;
                        case "Snake":
                            var Snake = new Snake
                            {
                                Name = animalName,
                                Age = animalAge,
                                CrueltyCoefficient = animalParam
                            };
                            snakeParam.Add(animalName,Snake);
                            break;

                    }
                }
                input = Console.ReadLine();
            }

            foreach (var dog in dogsParam.Values)
            {
                Console.WriteLine("Dog: {0}, Age: {1}, Number Of Legs: {2}", dog.Name, dog.Age, dog.NumberOfLegs);
            }
            foreach (var cat in catParam.Values)
            {
                Console.WriteLine("Cat: {0}, Age: {1}, IQ: {2}", cat.Name, cat.Age, cat.IntelligenceQuotient);
            }
            foreach (var snake in snakeParam.Values)
            {
                Console.WriteLine("Snake: {0}, Age: {1}, Cruelty: {2}", snake.Name, snake.Age, snake.CrueltyCoefficient);
            }
        }

    }
}