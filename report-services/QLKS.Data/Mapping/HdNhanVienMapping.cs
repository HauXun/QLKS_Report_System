using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLKS.Core.Entities;

namespace QLKS.Data.Mapping;

public class HdNhanVienMapping : IEntityTypeConfiguration<HdNhanVien>
{
    public void Configure(EntityTypeBuilder<HdNhanVien> entity)
    {
        entity.ToTable("HDNhanVien");

        entity.Property(e => e.HslamViec).HasColumnName("HSLamViec");
        entity.Property(e => e.ThoiGianTao).HasColumnType("smalldatetime").IsRequired();

        entity.HasOne(d => d.KhachSan).WithMany(p => p.HdNhanVien)
            .HasForeignKey(d => d.KhachSanId)
            .HasConstraintName("FK_HDNhanVien_KhachSan")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
