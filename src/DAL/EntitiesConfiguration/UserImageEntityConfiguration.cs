using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfiguration
{
    public class UserImageEntityConfiguration : IEntityTypeConfiguration<UserImageEntity>
    {
        public void Configure(EntityTypeBuilder<UserImageEntity> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Extension)
                .IsRequired();

            builder.Property(i => i.Content)
                .IsRequired();

            builder.HasOne(i => i.User)
                .WithOne(u => u.UserImage)
                .HasForeignKey<UserImageEntity>(i => i.UserId);
        }
    }
}