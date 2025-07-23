using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USERS
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(100)
                .IsRequired();

            // CATEGORIES
            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .HasMaxLength(100)
                .IsRequired();

            // COURSES
            modelBuilder.Entity<Course>()
                .Property(c => c.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .HasMaxLength(100);

            modelBuilder.Entity<Course>()
                .Property(c => c.Price)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Course>()
                .HasOne(c => c.User)
                .WithMany(u => u.Courses)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Courses)
                .HasForeignKey(c => c.CategoryId);

            // ENROLLMENTS
            modelBuilder.Entity<Enrollment>()
                .Property(e => e.EnrollmentDate)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.User)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Programming" },
            new Category { CategoryId = 2, CategoryName = "Design" },
            new Category { CategoryId = 3, CategoryName = "Business" },
            new Category { CategoryId = 4, CategoryName = "Marketing" }
            );

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Email = "admin@example.com",
                Password = BCrypt.Net.BCrypt.HashPassword("student123")
            });
        }
    }
}
