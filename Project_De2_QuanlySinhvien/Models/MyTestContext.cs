using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Project_De2_QuanlySinhvien.Models
{
    public partial class MyTestContext : DbContext
    {
        public MyTestContext()
        {
        }

        public MyTestContext(DbContextOptions<MyTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<KetQua> KetQuas { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<Mon> Mons { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("StudentManagement"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<KetQua>(entity =>
            {
                entity.HasKey(e => new { e.MaSo, e.MaMh })
                    .HasName("PK__KetQua__A5575580ABE15210");

                entity.ToTable("KetQua");

                entity.Property(e => e.MaSo)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.MaMh)
                    .HasMaxLength(6)
                    .HasColumnName("MaMH")
                    .IsFixedLength(true);

                entity.Property(e => e.Diem).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.KetQuas)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KetQua__MaMH__2C3393D0");

                entity.HasOne(d => d.MaSoNavigation)
                    .WithMany(p => p.KetQuas)
                    .HasForeignKey(d => d.MaSo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KetQua__MaSo__2D27B809");
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa)
                    .HasName("PK__Khoa__65390405B44CF071");

                entity.ToTable("Khoa");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(6)
                    .IsFixedLength(true);

                entity.Property(e => e.TenKhoa).HasMaxLength(30);
            });

            modelBuilder.Entity<Mon>(entity =>
            {
                entity.HasKey(e => e.MaMh)
                    .HasName("PK__Mon__2725DFD9E389AEF4");

                entity.ToTable("Mon");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(6)
                    .HasColumnName("MaMH")
                    .IsFixedLength(true);

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(6)
                    .IsFixedLength(true);

                entity.Property(e => e.TenMh)
                    .HasMaxLength(30)
                    .HasColumnName("TenMH");

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.Mons)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("FK__Mon__MaKhoa__29572725");
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSo)
                    .HasName("PK__SinhVien__2725087D8B95A8CC");

                entity.ToTable("SinhVien");

                entity.Property(e => e.MaSo)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(6)
                    .IsFixedLength(true);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("FK__SinhVien__MaKhoa__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
