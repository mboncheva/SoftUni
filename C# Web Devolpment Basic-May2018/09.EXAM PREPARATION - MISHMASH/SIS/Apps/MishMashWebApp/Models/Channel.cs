namespace MishMashWebApp.Models
{
    using System.Collections.Generic;

    public class Channel
    {
        public Channel()
        {
            this.Tags = new HashSet<ChannelTag>();
            this.Followers = new HashSet<UserInChannel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Descripition { get; set; }

        public ChannelType ChannelType { get; set; }

        public virtual ICollection<ChannelTag> Tags { get; set; }

        public virtual ICollection<UserInChannel> Followers { get; set; }
    }
}
