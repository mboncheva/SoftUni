namespace MishMashWebApp.Controllers
{
    using MishMashWebApp.ViewModels.Channels;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;

    public class ChannelsController : BaseController
    {
        [HttpGet("/Channels/Details")]
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
    }
}
