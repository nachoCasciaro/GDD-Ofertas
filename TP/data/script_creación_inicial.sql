USE [GD2C2019]

--DROP CONSTRAINTS
--Hago un drop de las fk para despues poder hacer un drop de las tablas

DECLARE cursor_tablas CURSOR FOR
SELECT 
    'ALTER TABLE [' +  OBJECT_SCHEMA_NAME(parent_object_id) +
    '].[' + OBJECT_NAME(parent_object_id) + 
    '] DROP CONSTRAINT [' + name + ']'
FROM sys.foreign_keys

DECLARE @sql nvarchar(255)
OPEN cursor_tablas
FETCH NEXT FROM cursor_tablas INTO @sql

WHILE @@FETCH_STATUS = 0
	BEGIN
	exec    sp_executesql @sql
	FETCH NEXT FROM cursor_tablas INTO @sql
	END
CLOSE cursor_tablas
DEALLOCATE cursor_tablas
GO


--			INICIO DROPEO TABLAS/PROCEDURES/SCHEMA

--DROP TABLA CLIENTES
IF OBJECT_ID('POR_COLECTORA.Clientes', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.Clientes

--DROP TABLA USUARIOS
IF OBJECT_ID('POR_COLECTORA.Usuarios', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.Usuarios

--DROP TABLA DIRECCIONES
IF OBJECT_ID('POR_COLECTORA.Direcciones', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.Direcciones

--DROP TABLA ROLES
IF OBJECT_ID('POR_COLECTORA.Roles', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.Roles

--DROP TABLA ROLXUSUARIO
IF OBJECT_ID('POR_COLECTORA.RolxUsuario', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.RolxUsuario

--DROP TABLA FUNCIONALIDADES
IF OBJECT_ID('POR_COLECTORA.Funcionalidades', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.Funcionalidades

--DROP TABLA FUNCIONALIDADXROL
IF OBJECT_ID('POR_COLECTORA.FuncionalidadxRol', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.FuncionalidadxRol

--DROP TABLA RUBROS
IF OBJECT_ID('POR_COLECTORA.Rubros', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.Rubros

--DROP TABLA PROVEEDORES
IF OBJECT_ID('POR_COLECTORA.Proveedores', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.Proveedores

--DROP TABLA FACTURAS
IF OBJECT_ID('POR_COLECTORA.Facturas', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.Facturas

--DROP TABLA OFERTAS
IF OBJECT_ID('POR_COLECTORA.Ofertas', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.Ofertas

--DROP TABLA COMPRAS
IF OBJECT_ID('POR_COLECTORA.Compras', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.Compras

--DROP TABLA CUPONES
IF OBJECT_ID('POR_COLECTORA.Cupones', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.Cupones

--DROP TABLA TARJETAS
IF OBJECT_ID('POR_COLECTORA.Tarjetas', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.Tarjetas

--DROP TABLA CARGAS
IF OBJECT_ID('POR_COLECTORA.Cargas', 'U') IS NOT NULL
DROP TABLE POR_COLECTORA.Cargas

--DROP SP ALTA CLIENTE
IF OBJECT_ID ('POR_COLECTORA.sp_alta_cliente') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_alta_cliente

--DROP SP BAJA CLIENTE
IF OBJECT_ID ('POR_COLECTORA.sp_baja_cliente') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_baja_cliente

--DROP SP MODIFICAR CLIENTE
IF OBJECT_ID ('POR_COLECTORA.sp_modificar_cliente') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_modificar_cliente

--DROP SP ALTA PROVEEDOR
IF OBJECT_ID ('POR_COLECTORA.sp_alta_proveedor') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_alta_proveedor

--DROP SP BAJA PROVEEDOR
IF OBJECT_ID ('POR_COLECTORA.sp_baja_proveedor') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_baja_proveedor

--DROP SP MODIFICAR PROVEEDOR
IF OBJECT_ID ('POR_COLECTORA.sp_modificar_proveedor') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_modificar_proveedor

--DROP SP CARGA CREDITO
IF OBJECT_ID ('POR_COLECTORA.sp_carga_credito') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_carga_credito

--DROP SP LISTADO PROVEEDORES MAS DESCUENTO
IF OBJECT_ID ('POR_COLECTORA.sp_prov_mas_descuento') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_prov_mas_descuento

--DROP SP ALTA OFERTAS
IF OBJECT_ID ('POR_COLECTORA.sp_alta_ofertas') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_alta_ofertas

--DROP SP LISTADO PROVEEDORES MAYOR FACTURACION
IF OBJECT_ID ('POR_COLECTORA.sp_prov_mayor_facturacion') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_prov_mayor_facturacion

--DROP SP COMPRAR OFERTA
IF OBJECT_ID ('POR_COLECTORA.sp_comprar_oferta') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_comprar_oferta

GO

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'POR_COLECTORA')
BEGIN
	EXEC ('CREATE SCHEMA [POR_COLECTORA] AUTHORIZATION gdCruceros2019')
END
GO

--			FIN DROPEO 


--			INICIO CREACION TABLAS

--CREACIÓN DE TABLA DIRECCIONES
CREATE TABLE POR_COLECTORA.Direcciones(
	Direccion_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Direccion_Calle NVARCHAR(80) NOT NULL,
	Direccion_Nro_Piso VARCHAR(10),
	Direccion_Depto VARCHAR(10),
	Direccion_Ciudad NVARCHAR(80) NOT NULL)
GO

--CREACIÓN DE TABLA USUARIOS
CREATE TABLE POR_COLECTORA.Usuarios(
	Usuario_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Usuario_Nombre VARCHAR(100) NOT NULL,
	Usuario_Password VARCHAR(100) NOT NULL,
	Usuario_Intentos Numeric NOT NULL DEFAULT 0,
	Usuario_Habilitado BIT NOT NULL DEFAULT 1)
GO

--CREACIÓN DE TABLA CLIENTES
CREATE TABLE POR_COLECTORA.Clientes(
	Clie_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Clie_Nombre VARCHAR(30) NOT NULL,
	Clie_Apellido VARCHAR(30) NOT NULL,
	Clie_DNI Numeric(18,0) NOT NULL UNIQUE,
	Clie_Mail NVARCHAR(50) NOT NULL,
	Clie_Telefono Numeric NOT NULL,
	Clie_Direccion Numeric FOREIGN KEY REFERENCES POR_COLECTORA.Direcciones(Direccion_Id),
	Clie_CP Numeric,
	Clie_Fecha_Nac DATETIME NOT NULL,
	Clie_Habilitado BIT NOT NULL DEFAULT 1,
	Clie_Saldo Numeric NOT NULL DEFAULT 200,
	Clie_Usuario Numeric FOREIGN KEY REFERENCES POR_COLECTORA.Usuarios(Usuario_Id))
GO

--CREACIÓN DE TABLA ROLES
CREATE TABLE POR_COLECTORA.Roles(
	Rol_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Rol_Nombre VARCHAR(30) NOT NULL,
	Rol_Habilitado BIT NOT NULL DEFAULT 1)
GO

--CREACIÓN DE TABLA ROLxUSUARIO
CREATE TABLE POR_COLECTORA.RolxUsuario(
	Id_Rol Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Roles(Rol_Id),
	Id_Usuario Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Usuarios(Usuario_Id))
GO

--CREACIÓN DE TABLA FUNCIONALIDADES
CREATE TABLE POR_COLECTORA.Funcionalidades(
	Func_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Func_Descripcion VARCHAR(80) NOT NULL)
GO

--CREACIÓN DE TABLA FUNCIONALIDADxROL
CREATE TABLE POR_COLECTORA.FuncionalidadxRol(
	Id_Rol Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Roles(Rol_Id),
	Id_Func Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Funcionalidades(Func_Id))
GO

--CREACIÓN DE TABLA RUBROS
CREATE TABLE POR_COLECTORA.Rubros(
	Rubro_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Rubro_Detalle NVARCHAR(50) NOT NULL)
GO

--CREACIÓN DE TABLA PROVEEDORES
CREATE TABLE POR_COLECTORA.Proveedores(
	Provee_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Provee_RS NVARCHAR(80) NOT NULL,
	Provee_Mail NVARCHAR(50),
	Provee_Telefono Numeric NOT NULL,
	Provee_CUIT NVARCHAR(13) UNIQUE,
	Provee_Direccion Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Direcciones(Direccion_Id),
	Provee_CP Numeric,
	Provee_Rubro Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Rubros(Rubro_Id),
	Provee_Nombre_Contacto NVARCHAR(50),
	Provee_Usuario Numeric FOREIGN KEY REFERENCES POR_COLECTORA.Usuarios(Usuario_Id),
	Provee_Habilitado BIT NOT NULL DEFAULT 1)
GO

--CREACIÓN DE TABLA FACTURAS
CREATE TABLE POR_COLECTORA.Facturas(
	Fact_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Fact_Numero Numeric NOT NULL,
	Fact_Fecha_Desde DATETIME,
	Fact_Fecha_Hasta DATETIME NOT NULL,
	Fact_Importe Numeric NOT NULL,
	Fact_Proveedor_ID Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Proveedores(Provee_Id),
	Fact_Proveedor_CUIT NVARCHAR(13) NOT NULL,
	Fact_Proveedor_RS NVARCHAR(80) NOT NULL)
GO

--CREACIÓN DE TABLA OFERTAS
CREATE TABLE POR_COLECTORA.Ofertas(
	Oferta_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Oferta_Descripcion NVARCHAR(200) NOT NULL,
	Oferta_Fecha DATETIME NOT NULL,
	Oferta_Fecha_Venc DATETIME NOT NULL,
	Oferta_Precio Numeric NOT NULL,
	Oferta_Precio_Ficticio Numeric NOT NULL,
	Oferta_Cantidad Numeric NOT NULL,
	Oferta_Restriccion_Compra Numeric NOT NULL,
	Oferta_Proveedor Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Proveedores(Provee_Id))
GO

--CREACIÓN DE TABLA COMPRAS
CREATE TABLE POR_COLECTORA.Compras(
	Compra_Cliente Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Clientes(Clie_Id),
	Compra_Oferta Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Ofertas(Oferta_Id),
	Compra_Cantidad Numeric NOT NULL,
	Compra_Fecha DATETIME NOT NULL,
	Compra_Id_Factura Numeric FOREIGN KEY REFERENCES POR_COLECTORA.Facturas(Fact_Id),
	Compra_Oferta_Precio Numeric NOT NULL)
GO

--CREACIÓN DE TABLA CUPONES
CREATE TABLE POR_COLECTORA.Cupones(
	Cupon_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Cupon_Codigo Numeric NOT NULL,
	Cupon_Fecha_Venc DATETIME NOT NULL,
	Cupon_Fecha_Consumo DATETIME,
	--Cupon_Nro_Compra Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Compras(Compra_Id),
	Cupon_Id_Cliente_Consumidor Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Clientes(Clie_Id))
GO

--CREACIÓN DE TABLA TARJETAS
CREATE TABLE POR_COLECTORA.Tarjetas(
	Tarjeta_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Tarjeta_Numero Numeric NOT NULL,
	Tarjeta_Tipo nvarchar(50) NOT NULL,
	Tarjeta_Fecha_Venc DATETIME NOT NULL,
	Tarjeta_Id_Cliente Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Clientes(Clie_Id))
GO

--CREACIÓN DE TABLA CARGAS
CREATE TABLE POR_COLECTORA.Cargas(
	Carga_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Carga_Fecha DATETIME NOT NULL,
	Carga_Id_Cliente Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Clientes(Clie_Id),
	Carga_Tipo_Pago nvarchar(20), --Es el tipo de tarjeta
	Carga_Monto NUMERIC NOT NULL,
	Carga_Id_Tarjeta Numeric FOREIGN KEY REFERENCES POR_COLECTORA.Tarjetas(Tarjeta_Id),
	Carga_Medio_Pago VARCHAR(8))
GO

--			FIN CREACION TABLAS


--			COMIENZO MIGRACION TABLAS

--MIGRACION DIRECCIONES
INSERT INTO POR_COLECTORA.Direcciones
( Direccion_Calle,Direccion_Ciudad)
SELECT DISTINCT Cli_Direccion, Cli_Ciudad
FROM gd_esquema.Maestra

INSERT INTO POR_COLECTORA.Direcciones
( Direccion_Calle,Direccion_Ciudad)
SELECT DISTINCT Provee_Dom, Provee_Ciudad
FROM gd_esquema.Maestra
where Provee_Dom is not null

/*
--MIGRACION USUARIOS
INSERT INTO POR_COLECTORA.Usuarios
( Usuario_Nombre, Usuario_Password )
SELECT DISTINCT Cli_Nombre, NULL
FROM gd_esquema.Maestra
-- hacer el insert en usuarios de proveedores
*/

--MIGRACION TABLA CLIENTES
INSERT INTO POR_COLECTORA.Clientes
(Clie_Nombre, Clie_Apellido, Clie_DNI, Clie_Telefono, Clie_Mail, Clie_CP, Clie_Fecha_Nac, Clie_Direccion)
SELECT DISTINCT Cli_Nombre, Cli_Apellido, Cli_Dni, Cli_Telefono, Cli_Mail, NULL, Cli_Fecha_Nac,
				(SELECT Direccion_Id FROM POR_COLECTORA.Direcciones WHERE Direccion_Calle = Cli_Direccion)
FROM gd_esquema.Maestra


--MIGRACION TABLA ROLES
INSERT INTO POR_COLECTORA.Roles
( Rol_Nombre )
 VALUES ('Administrador'),('Cliente'),('Proveedor')

--INSERTO EL USUARIO ADMIN

DECLARE @password [nvarchar](100)
SET @password = 'w23e'

INSERT INTO POR_COLECTORA.Usuarios(Usuario_Nombre,Usuario_Password)
VALUES ('admin', HASHBYTES('SHA2_256', @password))
GO

--INSERTO EL USUARIO ADMIN EN ROLxUSUARIO

DECLARE @codigo_rol_administrador [NUMERIC]
SET @codigo_rol_administrador= (SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador')

INSERT INTO POR_COLECTORA.RolxUsuario(Id_Usuario, Id_Rol)
VALUES ((SELECT Usuario_Id FROM POR_COLECTORA.Usuarios WHERE Usuario_Nombre = 'admin'), @codigo_rol_administrador)
GO

--MIGRACION FUNCIONALIDADES
INSERT INTO POR_COLECTORA.Funcionalidades(Func_Descripcion)
VALUES	('Login y seguridad'), ('ABM Rol'), ('Registro de Usuario'),
		('ABM Cliente'), ('ABM Proveedor'), ('Cargar Crédito'),
		('Comprar Oferta'), ('Confección y publicación de Ofertas'),
		('Entrega/Consumo de Oferta'), ('Facturación a Proveedor'), ('Listado Estadistico');
GO

--MIGRACION FUNCIONALIDADxROL

--REVISAR TODOS EL JUEVES
--1 no lo dice bien la consigna, pero entiendo que solo el administrador puede modificar roles
--2 y 3 todos los USUARIOS pueden realizar el login (dice la consigna), no se si el administrador cuenta como usuario... (no segun nuestro DER)
--Listado estadistico no lo dice bien, entiendo que solo podria hacerlo el administrador
INSERT INTO POR_COLECTORA.FuncionalidadxRol(Id_Rol, Id_Func)
VALUES ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'ABM Rol')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Cliente'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Login y seguridad')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Proveedor'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Login y seguridad')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Cliente'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Registro de Usuario')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Proveedor'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Registro de Usuario')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'ABM Cliente')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'ABM Proveedor')), 
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Cliente'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Cargar Crédito')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Proveedor'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Confección y publicación de Ofertas')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Cliente'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Comprar Oferta')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Proveedor'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Entrega/Consumo de Oferta')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Facturación a Proveedor')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Listado Estadistico'));
GO

--MIGRACION TABLA RUBROS
INSERT INTO POR_COLECTORA.Rubros
(Rubro_Detalle)
SELECT DISTINCT Provee_Rubro
FROM gd_esquema.Maestra
where Provee_Rubro is not null

--MIGRACION TABLA PROVEEDORES
INSERT INTO POR_COLECTORA.Proveedores
( Provee_RS, Provee_Telefono, Provee_CUIT, Provee_Direccion, 
  Provee_Rubro)
SELECT DISTINCT Maestra.Provee_RS, Maestra.Provee_Telefono, Maestra.Provee_CUIT, 
				(SELECT Direccion_Id FROM POR_COLECTORA.Direcciones WHERE Direccion_Calle = Maestra.Provee_Dom), 
				(SELECT Rubro_Id FROM POR_COLECTORA.Rubros WHERE Rubro_Detalle = Maestra.Provee_Rubro)
FROM gd_esquema.Maestra as Maestra
where Maestra.Provee_RS is not null

--MIGRACION TABLA OFERTAS
INSERT INTO POR_COLECTORA.Ofertas
(Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio,
	Oferta_Cantidad, Oferta_Restriccion_Compra,	Oferta_Proveedor)
SELECT DISTINCT Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio, Oferta_Cantidad, 0,
				(SELECT Provee_Id FROM POR_COLECTORA.Proveedores As Colectora WHERE Colectora.Provee_RS = Maestra.Provee_RS)
FROM gd_esquema.Maestra As Maestra
where Oferta_Descripcion is not null

--MIGRACION FACTURAS

INSERT INTO POR_COLECTORA.Facturas
	(Fact_Numero,Fact_Fecha_Desde,Fact_Fecha_Hasta,Fact_Importe, Fact_Proveedor_ID,Fact_Proveedor_CUIT,Fact_Proveedor_RS )
SELECT DISTINCT Factura_Nro,NULL,Factura_Fecha,
	SUM(Oferta_Precio),
	(SELECT Provee_Id FROM POR_COLECTORA.Proveedores As Colectora WHERE Colectora.Provee_RS = Maestra.Provee_RS),
	(SELECT Provee_CUIT FROM POR_COLECTORA.Proveedores As Colectora WHERE Colectora.Provee_RS = Maestra.Provee_RS),
	(SELECT Provee_RS FROM POR_COLECTORA.Proveedores As Colectora WHERE Colectora.Provee_RS = Maestra.Provee_RS)
FROM gd_esquema.Maestra MAESTRA
where Factura_Nro is not null 
GROUP BY Factura_Nro, Factura_Fecha, Provee_RS


--MIGRACION COMPRAS - Revisar el jueves el matching de compra_oferta
INSERT INTO POR_COLECTORA.Compras
(Compra_Cliente,Compra_Oferta,Compra_Cantidad,Compra_Fecha,Compra_Id_Factura,Compra_Oferta_Precio)
SELECT DISTINCT (SELECT Clie_Id FROM POR_COLECTORA.Clientes As Colectora WHERE Colectora.Clie_DNI = Maestra.Cli_Dni), 
				(SELECT Oferta_id FROM POR_COLECTORA.Ofertas AS Colectora WHERE 
					Colectora.Oferta_Fecha = Maestra.Oferta_Fecha AND Colectora.Oferta_Fecha_Venc = Maestra.Oferta_Fecha_Venc 
					AND Colectora.Oferta_Descripcion = Maestra.Oferta_Descripcion AND Colectora.Oferta_Precio = Maestra.Oferta_Precio),
				1,Maestra.Oferta_Fecha_Compra,
				(SELECT Fact_Id FROM POR_COLECTORA.Facturas AS Colectora WHERE Colectora.Fact_Numero = Maestra.Factura_Nro),
				Maestra.Oferta_Precio
FROM gd_esquema.Maestra As Maestra
where Oferta_Descripcion is not null

--MIGRACION CUPONES
/*
INSERT INTO POR_COLECTORA.Cupones
(Cupon_Fecha_Venc, Cupon_Codigo,Cupon_Fecha_Consumo,Cupon_Id_Cliente_Consumidor)
SELECT DISTINCT 30, (select  ,
FROM gd_esquema.Maestra AS Maestra
*/



--MIGRACION CARGAS
INSERT INTO POR_COLECTORA.Cargas
(Carga_Fecha, Carga_Id_Cliente, Carga_Tipo_Pago, Carga_Monto)
SELECT DISTINCT Carga_fecha, (SELECT Clie_Id FROM POR_COLECTORA.Clientes AS Colectora WHERE Colectora.Clie_DNI = Maestra.Cli_Dni and Colectora.Clie_Nombre + Colectora.Clie_Apellido = Maestra.Cli_Nombre + Maestra.Cli_Apellido),
				Tipo_Pago_Desc,Carga_Credito 
FROM gd_esquema.Maestra AS Maestra
where Carga_Fecha is not null

GO

--FIN MIGRACIONES


--CREACION DE OBJETOS


CREATE PROCEDURE POR_COLECTORA.sp_alta_cliente (
@nombre char(50),
@apellido char(50),
@dni numeric (18,0),
@mail char(50),
@telefono numeric(18,0),
@direCalle char(80),
@nroPiso numeric(10),
@depto numeric(5),
@ciudad char(50),
@CP char(20),
@fechaNacimiento datetime
)
AS
BEGIN

	IF not exists (select 1 from POR_COLECTORA.Direcciones where Direccion_Calle = @direCalle and Direccion_Nro_Piso = @nroPiso and Direccion_Depto = @depto and Direccion_Ciudad = @ciudad) 
		BEGIN
			INSERT INTO POR_COLECTORA.Direcciones (Direccion_Calle,Direccion_Nro_Piso,Direccion_Depto, Direccion_Ciudad) VALUES (@direCalle,@nroPiso,@depto,@ciudad)
		END

	declare @dire_id numeric
	set @dire_id = (select Direccion_Id from Direcciones where Direccion_Calle = @direCalle and Direccion_Nro_Piso = @nroPiso and Direccion_Depto = @depto and Direccion_Ciudad = @ciudad)
	
	INSERT INTO POR_COLECTORA.Clientes (Clie_Nombre,Clie_Apellido,Clie_DNI,Clie_Mail,Clie_Telefono,Clie_Direccion,Clie_CP,Clie_Fecha_Nac) 
	VALUES (@nombre,@apellido,@dni,@mail,@telefono,@dire_id,@CP,@fechaNacimiento)
END

GO


CREATE PROCEDURE POR_COLECTORA.sp_baja_cliente (
@id_clie numeric
)
AS
BEGIN
	UPDATE POR_COLECTORA.Clientes
	SET Clie_Habilitado = 0
	WHERE Clie_Id = @id_clie;
END

GO


CREATE PROCEDURE POR_COLECTORA.sp_modificar_cliente (
@id_clie numeric,
@nombre char(50),
@apellido char(50),
@dni numeric (18,0),
@mail char(50),
@telefono numeric(18,0),
@direCalle char(80),
@nroPiso numeric(10),
@depto numeric(5),
@ciudad char(50),
@CP char(20),
@fechaNacimiento datetime
)
AS
BEGIN

	UPDATE POR_COLECTORA.Direcciones
	SET Direccion_Calle = @direCalle, Direccion_Nro_Piso = @nroPiso, Direccion_Depto = @depto, Direccion_Ciudad = @ciudad
	WHERE Direccion_Id = (select Clie_Direccion from Clientes where Clie_Id = @id_clie)

	UPDATE POR_COLECTORA.Clientes
	SET Clie_Nombre = @nombre, Clie_Apellido = @apellido, Clie_DNI = @dni, Clie_Mail = @mail, Clie_Telefono = @telefono, Clie_CP = @CP, Clie_Fecha_Nac = @fechaNacimiento
	WHERE Clie_Id = @id_clie;
	
END

GO

CREATE PROCEDURE POR_COLECTORA.sp_alta_proveedor (
@razonSocial char(50),
@mail char(50),
@telefono numeric(18,0),
@direCalle char(80),
@nroPiso numeric(10),
@depto numeric(5),
@ciudad char(50),
@CP char(20),
@cuit numeric(20),
@nombreContacto char(20)
)
AS
BEGIN

	IF not exists (select 1 from POR_COLECTORA.Direcciones where Direccion_Calle = @direCalle and Direccion_Nro_Piso = @nroPiso and Direccion_Depto = @depto and Direccion_Ciudad = @ciudad) 
		BEGIN
			INSERT INTO POR_COLECTORA.Direcciones (Direccion_Calle,Direccion_Nro_Piso,Direccion_Depto, Direccion_Ciudad) VALUES (@direCalle,@nroPiso,@depto,@ciudad)
		END

	declare @dire_id numeric
	set @dire_id = (select Direccion_Id from Direcciones where Direccion_Calle = @direCalle and Direccion_Nro_Piso = @nroPiso and Direccion_Depto = @depto and Direccion_Ciudad = @ciudad)
	
	INSERT INTO POR_COLECTORA.Proveedores(Provee_RS,Provee_Mail,Provee_Telefono,Provee_Direccion,Provee_CP,Provee_CUIT,Provee_Nombre_Contacto) 
	VALUES (@razonSocial,@mail,@telefono,@dire_id,@CP,@cuit,@nombreContacto)
END

GO


CREATE PROCEDURE POR_COLECTORA.sp_baja_proveedor (
@id_prove numeric
)
AS
BEGIN
	UPDATE POR_COLECTORA.Proveedores
	SET Provee_Habilitado = 0
	WHERE Provee_Id = @id_prove;
END

GO

CREATE PROCEDURE POR_COLECTORA.sp_modificar_proveedor (
@id_prove numeric,
@razonSocial char(50),
@mail char(50),
@telefono numeric(18,0),
@direCalle char(80),
@nroPiso numeric(10),
@depto numeric(5),
@ciudad char(50),
@CP char(20),
@cuit numeric(20),
@nombreContacto char(20)
)
AS
BEGIN

	UPDATE POR_COLECTORA.Direcciones
	SET Direccion_Calle = @direCalle, Direccion_Nro_Piso = @nroPiso, Direccion_Depto = @depto, Direccion_Ciudad = @ciudad
	WHERE Direccion_Id = (select Provee_Direccion from Proveedores where Provee_Id = @id_prove)

	UPDATE POR_COLECTORA.Proveedores
	SET Provee_RS = @razonSocial, Provee_Mail = @mail, Provee_Telefono = @telefono, Provee_CP = @CP, Provee_CUIT = @cuit, Provee_Nombre_Contacto = @nombreContacto
	WHERE Provee_Id = @id_prove;
	
END

GO

CREATE PROCEDURE POR_COLECTORA.sp_carga_credito (
@id_cliente numeric,
@fecha_carga datetime, --pasar la de archivo configuracion -> esto lo haces en la interfaz
@monto int,
@tipo_tarjeta nvarchar(50),
@numero_tarjeta numeric,
@fecha_venc datetime
)

--en el enunciado dice que el usuario elija el tipo de pago: tarjeta de credito o debito, 
--chau efectivo?
AS
BEGIN
	UPDATE POR_COLECTORA.Clientes
	SET Clie_Saldo = Clie_Saldo + @monto
	WHERE Clie_Id = @id_cliente;

	IF not exists (select 1 from POR_COLECTORA.Tarjetas where Tarjeta_Tipo = @tipo_tarjeta and Tarjeta_Fecha_Venc = @tipo_tarjeta and Tarjeta_Id_Cliente = @id_cliente) 
		BEGIN
			INSERT INTO POR_COLECTORA.Tarjetas (Tarjeta_Numero,Tarjeta_Tipo,Tarjeta_Fecha_Venc, Tarjeta_Id_Cliente) VALUES (@numero_tarjeta,@tipo_tarjeta,@fecha_venc,@id_cliente)
		END

	declare @id_tarjeta numeric
	set @id_tarjeta = (select Tarjeta_Id from Tarjetas where Tarjeta_Id_Cliente = @id_cliente and Tarjeta_Numero = @numero_tarjeta)

	
	INSERT INTO POR_COLECTORA.Cargas(Carga_Fecha,Carga_Id_Cliente,Carga_Monto,Carga_Tipo_Pago,Carga_Id_Tarjeta) 
	VALUES (@fecha_carga,@id_cliente,@monto,@tipo_tarjeta,@id_tarjeta)

END

GO

--TOP 5 de proveedores con mayor porcentaje de descuento ofrecido en sus ofertas en forma descendente por monto
--La pantalla debe permitirnos seleccionar el semestre

--Ofertas que se hayan lanzado en el semestre, o tambien tiene que entrar el vencimiento??
CREATE PROCEDURE POR_COLECTORA.sp_prov_mas_descuento (@semestre numeric, @anio numeric)
AS
BEGIN

	SELECT TOP 5 Provee_RS AS RAZON_SOCIAL_PROVEEDOR, Provee_Rubro AS RUBRO, AVG(Oferta_Precio_Ficticio - Oferta_Precio) AS PORCENTAJE_PROMEDIO_OFERTA
	FROM POR_COLECTORA.Proveedores JOIN POR_COLECTORA.Ofertas ON Provee_Id = Oferta_Proveedor
	WHERE YEAR(Oferta_Fecha) = @anio AND 
								(MONTH(Oferta_Fecha) = (@semestre * 6) 
								OR MONTH(Oferta_Fecha) = (@semestre * 6) - 1 
								OR MONTH(Oferta_Fecha) = (@semestre * 6) - 2
								OR MONTH(Oferta_Fecha) = (@semestre * 6) - 3
								OR MONTH(Oferta_Fecha) = (@semestre * 6) - 4
								OR MONTH(Oferta_Fecha) = (@semestre * 6) - 5) 
	GROUP BY Provee_RS, Provee_Rubro
	ORDER BY 3 DESC

END

GO

--TOP 5 de proveedores con mayor facturacion
--La pantalla debe permitirnos seleccionar el semestre
CREATE PROCEDURE POR_COLECTORA.sp_prov_mayor_facturacion (@semestre numeric, @anio numeric)
AS
BEGIN

	SELECT TOP 5 Provee_RS AS RAZON_SOCIAL_PROVEEDOR, Provee_Rubro AS RUBRO, AVG(Fact_Importe) AS PROMEDIO_FACTURACION
	FROM POR_COLECTORA.Proveedores JOIN POR_COLECTORA.Facturas o1 ON Provee_Id = Fact_Proveedor_ID
	WHERE YEAR(Fact_Fecha_Desde) = @anio AND 
								(MONTH(Fact_Fecha_Desde) = (@semestre * 6) 
								OR MONTH(Fact_Fecha_Desde) = (@semestre * 6) - 1 
								OR MONTH(Fact_Fecha_Desde) = (@semestre * 6) - 2
								OR MONTH(Fact_Fecha_Desde) = (@semestre * 6) - 3
								OR MONTH(Fact_Fecha_Desde) = (@semestre * 6) - 4
								OR MONTH(Fact_Fecha_Desde) = (@semestre * 6) - 5) 
			AND YEAR(Fact_Fecha_Hasta) = @anio AND 
								(MONTH(Fact_Fecha_Hasta) = (@semestre * 6) 
								OR MONTH(Fact_Fecha_Hasta) = (@semestre * 6) - 1 
								OR MONTH(Fact_Fecha_Hasta) = (@semestre * 6) - 2
								OR MONTH(Fact_Fecha_Hasta) = (@semestre * 6) - 3
								OR MONTH(Fact_Fecha_Hasta) = (@semestre * 6) - 4
								OR MONTH(Fact_Fecha_Hasta) = (@semestre * 6) - 5) 
	GROUP BY Provee_RS, Provee_Rubro
	ORDER BY 3 DESC

END

GO


--SP Alta ofertas proveedores 
CREATE PROCEDURE POR_COLECTORA.sp_alta_ofertas(
@id_prove numeric,
@descripcion char(50), 
@fecha DateTime, 
@fecha_venc DateTime, 
@precio_oferta numeric, 
@precio_original numeric, 
@stock numeric, 
@max_compra numeric)

AS
BEGIN
	--Chequeo fechas contra el sistema?? 
	--El proveedor podrá ir cargando ofertas con diferentes fechas, esta fecha debe ser mayor o igual a la fecha actual del sistema.

	INSERT INTO POR_COLECTORA.Ofertas(Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio, Oferta_Cantidad, Oferta_Restriccion_Compra, Oferta_Proveedor) 
	VALUES (@descripcion, @fecha, @fecha_venc, @precio_original, @precio_oferta, @stock, @max_compra,@id_prove)

END

GO

--SP COMPRA OFERTA 
CREATE PROCEDURE POR_COLECTORA.sp_comprar_oferta(
@id_oferta numeric,
@id_cliente numeric,
@fecha_compra datetime,
@cantidad_compra numeric
)

AS
BEGIN
	
	declare @precio_oferta numeric
	set @precio_oferta = (select Oferta_Precio from Ofertas where Oferta_Id = @id_oferta)

	declare @cantidad_maxima numeric
	set @cantidad_maxima = (select Oferta_Restriccion_Compra from Ofertas where Oferta_Id = @id_oferta)


	if ( (select Clie_Saldo from Clientes where Clie_Id = @id_cliente) >= @precio_oferta 
			and ( (select count(*) from Compras where Compra_Oferta = @id_oferta and Compra_Cliente = @id_cliente group by Compra_Cliente) + @cantidad_compra ) <  @cantidad_maxima  )
		begin
			INSERT INTO POR_COLECTORA.Compras(Compra_Fecha, Compra_Oferta, Compra_Cliente, Compra_Cantidad, Compra_Oferta_Precio) 
			VALUES (@fecha_compra,@id_oferta,@id_cliente,@cantidad_compra,@precio_oferta)
		end	

END

GO

--SP FACTURACION A PROVEEDOR
--Listado ofertas adquiridas por clientes, no me dice que campos mostrar, muestro ID y descripcion
CREATE PROCEDURE POR_COLECTORA.sp_facturar_a_proveedor(@fecha_inicio DateTime, @fecha_fin DateTime, @proveedor numeric)
AS
BEGIN

	SELECT DISTINCT(Compra_Oferta) AS OFERTA_CODIGO, Oferta_Descripcion AS OFERTA_DESCRIPCION 
	FROM Compras JOIN Ofertas ON Compra_Oferta = Oferta_Id JOIN Proveedores ON Oferta_Proveedor = Provee_Id
	WHERE Compra_Fecha >= @fecha_inicio AND Compra_Fecha <= @fecha_fin AND Provee_Id = @proveedor) 

END

GO

--SP FACTURACION A PROVEEDOR
--Importe factura y numero factura
CREATE PROCEDURE POR_COLECTORA.sp_facturar_a_proveedor(@fecha_inicio DateTime, @fecha_fin DateTime, @proveedor numeric)
AS
BEGIN
	--Importe factura
	declare @importe_total numeric
	set @importe_total = (SELECT SUM(Compra_Oferta_Precio * Compra_Cantidad)
						FROM Compras JOIN Ofertas ON Compra_Oferta = Oferta_Id JOIN Proveedores ON Oferta_Proveedor = Provee_Id
						WHERE Compra_Fecha >= @fecha_inicio AND Compra_Fecha <= @fecha_fin AND Provee_Id = @proveedor) 
 
	declare @fact_numero numeric
	set @fact_numero = (SELECT TOP 1 fact_numero
						FROM Facturas
						ORDER BY fact_numero DESC) + 1

END

GO


