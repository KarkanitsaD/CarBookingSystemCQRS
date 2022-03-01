using DAL.Entities;
using DAL.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class CarBookingSystemContext : DbContext
    {
        public CarBookingSystemContext(DbContextOptions<CarBookingSystemContext> options) 
            : base(options)
        {
        }

        public DbSet<BookingEntity> Bookings { get; set; }

        public DbSet<BookingPointEntity> BookingPoints { get; set; }

        public DbSet<CarCarImageEntity> CarCarImages { get; set; }

        public DbSet<CarEntity> Cars { get; set; }

        public DbSet<CarImageEntity> CarImages { get; set; }

        public DbSet<CarLockEntity> CarLocks { get; set; }

        public DbSet<CarTransmissionEntity> CarTransmissionTypes { get; set; }

        public DbSet<CityEntity> Cities { get; set; }

        public DbSet<CountryEntity> Countries { get; set; }

        public DbSet<ExtraServiceBookingEntity> ExtraServiceBookings { get; set; }

        public DbSet<ExtraServiceEntity> ExtraServices { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        public DbSet<RoleUserEntity> RoleUsers { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<UserImageEntity> UserImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingEntityConfiguration())
                .ApplyConfiguration(new BookingPointEntityConfiguration())
                .ApplyConfiguration(new CarCarImageEntityConfiguration())
                .ApplyConfiguration(new CarEntityConfiguration())
                .ApplyConfiguration(new CarImageEntityConfiguration())
                .ApplyConfiguration(new CarLockEntityConfiguration())
                .ApplyConfiguration(new CarTransmissionEntityConfiguration())
                .ApplyConfiguration(new CityEntityConfiguration())
                .ApplyConfiguration(new CountryEntityConfiguration())
                .ApplyConfiguration(new ExtraServiceBookingEntityConfiguration())
                .ApplyConfiguration(new ExtraServiceEntityConfiguration())
                .ApplyConfiguration(new RoleEntityConfiguration())
                .ApplyConfiguration(new RoleUserEntityConfiguration())
                .ApplyConfiguration(new UserEntityConfiguration())
                .ApplyConfiguration(new UserImageEntityConfiguration());
        }
    }
}