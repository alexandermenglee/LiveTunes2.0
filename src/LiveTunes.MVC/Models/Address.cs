using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveTunes.MVC.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        [ForeignKey(nameof(Business))]
        public int BusinessId { get; set; }
        public BusinessProfile Business { get; set; }
    }
}