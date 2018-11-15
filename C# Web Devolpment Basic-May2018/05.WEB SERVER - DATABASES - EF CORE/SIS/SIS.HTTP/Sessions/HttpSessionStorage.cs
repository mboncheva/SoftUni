namespace SIS.HTTP.Sessions
{
    using SIS.HTTP.Sessions.Interfaces;
    using System.Collections.Concurrent;

    public class HttpSessionStorage
    {
        public const string SessionCookieKey = "SIS_ID";

        private static readonly ConcurrentDictionary<string, IHttpSession> sessions =
            new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession GetSession(string id)
        {
            return sessions.GetOrAdd(id, _ => new HttpSessions(id));
        }
    }
}
