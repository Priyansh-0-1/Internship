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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegancyTimestampBehavior", true);
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Tatva",
                LastName = "Admin",
                EmailAddress = "admin@gmail.com",
                UserType = "admin",
                Password = "Gmail@123",
                PhoneNumber = "9876543210",
                CreatedDate = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
            ,
    new User
    {
        Id = 2,
        FirstName = "John",
        LastName = "Doe",
        EmailAddress = "john@ex.com",
        UserType = "user",
        Password = "John@123",
        PhoneNumber = "9123456780",
        CreatedDate = new DateTime(2020, 5, 15, 0, 0, 0, DateTimeKind.Utc)
    } );
            base.OnModelCreating(modelBuilder);
        }
    }
}
