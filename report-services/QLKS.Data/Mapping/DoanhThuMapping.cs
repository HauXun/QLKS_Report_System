using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLKS.Core.Entities;

namespace QLKS.Data.Mapping;

public class DoanhThuMapping : IEntityTypeConfiguration<DoanhThu>
{
    public void Configure(EntityTypeBuilder<DoanhThu> entity)
    {
        entity.ToTable("DoanhThu");

        entity.Property(e => e.MoTa).HasMaxLength(4000);
        entity.Property(e => e.TenDoanhThu).HasMaxLength(1000).IsRequired();
        entity.Property(e => e.ThoiGianTao).HasColumnType("smalldatetime").IsRequired();

        entity.HasOne(d => d.KhachSan).WithMany(p => p.DoanhThu)
            .HasForeignKey(d => d.KhachSanId)
            .HasConstraintName("FK_DoanhThu_KhachSan")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
