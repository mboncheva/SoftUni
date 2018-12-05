﻿namespace SIS.Framework
{
    using System;
    using System.Reflection;
    using SIS.WebServer;

    public class MvcEngine
    {
        public void Run(Server server)
        {
            MvcContext.Get.AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
            try
            {
                server.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
