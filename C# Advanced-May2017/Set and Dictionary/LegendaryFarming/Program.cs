using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var materials = new Dictionary<string, long>();
            materials["shards"] = 0;
            materials["fragments"] = 0;
            materials["motes"] = 0;

            var keyMaterial = new Dictionary<string, string>();
            keyMaterial["shards"] = "Shadowmourne";
            keyMaterial["fragments"] = "Valanyr";
            keyMaterial["motes"] = "Dragonwrath";


            bool isObtain = false;

            while (!isObtain)
            {
                var input = Console.ReadLine().ToLower().Split(' ');

                for (int i = 0; i < input.Length; i+=2)
                {
                    var quantity = int.Parse(input[i]);
                    var material = input[i + 1];

                    if (!materials.ContainsKey(material))
                    {
                        materials[material] = 0;
                    }
                    materials[material] += quantity;

                    if (keyMaterial.ContainsKey(material) && materials[material] >= 250)
                    {
                        foreach (var item in keyMaterial)
                        {
                            if (item.Key == material)
                            {
                                Console.WriteLine("{0} obtained!",item.Value);
                                materials[material] -= 250;
                                break;
                            }
                        }
                        isObtain = true;

                        var reminingKey = materials.Take(3).OrderByDescending(x => x.Value).ThenBy(x => x.Key);
                        foreach (var item in reminingKey)
                        {
                            Console.WriteLine($"{item.Key}: {item.Value}");
                        }

                        var junkKey = materials.Skip(3).OrderBy(x => x.Key);
                        foreach (var item in junkKey)
                        {
                            Console.WriteLine($"{item.Key}: {item.Value}");
                           
                        }
                        break;
                    }
                }
            }
        }
    }
}
