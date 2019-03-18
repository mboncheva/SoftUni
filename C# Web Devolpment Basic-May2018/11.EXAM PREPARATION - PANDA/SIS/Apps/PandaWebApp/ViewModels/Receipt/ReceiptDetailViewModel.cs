namespace PandaWebApp.ViewModels.Receipt
{
    using System;

    public class ReceiptDetailViewModel
    {
        public int Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string Username { get; set; }

        public string ShippingAddress { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }


    }
}
