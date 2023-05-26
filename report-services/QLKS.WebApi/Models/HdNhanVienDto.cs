namespace QLKS.WebApi.Models;

public class HdNhanVienDto
{
    public int Id { get; set; }

    public int KhachSanId { get; set; }

    public double HslamViec { get; set; }

    public int SoNgayNghi { get; set; }

    public float PhuCap { get; set; }

    public float LuongThuong { get; set; }

    public DateTime ThoiGianTao { get; set; }

    public virtual KhachSanDto KhachSan { get; set; }
}
