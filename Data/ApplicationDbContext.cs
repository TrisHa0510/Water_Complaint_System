using Microsoft.EntityFrameworkCore;
using WaterComplaintSystem.Models;

namespace WaterComplaintSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Ward> Wards { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ComplaintPhoto> ComplaintPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Complaint>()
                .HasOne(c => c.Citizen)
                .WithMany(ci => ci.Complaints)
                .HasForeignKey(c => c.CitizenId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Complaint>()
                .HasOne(c => c.Ward)
                .WithMany(w => w.Complaints)
                .HasForeignKey(c => c.WardId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Complaint>()
                .HasOne(c => c.AssignedWorker)
                .WithMany(w => w.Complaints)
                .HasForeignKey(c => c.AssignedWorkerId)
                .OnDelete(DeleteBehavior.SetNull);

            // Seed data - 5 Wards
            modelBuilder.Entity<Ward>().HasData(
                new Ward { Id = 1, Name = "Ward 1", Area = "Central Business District", Description = "Downtown commercial area" },
                new Ward { Id = 2, Name = "Ward 2", Area = "Residential North", Description = "Northern residential zone" },
                new Ward { Id = 3, Name = "Ward 3", Area = "Industrial East", Description = "Eastern industrial sector" },
                new Ward { Id = 4, Name = "Ward 4", Area = "Suburban South", Description = "Southern suburban area" },
                new Ward { Id = 5, Name = "Ward 5", Area = "Commercial West", Description = "Western commercial district" }
            );

            // Seed data - 5 Workers
            modelBuilder.Entity<Worker>().HasData(
                new Worker { Id = 1, Name = "John Smith", Phone = "9876543210", Email = "john.smith@municipal.gov", WardId = 1 },
                new Worker { Id = 2, Name = "Sarah Johnson", Phone = "9876543211", Email = "sarah.johnson@municipal.gov", WardId = 2 },
                new Worker { Id = 3, Name = "Michael Brown", Phone = "9876543212", Email = "michael.brown@municipal.gov", WardId = 3 },
                new Worker { Id = 4, Name = "Emily Davis", Phone = "9876543213", Email = "emily.davis@municipal.gov", WardId = 4 },
                new Worker { Id = 5, Name = "Robert Wilson", Phone = "9876543214", Email = "robert.wilson@municipal.gov", WardId = 5 }
            );

            // Seed data - 5 Citizens
            modelBuilder.Entity<Citizen>().HasData(
                new Citizen { Id = 1, Name = "Alice Williams", Phone = "9123456780", Email = "alice.w@email.com", Address = "123 Main Street, Ward 1" },
                new Citizen { Id = 2, Name = "Bob Miller", Phone = "9123456781", Email = "bob.m@email.com", Address = "456 Oak Avenue, Ward 2" },
                new Citizen { Id = 3, Name = "Carol Garcia", Phone = "9123456782", Email = "carol.g@email.com", Address = "789 Pine Road, Ward 3" },
                new Citizen { Id = 4, Name = "David Martinez", Phone = "9123456783", Email = "david.m@email.com", Address = "321 Elm Street, Ward 4" },
                new Citizen { Id = 5, Name = "Eva Anderson", Phone = "9123456784", Email = "eva.a@email.com", Address = "654 Maple Drive, Ward 5" }
            );

            // Seed data - 5 Sample Complaints
            modelBuilder.Entity<Complaint>().HasData(
                new Complaint { Id = 1, Title = "No water supply since morning", Description = "Water supply completely stopped from 6 AM today", Status = "Pending", Priority = "High", CitizenId = 1, WardId = 1, CreatedDate = DateTime.Now.AddDays(-2) },
                new Complaint { Id = 2, Title = "Low water pressure", Description = "Water pressure very low, difficult to use", Status = "InProgress", Priority = "Medium", CitizenId = 2, WardId = 2, AssignedWorkerId = 2, CreatedDate = DateTime.Now.AddDays(-5) },
                new Complaint { Id = 3, Title = "Dirty water supply", Description = "Water coming out is brownish in color", Status = "Pending", Priority = "Critical", CitizenId = 3, WardId = 3, CreatedDate = DateTime.Now.AddDays(-1) },
                new Complaint { Id = 4, Title = "Pipeline leakage", Description = "Major pipeline leak on the street", Status = "Resolved", Priority = "High", CitizenId = 4, WardId = 4, AssignedWorkerId = 4, CreatedDate = DateTime.Now.AddDays(-10), ResolvedDate = DateTime.Now.AddDays(-3) },
                new Complaint { Id = 5, Title = "Irregular water timing", Description = "Water supply timing not consistent", Status = "Pending", Priority = "Low", CitizenId = 5, WardId = 5, CreatedDate = DateTime.Now.AddDays(-7) }
            );
        }
    }
}
