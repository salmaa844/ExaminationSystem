using EXSYS.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly  IHttpContextAccessor httpContextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IHttpContextAccessor httpContextAccessor) : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamStudent> ExamStudents { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");


            foreach (var entityType in builder.Model.GetEntityTypes()
             .Where(t => typeof(AuditableEntity).IsAssignableFrom(t.ClrType)))
            {
                builder.Entity(entityType.ClrType)
                    .HasOne(typeof(ApplicationUser), "CreatedBy")
                    .WithMany()
                    .HasForeignKey("CreatedById")
                    .OnDelete(DeleteBehavior.NoAction);


                builder.Entity(entityType.ClrType)
                    .HasOne(typeof(ApplicationUser), "UpdatedBy")
                    .WithMany()
                    .HasForeignKey("UpdatedById")
                    .OnDelete(DeleteBehavior.NoAction);
            }


            // User - Student
            builder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);


            // User - Instructor
            builder.Entity<Instructor>()
                .HasOne(i => i.User)
                .WithOne(u => u.Instructor)
                .HasForeignKey<Instructor>(i => i.UserId)
               .OnDelete(DeleteBehavior.NoAction);


          
            builder.Entity<Exam>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Exams)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.NoAction);


        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            if (httpContextAccessor.HttpContext != null)
            {
                var entries = ChangeTracker.Entries<AuditableEntity>();
                var currentUserId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                foreach (var entry in entries)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property(e => e.CreatedById).CurrentValue = currentUserId;
                        entry.Property(e => e.CreatedOn).CurrentValue = DateTime.UtcNow;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property(e => e.UpdatedById).CurrentValue = currentUserId;
                        entry.Property(e => e.UpdatedOn).CurrentValue = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }

}
