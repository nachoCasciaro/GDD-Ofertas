USE [GD2C2019]

GO

CREATE SCHEMA POR_COLECTORA AUTHORIZATION gdCupon2019;

GO

CREATE TABLE POR_COLECTORA.Direcciones(
	Direccion_Id Numeric PRIMARY KEY,
	Direccion_Calle VARCHAR,
	Direccion_Nro_Piso VARCHAR,
	Direccion_Depto VARCHAR,
	Direccion_Ciudad VARCHAR)
GO

CREATE TABLE POR_COLECTORA.Usuarios(
	User_Id Numeric PRIMARY KEY,
	User_Nombre VARCHAR,
	User_Password VARCHAR,
	User_Intentos Numeric,
	User_Habilitado BIT DEFAULT 1)
GO

CREATE TABLE POR_COLECTORA.Clientes(
	Clie_Id Numeric PRIMARY KEY,
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
	Clie_Usuario Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.usuarios(Usuario_Id))
GO

CREATE TABLE POR_COLECTORA.Roles(
	Rol_Id Numeric PRIMARY KEY,
	Rol_Nombre VARCHAR,
	Rol_Habilitado BIT DEFAULT 1)
GO
