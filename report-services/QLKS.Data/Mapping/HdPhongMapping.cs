using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLKS.Core.Entities;

namespace QLKS.Data.Mapping;

public class HdPhongMapping : IEntityTypeConfiguration<HdPhong>
{
    public void Configure(EntityTypeBuilder<HdPhong> entity)
    {
        entity.ToTable("HDPhong");

        entity.Property(e => e.ThoiGianTao).HasColumnType("smalldatetime").IsRequired();

        entity.HasOne(d => d.KhachSan).WithMany(p => p.HdPhong)
            .HasForeignKey(d => d.KhachSanId)
            .HasConstraintName("FK_HDPhong_KhachSan")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
