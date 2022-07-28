using GlobalManagementSystem.Web.Constants;
using GlobalManagementSystem.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlobalManagementSystem.Web.Configuration.Entities
{
    public class ConditionsSeedConfiguration : IEntityTypeConfiguration<Condition>
    {

        public void Configure(EntityTypeBuilder<Condition> builder)
        {
            builder.HasData(
                new Condition
                {
                    Id = 1,
                    Name = "New"
                },
                 new Condition
                 {
                     Id = 2,
                     Name = "Used"
                 }

            );
        }
    }
}
