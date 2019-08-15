using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LiveTunes.MVC.Models
{
    [Table("Music Preferences")]
    public class MusicPreference
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public UserProfile User { get; set; }
        [Key]
        public int MusicPreferenceId { get; set; }
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }
        [Display(Name = "Song Name")]
        public string SongName { get; set; }
        [Display(Name = "Genre")]
        public string Genre { get; set; }
    }
}