namespace MyWebServer.GameStoreApplication.ViewModels.Account
{
    using Common;
    using Utilities;
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Display(Name ="Full Name")]
        [MinLength(
            ValidationConstants.Account.NameMinLength,
            ErrorMessage = ValidationConstants.InvalidMinLegnthErrorMessage)]
        [MaxLength(
            ValidationConstants.Account.NameMaxLength,
             ErrorMessage = ValidationConstants.InvalidMaxLegnthErrorMessage)]
        public string FullName { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        [MaxLength(
            ValidationConstants.Account.EmailMaxLength,
            ErrorMessage = ValidationConstants.InvalidMaxLegnthErrorMessage)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(
            ValidationConstants.Account.PasswordMinLength,
             ErrorMessage = ValidationConstants.InvalidMinLegnthErrorMessage)]
        [MaxLength(
            ValidationConstants.Account.PasswordMaxLength,
             ErrorMessage = ValidationConstants.InvalidMaxLegnthErrorMessage)]
        [PasswordAtribute]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
