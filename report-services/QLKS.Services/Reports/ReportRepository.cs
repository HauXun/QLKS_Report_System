using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using QLKS.Core.Entities;
using QLKS.Data.Contextp;

namespace QLKS.Services.Reports;

public class ReportRepository : IReportRepository
{
    private readonly ReportDbContext _dbContext;
    private readonly IMemoryCache _memoryCache;

    public ReportRepository(ReportDbContext dbContext, IMemoryCache memoryCache)
    {
        _dbContext = dbContext;
        _memoryCache = memoryCache;
    }

    public async Task<IList<KhachSan>> GetAllKhachSanAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.KhachSan.ToListAsync(cancellationToken);
    }

    public async Task<KhachSan> GetKhachSanByIdAsync(int ksId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.KhachSan.FirstOrDefaultAsync(ks => ks.Id == ksId, cancellationToken);
    }

    public async Task<KhachSan> GetCacheKhachSanByIdAsync(int ksId, CancellationToken cancellationToken = default)
    {
        return await _memoryCache.GetOrCreateAsync(
            $"khachsan.by-id.{ksId}",
            async (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                return await GetKhachSanByIdAsync(ksId);
            });
    }

    public async Task<IList<ChiPhi>> GetChiPhiAsync(int ksId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ChiPhi.Include(c => c.KhachSan)
                                      .AsNoTracking()
                                      .AsSplitQuery()
                                      .Where(c => c.KhachSanId == ksId)
                                      .ToListAsync(cancellationToken);
    }

    public async Task<IList<ChiPhi>> GetChiPhiAsync(int ksId, DateTime date, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ChiPhi.Include(c => c.KhachSan)
                                      .AsNoTracking()
                                      .AsSplitQuery()
                                      .Where(c => c.KhachSanId == ksId && c.ThoiGianTao.Date.Equals(date))
                                      .ToListAsync(cancellationToken);
    }

    public async Task<IList<ChiPhi>> GetChiPhiAsync(int ksId, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ChiPhi.Include(c => c.KhachSan)
                                      .AsNoTracking()
                                      .AsSplitQuery()
                                      .Where(c => c.KhachSanId == ksId && c.ThoiGianTao.Date > fromDate && c.ThoiGianTao.Date < toDate)
                                      .ToListAsync(cancellationToken);
    }

    public async Task<IList<DoanhThu>> GetDoanhThuAsync(int ksId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.DoanhThu.Include(c => c.KhachSan)
                                        .AsNoTracking()
                                        .AsSplitQuery()
                                        .Where(c => c.KhachSanId == ksId)
                                        .ToListAsync(cancellationToken);
    }

    public async Task<IList<DoanhThu>> GetDoanhThuAsync(int ksId, DateTime date, CancellationToken cancellationToken = default)
    {
        return await _dbContext.DoanhThu.Include(c => c.KhachSan)
                                        .AsNoTracking()
                                        .AsSplitQuery()
                                        .Where(c => c.KhachSanId == ksId && c.ThoiGianTao.Date.Equals(date))
                                        .ToListAsync(cancellationToken);
    }

    public async Task<IList<DoanhThu>> GetDoanhThuAsync(int ksId, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.DoanhThu.Include(c => c.KhachSan)
                                        .AsNoTracking()
                                        .AsSplitQuery()
                                        .Where(c => c.KhachSanId == ksId && c.ThoiGianTao.Date > fromDate && c.ThoiGianTao.Date < toDate)
                                        .ToListAsync(cancellationToken);
    }

    public async Task<IList<HdDanhGia>> GetHDDanhGiaAsync(int ksId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.HdDanhGia.Include(c => c.KhachSan)
                                         .AsNoTracking()
                                         .AsSplitQuery()
                                         .Where(c => c.KhachSanId == ksId)
                                         .ToListAsync(cancellationToken);
    }

    public async Task<IList<HdDanhGia>> GetHDDanhGiaAsync(int ksId, DateTime date, CancellationToken cancellationToken = default)
    {
        return await _dbContext.HdDanhGia.Include(c => c.KhachSan)
                                         .AsNoTracking()
                                         .AsSplitQuery()
                                         .Where(c => c.KhachSanId == ksId && c.ThoiGianTao.Date.Equals(date))
                                         .ToListAsync(cancellationToken);
    }

    public async Task<IList<HdDanhGia>> GetHDDanhGiaAsync(int ksId, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.HdDanhGia.Include(c => c.KhachSan)
                                         .AsNoTracking()
                                         .AsSplitQuery()
                                         .Where(c => c.KhachSanId == ksId && c.ThoiGianTao.Date > fromDate && c.ThoiGianTao.Date < toDate)
                                         .ToListAsync(cancellationToken);
    }

    public async Task<IList<HdKhachHang>> GetHDKhachHangAsync(int ksId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.HdKhachHang.Include(c => c.KhachSan)
                                           .AsNoTracking()
                                           .AsSplitQuery()
                                           .Where(c => c.KhachSanId == ksId)
                                           .ToListAsync(cancellationToken);
    }

    public async Task<IList<HdKhachHang>> GetHDKhachHangAsync(int ksId, DateTime date, CancellationToken cancellationToken = default)
    {
        return await _dbContext.HdKhachHang.Include(c => c.KhachSan)
                                           .AsNoTracking()
                                           .AsSplitQuery()
                                           .Where(c => c.KhachSanId == ksId && c.ThoiGianTao.Date.Equals(date))
                                           .ToListAsync(cancellationToken);
    }

    public async Task<IList<HdKhachHang>> GetHDKhachHangAsync(int ksId, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.HdKhachHang.Include(c => c.KhachSan)
                                           .AsNoTracking()
                                           .AsSplitQuery()
                                           .Where(c => c.KhachSanId == ksId && c.ThoiGianTao.Date > fromDate && c.ThoiGianTao.Date < toDate)
                                           .ToListAsync(cancellationToken);
    }

    public async Task<IList<HdNhanVien>> GetHDNhanVienAsync(int ksId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.HdNhanVien.Include(c => c.KhachSan)
                                          .AsNoTracking()
                                          .AsSplitQuery()
                                          .Where(c => c.KhachSanId == ksId)
                                          .ToListAsync(cancellationToken);
    }

    public async Task<IList<HdNhanVien>> GetHDNhanVienAsync(int ksId, DateTime date, CancellationToken cancellationToken = default)
    {
        return await _dbContext.HdNhanVien.Include(c => c.KhachSan)
                                          .AsNoTracking()
                                          .AsSplitQuery()
                                          .Where(c => c.KhachSanId == ksId && c.ThoiGianTao.Date.Equals(date))
                                          .ToListAsync(cancellationToken);
    }

    public async Task<IList<HdNhanVien>> GetHDNhanVienAsync(int ksId, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.HdNhanVien.Include(c => c.KhachSan)
                                          .AsNoTracking()
                                          .AsSplitQuery()
                                          .Where(c => c.KhachSanId == ksId && c.ThoiGianTao.Date > fromDate && c.ThoiGianTao.Date < toDate)
                                          .ToListAsync(cancellationToken);
    }

    public async Task<IList<HdPhong>> GetHDPhongAsync(int ksId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.HdPhong.Include(c => c.KhachSan)
                                       .AsNoTracking()
                                       .AsSplitQuery()
                                       .Where(c => c.KhachSanId == ksId)
                                       .ToListAsync(cancellationToken);
    }

    public async Task<IList<HdPhong>> GetHDPhongAsync(int ksId, DateTime date, CancellationToken cancellationToken = default)
    {
        return await _dbContext.HdPhong.Include(c => c.KhachSan)
                                       .AsNoTracking()
                                       .AsSplitQuery()
                                       .Where(c => c.KhachSanId == ksId && c.ThoiGianTao.Date.Equals(date))
                                       .ToListAsync(cancellationToken);
    }

    public async Task<IList<HdPhong>> GetHDPhongAsync(int ksId, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.HdPhong.Include(c => c.KhachSan)
                                       .AsNoTracking()
                                       .AsSplitQuery()
                                       .Where(c => c.KhachSanId == ksId && c.ThoiGianTao.Date > fromDate && c.ThoiGianTao.Date < toDate)
                                       .ToListAsync(cancellationToken);
    }
}
