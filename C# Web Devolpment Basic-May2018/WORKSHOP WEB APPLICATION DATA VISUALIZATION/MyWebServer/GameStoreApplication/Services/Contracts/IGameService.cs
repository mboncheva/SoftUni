namespace MyWebServer.GameStoreApplication.Services.Contracts
{
    using ViewModels.Admin;
    using System;
    using System.Collections.Generic;
    using Data.Models;

    public interface IGameService
    {
        void Create(
            string title,
            string description,
            string image,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate);

        IEnumerable<AdminListGameViewModel> All();

        Game Find(int id);

        bool Edit(int id,string title,
            string description,
            string image,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate);

        bool Delete(int id);

    }
}
