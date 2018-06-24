alter trigger chitietpx on phieuxuat for insert
as begin
declare @makh varchar(10),@mapx varchar(10)
select @makh=MAKH,@mapx=MAPX from inserted
insert into CHITIETPHIEUXUAT(MAPX,MASP,SOLUONG,DONGIAXUAT)
select MAPX,GIOHANG.MASP,giohang.SOLUONG,DONGIA from inserted,GIOHANG,SANPHAM WHERE GIOHANG.MAKH=@makh and GIOHANG.MASP=SANPHAM.MASP

DELETE FROM GIOHANG
WHERE MAKH=@makh

end