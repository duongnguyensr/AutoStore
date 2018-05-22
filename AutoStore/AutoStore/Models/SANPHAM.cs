namespace AutoStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETPHIEUNHAPs = new HashSet<CHITIETPHIEUNHAP>();
            CHITIETPHIEUXUATs = new HashSet<CHITIETPHIEUXUAT>();
        }

        [Key]
        [StringLength(10)]
        public string MASP { get; set; }

        [StringLength(50)]
        public string TENSP { get; set; }

        [StringLength(10)]
        public string MANSX { get; set; }

        [StringLength(50)]
        public string MAUSAC { get; set; }

        [StringLength(10)]
        public string MALOAI { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(500)]
        public string MOTA { get; set; }

        [StringLength(1000)]
        public string HINHANH { get; set; }

        public double? DONGIA { get; set; }

        public int? SOLUONG { get; set; }

        public int? YEAR { get; set; }

        public int? KM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUXUAT> CHITIETPHIEUXUATs { get; set; }

        public virtual LOAISANPHAM LOAISANPHAM { get; set; }

        public virtual NHASANXUAT NHASANXUAT { get; set; }
    }
}
