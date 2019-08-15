using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveTunes.MVC.Models
{
    [Table("Like")]
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public Event Event { get; set; }
        [ForeignKey(nameof(UserProfile))]
        public int UserId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}