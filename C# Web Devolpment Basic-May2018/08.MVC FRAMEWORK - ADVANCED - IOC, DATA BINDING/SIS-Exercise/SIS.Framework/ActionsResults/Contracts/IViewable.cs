namespace SIS.Framework.ActionsResults.Contracts
{
    using SIS.Framework.ActionsResults.Base;

    public interface IViewable : IActionResult
    {
        IRenderable View { get; set; }
    }
}
