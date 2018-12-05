namespace SIS.WebServer.Api.Contracts
{
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;

    public interface IHttpHandler
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}
