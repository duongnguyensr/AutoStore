namespace AutoStore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBConnection : DbContext
    {
        public DBConnection()
            : base("name=DBConnection")
        {
        }

        public virtual DbSet<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }
        public virtual DbSet<CHITIETPHIEUXUAT> CHITIETPHIEUXUATs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAISANPHAM> LOAISANPHAMs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHASANXUAT> NHASANXUATs { get; set; }
        public virtual DbSet<PHIEUNHAP> PHIEUNHAPs { get; set; }
        public virtual DbSet<PHIEUXUAT> PHIEUXUATs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<GIOHANG> GIOHANGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETPHIEUNHAP>()
                .Property(e => e.MAPN)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETPHIEUNHAP>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETPHIEUXUAT>()
                .Property(e => e.MAPX)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETPHIEUXUAT>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.PHIEUXUATs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAISANPHAM>()
                .Property(e => e.MALOAI)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MANCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.DIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.PHIEUNHAPs)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.DIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUNHAPs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUXUATs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHASANXUAT>()
                .Property(e => e.MANSX)
                .IsUnicode(false);

            modelBuilder.Entity<NHASANXUAT>()
                .Property(e => e.DIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.MAPN)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.MANCC)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .HasMany(e => e.CHITIETPHIEUNHAPs)
                .WithRequired(e => e.PHIEUNHAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .Property(e => e.MAPX)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .HasMany(e => e.CHITIETPHIEUXUATs)
                .WithRequired(e => e.PHIEUXUAT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MANSX)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MALOAI)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MOTA)
                .IsFixedLength();

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETPHIEUNHAPs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETPHIEUXUATs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIOHANG>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<GIOHANG>()
                .Property(e => e.MAKH)
                .IsUnicode(false);
        }
    }
}
