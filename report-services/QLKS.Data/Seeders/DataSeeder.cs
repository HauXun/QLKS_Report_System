using Bogus;
using QLKS.Core.Entities;
using QLKS.Data.Contextp;

namespace QLKS.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly ReportDbContext _dbContext;

        public DataSeeder(ReportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.KhachSan.Any()) return;

            Randomizer.Seed = new Random(8675309);
            RandomSeedData().GetAwaiter().GetResult();
        }
        private async Task RandomSeedData()
        {
            var ks = _dbContext.KhachSan.Any() ? _dbContext.KhachSan.ToList() : await AddKs();
            var doanhthu = _dbContext.DoanhThu.Any() ? _dbContext.DoanhThu.ToList() : await AddDoanhThu(ks);
            var chiphi = _dbContext.ChiPhi.Any() ? _dbContext.ChiPhi.ToList() : await AddChiPhi(ks);
            var hdKhachHang = _dbContext.HdKhachHang.Any() ? _dbContext.HdKhachHang.ToList() : await AddHdKhachHang(ks);
            var hdNhanVien = _dbContext.HdNhanVien.Any() ? _dbContext.HdNhanVien.ToList() : await AddHdNhanVien(ks);
            var hdPhong = _dbContext.HdPhong.Any() ? _dbContext.HdPhong.ToList() : await AddHdPhong(ks);
            var hdDanhGia = _dbContext.HdDanhGia.Any() ? _dbContext.HdDanhGia.ToList() : await AddHDDanhGIa(ks);
        }

        private async Task<List<HdDanhGia>> AddHDDanhGIa(List<KhachSan> ks)
        {
            var fakeKs = new Faker<HdDanhGia>("vi");
            fakeKs.RuleFor(u => u.ChatLuongKhachSan, f => f.Random.Byte(1, 10));
            fakeKs.RuleFor(u => u.ChatLuongDichVu, f => f.Random.Byte(1, 10));
            fakeKs.RuleFor(u => u.KhachSan, f => f.PickRandom(ks));
            fakeKs.RuleFor(u => u.ThoiGianTao, f => f.Date.Between(new DateTime(2023, 1, 10), new DateTime(2023, 6, 30)));

            var hdDanhGia = fakeKs.Generate(500);

            _dbContext.HdDanhGia.AddRange(hdDanhGia);
            await _dbContext.SaveChangesAsync();

            return hdDanhGia;
        }

        private async Task<List<HdPhong>> AddHdPhong(List<KhachSan> ks)
        {
            var fakeKs = new Faker<HdPhong>("vi");
            fakeKs.RuleFor(u => u.SoLuong, f => f.Random.Int(1, 100));
            fakeKs.RuleFor(u => u.TyLeDatPhong, f => f.Random.Int(1, 10));
            fakeKs.RuleFor(u => u.TyLePhongTrong, f => f.Random.Int(1, 10));
            fakeKs.RuleFor(u => u.KhachSan, f => f.PickRandom(ks));
            fakeKs.RuleFor(u => u.ThoiGianTao, f => f.Date.Between(new DateTime(2023, 1, 10), new DateTime(2023, 6, 30)));

            var hdPhong = fakeKs.Generate(500);

            _dbContext.HdPhong.AddRange(hdPhong);
            await _dbContext.SaveChangesAsync();

            return hdPhong;
        }

        private async Task<List<HdNhanVien>> AddHdNhanVien(List<KhachSan> ks)
        {
            var fakeKs = new Faker<HdNhanVien>("vi");
            fakeKs.RuleFor(u => u.HslamViec, f => f.Random.Int(1, 100));
            fakeKs.RuleFor(u => u.SoNgayNghi, f => f.Random.Int(1, 10));
            fakeKs.RuleFor(u => u.PhuCap, f => f.Random.Int(250000, 550000));
            fakeKs.RuleFor(u => u.LuongThuong, f => f.Random.Int(2500000, 5500000));
            fakeKs.RuleFor(u => u.KhachSan, f => f.PickRandom(ks));
            fakeKs.RuleFor(u => u.ThoiGianTao, f => f.Date.Between(new DateTime(2023, 1, 10), new DateTime(2023, 6, 30)));

            var hdNhanVien = fakeKs.Generate(500);

            _dbContext.HdNhanVien.AddRange(hdNhanVien);
            await _dbContext.SaveChangesAsync();

            return hdNhanVien;
        }

        private async Task<List<HdKhachHang>> AddHdKhachHang(List<KhachSan> ks)
        {
            var fakeKs = new Faker<HdKhachHang>("vi");
            fakeKs.RuleFor(u => u.TyLeKhachHangDen, f => f.Random.Int(1, 100));
            fakeKs.RuleFor(u => u.TyLeKhachHangDi, f => f.Random.Int(1, 100));
            fakeKs.RuleFor(u => u.TyLeHuyPhong, f => f.Random.Int(1, 100));
            fakeKs.RuleFor(u => u.KhachSan, f => f.PickRandom(ks));
            fakeKs.RuleFor(u => u.ThoiGianTao, f => f.Date.Between(new DateTime(2023, 1, 10), new DateTime(2023, 6, 30)));

            var hdKhachHang = fakeKs.Generate(500);

            _dbContext.HdKhachHang.AddRange(hdKhachHang);
            await _dbContext.SaveChangesAsync();

            return hdKhachHang;
        }

        private async Task<List<ChiPhi>> AddChiPhi(List<KhachSan> ks)
        {
            var fakeKs = new Faker<ChiPhi>("vi");
            fakeKs.RuleFor(u => u.TenChiPhi, f => f.Name.FullName());
            fakeKs.RuleFor(u => u.KhachSan, f => f.PickRandom(ks));
            fakeKs.RuleFor(u => u.MucDich, f => f.Lorem.Paragraph());
            fakeKs.RuleFor(u => u.MoTa, f => f.Lorem.Paragraphs(3));
            fakeKs.RuleFor(u => u.GhiChu, f => f.Lorem.Paragraphs(3));
            fakeKs.RuleFor(u => u.KhachSan, f => f.PickRandom(ks));
            fakeKs.RuleFor(u => u.ThoiGianTao, f => f.Date.Between(new DateTime(2023, 1, 10), new DateTime(2023, 6, 30)));
            fakeKs.Rules((f, r) =>
            {
                var chiPhiVao = f.Random.Int(1700000, 3000000);
                var chiPhiRa = f.Random.Int(1700000, 3000000);

                r.ChiPhiVao = chiPhiVao;
                r.ChiPhiRa = chiPhiRa;
                r.TongChiPhi = chiPhiVao + chiPhiRa;
            });

            var chiphi = fakeKs.Generate(100);

            _dbContext.ChiPhi.AddRange(chiphi);
            await _dbContext.SaveChangesAsync();

            return chiphi;
        }

        private async Task<List<DoanhThu>> AddDoanhThu(List<KhachSan> ks)
        {
            var fakeKs = new Faker<DoanhThu>("vi");
            fakeKs.RuleFor(u => u.TenDoanhThu, f => f.Name.FullName());
            fakeKs.RuleFor(u => u.TongDoanhThu, f => f.Random.Int(1700000, 3000000));
            fakeKs.RuleFor(u => u.KhachSan, f => f.PickRandom(ks));
            fakeKs.RuleFor(u => u.MoTa, f => f.Lorem.Paragraphs(3));
            fakeKs.RuleFor(u => u.ThoiGianTao, f => f.Date.Between(new DateTime(2023, 1, 10), new DateTime(2023, 6, 30)));

            var doanhthu = fakeKs.Generate(500);

            _dbContext.DoanhThu.AddRange(doanhthu);
            await _dbContext.SaveChangesAsync();

            return doanhthu;
        }

        private async Task<List<KhachSan>> AddKs()
        {
            var fakeKs = new Faker<KhachSan>("vi");
            fakeKs.RuleFor(u => u.TenKhachSan, f => f.Name.FullName());
            fakeKs.RuleFor(u => u.DiaChi, f => f.Address.FullAddress());

            var ks = fakeKs.Generate(5);

            _dbContext.KhachSan.AddRange(ks);
            await _dbContext.SaveChangesAsync();

            return ks;
        }
    }
}
