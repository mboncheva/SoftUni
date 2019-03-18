using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels.Package
{
    class PackagePendingViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string Username { get; set; }
    }
}
