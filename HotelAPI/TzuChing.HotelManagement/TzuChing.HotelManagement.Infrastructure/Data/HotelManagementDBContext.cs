using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TzuChing.HotelManagement.ApplicationCore.Entities;

namespace TzuChing.HotelManagement.Infrastructure.Data
{
    public class HotelManagementDBContext : DbContext
    {
        public HotelManagementDBContext(DbContextOptions<HotelManagementDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RoomTypes>(ConfigureRT);
            builder.Entity<Services>(ConfigureService);
            builder.Entity<Customers>(ConfigureCustomer);
            builder.Entity<Rooms>(ConfigureRoom);
        }

        private void ConfigureRT(EntityTypeBuilder<RoomTypes> builder)
        {
            builder.ToTable("RoomType");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.RTDESC).HasMaxLength(20);
        }

        private void ConfigureRoom(EntityTypeBuilder<Rooms> builder)
        {
            builder.ToTable("Room");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.RoomTypeId).HasMaxLength(20);
            builder.Property(r => r.RoomTypeId).HasColumnName("RTCode");
            builder.Property(r => r.Status).HasDefaultValue(true);
        }

        private void ConfigureService(EntityTypeBuilder<Services> builder)
        {
            builder.ToTable("Service");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.SDESC).HasMaxLength(50);
            builder.Property(s => s.RoomId).HasColumnName("RoomNo");
        }

        private void ConfigureCustomer(EntityTypeBuilder<Customers> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CName).HasMaxLength(20);
            builder.Property(c => c.Address).HasMaxLength(100);
            builder.Property(c => c.Phone).HasMaxLength(20);
            builder.Property(c => c.Email).HasMaxLength(40);
            builder.Property(c => c.RoomId).HasColumnName("RoomNo");
        }

        public DbSet<Customers> Customer { get; set; }
        public DbSet<Services> Service { get; set; }
        public DbSet<Rooms> Room { get; set; }
        public DbSet<RoomTypes> RoomType { get; set; }
    }
}
