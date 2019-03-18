﻿namespace PandaWebApp.Models
{
    using System;

    public class Package
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public virtual User User { get; set; }

        public int UserId { get; set; }

        public virtual Receipt Receipt { get; set; }

        public int ReceiptId { get; set; }
    }
}
