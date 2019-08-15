using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveTunes.MVC.Models
{
    [Table("Survey")]
    public class Survey
    {
        [Key]
        public int SurverId { get; set; }
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }
        [Display(Name = "Favorite Genre 1")]
        public string FavoriteGenre1 { get; set; }
        [Display(Name = "Favorite Genre 2")]
        public string FavoriteGenre2 { get; set; }
        [Display(Name = "Favorite Genre 3")]
        public string FavoriteGenre3 { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public UserProfile User { get; set; }
    }
}