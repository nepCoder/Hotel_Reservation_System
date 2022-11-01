
using HotelReservation.Entities;
using Microsoft.EntityFrameworkCore;
namespace Hotel_Reservation_System.Context
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomCategory> RoomCategories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('pending payment')");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Customer");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Booking_Room");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.CheckOutTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('pending payment')");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Invoice_Customer");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.HasIndex(e => e.RoomName, "UQ__Room__6B500B55BB54B0D2")
                    .IsUnique();

                entity.Property(e => e.RoomDescription).HasMaxLength(250);

                entity.Property(e => e.RoomName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Available')");

                entity.HasOne(d => d.RoomCategory)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomCategoryId)
                    .HasConstraintName("FK_Room_RoomCategory");
            });

            modelBuilder.Entity<RoomCategory>(entity =>
            {
                entity.ToTable("RoomCategory");

                entity.HasIndex(e => e.CategoryName, "UQ__RoomCate__8517B2E06EE7E471")
                    .IsUnique();

                entity.Property(e => e.CategoryDescription).HasMaxLength(250);

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
