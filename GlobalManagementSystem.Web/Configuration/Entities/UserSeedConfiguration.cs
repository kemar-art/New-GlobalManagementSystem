using GlobalManagementSystem.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlobalManagementSystem.Web.Configuration.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                new Employee
                {
                    Id = "ef7547bf-bd4d-485c-b761-a211dd47fa9a",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    Firstname = "Admin",
                    Lastname = "Admin",
                    PasswordHash = hasher.HashPassword(null, "admin@1"),
                    EmailConfirmed = true
                },
                new Employee
                {
                    Id = "0f127aa8-a53b-471f-ab80-877381474d56",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    UserName = "user@localhost.com",
                    Firstname = "User",
                    Lastname = "User",
                    PasswordHash = hasher.HashPassword(null, "user@1"),
                    EmailConfirmed = true
                }
            );
        }
    }
}