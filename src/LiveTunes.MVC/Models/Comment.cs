using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveTunes.MVC.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Display(Name = "Comment Text")]
        public string CommentText { get; set; }
        [Display(Name = "Comment Time")]
        public DateTime DateTime { get; set; }
        [ForeignKey(nameof(UserProfile))]
        public int UserId { get; set; }
        public UserProfile UserProfile { get; set; }
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}