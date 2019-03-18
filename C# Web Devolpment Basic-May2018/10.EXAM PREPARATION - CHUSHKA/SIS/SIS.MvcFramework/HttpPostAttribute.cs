namespace SIS.MvcFramework
{
    using SIS.HTTP.Enums;

    public class HttpPostAttribute : HttpAttribute
    {
        public HttpPostAttribute(string path = null)
            : base(path)
        {
        }

        public override HttpRequestMethod Method => HttpRequestMethod.Post;
    }
}
