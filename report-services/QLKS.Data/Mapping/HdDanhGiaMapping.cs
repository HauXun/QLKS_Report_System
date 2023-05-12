using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLKS.Core.Entities;

namespace QLKS.Data.Mapping;

public class HdDanhGiaMapping : IEntityTypeConfiguration<HdDanhGia>
{
    public void Configure(EntityTypeBuilder<HdDanhGia> entity)
    {
        entity.ToTable("HDDanhGia");
        
        entity.Property(e => e.ThoiGianTao).HasColumnType("smalldatetime").IsRequired();

        entity.HasOne(d => d.KhachSan).WithMany(p => p.HdDanhGia)
            .HasForeignKey(d => d.KhachSanId)
            .HasConstraintName("FK_HDDanhGia_Khachsan")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
