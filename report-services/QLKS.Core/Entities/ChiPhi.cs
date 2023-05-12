using QLKS.Core.Contracts;

namespace QLKS.Core.Entities;

public partial class ChiPhi : IEntity<int>
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

    public virtual KhachSan KhachSan { get; set; }
}
