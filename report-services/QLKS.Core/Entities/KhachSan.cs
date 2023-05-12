using QLKS.Core.Contracts;

namespace QLKS.Core.Entities;

public partial class KhachSan : IEntity<int>
{
    public int Id { get; set; }

    public string TenKhachSan { get; set; }

    public string DiaChi { get; set; }

    public virtual ICollection<ChiPhi> ChiPhi { get; set; } = new List<ChiPhi>();

    public virtual ICollection<DoanhThu> DoanhThu { get; set; } = new List<DoanhThu>();

    public virtual ICollection<HdDanhGia> HdDanhGia { get; set; } = new List<HdDanhGia>();

    public virtual ICollection<HdKhachHang> HdKhachHang { get; set; } = new List<HdKhachHang>();

    public virtual ICollection<HdNhanVien> HdNhanVien { get; set; } = new List<HdNhanVien>();

    public virtual ICollection<HdPhong> HdPhong { get; set; } = new List<HdPhong>();
}
