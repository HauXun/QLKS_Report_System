namespace QLKS.WebApi.Models;

public class HdPhongDto
{
    public int Id { get; set; }

    public int KhachSanId { get; set; }

    public int SoLuong { get; set; }

    public double TyLeDatPhong { get; set; }

    public double TyLePhongTrong { get; set; }

    public DateTime ThoiGianTao { get; set; }

    public virtual KhachSanDto KhachSan { get; set; }
}
