using Api.User.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.User.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options):base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<UserProperty> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().ToTable("Users").HasKey(u => u.Id);
            modelBuilder.Entity<BPFile>().ToTable("UserBPFiles").HasKey(u => u.Id);
            modelBuilder.Entity<UserProperty>().ToTable("UserProperties").HasKey(u => new { u.Key,u.AppUserId,u.Value});
            modelBuilder.Entity<UserTag>().ToTable("UserTags").HasKey(u => new { u.AppUserId, u.Tag });
            modelBuilder.Entity<UserTag>().Property(u => u.Tag).HasMaxLength(100);
            base.OnModelCreating(modelBuilder);
        }
    }
}
