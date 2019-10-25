USE [GD2C2019]

GO

CREATE SCHEMA POR_COLECTORA AUTHORIZATION gdCupon2019;

GO

--			INICIO CREACION TABLAS

--CREACIÓN DE TABLA DIRECCIONES
CREATE TABLE POR_COLECTORA.Direcciones(
	Direccion_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Direccion_Calle VARCHAR NOT NULL,
	Direccion_Nro_Piso VARCHAR,
	Direccion_Depto VARCHAR,
	Direccion_Ciudad VARCHAR NOT NULL)
GO

--CREACIÓN DE TABLA USUARIOS
CREATE TABLE POR_COLECTORA.Usuarios(
	Usuario_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Usuario_Nombre VARCHAR NOT NULL,
	Usuario_Password VARCHAR NOT NULL,
	Usuario_Intentos Numeric DEFAULT 0,
	Usuario_Habilitado BIT NOT NULL DEFAULT 1)
GO

--CREACIÓN DE TABLA CLIENTES
CREATE TABLE POR_COLECTORA.Clientes(
	Clie_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Clie_Nombre VARCHAR NOT NULL,
	Clie_Apellido VARCHAR NOT NULL,
	Clie_DNI Numeric(18,0) NOT NULL UNIQUE,
	Clie_Mail NVARCHAR(50) NOT NULL,
	Clie_Telefono Numeric NOT NULL,
	Clie_Direccion Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Direcciones(Direccion_Id),
	Clie_CP Numeric NOT NULL,
	Clie_Fecha_Nac DATETIME NOT NULL,
	Clie_Habilitado BIT NOT NULL DEFAULT 1,
	Clie_Saldo Numeric NOT NULL DEFAULT 200,
	Clie_Usuario Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Usuarios(Usuario_Id))
GO

--CREACIÓN DE TABLA ROLES
CREATE TABLE POR_COLECTORA.Roles(
	Rol_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Rol_Nombre VARCHAR NOT NULL,
	Rol_Habilitado BIT NOT NULL DEFAULT 1)
GO

--CREACIÓN DE TABLA ROLxUSUARIO
CREATE TABLE POR_COLECTORA.RolxUsario(
	Id_Rol Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Roles(Rol_Id),
	Id_Usuario Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Usuarios(Usuario_Id))
GO

--CREACIÓN DE TABLA FUNCIONALIDADES
CREATE TABLE POR_COLECTORA.Funcionalidades(
	Func_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Func_Descripcion VARCHAR NOT NULL)
GO

--CREACIÓN DE TABLA FUNCIONALIDADxROL
CREATE TABLE POR_COLECTORA.FuncionalidadxRol(
	Id_Rol Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Roles(Rol_Id),
	Id_Func Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Funcionalidades(Func_Id))
GO

--CREACIÓN DE TABLA RUBROS
CREATE TABLE POR_COLECTORA.Rubros(
	Rubro_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Rubro_Detalle NVARCHAR NOT NULL)
GO

--CREACIÓN DE TABLA PROVEEDORES
CREATE TABLE POR_COLECTORA.Proveedores(
	Provee_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Provee_RS VARCHAR NOT NULL,
	Provee_Mail VARCHAR,
	Provee_Telefono Numeric NOT NULL,
	Provee_CUIT NVARCHAR(13) NOT NULL,
	Provee_Direccion Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Direcciones(Direccion_Id),
	Provee_CP Numeric,
	Provee_Ciudad Numeric NOT NULL,
	Provee_Rubro Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Rubros(Rubro_Id),
	Provee_Nombre_Contacto VARCHAR,
	Provee_Usuario Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Usuarios(Usuario_Id),
	Provee_Habilitado BIT NOT NULL DEFAULT 1)
GO

--CREACIÓN DE TABLA FACTURAS
CREATE TABLE POR_COLECTORA.Facturas(
	Fact_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Fact_Numero Numeric NOT NULL,
	Fact_Fecha_Desde DATETIME NOT NULL,
	Fact_Fecha_Hasta DATETIME NOT NULL,
	Fact_Importe Numeric NOT NULL,
	Fact_Proveedor_ID Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Proveedores(Provee_Id),
	Fact_Proveedor_CUIT NVARCHAR(13) NOT NULL,
	Fact_Proveedor_RS VARCHAR NOT NULL)
GO

--CREACIÓN DE TABLA OFERTAS
CREATE TABLE POR_COLECTORA.Ofertas(
	Oferta_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Oferta_Descripcion VARCHAR NOT NULL,
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
	Cupon_Id_Cliente Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Clientes(Clie_Id))
GO

--CREACIÓN DE TABLA CARGAS
CREATE TABLE POR_COLECTORA.Cargas(
	Carga_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Carga_Fecha DATETIME NOT NULL,
	Carga_Id_Cliente Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Clientes(Clie_Id),
	Carga_Tipo_Pago nvarchar(20) NOT NULL, --Es el tipo de tarjeta
	Carga_Monto NUMERIC NOT NULL,
	Carga_Id_Tarjeta Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Tarjetas(Tarjeta_Numero),
	Carga_Medio_Pago VARCHAR(8) NOT NULL)
GO

--			FIN CREACION TABLAS



--			COMIENZO MIGRACION TABLAS

--MIGRACION DIRECCIONES
INSERT INTO POR_COLECTORA.Direcciones
( Direccion_Calle, Direccion_Nro_Piso, Direccion_Depto, Direccion_Ciudad )
SELECT DISTINCT Cli_Direccion, NULL, NULL, Cli_Ciudad
FROM gd_esquema.Maestra
-- hacer el insert en direcciones de proveedores

--MIGRACION USUARIOS
INSERT INTO POR_COLECTORA.Usuarios
( Usuario_Nombre, Usuario_Password )
SELECT DISTINCT Cli_Nombre, NULL
FROM gd_esquema.Maestra
-- hacer el insert en usuarios de proveedores

--MIGRACION TABLA CLIENTES
INSERT INTO POR_COLECTORA.Clientes
(Clie_Nombre, Clie_Apellido, Clie_DNI, Clie_Telefono, Clie_Mail, Clie_CP, Clie_Fecha_Nac, Clie_Direccion, Clie_Usuario)
SELECT DISTINCT Cli_Nombre, Cli_Apellido, Cli_Dni, Cli_Telefono, Cli_Mail, NULL, Cli_Fecha_Nac,
				(SELECT Direccion_Id FROM POR_COLECTORA.Direcciones WHERE Direccion_Calle = Cli_Direccion), NULL
FROM gd_esquema.Maestra

--MIGRACION TABLA ROLES


--MIGRACION TABLA ROLXUSUARIO


--MIGRACION FUNCIONALIDADES


--MIGRACION FUNCIONALIDADxROL


--MIGRACION RUBROS


--MIGRACION TABLA PROVEEDORES
INSERT INTO POR_COLECTORA.Proveedores
( Provee_RS, Provee_Mail, Provee_Telefono, Provee_CUIT, Provee_Direccion, Provee_CP, Provee_Ciudad, 
  Provee_Rubro, Provee_Nombre_Contacto, Provee_Usuario)
SELECT DISTINCT Provee_RS, NULL, Provee_Telefono, Provee_CUIT, 
				(SELECT Direccion_Id FROM POR_COLECTORA.Direcciones WHERE Direccion_Calle = Provee_Dom), 
				NULL, Provee_Ciudad, Provee_Rubro, NULL, NULL
FROM gd_esquema.Maestra

--MIGRACION FACTURAS


--MIGRACION TABLA OFERTAS
INSERT INTO POR_COLECTORA.Ofertas
(	Oferta_Descripcion,	Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio,	Oferta_Precio_Ficticio,
	Oferta_Cantidad, Oferta_Restriccion_Compra,	Oferta_Proveedor)
SELECT DISTINCT Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio, Oferta_Cantidad, 1,
				(SELECT Provee_Id FROM POR_COLECTORA.Proveedores As Colectora WHERE Colectora.Provee_RS = Maestra.Provee_RS)
FROM gd_esquema.Maestra As Maestra

--MIGRACION COMPRAS


--MIGRACION CUPONES


--MIGRACION CARGAS


--MIGRACION TABLA RUBROS
INSERT INTO POR_COLECTORA.Rubros
(Rubro_Detalle)
SELECT DISTINCT Provee_Rubro
FROM gd_esquema.Maestra



