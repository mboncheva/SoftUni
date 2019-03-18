namespace ChushkaWebApp.Models
{
    using System;

    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderedOn { get; set; } = DateTime.UtcNow;

        public virtual User User { get; set; }

        public int UserId { get; set; }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
