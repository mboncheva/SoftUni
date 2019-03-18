namespace PandaWebApp.ViewModels.Receipt
{
    using System;

    public class ReceiptIndexViewModel
    {
        public int Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string Username { get; set; }

    }
}
