using QLKS.Core.Contracts;

namespace QLKS.Core.Entities;

public partial class HdDanhGia : IEntity<int>
{
    public int Id { get; set; }

    public int KhachSanId { get; set; }

    public byte ChatLuongDichVu { get; set; }

    public byte ChatLuongKhachSan { get; set; }

    public DateTime ThoiGianTao { get; set; }

    public virtual KhachSan KhachSan { get; set; }
}
