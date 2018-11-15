namespace SIS.HTTP.Exceptions
{
    using System;
    using System.Net;

    public class BadRequestException : Exception
    {
        private const string ErrorMessage = "The Request was malformed or contains unsupported elements.";

        public const HttpStatusCode statusCode = HttpStatusCode.BadRequest;
             
        public BadRequestException()
            :base(ErrorMessage)
        {
        }
    }
}
