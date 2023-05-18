using Carter;
using MapsterMapper;
using QLKS.Core.Entities;
using QLKS.Services.Reports;
using QLKS.WebApi.Models;
using System.Net;

namespace QLKS.WebApi.Endpoints;

public class ReportEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var routeGroupBuilder = app.MapGroup("/api/reports");

        // Nested Map with defined specific route
        routeGroupBuilder.MapGet("/hddanhgia", GetHoatDongDanhGia)
                         .WithName("GetHoatDongDanhGia");

        routeGroupBuilder.MapGet("/hdkhachhang", GetHoatDongKhachHang)
                         .WithName("GetHoatDongKhachHang");

        routeGroupBuilder.MapGet("/hdnhanvien", GetHoatDongNhanVien)
                         .WithName("GetHoatDongNhanVien");

        routeGroupBuilder.MapGet("/hdphong", GetHoatDongPhong)
                         .WithName("GetHoatDongPhong");

        routeGroupBuilder.MapGet("/chiphi", GetChiPhi)
                         .WithName("GetChiPhi");

        routeGroupBuilder.MapGet("/doanhthu", GetDoanhThu)
                         .WithName("GetDoanhThu");

        routeGroupBuilder.MapGet("/khachsan", GetKhachSan)
                         .WithName("GetKhachSan");

        routeGroupBuilder.MapGet("/khachsan/{id:int}", GetKhachSanById)
                         .WithName("GetKhachSanById");
    }

    private static async Task<IResult> GetHoatDongDanhGia([AsParameters] ReportFilterModel model, IReportRepository reportRepository, IMapper mapper)
    {
        if (model.KhachSanId == null)
        {
            return Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy khách sạn nào!"));
        }

        if (model.Date == null && model.FromDate == null && model.ToDate == null)
        {
            return Results.Ok(ApiResponse.Fail(HttpStatusCode.BadRequest, $"Thông tin không hợp lệ!"));
        }

        IList<HdDanhGia> result = null;
        if (model.Date != null)
        {
            result = await reportRepository.GetHDDanhGiaAsync(model.KhachSanId.Value, model.Date.Value);
        }

        if (model.FromDate != null && model.ToDate == null)
        {
            result = await reportRepository.GetHDDanhGiaAsync(model.KhachSanId.Value, model.FromDate.Value);
        }

        if (model.FromDate == null && model.ToDate != null)
        {
            result = await reportRepository.GetHDDanhGiaAsync(model.KhachSanId.Value, model.ToDate.Value);
        }

        if (model.FromDate != null && model.ToDate != null)
        {
            result = await reportRepository.GetHDDanhGiaAsync(model.KhachSanId.Value, model.FromDate.Value, model.ToDate.Value);
        }

        return Results.Ok(ApiResponse.Success(mapper.Map<List<HdDanhGiaDto>>(result)));
    }


    private static async Task<IResult> GetHoatDongKhachHang([AsParameters] ReportFilterModel model, IReportRepository reportRepository, IMapper mapper)
    {
        if (model.KhachSanId == null)
        {
            return Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy khách sạn nào!"));
        }

        if (model.Date == null && model.FromDate == null && model.ToDate == null)
        {
            return Results.Ok(ApiResponse.Fail(HttpStatusCode.BadRequest, $"Thông tin không hợp lệ!"));
        }

        IList<HdKhachHang> result = null;
        if (model.Date != null)
        {
            result = await reportRepository.GetHDKhachHangAsync(model.KhachSanId.Value, model.Date.Value);
        }

        if (model.FromDate != null && model.ToDate == null)
        {
            result = await reportRepository.GetHDKhachHangAsync(model.KhachSanId.Value, model.FromDate.Value);
        }

        if (model.FromDate == null && model.ToDate != null)
        {
            result = await reportRepository.GetHDKhachHangAsync(model.KhachSanId.Value, model.ToDate.Value);
        }

        if (model.FromDate != null && model.ToDate != null)
        {
            result = await reportRepository.GetHDKhachHangAsync(model.KhachSanId.Value, model.FromDate.Value, model.ToDate.Value);
        }

        return Results.Ok(ApiResponse.Success(mapper.Map<List<HdKhachHangDto>>(result)));
    }

    private static async Task<IResult> GetHoatDongNhanVien([AsParameters] ReportFilterModel model, IReportRepository reportRepository, IMapper mapper)
    {
        if (model.KhachSanId == null)
        {
            return Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy khách sạn nào!"));
        }

        if (model.Date == null && model.FromDate == null && model.ToDate == null)
        {
            return Results.Ok(ApiResponse.Fail(HttpStatusCode.BadRequest, $"Thông tin không hợp lệ!"));
        }

        IList<HdNhanVien> result = null;
        if (model.Date != null)
        {
            result = await reportRepository.GetHDNhanVienAsync(model.KhachSanId.Value, model.Date.Value);
        }

        if (model.FromDate != null && model.ToDate == null)
        {
            result = await reportRepository.GetHDNhanVienAsync(model.KhachSanId.Value, model.FromDate.Value);
        }

        if (model.FromDate == null && model.ToDate != null)
        {
            result = await reportRepository.GetHDNhanVienAsync(model.KhachSanId.Value, model.ToDate.Value);
        }

        if (model.FromDate != null && model.ToDate != null)
        {
            result = await reportRepository.GetHDNhanVienAsync(model.KhachSanId.Value, model.FromDate.Value, model.ToDate.Value);
        }

        return Results.Ok(ApiResponse.Success(mapper.Map<List<HdNhanVienDto>>(result)));
    }

    private static async Task<IResult> GetHoatDongPhong([AsParameters] ReportFilterModel model, IReportRepository reportRepository, IMapper mapper)
    {
        if (model.KhachSanId == null)
        {
            return Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy khách sạn nào!"));
        }

        if (model.Date == null && model.FromDate == null && model.ToDate == null)
        {
            return Results.Ok(ApiResponse.Fail(HttpStatusCode.BadRequest, $"Thông tin không hợp lệ!"));
        }

        IList<HdPhong> result = null;
        if (model.Date != null)
        {
            result = await reportRepository.GetHDPhongAsync(model.KhachSanId.Value, model.Date.Value);
        }

        if (model.FromDate != null && model.ToDate == null)
        {
            result = await reportRepository.GetHDPhongAsync(model.KhachSanId.Value, model.FromDate.Value);
        }

        if (model.FromDate == null && model.ToDate != null)
        {
            result = await reportRepository.GetHDPhongAsync(model.KhachSanId.Value, model.ToDate.Value);
        }

        if (model.FromDate != null && model.ToDate != null)
        {
            result = await reportRepository.GetHDPhongAsync(model.KhachSanId.Value, model.FromDate.Value, model.ToDate.Value);
        }

        return Results.Ok(ApiResponse.Success(mapper.Map<List<HdPhongDto>>(result)));
    }

    private static async Task<IResult> GetChiPhi([AsParameters] ReportFilterModel model, IReportRepository reportRepository, IMapper mapper)
    {
        if (model.KhachSanId == null)
        {
            return Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy khách sạn nào!"));
        }

        if (model.Date == null && model.FromDate == null && model.ToDate == null)
        {
            return Results.Ok(ApiResponse.Fail(HttpStatusCode.BadRequest, $"Thông tin không hợp lệ!"));
        }

        IList<ChiPhi> result = null;
        if (model.Date != null)
        {
            result = await reportRepository.GetChiPhiAsync(model.KhachSanId.Value, model.Date.Value);
        }

        if (model.FromDate != null && model.ToDate == null)
        {
            result = await reportRepository.GetChiPhiAsync(model.KhachSanId.Value, model.FromDate.Value);
        }

        if (model.FromDate == null && model.ToDate != null)
        {
            result = await reportRepository.GetChiPhiAsync(model.KhachSanId.Value, model.ToDate.Value);
        }

        if (model.FromDate != null && model.ToDate != null)
        {
            result = await reportRepository.GetChiPhiAsync(model.KhachSanId.Value, model.FromDate.Value, model.ToDate.Value);
        }

        return Results.Ok(ApiResponse.Success(mapper.Map<List<ChiPhiDto>>(result)));
    }

    private static async Task<IResult> GetDoanhThu([AsParameters] ReportFilterModel model, IReportRepository reportRepository, IMapper mapper)
    {
        if (model.KhachSanId == null)
        {
            return Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy khách sạn nào!"));
        }

        if (model.Date == null && model.FromDate == null && model.ToDate == null)
        {
            return Results.Ok(ApiResponse.Fail(HttpStatusCode.BadRequest, $"Thông tin không hợp lệ!"));
        }

        IList<DoanhThu> result = null;
        if (model.Date != null)
        {
            result = await reportRepository.GetDoanhThuAsync(model.KhachSanId.Value, model.Date.Value);
        }

        if (model.FromDate != null && model.ToDate == null)
        {
            result = await reportRepository.GetDoanhThuAsync(model.KhachSanId.Value, model.FromDate.Value);
        }

        if (model.FromDate == null && model.ToDate != null)
        {
            result = await reportRepository.GetDoanhThuAsync(model.KhachSanId.Value, model.ToDate.Value);
        }

        if (model.FromDate != null && model.ToDate != null)
        {
            result = await reportRepository.GetDoanhThuAsync(model.KhachSanId.Value, model.FromDate.Value, model.ToDate.Value);
        }

        return Results.Ok(ApiResponse.Success(mapper.Map<List<DoanhThuDto>>(result)));
    }

    private static async Task<IResult> GetKhachSan(IReportRepository reportRepository, IMapper mapper)
    {
        var result = await reportRepository.GetAllKhachSanAsync();

        return Results.Ok(ApiResponse.Success(mapper.Map<List<KhachSanDto>>(result)));
    }

    private static async Task<IResult> GetKhachSanById(int id, IReportRepository reportRepository, IMapper mapper)
    {
        var result = await reportRepository.GetCacheKhachSanByIdAsync(id);

        return Results.Ok(ApiResponse.Success(mapper.Map<KhachSanDto>(result)));
    }
}
