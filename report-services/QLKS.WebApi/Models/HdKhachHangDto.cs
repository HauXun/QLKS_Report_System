namespace QLKS.WebApi.Models;

public class HdKhachHangDto
{
    public int Id { get; set; }

    public int KhachSanId { get; set; }

    public double TyLeKhachHangDi { get; set; }

    public double TyLeKhachHangDen { get; set; }

    public double TyLeHuyPhong { get; set; }

    public DateTime ThoiGianTao { get; set; }

    public virtual KhachSanDto KhachSan { get; set; }
}
