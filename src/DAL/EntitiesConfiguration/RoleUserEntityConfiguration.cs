using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfiguration
{
    public class RoleUserEntityConfiguration : IEntityTypeConfiguration<RoleUserEntity>
    {
        public void Configure(EntityTypeBuilder<RoleUserEntity> builder)
        {
            builder.HasKey(ru => new { ru.RoleId, ru.UserId });

            builder.HasOne(ru => ru.Role)
                .WithMany(r => r.RoleUsers)
                .HasForeignKey(ru => ru.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ru => ru.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ru => ru.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}