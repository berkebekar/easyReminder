using EasyReminder.Core.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyReminder.Infrastructure.Persistence.Configurations;

public sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.TimeZoneId).IsRequired();
    }

}
