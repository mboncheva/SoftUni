namespace MyWebServer.Server.HTTP.Responce
{
    using Enums;

    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
        {
            this.StatusCode = HttpStatusCode.NotFound;

        }
    }
}