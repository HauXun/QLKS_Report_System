namespace QLKS.WebApi.Models;

public class ChiPhiDto
{
    public int Id { get; set; }

    public int KhachSanId { get; set; }

    public string TenChiPhi { get; set; }

    public float TongChiPhi { get; set; }

    public float ChiPhiVao { get; set; }

    public float ChiPhiRa { get; set; }

    public string MucDich { get; set; }

    public string MoTa { get; set; }

    public string GhiChu { get; set; }

    public DateTime ThoiGianTao { get; set; }

    public virtual KhachSanDto KhachSan { get; set; }
}
