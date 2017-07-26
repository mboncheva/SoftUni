using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var songs = new List<Songs>();

        for (int i = 0; i < n; i++)
        {
            try
            {
                var input = Console.ReadLine().Split(';');
                if (input.Length < 3)
                {
                    throw new ArgumentException("Invalid song.");
                }
                var artistName = input[0];
                var songName = input[1];

                try
                {
                    var songTime = input[2].Split(':').Select(int.Parse).ToList();
                }
                catch (Exception)
                {
                    throw new ArgumentException("Invalid song length.");
                }
                var song = new Songs(artistName, songName, input[2]);
                songs.Add(song);
                Console.WriteLine("Song added.");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine($"Songs added: {songs.Count}");
        var tottalTime = 0;
        foreach (var item in songs)
        {
            var time = item.SongLenght.Split(':');
            var minute = int.Parse(time[0]);
            var seconds = int.Parse(time[1]);
            tottalTime += minute * 60 + seconds;

        }
        Console.WriteLine($"Playlist length: {TimeSpan.FromSeconds(tottalTime).Hours}h {TimeSpan.FromSeconds(tottalTime).Minutes}m {TimeSpan.FromSeconds(tottalTime).Seconds}s");
    }
}
