using QLKS.Core.Contracts;

namespace QLKS.Core.Entities;

public partial class HdKhachHang : IEntity<int>
{
    public int Id { get; set; }

    public int KhachSanId { get; set; }

    public double TyLeKhachHangDi { get; set; }

    public double TyLeKhachHangDen { get; set; }

    public double TyLeHuyPhong { get; set; }

    public DateTime ThoiGianTao { get; set; }

    public virtual KhachSan KhachSan { get; set; }
}
