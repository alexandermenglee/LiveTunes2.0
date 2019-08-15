using System;
using System.Collections.Generic;
using System.Text;
using LiveTunes.MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiveTunes.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BusinessProfile> BusinessProfiles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<MusicPreference> MusicPreferences { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
    }
}
