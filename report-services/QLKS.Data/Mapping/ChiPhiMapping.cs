using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLKS.Core.Entities;

namespace QLKS.Data.Mapping;

public class ChiPhiMapping : IEntityTypeConfiguration<ChiPhi>
{
    public void Configure(EntityTypeBuilder<ChiPhi> entity)
    {
        entity.ToTable("ChiPhi");

        entity.Property(e => e.GhiChu)
              .HasMaxLength(4000);

        entity.Property(e => e.MoTa)
              .HasMaxLength(4000);

        entity.Property(e => e.MucDich)
              .HasMaxLength(4000);

        entity.Property(e => e.TenChiPhi)
              .HasMaxLength(1000)
              .IsRequired();

        entity.Property(e => e.ThoiGianTao)
              .HasColumnType("smalldatetime")
              .IsRequired();

        entity.HasOne(d => d.KhachSan).WithMany(p => p.ChiPhi)
            .HasForeignKey(d => d.KhachSanId)
            .HasConstraintName("FK_ChiPhi_KhachSan")
            .OnDelete(DeleteBehavior.Cascade);
    }
}