USE [GD2C2019]

GO

CREATE SCHEMA POR_COLECTORA AUTHORIZATION gdCupon2019;

GO

CREATE TABLE POR_COLECTORA.Direcciones(
	Direccion_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Direccion_Calle VARCHAR,
	Direccion_Nro_Piso VARCHAR,
	Direccion_Depto VARCHAR,
	Direccion_Ciudad VARCHAR)
GO

CREATE TABLE POR_COLECTORA.Usuarios(
	Usuario_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Usuario_Nombre VARCHAR,
	Usuario_Password VARCHAR,
	Usuario_Intentos Numeric,
	Usuario_Habilitado BIT DEFAULT 1)
GO

CREATE TABLE POR_COLECTORA.Clientes(
	Clie_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Clie_Nombre VARCHAR,
	Clie_Apellido VARCHAR,
	Clie_DNI Numeric(18,0) UNIQUE,
	Clie_Mail NVARCHAR(50),
	Clie_Telefono Numeric,
	Clie_Direccion Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Direcciones(Direccion_Id),
	Clie_CP Numeric,
	Clie_Fecha_Nac DATETIME,
	Clie_Habilitado BIT DEFAULT 1,
	Clie_Saldo Numeric,
	Clie_Usuario Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Usuarios(Usuario_Id))
GO

CREATE TABLE POR_COLECTORA.Roles(
	Rol_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Rol_Nombre VARCHAR,
	Rol_Habilitado BIT DEFAULT 1)
GO

CREATE TABLE POR_COLECTORA.RolxUsario(
	Id_Rol Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Roles(Rol_Id),
	Id_Usuario Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Usuarios(Usuario_Id))
GO

CREATE TABLE POR_COLECTORA.Funcionalidades(
	Func_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Func_Descripcion VARCHAR)
GO

CREATE TABLE POR_COLECTORA.FuncionalidadxRol(
	Id_Rol Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Roles(Rol_Id),
	Id_Func Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Funcionalidades(Func_Id))
GO

CREATE TABLE POR_COLECTORA.Rubros(
	Rubro_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Rubro_Detalle VARCHAR)
GO

CREATE TABLE POR_COLECTORA.Proveedores(
	Provee_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Provee_RS VARCHAR,
	Provee_Mail VARCHAR,
	Provee_Telefono Numeric,
	Provee_CUIT NVARCHAR(13),
	Provee_Direccion Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Direcciones(Direccion_Id),
	Provee_CP Numeric,
	Provee_Ciudad Numeric,
	Provee_Rubro Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Rubros(Rubro_Id),
	Provee_Nombre_Contacto NVARCHAR(20),
	Provee_Usuario Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Usuarios(Usuario_Id),
	Provee_Habilitado BIT DEFAULT 1)
GO

CREATE TABLE POR_COLECTORA.Facturas(
	Fact_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Fact_Numero Numeric,
	Fact_Fecha_Desde DATETIME,
	Fact_Fecha_Hasta DATETIME,
	Fact_Importe Numeric,
	Fact_Proveedor_ID Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Proveedores(Provee_Id),
	Fact_Proveedor_CUIT NVARCHAR(13),
	Fact_Proveedor_RS VARCHAR)
GO

CREATE TABLE POR_COLECTORA.Ofertas(
	Oferta_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Oferta_Descripcion VARCHAR,
	Oferta_Fecha DATETIME,
	Oferta_Fecha_Venc DATETIME,
	Oferta_Precio Numeric,
	Oferta_Precio_Ficticio Numeric,
	Oferta_Cantidad Numeric,
	Oferta_Restriccion_Compra Numeric,
	Oferta_Proveedor Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Proveedores(Provee_Id))
GO

CREATE TABLE POR_COLECTORA.Compras(
	Compra_Cliente Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Clientes(Clie_Id),
	Compra_Oferta Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Ofertas(Oferta_Id),
	Compra_Cantidad Numeric,
	Compra_Fecha DATETIME,
	Compra_Codigo Numeric,
	Compra_Id_Factura Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Facturas(Fact_Id),
	Compra_Oferta_Precio Numeric)
GO

CREATE TABLE POR_COLECTORA.Cupones(
	Cupon_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Cupon_Fecha_Venc DATETIME,
	Cupon_Fecha_Consumo DATETIME,
	--Cupon_Nro_Compra Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Compras(Compra_Id),
	Cupon_Id_Cliente_Consumidor Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Clientes(Clie_Id))
GO

CREATE TABLE POR_COLECTORA.Tarjetas(
	Tarjeta_Numero Numeric PRIMARY KEY,
	Tarjeta_Tipo nvarchar(50),
	Tarjeta_Fecha_Venc DATETIME,
	Cupon_Id_Cliente Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Clientes(Clie_Id))
GO

CREATE TABLE POR_COLECTORA.Cargas(
	Carga_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Carga_Fecha DATETIME,
	Carga_Id_Cliente Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Clientes(Clie_Id),
	Carga_Tipo_Pago nvarchar(20),
	Carga_Monto NUMERIC,
	Carga_Id_Tarjeta Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Tarjetas(Tarjeta_Numero),
	Carga_Forma_Pago VARCHAR(8))
GO

