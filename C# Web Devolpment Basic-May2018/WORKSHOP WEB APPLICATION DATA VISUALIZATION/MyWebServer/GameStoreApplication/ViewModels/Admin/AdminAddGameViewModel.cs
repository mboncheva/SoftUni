namespace MyWebServer.GameStoreApplication.ViewModels.Admin
{
    using Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AdminAddGameViewModel
    {
        [Required]
        [MinLength(ValidationConstants.Game.TitleMinLength,
            ErrorMessage =ValidationConstants.InvalidMinLegnthErrorMessage)]
        [MaxLength(ValidationConstants.Game.TitleMaxLength,
            ErrorMessage =ValidationConstants.InvalidMaxLegnthErrorMessage)]
        public string Title { get; set; }

        [Display(Name = "YouTube Video URL")]
        [Required]
        [MinLength(ValidationConstants.Game.VideoIdLength,
            ErrorMessage = ValidationConstants.ExactLegnthErrorMessage)]
        [MaxLength(ValidationConstants.Game.VideoIdLength,
            ErrorMessage = ValidationConstants.ExactLegnthErrorMessage)]
        public string VideoId { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MinLength(ValidationConstants.Game.DescriptionMinLength,
            ErrorMessage = ValidationConstants.InvalidMinLegnthErrorMessage)]
        public string Description { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
    }
}
