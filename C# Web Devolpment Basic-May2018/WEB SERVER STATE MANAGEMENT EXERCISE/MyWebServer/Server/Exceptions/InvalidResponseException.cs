﻿//namespace MyWebServer.Server.Exceptions
//{
namespace MyWebServer.Server.Exceptions
{
    using System;

    public class InvalidResponseException : Exception
    {
        public InvalidResponseException(string message)
            : base(message)
        {
        }
    }
}