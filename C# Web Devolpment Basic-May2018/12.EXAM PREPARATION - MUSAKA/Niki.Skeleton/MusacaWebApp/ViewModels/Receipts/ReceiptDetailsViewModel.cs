using System;
using System.Collections.Generic;
using System.Text;

namespace MusacaWebApp.ViewModels.Receipts
{
    public class ReceiptDetailsViewModel
    {
        public int Id { get; set; }

        public string IssuedOn { get; set; }

        public string Cashier { get; set; }

        public decimal Tottal { get; set; }

        public IEnumerable<ProductViewModel> Orders { get; set; }
    }
}
