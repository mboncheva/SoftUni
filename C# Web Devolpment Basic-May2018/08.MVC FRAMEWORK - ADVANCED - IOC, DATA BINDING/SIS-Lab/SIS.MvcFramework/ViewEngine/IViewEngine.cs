namespace SIS.MvcFramework.ViewEngine
{
    public interface IViewEngine
    {
        string GetHtml<T>(string viewName, string ViewCode, T model);
    }
}
