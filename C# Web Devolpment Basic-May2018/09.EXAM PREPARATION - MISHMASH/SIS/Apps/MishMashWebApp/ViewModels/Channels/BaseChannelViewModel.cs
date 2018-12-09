namespace MishMashWebApp.ViewModels.Channels
{
    using MishMashWebApp.Models;

    public class BaseChannelViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ChannelType Type { get; set; }

        public int FollowersCount { get; set; }
    }
}