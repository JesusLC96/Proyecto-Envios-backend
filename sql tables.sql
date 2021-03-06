
CREATE TABLE TM_USER
(
	IDUSER          	INT PRIMARY KEY IDENTITY(1,1),
	USERNAME			VARCHAR(64),
	PASSWORD            VARCHAR(128),
	NAME              	VARCHAR(256),
	LASTNAME			VARCHAR(256),
	BIRTH				DATE,
	PHONE				VARCHAR(9),
	EMAIL				VARCHAR(200)

)
GO

CREATE TABLE TM_ENVIO
(
	COD_ORDEN			CHAR(15) PRIMARY KEY,
	IDUSER				INT,
	SRC_ADD				VARCHAR(256),
	DEST_ADD			VARCHAR (256),
	PRICE				DECIMAL(10,2),
	WEIGHT				DECIMAL(10,2),
	PAQUETE				VARCHAR (256),
	ESTADO				INT,
	FOREIGN KEY (IDUSER) REFERENCES TM_USER(IDUSER),
	FOREIGN KEY (ESTADO) REFERENCES ESTADO_ENVIO (COD_ESTADO),
)
GO

/* ACTUALIZAR COD ORDEN*/
ALTER TABLE TM_ENVIO ALTER COLUMN COD_ORDEN VARCHAR(15)
/* */

CREATE TABLE ESTADO_ENVIO
(
	COD_ESTADO	INT PRIMARY KEY IDENTITY(1,1),
	NOMBRE_ESTADO	VARCHAR(20),
	DESC_ESTADO	VARCHAR(60)
)
GO

/* NUEVOS CAMBIOS */
