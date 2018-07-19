namespace MyWebServer.Server.HTTP.Responce
{
    using Enums;
    using Server.Common;
    using System;

    public class InternalServerErrorResponse : ViewResponse
    {
        public InternalServerErrorResponse(Exception ex)
           : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(ex))
        {
        }
    }
}
