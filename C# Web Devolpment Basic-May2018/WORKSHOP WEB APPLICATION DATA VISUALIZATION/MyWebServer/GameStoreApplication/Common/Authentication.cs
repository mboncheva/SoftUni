namespace MyWebServer.GameStoreApplication.Common
{
    public class Authentication
    {
        public bool IsAuthenticated { get; private set; }

        public bool IsAdmin { get; private set; }

        public Authentication(bool isAuthenticated,bool IsAdmin)
        {
            this.IsAuthenticated = isAuthenticated;
            this.IsAdmin = IsAdmin;
        }
    }
}
