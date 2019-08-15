using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveTunes.MVC.Models
{
    public class MusicCategory
    {
        public MusicCategory()
        {

        }
        public MusicCategory(int id, string name)
        {
            this.Id = id;
            this.CategoryName = name;
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
