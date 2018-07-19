namespace MyWebServer.ByTheCakeApplication.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
 
   public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(2000)]
        public string ImgUrl { get; set; }

        public List<OrderProduct> Orders { get; set; } = new List<OrderProduct>();
    }
}
