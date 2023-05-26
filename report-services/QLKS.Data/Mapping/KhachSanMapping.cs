using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLKS.Core.Entities;

namespace QLKS.Data.Mapping;

public class KhachSanMapping : IEntityTypeConfiguration<KhachSan>
{
    public void Configure(EntityTypeBuilder<KhachSan> entity)
    {
        entity.ToTable("KhachSan");

        entity.Property(e => e.DiaChi).HasMaxLength(1000).IsRequired();
        entity.Property(e => e.TenKhachSan).HasMaxLength(1000).IsRequired();
    }
}
