using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        List<Rectangle> listOfRectangle = new List<Rectangle>();
        List<string[]> listOfpairs = new List<string[]>();

        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int numberOfRectangles = input[0];
        int numberOfIntersectionChecks = input[1];

        for (int i = 0; i < numberOfRectangles; i++)
        {
            string[] inputLine = Console.ReadLine().Split(' ');

            string id = inputLine[0];
            double width = double.Parse(inputLine[1]);
            double height = double.Parse(inputLine[2]);
            double topLeftCornerX = double.Parse(inputLine[3]);
            double topLeftCornerY = double.Parse(inputLine[4]);

            Rectangle current = new Rectangle()
            {
                ID = id,
                Width = width,
                Height = height,
                XCoord = topLeftCornerX,
                YCoord = topLeftCornerY
            };

            listOfRectangle.Add(current);
        }

        for (int j = 0; j < numberOfIntersectionChecks; j++)
        {
            string[] pair = Console.ReadLine().Split(' ');
            listOfpairs.Add(pair);
        }

        Rectangle rc = new Rectangle();

        foreach (var pair in listOfpairs)
        {
            rc.IsIntersect(pair[0], pair[1], listOfRectangle);
        }
    }
}