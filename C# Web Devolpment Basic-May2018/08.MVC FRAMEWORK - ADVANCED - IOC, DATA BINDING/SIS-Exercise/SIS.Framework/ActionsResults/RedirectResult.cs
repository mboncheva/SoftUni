namespace SIS.Framework.ActionsResults
{
    using SIS.Framework.ActionsResults.Contracts;

    public class RedirectResult : IRedirectable
    {
        public RedirectResult(string redirectUrl)
        {
            this.RedirectUrl = redirectUrl;
        }

        public string RedirectUrl { get; }

        public string Invoke() =>
            this.RedirectUrl;
    }
}
