namespace QLKS.WebApi.Models;

public class DoanhThuDto
{
    public int Id { get; set; }

    public int KhachSanId { get; set; }

    public string TenDoanhThu { get; set; }

    public float TongDoanhThu { get; set; }

    public string MoTa { get; set; }

    public DateTime ThoiGianTao { get; set; }

    public virtual KhachSanDto KhachSan { get; set; }
}
