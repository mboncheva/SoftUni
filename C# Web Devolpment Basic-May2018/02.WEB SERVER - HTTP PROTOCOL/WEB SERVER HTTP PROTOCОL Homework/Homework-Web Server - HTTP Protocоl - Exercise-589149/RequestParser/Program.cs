namespace RequestParser
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var request = new HttpRequest();

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "END")
                {
                    break;
                }

                request.AddInfo(inputLine);
            }

            var finalInput = Console.ReadLine();

            bool isValid = request.ProccessData(finalInput);

            var response = new HttpResponse(isValid);
            Console.WriteLine(new string('-', 25));
            Console.WriteLine(response);
        }
    }
}
