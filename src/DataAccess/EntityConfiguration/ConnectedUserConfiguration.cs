using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration
{
    public class ConnectedUserConfiguration : IEntityTypeConfiguration<ConnectedUser>
    {
        public void Configure(EntityTypeBuilder<ConnectedUser> builder)
        {
            builder
                .HasOne(prop => prop.User)
                .WithMany(prop => prop.ConnectionFromUser)
                .HasForeignKey(prop => prop.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(prop => prop.ConnectedToUser)
                .WithMany(prop => prop.ConnectionToUser)
                .HasForeignKey(prop => prop.ConnectedToUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(prop => prop.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
