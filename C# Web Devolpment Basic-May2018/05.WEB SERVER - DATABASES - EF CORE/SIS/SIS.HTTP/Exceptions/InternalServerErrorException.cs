namespace SIS.HTTP.Exceptions
{
    using System;
    using System.Net;

    public class InternalServerErrorException : Exception
    {
        private const string ErrorMessage = "The Server has encountered an error.";

        public const HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

        public InternalServerErrorException()
            :base(ErrorMessage)
        {

        }
    }
}
