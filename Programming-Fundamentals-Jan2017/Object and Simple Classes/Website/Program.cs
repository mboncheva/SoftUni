using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Website
{
    public string Host { get; set; }

    public string Domain { get; set; }

    public List<string> Queries { get; set; }

}


class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var web = new List<Website>();

        while (input != "end")
        {
            var currentInput = input.Split(new[] { ' ', '|', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var host = currentInput[0];
            var domain = currentInput[1];
            var quaries = currentInput.Skip(2).ToList();

            var websiteNew = new Website
            {
                Host = host,
                Domain = domain,
                Queries = quaries
            };

            web.Add(websiteNew);
            
            input = Console.ReadLine();
        }

        foreach (var item in web)
        {
            if (item.Queries.Count == 0)
            {
                Console.WriteLine("https://www.{0}.{1}",item.Host,item.Domain);
            }
            else
            {
                Console.WriteLine("https://www.{0}.{1}/query?=[{2}]",
                    item.Host, item.Domain, string.Join("]&[", item.Queries));
            }
        }
                
    }
}
