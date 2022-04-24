
//////////////////////////// REGISTRO DE USUARIOS ////////////////////////

insert into TM_USER( USERNAME, PASSWORD, NAME, LASTNAME, BIRTH,PHONE, EMAIL) values('jlopez', '12345','Jesús','López','1996-06-18', '994423347','jlopez@envios.pe'); 
go

insert into TM_USER(USERNAME, PASSWORD, NAME, LASTNAME, BIRTH,PHONE, EMAIL) values('jperez','987654','Juan','Pérez','1985-07-23', '987654321','jperez@envios.pe'); 
go


//////////////////////// REGISTRO DE ENVIOS /////////////////////////

insert into TM_ENVIO (COD_ORDEN, IDUSER, SRC_ADD, DEST_ADD, PRICE, WEIGHT, PAQUETE, ESTADO) 
values ('C-0001',1,'Santa Anita','Miraflores', 50, 2,'Documentos',1); 
go

insert into TM_ENVIO(COD_ORDEN, IDUSER, SRC_ADD, DEST_ADD, PRICE, WEIGHT, PAQUETE, ESTADO) values('C-0002',1,'San Luis','La Victoria', 30, 2,'Lapiceros',4); 
go

insert into TM_ENVIO(COD_ORDEN, IDUSER, SRC_ADD, DEST_ADD, PRICE, WEIGHT, PAQUETE, ESTADO) values('C-0003',2,'VMT','Comas', 90, 14,'Cuadernos',5); 
go



///////////////////// ESTADOS DE ENVIO /////////////////////////////////

insert into ESTADO_ENVIO (NOMBRE_ESTADO, DESC_ESTADO) 
values ('Recibido','Se recibió solicitud de envio');
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