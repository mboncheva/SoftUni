namespace MyWebServer.GameStoreApplication.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Data.Models;
    using MyWebServer.GameStoreApplication.ViewModels.Admin;

    public class GameService : IGameService
    {
        public void Create(
            string title,
            string description,
            string image,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate)
        {
           using(var context = new GameStoreDbContext())
           {
                var game = new Game()
                {
                    Title = title,
                    Description = description,
                    ImageUrl = image,
                    Price = price,
                    Size = size,
                    VideoId = videoId,
                    ReleaseDate = releaseDate
                };

                context.Add(game);
                context.SaveChanges();
           }
        }

        public IEnumerable<AdminListGameViewModel> All()
        {
            using(var context=new GameStoreDbContext())
            {
                return context.Games.Select(
                    x => new AdminListGameViewModel
                    {
                        Id = x.Id,
                        Name = x.Title,
                        Price = x.Price,
                        Size = x.Size
                    }).ToList();
            }
        }

        public Game Find(int id)
        {
            using (var context = new GameStoreDbContext())
            {
                var game = context.Games.FirstOrDefault(x => x.Id == id);
                return game;
            }
        }

        public bool Edit(int id, string title,
            string description,
            string image,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate)
        {
           using(var context = new GameStoreDbContext())
           {
                var game = context.Games.FirstOrDefault(x => x.Id == id);

                if (game == null)
                {
                    return false;
                }

                game.Title = title;
                game.Description = description;
                game.ImageUrl = image;
                game.Price = price;
                game.Size = size;
                game.VideoId = videoId;
                game.ReleaseDate = releaseDate;

                context.Update(game);
                context.SaveChanges();
           }

            return true;
        }

        public bool Delete(int id)
        {
            using(var context = new GameStoreDbContext())
            {
                var game = context.Games.Find(id);

                if (game == null)
                {
                    return false;
                }

                context.Games.Remove(game);
                context.SaveChanges();

                return true;
            }
        }
    }
}
