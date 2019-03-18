﻿namespace PandaWebApp.Controllers
{
    using PandaWebApp.Data;
    using SIS.MvcFramework;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new PandaDbContext();
        }

        protected PandaDbContext Db { get; }
    }
}
