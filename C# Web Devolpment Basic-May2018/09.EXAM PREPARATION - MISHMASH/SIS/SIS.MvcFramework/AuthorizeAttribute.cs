namespace SIS.MvcFramework
{
    using System;

    public class AuthorizeAttribute : Attribute
    {
        public string RoleName { get; }

        public AuthorizeAttribute(string roleName = null)
        {
            this.RoleName = roleName;
        }
    }
}
