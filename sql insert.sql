
/*/////////////////////////// REGISTRO DE USUARIOS /////////////////////// */

insert into TM_USER( USERNAME, PASSWORD, NAME, LASTNAME, BIRTH,PHONE, EMAIL) values('jlopez', '12345','Jesús','López','1996-06-18', '994423347','jlopez@envios.pe'); 
go

insert into TM_USER(USERNAME, PASSWORD, NAME, LASTNAME, BIRTH,PHONE, EMAIL) values('jperez','987654','Juan','Pérez','1985-07-23', '987654321','jperez@envios.pe'); 
go

insert into TM_USER(USERNAME, PASSWORD, NAME, LASTNAME, BIRTH,PHONE, EMAIL) values('mescobar','147852','Martin','Escobar','1998-02-23', '947856321','mescobar@envios.pe'); 
go

insert into TM_USER(USERNAME, PASSWORD, NAME, LASTNAME, BIRTH,PHONE, EMAIL) values('druiz','abcdef','Daniel','Ruiz','1970-02-23', '947856541','druiz@envios.pe'); 
go

insert into TM_USER(USERNAME, PASSWORD, NAME, LASTNAME, BIRTH,PHONE, EMAIL) values('cquispe','abcdef','Christian','Quispe','1995-02-23', '94754623','cquispe@envios.pe'); 
go

insert into TM_USER(USERNAME, PASSWORD, NAME, LASTNAME, BIRTH,PHONE, EMAIL) values('mcarrasco','Server001','Soledad','Carrasco','1996-05-13', '947986231','mcarrasco@envios.pe'); 
go


/*/////////////////////// REGISTRO DE ENVIOS //////////////////////// */

insert into TM_ENVIO (COD_ORDEN, IDUSER, SRC_ADD, DEST_ADD, PRICE, WEIGHT, PAQUETE, ESTADO) 
values ('C-0001',1,'Santa Anita','Miraflores', 50, 2,'Documentos',1); 
go

insert into TM_ENVIO(COD_ORDEN, IDUSER, SRC_ADD, DEST_ADD, PRICE, WEIGHT, PAQUETE, ESTADO) values('C-0002',1,'San Luis','La Victoria', 30, 2,'Lapiceros',4); 
go

insert into TM_ENVIO(COD_ORDEN, IDUSER, SRC_ADD, DEST_ADD, PRICE, WEIGHT, PAQUETE, ESTADO) values('C-0003',2,'VMT','Comas', 90, 14,'Cuadernos',5); 
go

insert into TM_ENVIO(COD_ORDEN, IDUSER, SRC_ADD, DEST_ADD, PRICE, WEIGHT, PAQUETE, ESTADO) values('C-0004',6,'Lince','Miraflores', 50, 20,'Papeles',4); 
go

insert into TM_ENVIO(COD_ORDEN, IDUSER, SRC_ADD, DEST_ADD, PRICE, WEIGHT, PAQUETE, ESTADO) values('C-0005',3,'Ate','Surco', 100, 15,'Laptop',2); 
go

insert into TM_ENVIO(COD_ORDEN, IDUSER, SRC_ADD, DEST_ADD, PRICE, WEIGHT, PAQUETE, ESTADO) values('C-0006',5,'Surquillo','Lurin', 54, 23,'Folders',5); 
go

/*//////////////////// ESTADOS DE ENVIO //////////////////////////////// */

insert into ESTADO_ENVIO (NOMBRE_ESTADO, DESC_ESTADO) 
values ('Registrado','Se recibió solicitud de envio');
go

insert into ESTADO_ENVIO (NOMBRE_ESTADO, DESC_ESTADO) 
values ('Confirmado','Se confirma la solicitud');
go

insert into ESTADO_ENVIO (NOMBRE_ESTADO, DESC_ESTADO) 
values ('Recogido','Se recogió el paquete del solicitante');
go

insert into ESTADO_ENVIO (NOMBRE_ESTADO, DESC_ESTADO) 
values ('En camino','El envio se encuentra en camino al destino');
go

insert into ESTADO_ENVIO (NOMBRE_ESTADO, DESC_ESTADO) 
values ('Entregado','Se entregó el pedido al destinatario');
go

insert into ESTADO_ENVIO (NOMBRE_ESTADO, DESC_ESTADO) 
values ('Cancelado','Envio cancelado');
go