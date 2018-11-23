namespace SIS.MvcFramework.ViewEngine
{
    public partial class ViewEngine
    {
        public interface IView<T>
        {
            string GetHtml(T model);
        }
    }
}
