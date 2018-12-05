namespace SIS.WebServer.Api.Contracts
{
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;

    public interface IHttpHandlingContext
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}
