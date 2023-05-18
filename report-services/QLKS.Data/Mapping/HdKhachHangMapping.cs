using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLKS.Core.Entities;

namespace QLKS.Data.Mapping;

public class HdKhachHangMapping : IEntityTypeConfiguration<HdKhachHang>
{
    public void Configure(EntityTypeBuilder<HdKhachHang> entity)
    {
        entity.ToTable("HDKhachHang");

        entity.Property(e => e.ThoiGianTao).HasColumnType("smalldatetime").IsRequired();

        entity.HasOne(d => d.KhachSan).WithMany(p => p.HdKhachHang)
            .HasForeignKey(d => d.KhachSanId)
            .HasConstraintName("FK_HDKhachHang_KhachSan")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
