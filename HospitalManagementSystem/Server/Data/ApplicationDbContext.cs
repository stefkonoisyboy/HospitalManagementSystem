using HospitalManagementSystem.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public virtual DbSet<Hospital> Hospitals { get; set; }

        public virtual DbSet<BloodType> BloodTypes { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Document> Documents { get; set; }

        public virtual DbSet<Documentation> Documentations { get; set; }

        public virtual DbSet<DocumentDocumentation> DocumentDocumentations { get; set; }

        public virtual DbSet<Medicine> Medicines { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Recipe> Recipes { get; set; }

        public virtual DbSet<RecipeMedicine> RecipeMedicines { get; set; }

        public virtual DbSet<Treatment> Treatments { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<PaymentProduct> PaymentProducts { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<UserMessage> UserMessages { get; set; }

        public virtual DbSet<Appointment> Appointments { get; set; }

        public virtual DbSet<Bed> Beds { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

        public virtual DbSet<Floor> Floors { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<BlogPostTag> BlogPostTags { get; set; }

        public virtual DbSet<BlogCategory> BlogCategories { get; set; }

        public virtual DbSet<BlogPost> BlogPosts { get; set; }

        public virtual DbSet<SmsMessage> SmsMessages { get; set; }

        public virtual DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Treatment>()
                .HasOne(t => t.Doctor)
                .WithMany(d => d.TreatmentsCreated)
                .HasForeignKey(f => f.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Treatment>()
                .HasOne(t => t.Patient)
                .WithMany(p => p.TreatmentsReceived)
                .HasForeignKey(f => f.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Recipe>()
                .HasOne(r => r.Doctor)
                .WithMany(d => d.RecipesCreated)
                .HasForeignKey(f => f.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Recipe>()
               .HasOne(r => r.Patient)
               .WithMany(d => d.RecipesReceived)
               .HasForeignKey(f => f.PatientId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Payment>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.PaymentsCreated)
                .HasForeignKey(f => f.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Payment>()
               .HasOne(p => p.Patient)
               .WithMany(d => d.PaymentsReceived)
               .HasForeignKey(f => f.PatientId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.AppointmentsSupervised)
                .HasForeignKey(f => f.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(f => f.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Appointment>()
               .HasOne(a => a.Creator)
               .WithMany(p => p.AppointmentsCreated)
               .HasForeignKey(f => f.CreatorId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
