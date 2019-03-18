using System;
using System.Collections.Generic;
using System.Text;

namespace MusacaWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public long Barcode { get; set; }

        public string Picture { get; set; }

    }
}
