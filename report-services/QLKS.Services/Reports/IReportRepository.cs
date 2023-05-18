using QLKS.Core.Entities;

namespace QLKS.Services.Reports;

public interface IReportRepository
{
    Task<IList<HdDanhGia>> GetHDDanhGiaAsync(int ksId, CancellationToken cancellationToken = default);
    Task<IList<HdDanhGia>> GetHDDanhGiaAsync(int ksId, DateTime date, CancellationToken cancellationToken = default);
    Task<IList<HdDanhGia>> GetHDDanhGiaAsync(int ksId, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default);

    Task<IList<HdKhachHang>> GetHDKhachHangAsync(int ksId, CancellationToken cancellationToken = default);
    Task<IList<HdKhachHang>> GetHDKhachHangAsync(int ksId, DateTime date, CancellationToken cancellationToken = default);
    Task<IList<HdKhachHang>> GetHDKhachHangAsync(int ksId, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default);

    Task<IList<HdNhanVien>> GetHDNhanVienAsync(int ksId, CancellationToken cancellationToken = default);
    Task<IList<HdNhanVien>> GetHDNhanVienAsync(int ksId, DateTime date, CancellationToken cancellationToken = default);
    Task<IList<HdNhanVien>> GetHDNhanVienAsync(int ksId, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default);

    Task<IList<HdPhong>> GetHDPhongAsync(int ksId, CancellationToken cancellationToken = default);
    Task<IList<HdPhong>> GetHDPhongAsync(int ksId, DateTime date, CancellationToken cancellationToken = default);
    Task<IList<HdPhong>> GetHDPhongAsync(int ksId, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default);

    Task<IList<ChiPhi>> GetChiPhiAsync(int ksId, CancellationToken cancellationToken = default);
    Task<IList<ChiPhi>> GetChiPhiAsync(int ksId, DateTime date, CancellationToken cancellationToken = default);
    Task<IList<ChiPhi>> GetChiPhiAsync(int ksId, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default);

    Task<IList<DoanhThu>> GetDoanhThuAsync(int ksId, CancellationToken cancellationToken = default);
    Task<IList<DoanhThu>> GetDoanhThuAsync(int ksId, DateTime date, CancellationToken cancellationToken = default);
    Task<IList<DoanhThu>> GetDoanhThuAsync(int ksId, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default);

    Task<IList<KhachSan>> GetAllKhachSanAsync(CancellationToken cancellationToken = default);

    Task<KhachSan> GetKhachSanByIdAsync(int ksId, CancellationToken cancellationToken = default);
    Task<KhachSan> GetCacheKhachSanByIdAsync(int ksId, CancellationToken cancellationToken = default);
}
