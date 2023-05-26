using QLKS.Core.Contracts;

namespace QLKS.Core.Entities;

public partial class DoanhThu : IEntity<int>
{
    public int Id { get; set; }

    public int KhachSanId { get; set; }

    public string TenDoanhThu { get; set; }

    public float TongDoanhThu { get; set; }

    public string MoTa { get; set; }

    public DateTime ThoiGianTao { get; set; }

    public virtual KhachSan KhachSan { get; set; }
}
