using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLKS.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachSan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhachSan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachSan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiPhi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachSanId = table.Column<int>(type: "int", nullable: false),
                    TenChiPhi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongChiPhi = table.Column<float>(type: "real", nullable: false),
                    ChiPhiVao = table.Column<float>(type: "real", nullable: false),
                    ChiPhiRa = table.Column<float>(type: "real", nullable: false),
                    MucDich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiPhi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiPhi_KhachSan_KhachSanId",
                        column: x => x.KhachSanId,
                        principalTable: "KhachSan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoanhThu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachSanId = table.Column<int>(type: "int", nullable: false),
                    TenDoanhThu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongDoanhThu = table.Column<float>(type: "real", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhThu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoanhThu_KhachSan_KhachSanId",
                        column: x => x.KhachSanId,
                        principalTable: "KhachSan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HddanhGia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachSanId = table.Column<int>(type: "int", nullable: false),
                    ChatLuongDichVu = table.Column<byte>(type: "tinyint", nullable: false),
                    ChatLuongKhachSan = table.Column<byte>(type: "tinyint", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HddanhGia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HddanhGia_KhachSan_KhachSanId",
                        column: x => x.KhachSanId,
                        principalTable: "KhachSan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HdkhachHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachSanId = table.Column<int>(type: "int", nullable: false),
                    TyLeKhachHangDi = table.Column<double>(type: "float", nullable: false),
                    TyLeKhachHangDen = table.Column<double>(type: "float", nullable: false),
                    TyLeHuyPhong = table.Column<double>(type: "float", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HdkhachHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HdkhachHang_KhachSan_KhachSanId",
                        column: x => x.KhachSanId,
                        principalTable: "KhachSan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HdnhanVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachSanId = table.Column<int>(type: "int", nullable: false),
                    HslamViec = table.Column<double>(type: "float", nullable: false),
                    SoNgayNghi = table.Column<int>(type: "int", nullable: false),
                    PhuCap = table.Column<float>(type: "real", nullable: false),
                    LuongThuong = table.Column<float>(type: "real", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HdnhanVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HdnhanVien_KhachSan_KhachSanId",
                        column: x => x.KhachSanId,
                        principalTable: "KhachSan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HdPhong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachSanId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TyLeDatPhong = table.Column<double>(type: "float", nullable: false),
                    TyLePhongTrong = table.Column<double>(type: "float", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HdPhong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HdPhong_KhachSan_KhachSanId",
                        column: x => x.KhachSanId,
                        principalTable: "KhachSan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiPhi_KhachSanId",
                table: "ChiPhi",
                column: "KhachSanId");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhThu_KhachSanId",
                table: "DoanhThu",
                column: "KhachSanId");

            migrationBuilder.CreateIndex(
                name: "IX_HddanhGia_KhachSanId",
                table: "HddanhGia",
                column: "KhachSanId");

            migrationBuilder.CreateIndex(
                name: "IX_HdkhachHang_KhachSanId",
                table: "HdkhachHang",
                column: "KhachSanId");

            migrationBuilder.CreateIndex(
                name: "IX_HdnhanVien_KhachSanId",
                table: "HdnhanVien",
                column: "KhachSanId");

            migrationBuilder.CreateIndex(
                name: "IX_HdPhong_KhachSanId",
                table: "HdPhong",
                column: "KhachSanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiPhi");

            migrationBuilder.DropTable(
                name: "DoanhThu");

            migrationBuilder.DropTable(
                name: "HddanhGia");

            migrationBuilder.DropTable(
                name: "HdkhachHang");

            migrationBuilder.DropTable(
                name: "HdnhanVien");

            migrationBuilder.DropTable(
                name: "HdPhong");

            migrationBuilder.DropTable(
                name: "KhachSan");
        }
    }
}
