using System;
using System.Collections.Generic;
using System.Text;

namespace MusacaWebApp.ViewModels.Users
{
    public class ProfileViewModel
    {
        public int Id { get; set; }

        public decimal Total { get; set; }

        public string IssuedOn { get; set; }

        public string Cashier { get; set; }
    }
}
