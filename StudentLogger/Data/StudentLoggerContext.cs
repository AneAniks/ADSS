using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentLogger.Models;

namespace StudentLogger.Data
{
    public partial class StudentLoggerContext : DbContext
    {
        //public StudentLoggerContext()
        //{
        //}

        public StudentLoggerContext(DbContextOptions<StudentLoggerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activities> Activities { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<EnrolledIn> EnrolledIn { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost,1432;Initial Catalog=StudentLogger;Persist Security Info=True;User ID=sa;Password=!2E45678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activities>(entity =>
            {
                entity.HasKey(e => e.ActivityId)
                    .HasName("PK__Activiti__45F4A791D7FBBF88");

                entity.Property(e => e.DatePresented).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Activitie__Cours__403A8C7D");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Activitie__Stude__3E52440B");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__Courses__C92D71A767275FA4");

                entity.Property(e => e.CourseName).HasMaxLength(250);

                entity.Property(e => e.Proffesor).HasMaxLength(250);
            });

            modelBuilder.Entity<EnrolledIn>(entity =>
            {
                entity.HasKey(e => e.EnrollId)
                    .HasName("PK__Enrolled__405B562CE2230CE1");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.EnrolledIn)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__EnrolledI__Cours__3C69FB99");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.EnrolledIn)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__EnrolledI__Stude__3D5E1FD2");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__Students__32C52B9912390B29");

                entity.Property(e => e.EnrollDate).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
