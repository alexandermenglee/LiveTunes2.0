using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LiveTunes.MVC.Models
{
    [Table("Business Profile")]
    public class BusinessProfile
    {
        [Key]
        public int BusinessProfileId { get; set; }
        public int VenueId { get; set; }
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}