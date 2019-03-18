namespace PandaWebApp.ViewModels.Package
{
    using System;

    public class PackageDetailViewModel
    {
        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string Status { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public string Username { get; set; }

    }
}
