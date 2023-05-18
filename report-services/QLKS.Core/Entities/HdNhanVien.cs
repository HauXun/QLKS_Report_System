using QLKS.Core.Contracts;

namespace QLKS.Core.Entities;

public partial class HdNhanVien : IEntity<int>
{
    public int Id { get; set; }

    public int KhachSanId { get; set; }

    public double HslamViec { get; set; }

    public int SoNgayNghi { get; set; }

    public float PhuCap { get; set; }

    public float LuongThuong { get; set; }

    public DateTime ThoiGianTao { get; set; }

    public virtual KhachSan KhachSan { get; set; }
}
