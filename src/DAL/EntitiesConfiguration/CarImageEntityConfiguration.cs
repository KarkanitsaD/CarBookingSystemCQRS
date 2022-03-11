using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfiguration
{
    public class CarImageEntityConfiguration : IEntityTypeConfiguration<CarImageEntity>
    {
        public void Configure(EntityTypeBuilder<CarImageEntity> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(b => b.Base64Content)
                .IsRequired();
        }
    }
}