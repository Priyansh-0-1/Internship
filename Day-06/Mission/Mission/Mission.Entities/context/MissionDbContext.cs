using Microsoft.EntityFrameworkCore;
using Mission.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.context
{
    public class MissionDbContext : DbContext
    {
        public MissionDbContext(DbContextOptions<MissionDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<MissionTheme> MissionTheme { get; set; }

        public DbSet<MissionSkill> MissionSkill { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegancyTimestampBehavior", true);
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 2,
                FirstName = "Tatva",
                LastName = "Admin",
                EmailAddress = "admin@tatvasoft.com",
                UserType = "admin",
                Password = "Tatva@123",
                PhoneNumber = "9876543210",
                CreatedDate = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
           ,

                new User()
                {
                    Id = 3,
                    FirstName = "p",
                    LastName= "p",
                    EmailAddress= "p@admin.com",
                    UserType = "admin",
                    Password = "P@123",
                    PhoneNumber= "1234567890",
                    CreatedDate = new DateTime(2004, 1,1,0,0,0, DateTimeKind.Utc)
                }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
