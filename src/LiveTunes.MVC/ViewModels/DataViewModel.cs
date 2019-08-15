using System.Collections.Generic;
using LiveTunes.MVC.Models;

namespace LiveTunes.MVC.ViewModels
{
    public class DataViewModel
    {
        public Event Event { get; set; }
        public List<Comment> Comments { get; set; }
    }
}