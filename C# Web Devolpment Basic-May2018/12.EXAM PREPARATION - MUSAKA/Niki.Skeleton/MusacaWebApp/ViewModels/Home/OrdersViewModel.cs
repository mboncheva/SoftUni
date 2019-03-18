using System;
using System.Collections.Generic;
using System.Text;

namespace MusacaWebApp.ViewModels.Home
{
    public class OrdersViewModel
    {
        public IEnumerable<ActiveOrdersViewModel> Orders { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
