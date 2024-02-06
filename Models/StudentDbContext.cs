using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDWebApi.Models;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Studentss> Studentsses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-K675LDHS\\SQLEXPRESS;Database=StudentDb;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StudetGander)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Studentss>(entity =>
        {
            entity.ToTable("Studentss");

            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Stander)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.StudentGender)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.StudentName)
                .HasMaxLength(15)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
