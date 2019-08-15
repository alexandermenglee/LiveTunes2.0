using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveTunes.MVC.Models
{
    [Table("Event")]
    public class Event
    {
        public int VenueId { get; set; }
        [Display(Name = "Venue Name")]
        public string Venue { get; set; }
        [Key]
        public int EventId { get; set; }
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }
        [Display(Name = "Longitude")]
        public double Longitude { get; set; }
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [Display(Name = "Event Date")]
        public DateTime DateTime { get; set; }
        [Display(Name = "Genre")]
        public string Genre { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public int LikeCount { get; set; }
        [NotMapped]
        public bool UserLiked { get; set; }
        
        public virtual List<Like> Likes { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}