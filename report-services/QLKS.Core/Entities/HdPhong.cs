using QLKS.Core.Contracts;

namespace QLKS.Core.Entities;

public partial class HdPhong : IEntity<int>
{
    public int Id { get; set; }

    public int KhachSanId { get; set; }

    public int SoLuong { get; set; }

    public double TyLeDatPhong { get; set; }

    public double TyLePhongTrong { get; set; }

    public DateTime ThoiGianTao { get; set; }

    public virtual KhachSan KhachSan { get; set; }
}
