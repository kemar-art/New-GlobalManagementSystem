using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlobalManagementSystem.Web.Configuration.Entities
{
    internal class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    UserId = "ef7547bf-bd4d-485c-b761-a211dd47fa9a"

                },
                new IdentityUserRole<string>
                {
                    RoleId = "eba7548ff-da7d-475a-b17c-a200ad79f77a",
                    UserId = "0f127aa8-a53b-471f-ab80-877381474d56"

                }
             );
        }
    }
}