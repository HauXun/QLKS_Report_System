//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BussinessLayer.DBAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class HDNhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HDNhanVien()
        {
            this.HoatDongs = new HashSet<HoatDong>();
        }
    
        public int Id { get; set; }
        public Nullable<double> HSLamViec { get; set; }
        public Nullable<int> SoNgayNghi { get; set; }
        public Nullable<float> PhuCap { get; set; }
        public Nullable<float> LuongThuong { get; set; }
        public Nullable<System.DateTime> ThoiGianTao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoatDong> HoatDongs { get; set; }
    }
}
