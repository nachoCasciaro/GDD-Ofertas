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

--DROP SP CREAR ROL
IF OBJECT_ID ('POR_COLECTORA.sp_alta_cliente') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_alta_cliente

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
	Provee_CUIT NVARCHAR(13),
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
	Compra_Codigo Numeric NOT NULL,
	Compra_Id_Factura Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Facturas(Fact_Id),
	Compra_Oferta_Precio Numeric NOT NULL)
GO

--CREACIÓN DE TABLA CUPONES
CREATE TABLE POR_COLECTORA.Cupones(
	Cupon_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Cupon_Fecha_Venc DATETIME NOT NULL,
	Cupon_Fecha_Consumo DATETIME,
	--Cupon_Nro_Compra Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Compras(Compra_Id),
	Cupon_Id_Cliente_Consumidor Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Clientes(Clie_Id))
GO

--CREACIÓN DE TABLA TARJETAS
CREATE TABLE POR_COLECTORA.Tarjetas(
	Tarjeta_Numero Numeric PRIMARY KEY,
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
	Carga_Id_Tarjeta Numeric FOREIGN KEY REFERENCES POR_COLECTORA.Tarjetas(Tarjeta_Numero),
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
(Compra_Cliente,Compra_Oferta,Compra_Cantidad,Compra_Fecha,Compra_Codigo,Compra_Id_Factura,Compra_Oferta_Precio)
SELECT DISTINCT (SELECT Clie_Id FROM POR_COLECTORA.Clientes As Colectora WHERE Colectora.Clie_DNI = Maestra.Cli_Dni), 
				(SELECT Oferta_id FROM POR_COLECTORA.Ofertas AS Colectora WHERE 
					Colectora.Oferta_Fecha = Maestra.Oferta_Fecha AND Colectora.Oferta_Fecha_Venc = Maestra.Oferta_Fecha_Venc 
					AND Colectora.Oferta_Descripcion = Maestra.Oferta_Descripcion AND Colectora.Oferta_Precio = Maestra.Oferta_Precio),
				1,Maestra.Oferta_Fecha_Compra,Maestra.Oferta_Codigo,
				(SELECT Fact_Id FROM POR_COLECTORA.Facturas AS Colectora WHERE Colectora.Fact_Numero = Maestra.Factura_Nro),
				Maestra.Oferta_Precio
FROM gd_esquema.Maestra As Maestra
where Oferta_Descripcion is not null

--MIGRACION CUPONES
/*
INSERT INTO POR_COLECTORA.Cupones
(Cupon_Fecha_Venc,Cupon_Fecha_Consumo,Cupon_Id_Cliente_Consumidor)

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



