namespace AutoStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAP")]
    public partial class PHIEUNHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUNHAP()
        {
            CHITIETPHIEUNHAPs = new HashSet<CHITIETPHIEUNHAP>();
        }

        [Key]
        [StringLength(10)]
        public string MAPN { get; set; }

        [StringLength(50)]
        public string TENPN { get; set; }

        [Required]
        [StringLength(10)]
        public string MANV { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? NGAYNHAP { get; set; }

        [Required]
        [StringLength(10)]
        public string MANCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
