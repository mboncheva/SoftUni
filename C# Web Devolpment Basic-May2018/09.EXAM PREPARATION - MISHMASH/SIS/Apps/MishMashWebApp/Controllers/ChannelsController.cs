namespace MishMashWebApp.Controllers
{
    using MishMashWebApp.Models;
    using MishMashWebApp.ViewModels.Channels;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;

    public class ChannelsController : BaseController
    {
        [HttpGet("/channels/details")]
        public IHttpResponse Details(int id)
        {
            if (this.User == null)
            {
                return this.Redirect("/Users/Login");
            }

            var channelViewModel = this.Db.Channels
                .Where(x => x.Id == id)
                .Select(x => new ChannelViewModel
                {
                    Name = x.Name,
                    Description = x.Descripition,
                    Type = x.ChannelType,
                    FollowersCount = x.Followers.Count(),
                    Tags = x.Tags.Select(t => t.Tag.Name)
                })
               .FirstOrDefault();

            return this.View("Channels/Details", channelViewModel);
        }

       
        [HttpGet("/channels/followed")]
        public IHttpResponse Followed()
        {
            if (this.User == null)
            {
                return this.Redirect("/Users/Login");
            }
            var followedChannels = this.Db.Channels.Where(
                   x => x.Followers.Any(f => f.User.Username == this.User))
                           .Select(x => new FollowedChannelViewModel
                           {
                               Id = x.Id,
                               Type = x.ChannelType,
                               Name = x.Name,
                               FollowersCount = x.Followers.Count(),
                           }).ToList();
            var viewModel = new FollowedChannelsViewModel
            { FollowedChannels = followedChannels };

            return this.View("Channels/Followed", viewModel);
        }

        [HttpGet("/channels/follow")]
        public IHttpResponse Follow(int id)
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User);
            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }
            if (!this.Db.UserInChannel.Any(
               x => x.UserId == user.Id && x.ChannelId == id))
            {
                this.Db.UserInChannel.Add(new UserInChannel
                {
                    ChannelId = id,
                    UserId = user.Id,
                });
                this.Db.SaveChanges();
            }
            return this.Redirect("/channels/followed");
        }

        [HttpGet("/channels/unfollow")]
        public IHttpResponse Unfollow(int id)
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User);
            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }
            var userInChannel = this.Db.UserInChannel.FirstOrDefault(
               x => x.UserId == user.Id && x.ChannelId == id);
            if (userInChannel != null)
            {
                this.Db.UserInChannel.Remove(userInChannel);
                this.Db.SaveChanges();
            }
            return this.Redirect("/channels/followed");
        }
    }
}
