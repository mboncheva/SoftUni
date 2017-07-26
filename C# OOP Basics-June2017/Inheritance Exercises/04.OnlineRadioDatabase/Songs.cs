using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Songs
{
    private string artistName;
    private string songName;
    private string songLenght;

    public Songs(string artistName, string songName, string songLenght)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.SongLenght = songLenght;
    }

    public string ArtistName
    {
        get { return this.artistName; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }
            this.artistName = value;
        }
    }

    public string SongName
    {
        get { return this.songName; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            }
            this.songName = value;
        }
    }

    public string SongLenght
    {
        get { return this.songLenght; }
        set
        {

            var songTime = value.Split(':');
            var minute = int.Parse(songTime[0]);
            var seconds = int.Parse(songTime[1]);

            if (minute < 0 || minute > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }
            if (seconds < 0 || seconds > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }
            this.songLenght = value;
        }

    }
}