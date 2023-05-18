using Mapster;
using QLKS.Core.Entities;
using QLKS.WebApi.Models;

namespace QLKS.WebApi.Mapsters;

public class MapsterConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<KhachSan, KhachSanDto>();
        config.NewConfig<ChiPhi, ChiPhiDto>();
        config.NewConfig<DoanhThu, DoanhThuDto>();
        config.NewConfig<HdDanhGia, HdDanhGiaDto>();
        config.NewConfig<HdKhachHang, HdKhachHangDto>();
        config.NewConfig<HdNhanVien, HdNhanVienDto>();
        config.NewConfig<HdPhong, HdPhongDto>();
    }
}
