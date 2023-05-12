using Bogus;
using BussinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace BussinessLayer.MethodObjects
{
    public class SeedData : SqlDataProvider
    {
        private readonly DBAccess.QLKS_System _dbContext;

        public SeedData()
        {
            _dbContext = GetContext();
        }

        public async Task Initialize()
        {
            //_dbContext.Database.Create();

            //if (_dbContext.DoanhThus.AsQueryable().Any()) return;

            var ks = _dbContext.KhachSans.AsQueryable().Any() ? _dbContext.KhachSans.AsQueryable().ToList() : await AddKs();
            var doanhthu = _dbContext.DoanhThus.AsQueryable().Any() ? _dbContext.DoanhThus.AsQueryable().ToList() : await AddDoanhThu(ks);
            var chiphi = _dbContext.ChiPhis.AsQueryable().Any() ? _dbContext.ChiPhis.AsQueryable().ToList() : await AddChiPhi(ks);
            var hdKhachHang = _dbContext.HDKhachHangs.AsQueryable().Any() ? _dbContext.HDKhachHangs.AsQueryable().ToList() : await AddHDKhachHang();
            var hdNhanVien = _dbContext.HDNhanViens.AsQueryable().Any() ? _dbContext.HDNhanViens.AsQueryable().ToList() : await AddHDNhanVien();
            var hdPhong = _dbContext.HDPhongs.AsQueryable().Any() ? _dbContext.HDPhongs.AsQueryable().ToList() : await AddHDPhong();
            var hdDanhGia = _dbContext.HDDanhGias.AsQueryable().Any() ? _dbContext.HDDanhGias.AsQueryable().ToList() : await AddHDDanhGIa();
            var hd = _dbContext.HoatDongs.AsQueryable().Any() ? _dbContext.HoatDongs.AsQueryable().ToList() : await AddHoatDong(ks, hdKhachHang, hdNhanVien, hdPhong, hdDanhGia);
        }

        private async Task<List<HoatDong>> AddHoatDong(List<KhachSan> ks, List<HDKhachHang> hdKhachHang, List<HDNhanVien> hdNhanVien, List<HDPhong> hdPhong, List<HDDanhGia> hdDanhGia)
        {
            var fakeKs = new Faker<HoatDong>("vi");
            fakeKs.RuleFor(u => u.KhachSan, f => f.PickRandom(ks));
            fakeKs.RuleFor(u => u.HDKhachHang, f => f.PickRandom(hdKhachHang));
            fakeKs.RuleFor(u => u.HDPhong, f => f.PickRandom(hdPhong));
            fakeKs.RuleFor(u => u.HDNhanVien, f => f.PickRandom(hdNhanVien));
            fakeKs.RuleFor(u => u.HDDanhGia, f => f.PickRandom(hdDanhGia));

            var hd = fakeKs.Generate(1000);

            _dbContext.HoatDongs.AddRange(hd);
            await _dbContext.SaveChangesAsync();

            return hd;
        }

        private async Task<List<HDDanhGia>> AddHDDanhGIa()
        {
            var fakeKs = new Faker<HDDanhGia>("vi");
            fakeKs.RuleFor(u => u.ChatLuongKhachSan, f => f.Random.Byte(1, 10));
            fakeKs.RuleFor(u => u.ChatLuongDichVu, f => f.Random.Byte(1, 10));
            fakeKs.RuleFor(u => u.ThoiGianTao, f => f.Date.Between(new DateTime(2023, 1, 10), new DateTime(2023, 6, 30)));

            var hdDanhGia = fakeKs.Generate(100);

            _dbContext.HDDanhGias.AddRange(hdDanhGia);
            await _dbContext.SaveChangesAsync();

            return hdDanhGia;
        }

        private async Task<List<HDPhong>> AddHDPhong()
        {
            var fakeKs = new Faker<HDPhong>("vi");
            fakeKs.RuleFor(u => u.SoLuong, f => f.Random.Int(1, 100));
            fakeKs.RuleFor(u => u.TyLeDatPhong, f => f.Random.Int(1, 10));
            fakeKs.RuleFor(u => u.TyLePhongTrong, f => f.Random.Int(1, 10));
            fakeKs.RuleFor(u => u.ThoiGianTao, f => f.Date.Between(new DateTime(2023, 1, 10), new DateTime(2023, 6, 30)));

            var hdPhong = fakeKs.Generate(100);

            _dbContext.HDPhongs.AddRange(hdPhong);
            await _dbContext.SaveChangesAsync();

            return hdPhong;
        }

        private async Task<List<HDNhanVien>> AddHDNhanVien()
        {
            var fakeKs = new Faker<HDNhanVien>("vi");
            fakeKs.RuleFor(u => u.HSLamViec, f => f.Random.Int(1, 100));
            fakeKs.RuleFor(u => u.SoNgayNghi, f => f.Random.Int(1, 10));
            fakeKs.RuleFor(u => u.PhuCap, f => f.Random.Int(250000, 550000));
            fakeKs.RuleFor(u => u.LuongThuong, f => f.Random.Int(2500000, 5500000));
            fakeKs.RuleFor(u => u.ThoiGianTao, f => f.Date.Between(new DateTime(2023, 1, 10), new DateTime(2023, 6, 30)));

            var hdNhanVien = fakeKs.Generate(100);

            _dbContext.HDNhanViens.AddRange(hdNhanVien);
            await _dbContext.SaveChangesAsync();

            return hdNhanVien;
        }

        private async Task<List<HDKhachHang>> AddHDKhachHang()
        {
            var fakeKs = new Faker<HDKhachHang>("vi");
            fakeKs.RuleFor(u => u.TyLeKhachHangDen, f => f.Random.Int(1, 100));
            fakeKs.RuleFor(u => u.TyLeKhachHangDi, f => f.Random.Int(1, 100));
            fakeKs.RuleFor(u => u.TyLeHuyPhong, f => f.Random.Int(1, 100));
            fakeKs.RuleFor(u => u.ThoiGianTao, f => f.Date.Between(new DateTime(2023, 1, 10), new DateTime(2023, 6, 30)));

            var hdKhachHang = fakeKs.Generate(100);

            _dbContext.HDKhachHangs.AddRange(hdKhachHang);
            await _dbContext.SaveChangesAsync();

            return hdKhachHang;
        }

        private async Task<List<ChiPhi>> AddChiPhi(List<KhachSan> ks)
        {
            var fakeKs = new Faker<ChiPhi>("vi");
            fakeKs.RuleFor(u => u.TenChiPhi, f => f.Name.FullName());
            fakeKs.RuleFor(u => u.TongChiPhi, f => f.Random.Int(1700000, 3000000));
            fakeKs.RuleFor(u => u.ChiPhiVao, f => f.Random.Int(1700000, 3000000));
            fakeKs.RuleFor(u => u.ChiPhiRa, f => f.Random.Int(1700000, 3000000));
            fakeKs.RuleFor(u => u.KhachSan, f => f.PickRandom(ks));
            fakeKs.RuleFor(u => u.MucDich, f => f.Lorem.Paragraph());
            fakeKs.RuleFor(u => u.MoTa, f => f.Lorem.Paragraphs(3));
            fakeKs.RuleFor(u => u.MoTa, f => f.Lorem.Paragraphs(3));
            fakeKs.RuleFor(u => u.ThoiGianTao, f => f.Date.Between(new DateTime(2023, 1, 10), new DateTime(2023, 6, 30)));

            var chiphi = fakeKs.Generate(100);

            _dbContext.ChiPhis.AddRange(chiphi);
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

            var doanhthu = fakeKs.Generate(100);

            _dbContext.DoanhThus.AddRange(doanhthu);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return doanhthu;
        }

        private async Task<List<KhachSan>> AddKs()
        {
            var fakeKs = new Faker<KhachSan>("vi");
            fakeKs.RuleFor(u => u.TenKhachSan, f => f.Name.FullName());
            fakeKs.RuleFor(u => u.DiaChi, f => f.Address.FullAddress());

            var ks = fakeKs.Generate(1);

            _dbContext.KhachSans.AddRange(ks);
            await _dbContext.SaveChangesAsync();

            return ks;
        }
    }
}
