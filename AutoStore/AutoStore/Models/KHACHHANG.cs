namespace AutoStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            PHIEUXUATs = new HashSet<PHIEUXUAT>();
        }

        [Key]
        [StringLength(10)]
        public string MAKH { get; set; }

        [StringLength(50)]
        public string TENKH { get; set; }

        [StringLength(50)]
        public string DIACHI { get; set; }

        [StringLength(20)]
        public string DIENTHOAI { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string USERNAME { get; set; }

        [StringLength(50)]
        public string PASSWORD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXUAT> PHIEUXUATs { get; set; }
    }
}
