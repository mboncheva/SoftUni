namespace SIS.Framework.ActionsResults.Contracts
{
    using SIS.Framework.ActionsResults.Base;

    public interface IRedirectable : IActionResult
    {
        string RedirectUrl { get; }
    }
}
