namespace CakesWebApp.ViewModels.Cakes
{
    using System.Collections.Generic;

    public class SearchViewModel
    {
        public List<ByIdViewModel> Cakes { get; set; }

        public string SearchText { get; set; }
    }
}
