namespace MishMashWebApp.ViewModels.Home
{
    using MishMashWebApp.ViewModels.Channels;
    using System.Collections.Generic;

    public class LoggedInIndexViewModel
    {
        public string UserRole { get; set; }

        public IEnumerable<BaseChannelViewModel> YourChannels { get; set; }

        public IEnumerable<BaseChannelViewModel> SuggestedChannels { get; set; }

        public IEnumerable<BaseChannelViewModel> SeeOtherChannels { get; set; }

    }
}
