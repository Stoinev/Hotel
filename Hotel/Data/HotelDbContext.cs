using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data
{
    public class HotelDbContext:DbContext
    {
        
        public HotelDbContext()
        {

        }
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=hotel1;User=root;Password=0000;",
                    new MySqlServerVersion(new Version(8, 0, 41)));
            }
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
              .HasKey(k => new { k.ClientId, k.RoomId });

            modelBuilder.Entity<Reservation>()
                .HasOne(rs => rs.Client)
                .WithMany(r => r.Reservations)
                .HasForeignKey(cl => cl.ClientId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(rs => rs.Reservations)
                .HasForeignKey(s => s.RoomId);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Clients)
                .WithMany(e => e.Rooms)
                .UsingEntity<Reservation>(
                l => l.HasOne<Client>(e => e.Client).WithMany(e => e.Reservations),
                r => r.HasOne<Room>(e => e.Room).WithMany(e => e.Reservations));

            modelBuilder.Entity<Client>()
              .HasMany(e => e.Rooms)
              .WithMany(k => k.Clients)
              .UsingEntity<Reservation>(
              l => l.HasOne<Room>(e => e.Room).WithMany(e => e.Reservations),
              r => r.HasOne<Client>(e => e.Client).WithMany(e => e.Reservations));
        }
    }
}
