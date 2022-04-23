insert into TM_USER( USERNAME, PASSWORD, NAME, LASTNAME, BIRTH,PHONE, EMAIL) values('jlopez', '12345','Jesús','López','1996-06-18', '994423347','jlopez@envios.pe'); 
go

insert into TM_USER(USERNAME, PASSWORD, NAME, LASTNAME, BIRTH,PHONE, EMAIL) values('jperez','987654','Juan','Pérez','1985-07-23', '987654321','jperez@envios.pe'); 
go



insert into TM_ENVIO (COD_ORDEN, IDUSER, SRC_ADD, DEST_ADD, PRICE, WEIGHT) 
values ('COD-0001',1,'Santa Anita','Miraflores', 50, 2); 
go

insert into TM_ENVIO(COD_ORDEN, IDUSER, SRC_ADD, DEST_ADD, PRICE, WEIGHT, PAQUETE) values('C-0002',1,'San Luis','La Victoria', 30, 2,'Lapiceros'); 
go

insert into TM_ENVIO(COD_ORDEN, IDUSER, SRC_ADD, DEST_ADD, PRICE, WEIGHT, PAQUETE) values('C-0003',2,'VMT','Comas', 90, 14,'Cuadernos'); 
go