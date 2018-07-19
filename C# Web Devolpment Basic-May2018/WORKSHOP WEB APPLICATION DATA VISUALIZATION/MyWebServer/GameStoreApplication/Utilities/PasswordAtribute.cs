namespace MyWebServer.GameStoreApplication.Utilities
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PasswordAtribute : ValidationAttribute
    {
        public PasswordAtribute()
        {
            this.ErrorMessage = "Password should be at last 6 symbols long, should contains at least 1 uppercase letter, 1 lowercase letter and 1 digit.";
        }

        public override bool IsValid(object value)
        {
            var password = value as string;
            if (password == null)
            {
                return false;
            }

            return password.Any(x => char.IsDigit(x))
                && password.Any(x => char.IsLower(x))
                && password.Any(x => char.IsUpper(x));
        }
    }
}
