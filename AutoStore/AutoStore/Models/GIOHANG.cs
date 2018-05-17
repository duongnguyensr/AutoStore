namespace AutoStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIOHANG")]
    public partial class GIOHANG
    {
        [Key]
        [StringLength(10)]
        public string CODE { get; set; }


        [StringLength(10)]
        public string MASP { get; set; }

        
        [StringLength(10)]
        public string MAKH { get; set; }

        public Int32 SOLUONG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
