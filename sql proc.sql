CREATE PROC usp_ListarUsuarios
AS
	SELECT	P.IDUSER,
			P.USERNAME,
			P.NAME,
			P.LASTNAME,
			P.BIRTH,
			P.EMAIL
	FROM	TM_USER P
GO


CREATE PROC usp_ObtenerUsuario
(
	@IDUSER INT
)
AS
	SELECT	F.IDUSER,
			F.USERNAME,
			F.NAME,
			F.LASTNAME,
			F.BIRTH,
			F.EMAIL
	FROM	TM_USER F
	WHERE	F.IDUSER = @IDUSER
GO



CREATE PROC usp_MostrarEnvios_X_Usuario
(
	@IDUSER INT
)
AS
	SELECT	D.COD_ORDEN,
			D.IDUSER,
			P.NAME AS NOMBRE,
			P.LASTNAME AS APELLIDO,
			D.SRC_ADD,
			D.DEST_ADD,
			D.PRICE,
			D.WEIGHT,
			D.PAQUETE
	FROM	TM_ENVIO D
	INNER JOIN TM_USER P ON P.IDUSER = D.IDUSER
	WHERE	D.IDUSER = @IDUSER
GO


CREATE PROC usp_Lista_de_envios
AS
	SELECT	D.COD_ORDEN,
			D.IDUSER,
			P.NAME AS NOMBRE,
			P.LASTNAME AS APELLIDO,
			D.SRC_ADD,
			D.DEST_ADD,
			D.PRICE,
			D.WEIGHT,
			D.PAQUETE
	FROM	TM_ENVIO D
	INNER JOIN TM_USER P ON P.IDUSER = D.IDUSER
GO