namespace PandaWebApp.ViewModels.Home
{
    using PandaWebApp.ViewModels.Package;
    using System.Collections.Generic;

    public class UserIndexViewModel
    {
        public UserIndexViewModel()
        {
            this.Pendings = new HashSet<PackageIndexViewModel>();
            this.Shippeds = new HashSet<PackageIndexViewModel>();
            this.Delivereds = new HashSet<PackageIndexViewModel>();

        }
        public IEnumerable<PackageIndexViewModel> Pendings { get; set; }

        public IEnumerable<PackageIndexViewModel> Shippeds { get; set; }

        public IEnumerable<PackageIndexViewModel> Delivereds { get; set; }

    }
}
