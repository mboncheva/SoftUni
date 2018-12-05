namespace SIS.Framework.Attributes.Methods
{
    using SIS.Framework.Attributes.Methods.Base;

    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToLower() == "get")
            {
                return true;
            }

            return false;
        }
    }
}