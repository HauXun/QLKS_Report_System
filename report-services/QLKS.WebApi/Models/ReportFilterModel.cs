using System.ComponentModel;

namespace QLKS.WebApi.Models;

public class ReportFilterModel : PagingModel
{
    [DisplayName("Từ khoá")]
    public string Keyword { get; set; }
    [DisplayName("Khách sạn")]
    public int? KhachSanId { get; set; }
    [DisplayName("Thời gian")]
    public DateTime? Date { get; set; }
    [DisplayName("Từ")]
    public DateTime? FromDate { get; set; }
    [DisplayName("Tới")]
    public DateTime? ToDate { get; set; }
}
