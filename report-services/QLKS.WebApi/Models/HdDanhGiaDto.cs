namespace QLKS.WebApi.Models;

public class HdDanhGiaDto
{
    public int Id { get; set; }

    public int KhachSanId { get; set; }

    public byte ChatLuongDichVu { get; set; }

    public byte ChatLuongKhachSan { get; set; }

    public DateTime ThoiGianTao { get; set; }

    public virtual KhachSanDto KhachSan { get; set; }
}
