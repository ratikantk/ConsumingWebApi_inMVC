using EmployeeDataWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeDataWebApi.Context
{
    public partial class EmployeeDbConext :DbContext
    {
        public EmployeeDbConext()
        {

        }
        public EmployeeDbConext(DbContextOptions<EmployeeDbConext> options) : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<UserInfo>? UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");
                entity.Property(e => e.EmpId).HasColumnName("EmpID");
                entity.Property(e => e.FirstName).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.LastName).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Designation).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.DateOfBirth).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
