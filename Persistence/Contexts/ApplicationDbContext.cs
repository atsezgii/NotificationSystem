using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("NotificationConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasMany(u => u.SentNotifications)
                      .WithOne(n => n.Sender)
                      .HasForeignKey(n => n.SenderId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.ReceivedNotifications)
                      .WithOne(n => n.Receiver)
                      .HasForeignKey(n => n.ReceiverId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(n => n.Id);
                entity.Property(n => n.Contents).IsRequired();
                entity.Property(n => n.PostedDate).IsRequired();
                entity.Property(n => n.ReadStatus).IsRequired();
            });
        }
    }
}
    

