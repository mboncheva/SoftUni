﻿namespace MyWebServer.GameStoreApplication.Data.Models
{
    public class UserGame
    {
        public int UserId { get; set; }

        public int GameId { get; set; }

        public User User { get; set; }

        public Game Game { get; set; }
    }
}
