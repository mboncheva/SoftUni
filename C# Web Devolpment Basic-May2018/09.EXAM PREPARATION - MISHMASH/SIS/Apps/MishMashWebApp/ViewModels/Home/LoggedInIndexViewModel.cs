namespace MishMashWebApp.ViewModels.Home
{
    using System.Collections.Generic;
    using MishMashWebApp.ViewModels.Channels;

    public class LoggedInIndexViewModel
    {
        public IEnumerable<BaseChannelViewModel> YourChannels { get; set; }

        public IEnumerable<BaseChannelViewModel> SuggestedChannels { get; set; }

        public IEnumerable<BaseChannelViewModel> SeeOtherChannels { get; set; }
    }
}
