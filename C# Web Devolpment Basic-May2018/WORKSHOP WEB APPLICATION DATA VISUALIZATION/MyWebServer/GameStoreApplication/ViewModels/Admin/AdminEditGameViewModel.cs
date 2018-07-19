namespace MyWebServer.GameStoreApplication.ViewModels.Admin
{
    using Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AdminEditGameViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.Game.TitleMinLength,
            ErrorMessage =ValidationConstants.InvalidMinLegnthErrorMessage)]
        [MaxLength(ValidationConstants.Game.TitleMaxLength,
            ErrorMessage = ValidationConstants.InvalidMaxLegnthErrorMessage)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.Game.DescriptionMinLength,
            ErrorMessage = ValidationConstants.InvalidMinLegnthErrorMessage)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Youtube Video URL")]
        [MinLength(ValidationConstants.Game.VideoIdLength,
            ErrorMessage = ValidationConstants.InvalidMinLegnthErrorMessage)]
        [MaxLength(ValidationConstants.Game.VideoIdLength,
            ErrorMessage = ValidationConstants.InvalidMaxLegnthErrorMessage)]
        public string VideoId { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public double Size { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
    }
}
