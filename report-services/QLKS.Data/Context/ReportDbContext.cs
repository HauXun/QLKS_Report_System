using Microsoft.EntityFrameworkCore;
using QLKS.Core.Entities;

namespace QLKS.Data.Contextp;

public class ReportDbContext : DbContext
{
    public ReportDbContext()
    {
    }

    public ReportDbContext(DbContextOptions<ReportDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiPhi> ChiPhi { get; set; }

    public virtual DbSet<DoanhThu> DoanhThu { get; set; }

    public virtual DbSet<HdDanhGia> HdDanhGia { get; set; }

    public virtual DbSet<HdKhachHang> HdKhachHang { get; set; }

    public virtual DbSet<HdNhanVien> HdNhanVien { get; set; }

    public virtual DbSet<HdPhong> HdPhong { get; set; }

    public virtual DbSet<KhachSan> KhachSan { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=QLKS_Report_System;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KhachSan).Assembly);
    }
}
