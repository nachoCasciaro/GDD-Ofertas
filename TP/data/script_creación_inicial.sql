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

--DROP SP CONSUMIR OFERTA

IF OBJECT_ID ('POR_COLECTORA.sp_consumir_oferta') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_consumir_oferta

--DROP SP FACTURAR A PROVEEDOR

IF OBJECT_ID ('POR_COLECTORA.sp_facturar_a_proveedor') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_facturar_a_proveedor

--DROP SP FACTURAR A PROVEEDOR LISTADO

IF OBJECT_ID ('POR_COLECTORA.sp_facturar_a_proveedor_listado') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_facturar_a_proveedor_listado

--DROP SP FILTRAR CLIENTES

IF OBJECT_ID ('POR_COLECTORA.sp_filtrar_clientes') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_filtrar_clientes

--DROP FUNCTION EXISTE USUARIO

IF OBJECT_ID ('POR_COLECTORA.fn_existe_usuario') IS NOT NULL
DROP FUNCTION POR_COLECTORA.fn_existe_usuario

--DROP SP ALTA USUARIO

IF OBJECT_ID ('POR_COLECTORA.sp_alta_usuario') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_alta_usuario

--DROP SP ALTA ROL

IF OBJECT_ID ('POR_COLECTORA.sp_alta_rol') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_alta_rol

--DROP SP AGREGAR FUNCIONALIDAD A ROL

IF OBJECT_ID ('POR_COLECTORA.sp_agregar_funcionalidad_a_rol') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_agregar_funcionalidad_a_rol

--DROP SP OFERTAS VIGENTES

IF OBJECT_ID ('POR_COLECTORA.sp_ofertas_vigentes') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_ofertas_vigentes

--DROP SP FILTRAR PROVEEDORES

IF OBJECT_ID ('POR_COLECTORA.sp_filtrar_proveedores') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_filtrar_proveedores


--DROP SP BAJA ROL

IF OBJECT_ID ('POR_COLECTORA.sp_baja_rol') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_baja_rol


--DROP SP MODIFICAR NOMBRE ROL

IF OBJECT_ID ('POR_COLECTORA.sp_modificar_nombre_rol') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_modificar_nombre_rol

--DROP SP QUITA ROL USUARIOS

IF OBJECT_ID ('POR_COLECTORA.sp_quitar_rol_a_usuarios') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_quitar_rol_a_usuarios

--DROP SP ELIMINAR FUNCIONALIDAD ROL

IF OBJECT_ID ('POR_COLECTORA.sp_eliminar_funcionalidad_rol') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_eliminar_funcionalidad_rol


--DROP SP ELIMINAR HABILITAR ROL

IF OBJECT_ID ('POR_COLECTORA.sp_habilitar_rol') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_habilitar_rol

--DROP SP MOSTRAR ROLES

IF OBJECT_ID ('POR_COLECTORA.sp_mostrar_roles') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_mostrar_roles


--DROP SP MOSTRAR FUNCIONALIDADES ROL

IF OBJECT_ID ('POR_COLECTORA.sp_mostrar_funcionalidades_rol') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_mostrar_funcionalidades_rol

--DROP SP LOGIN

IF OBJECT_ID ('POR_COLECTORA.sp_login') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_login


--DROP SP OBTENER ID CLIENTE

IF OBJECT_ID ('POR_COLECTORA.sp_obtener_id_cliente') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_obtener_id_cliente

--DROP SP OBTENER ID PROVEEDOR

IF OBJECT_ID ('POR_COLECTORA.sp_obtener_id_proveedor') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_obtener_id_proveedor

--DROP SP CARGA CREDITO EFECTIVO

IF OBJECT_ID ('POR_COLECTORA.sp_carga_credito_efectivo') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_carga_credito_efectivo


--DROP SP ROL POSEE FUNCIONALIDAD

IF OBJECT_ID ('POR_COLECTORA.sp_rol_posee_funcionalidad') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_rol_posee_funcionalidad

--DROP SP CAMBIAR CONTRASEÑA USER

IF OBJECT_ID ('POR_COLECTORA.sp_cambiar_contraseña_user') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_cambiar_contraseña_user


--DROP SP BAJA USUARIO

IF OBJECT_ID ('POR_COLECTORA.sp_baja_usuario') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_baja_usuario

--DROP SP OBTENER ID USER

IF OBJECT_ID ('POR_COLECTORA.sp_obtener_id_user') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_obtener_id_user


--DROP SP MOSTRAR USUARIOS

IF OBJECT_ID ('POR_COLECTORA.sp_mostrar_usuarios') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_mostrar_usuarios


--DROP SP CLIENTE ESTA HABILITADO

IF OBJECT_ID ('POR_COLECTORA.sp_cliente_esta_habilitado') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_cliente_esta_habilitado


--DROP SP USER ES ADMIN

IF OBJECT_ID ('POR_COLECTORA.sp_user_es_admin') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_user_es_admin


--DROP SP PROVEEDOR ESTA HABILITADO

IF OBJECT_ID ('POR_COLECTORA.sp_proveedor_esta_habilitado') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_proveedor_esta_habilitado

--DROP SP EXISTE PROVEEDOR

IF OBJECT_ID ('POR_COLECTORA.sp_existe_proveedor') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_existe_proveedor


--DROP SP USER POSEE ROL CLIENTE

IF OBJECT_ID ('POR_COLECTORA.sp_user_posee_rol_cliente') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_user_posee_rol_cliente


--DROP SP USER POSEE ROL PROVEEDOR

IF OBJECT_ID ('POR_COLECTORA.sp_user_posee_rol_proveedor') IS NOT NULL
DROP PROCEDURE POR_COLECTORA.sp_user_posee_rol_proveedor


GO

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'POR_COLECTORA')
BEGIN
	EXEC ('CREATE SCHEMA [POR_COLECTORA] AUTHORIZATION gdCupon2019')
END
GO

--			FIN DROPEO 


--			INICIO CREACION TABLAS

--CREACIÓN DE TABLA DIRECCIONES

CREATE TABLE POR_COLECTORA.Direcciones(
	Direccion_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Direccion_Calle NVARCHAR(250) NOT NULL,
	Direccion_Nro_Piso NVARCHAR(50),
	Direccion_Depto NVARCHAR(50),
	Direccion_Ciudad NVARCHAR(250) NOT NULL)
GO

--CREACIÓN DE TABLA USUARIOS

CREATE TABLE POR_COLECTORA.Usuarios(
	Usuario_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Usuario_Nombre VARCHAR(250) NOT NULL,
	Usuario_Password BINARY(32) NOT NULL,
	Usuario_Intentos TINYINT NOT NULL DEFAULT 0,
	Usuario_Habilitado BIT NOT NULL DEFAULT 1)
GO

--CREACIÓN DE TABLA CLIENTES

CREATE TABLE POR_COLECTORA.Clientes(
	Clie_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Clie_Nombre NVARCHAR(250) NOT NULL,
	Clie_Apellido NVARCHAR(250) NOT NULL,
	Clie_DNI Numeric(18,0) NOT NULL UNIQUE,
	Clie_Mail NVARCHAR(250) NOT NULL,
	Clie_Telefono Numeric(18,0) NOT NULL,
	Clie_Direccion Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Direcciones(Direccion_Id),
	Clie_CP NVARCHAR(50),
	Clie_Fecha_Nac DATETIME NOT NULL,
	Clie_Habilitado BIT NOT NULL DEFAULT 1,
	Clie_Saldo Numeric(18,0) NOT NULL DEFAULT 200,
	Clie_Usuario Numeric FOREIGN KEY REFERENCES POR_COLECTORA.Usuarios(Usuario_Id))
GO

--CREACIÓN DE TABLA ROLES

CREATE TABLE POR_COLECTORA.Roles(
	Rol_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Rol_Nombre NVARCHAR(50) NOT NULL,
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
	Func_Descripcion NVARCHAR(250) NOT NULL)
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
	Provee_RS NVARCHAR(250) UNIQUE NOT NULL,
	Provee_Mail NVARCHAR(250),
	Provee_Telefono Numeric NOT NULL,
	Provee_CUIT NVARCHAR(13) UNIQUE NOT NULL,
	Provee_Direccion Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Direcciones(Direccion_Id),
	Provee_CP NVARCHAR(50),
	Provee_Rubro Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Rubros(Rubro_Id),
	Provee_Nombre_Contacto NVARCHAR(250),
	Provee_Usuario Numeric FOREIGN KEY REFERENCES POR_COLECTORA.Usuarios(Usuario_Id),
	Provee_Habilitado BIT NOT NULL DEFAULT 1)
GO

--CREACIÓN DE TABLA FACTURAS

CREATE TABLE POR_COLECTORA.Facturas(
	Fact_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Fact_Numero Numeric NOT NULL,
	Fact_Fecha_Desde DATETIME NOT NULL,
	Fact_Fecha_Hasta DATETIME NOT NULL,
	Fact_Importe numeric NOT NULL,
	Fact_Proveedor_ID Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Proveedores(Provee_Id),
	Fact_Proveedor_CUIT NVARCHAR(13) NOT NULL,
	Fact_Proveedor_RS NVARCHAR(250) NOT NULL)
GO

--CREACIÓN DE TABLA OFERTAS

CREATE TABLE POR_COLECTORA.Ofertas(
	Oferta_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Oferta_Codigo NVARCHAR(250) NOT NULL,
	Oferta_Descripcion NVARCHAR(250) NOT NULL,
	Oferta_Fecha DATETIME NOT NULL,
	Oferta_Fecha_Venc DATETIME NOT NULL,
	Oferta_Precio numeric NOT NULL,
	Oferta_Precio_Ficticio numeric NOT NULL,
	Oferta_Cantidad numeric NOT NULL,
	Oferta_Restriccion_Compra numeric,
	Oferta_Proveedor Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Proveedores(Provee_Id))
GO

--CREACIÓN DE TABLA COMPRAS

CREATE TABLE POR_COLECTORA.Compras(
	Compra_Nro Numeric IDENTITY(1,1) PRIMARY KEY,
	Compra_Cliente Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Clientes(Clie_Id),
	Compra_Oferta Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Ofertas(Oferta_Id),
	Compra_Cantidad numeric NOT NULL,
	Compra_Fecha DATETIME NOT NULL,
	Compra_Id_Factura Numeric FOREIGN KEY REFERENCES POR_COLECTORA.Facturas(Fact_Id),
	Compra_Oferta_Precio numeric NOT NULL)
GO

--CREACIÓN DE TABLA CUPONES

CREATE TABLE POR_COLECTORA.Cupones(
	Cupon_Id Numeric IDENTITY(1,1) PRIMARY KEY,
	Cupon_Codigo nvarchar(250) NOT NULL,
	Cupon_Fecha_Venc DATETIME ,
	Cupon_Fecha_Consumo DATETIME,
	Cupon_Nro_Compra Numeric NOT NULL FOREIGN KEY REFERENCES POR_COLECTORA.Compras(Compra_Nro),
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
	Carga_Tipo_Pago nvarchar(50) NOT NULL, 
	Carga_Monto NUMERIC(18,0) NOT NULL,
	Carga_Id_Tarjeta Numeric FOREIGN KEY REFERENCES POR_COLECTORA.Tarjetas(Tarjeta_Id))
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

--MIGRACION TABLA CLIENTES

INSERT INTO POR_COLECTORA.Clientes
(Clie_Nombre, Clie_Apellido, Clie_DNI, Clie_Telefono, Clie_Mail, Clie_Fecha_Nac, Clie_Direccion)
SELECT DISTINCT Cli_Nombre, Cli_Apellido, Cli_Dni, Cli_Telefono, Cli_Mail, Cli_Fecha_Nac,
				(SELECT Direccion_Id FROM POR_COLECTORA.Direcciones WHERE Direccion_Calle = Cli_Direccion)
FROM gd_esquema.Maestra


--MIGRACION TABLA ROLES

INSERT INTO POR_COLECTORA.Roles
( Rol_Nombre )
 VALUES ('Administrador General'),('Cliente'),('Proveedor')

--INSERTO EL USUARIO ADMIN

DECLARE @password [varchar](250)
SET @password = 'w23e'

INSERT INTO POR_COLECTORA.Usuarios(Usuario_Nombre,Usuario_Password)
VALUES ('admin', HASHBYTES('SHA2_256', @password))
GO

--INSERTO EL USUARIO ADMIN EN ROLxUSUARIO

DECLARE @codigo_rol_administrador numeric
SET @codigo_rol_administrador= (SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador General')

INSERT INTO POR_COLECTORA.RolxUsuario(Id_Usuario, Id_Rol)
VALUES ((SELECT Usuario_Id FROM POR_COLECTORA.Usuarios WHERE Usuario_Nombre = 'admin'), @codigo_rol_administrador)
GO

--MIGRACION FUNCIONALIDADES

INSERT INTO POR_COLECTORA.Funcionalidades(Func_Descripcion)
VALUES	 ('ABM Rol'), 
		('ABM Cliente'), ('ABM Proveedor'), ('Cargar Crédito'),
		('Comprar Oferta'), ('Confección y publicación de Ofertas'),
		('Entrega/Consumo de Oferta'), ('Facturación a Proveedor'), ('Listado Estadistico');
GO

--MIGRACION FUNCIONALIDADxROL

INSERT INTO POR_COLECTORA.FuncionalidadxRol(Id_Rol, Id_Func)
VALUES ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador General'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'ABM Rol')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador General'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'ABM Cliente')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador General'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'ABM Proveedor')), 
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Cliente'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Cargar Crédito')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Proveedor'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Confección y publicación de Ofertas')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Cliente'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Comprar Oferta')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Proveedor'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Entrega/Consumo de Oferta')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador General'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Facturación a Proveedor')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador General'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Cargar Crédito')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador General'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Confección y publicación de Ofertas')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador General'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Comprar Oferta')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador General'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Entrega/Consumo de Oferta')),
	   ((SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = 'Administrador General'), (SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = 'Listado Estadistico'));
GO

--MIGRACION TABLA RUBROS

INSERT INTO POR_COLECTORA.Rubros
(Rubro_Detalle)
SELECT DISTINCT Provee_Rubro
FROM gd_esquema.Maestra
where Provee_Rubro is not null

--MIGRACION TABLA PROVEEDORES

INSERT INTO POR_COLECTORA.Proveedores
(Provee_RS, Provee_Telefono, Provee_CUIT, Provee_Direccion, Provee_Rubro)
SELECT DISTINCT Maestra.Provee_RS, Maestra.Provee_Telefono, Maestra.Provee_CUIT, 
				(SELECT Direccion_Id FROM POR_COLECTORA.Direcciones WHERE Direccion_Calle = Maestra.Provee_Dom), 
				(SELECT Rubro_Id FROM POR_COLECTORA.Rubros WHERE Rubro_Detalle = Maestra.Provee_Rubro)
FROM gd_esquema.Maestra as Maestra
where Maestra.Provee_RS is not null

--MIGRACION TABLA OFERTAS

INSERT INTO POR_COLECTORA.Ofertas
(Oferta_Codigo,Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio,
	Oferta_Cantidad, Oferta_Proveedor)
SELECT DISTINCT SUBSTRING(Maestra.Oferta_Codigo,1,10),
				Maestra.Oferta_Descripcion, Maestra.Oferta_Fecha, Maestra.Oferta_Fecha_Venc, Maestra.Oferta_Precio, Maestra.Oferta_Precio_Ficticio, Maestra.Oferta_Cantidad,
				(SELECT Colectora.Provee_Id FROM POR_COLECTORA.Proveedores As Colectora WHERE Colectora.Provee_RS = Maestra.Provee_RS)
FROM gd_esquema.Maestra As Maestra
where Maestra.Oferta_Descripcion is not null

--MIGRACION FACTURAS

INSERT INTO POR_COLECTORA.Facturas
	(Fact_Numero,Fact_Fecha_Desde,Fact_Fecha_Hasta,Fact_Importe, Fact_Proveedor_ID,Fact_Proveedor_CUIT,Fact_Proveedor_RS )
SELECT DISTINCT Maestra.Factura_Nro,min(Maestra.Oferta_Fecha_Compra),Maestra.Factura_Fecha,
	SUM(Maestra.Oferta_Precio),
	(SELECT Colectora.Provee_Id FROM POR_COLECTORA.Proveedores As Colectora WHERE Colectora.Provee_RS = Maestra.Provee_RS),
	(SELECT Colectora.Provee_CUIT FROM POR_COLECTORA.Proveedores As Colectora WHERE Colectora.Provee_RS = Maestra.Provee_RS),
	(SELECT Colectora.Provee_RS FROM POR_COLECTORA.Proveedores As Colectora WHERE Colectora.Provee_RS = Maestra.Provee_RS)
FROM gd_esquema.Maestra Maestra
where Maestra.Factura_Nro is not null 
GROUP BY Maestra.Factura_Nro, Maestra.Factura_Fecha, Maestra.Provee_RS

--MIGRACION CARGAS

INSERT INTO POR_COLECTORA.Cargas
(Carga_Fecha, Carga_Id_Cliente, Carga_Tipo_Pago, Carga_Monto)
SELECT DISTINCT Maestra.Carga_fecha, (SELECT Colectora.Clie_Id FROM POR_COLECTORA.Clientes AS Colectora WHERE Colectora.Clie_DNI = Maestra.Cli_Dni and Maestra.Cli_Dni is not null),
				Maestra.Tipo_Pago_Desc,Maestra.Carga_Credito 
FROM gd_esquema.Maestra AS Maestra
where Maestra.Carga_Fecha is not null


--MIGRACION COMPRAS 

INSERT INTO POR_COLECTORA.Compras
(Compra_Cliente,Compra_Oferta,Compra_Cantidad,Compra_Fecha,Compra_Id_Factura,Compra_Oferta_Precio)
SELECT DISTINCT (SELECT Colectora.Clie_Id FROM POR_COLECTORA.Clientes As Colectora WHERE Colectora.Clie_DNI = Maestra.Cli_Dni), 
				(select Colectora.Oferta_Id from POR_COLECTORA.Ofertas As Colectora where Colectora.Oferta_Codigo = SUBSTRING(Maestra.Oferta_Codigo,1,10)),
				1,Maestra.Oferta_Fecha_Compra,
				(SELECT Colectora.Fact_Id FROM POR_COLECTORA.Facturas AS Colectora WHERE Colectora.Fact_Numero = Maestra.Factura_Nro),
				Maestra.Oferta_Precio
FROM gd_esquema.Maestra As Maestra
where Maestra.Oferta_Descripcion is not null and Maestra.Factura_Fecha is not null


--MIGRACION CUPONES 

INSERT INTO POR_COLECTORA.Cupones
(Cupon_Fecha_Venc, Cupon_Codigo,Cupon_Fecha_Consumo,Cupon_Id_Cliente_Consumidor,Cupon_Nro_Compra)
SELECT Maestra.Oferta_Fecha_Venc,
			    CONCAT( Oferta_Codigo, (SELECT Clie_Id FROM POR_COLECTORA.Clientes AS Colectora WHERE Colectora.Clie_DNI = Maestra.Cli_Dni)),
				Maestra.Oferta_Fecha_Compra,
				(SELECT Colectora.Clie_Id FROM POR_COLECTORA.Clientes AS Colectora WHERE Colectora.Clie_DNI = Maestra.Cli_Dni),
				(select Compra_Nro from POR_COLECTORA.Compras where
																Compra_Fecha = Maestra.Oferta_Fecha_Compra
																and Compra_Oferta = (select Colectora.Oferta_Id from POR_COLECTORA.Ofertas As Colectora where Colectora.Oferta_Codigo = SUBSTRING(Maestra.Oferta_Codigo,1,10))
																and Compra_Cliente = (SELECT Clie_Id FROM POR_COLECTORA.Clientes WHERE Clie_DNI = Maestra.Cli_Dni)
																and Compra_Id_Factura = (select Fact_Id from POR_COLECTORA.Facturas where Maestra.Factura_Nro = Fact_Numero))
FROM gd_esquema.Maestra AS Maestra
where Maestra.Factura_Nro is not null


--ACTUALIZO EL SALDO DEL ÚNICO CLIENTE QUE REALIZÓ CARGAS

UPDATE POR_COLECTORA.Clientes
SET Clie_Saldo += (select sum(Carga_Monto) from POR_COLECTORA.Cargas)
WHERE Clie_DNI = 83183632


--LE CREO UN USUARIO A CADA CLIENTE 

DECLARE cursor_clientes CURSOR FOR
SELECT Clie_Nombre,Clie_Apellido,Clie_DNI
FROM POR_COLECTORA.Clientes

DECLARE @nombre nvarchar(250)
DECLARE @apellido nvarchar(250)
DECLARE @dni Numeric(18,0)
OPEN cursor_clientes
FETCH NEXT FROM cursor_clientes INTO @nombre,@apellido,@dni

WHILE @@FETCH_STATUS = 0
	BEGIN

	declare @hash_pass BINARY(32)
	set @hash_pass = HASHBYTES('SHA2_256',CAST(@dni AS varchar(18)))
	
	INSERT INTO POR_COLECTORA.Usuarios (Usuario_Nombre,Usuario_Password)
	VALUES (@nombre + '_' + @apellido, @hash_pass)

	UPDATE POR_COLECTORA.Clientes
	SET Clie_Usuario = (select Usuario_Id from POR_COLECTORA.Usuarios where Usuario_Nombre = (@nombre + '_' + @apellido) )
	where Clie_DNI = @dni

	declare @idUser numeric
	set @idUser = (select Usuario_Id from POR_COLECTORA.Usuarios where Usuario_Nombre = (@nombre + '_' + @apellido))

	INSERT INTO POR_COLECTORA.RolxUsuario (Id_Rol,Id_Usuario)
	VALUES (2,@idUser)

	FETCH NEXT FROM cursor_clientes INTO @nombre,@apellido,@dni
	END
CLOSE cursor_clientes
DEALLOCATE cursor_clientes
GO

--LE CREO UN USUARIO A CADA PROVEEDOR

DECLARE cursor_proveedores CURSOR FOR
SELECT Provee_RS,Provee_CUIT
FROM POR_COLECTORA.Proveedores

DECLARE @rs nvarchar(250)
DECLARE @cuit NVARCHAR(13)

OPEN cursor_proveedores
FETCH NEXT FROM cursor_proveedores INTO @rs,@cuit

WHILE @@FETCH_STATUS = 0
	BEGIN

	declare @hash_pass BINARY(32)
	set @hash_pass = HASHBYTES('SHA2_256',cast(@cuit as varchar(13)) )
	
	INSERT INTO POR_COLECTORA.Usuarios (Usuario_Nombre,Usuario_Password)
	VALUES (@rs, @hash_pass)

	UPDATE POR_COLECTORA.Proveedores
	SET Provee_Usuario = (select Usuario_Id from POR_COLECTORA.Usuarios where Usuario_Nombre = @rs )
	where Provee_CUIT = @cuit

	declare @idUser numeric
	set @idUser = (select Usuario_Id from POR_COLECTORA.Usuarios where Usuario_Nombre = @rs)

	INSERT INTO POR_COLECTORA.RolxUsuario (Id_Rol,Id_Usuario)
	VALUES (3,@idUser)

	FETCH NEXT FROM cursor_proveedores INTO @rs,@cuit
	END
CLOSE cursor_proveedores
DEALLOCATE cursor_proveedores

GO

--FIN MIGRACIONES


--CREACION DE OBJETOS

CREATE FUNCTION POR_COLECTORA.fn_existe_usuario (@username VARCHAR(250))
RETURNS BIT 
AS BEGIN
	IF ((SELECT COUNT(*) FROM POR_COLECTORA.Usuarios WHERE Usuario_Nombre = @username) = 1)
		RETURN 1
	RETURN 0
END
GO

CREATE PROCEDURE POR_COLECTORA.sp_alta_usuario(
@username varchar(250),
@password varchar(250),
@resultado bit output
)
AS
BEGIN
	

	IF ( POR_COLECTORA.fn_existe_usuario(@username) = 0 )
	BEGIN
		INSERT INTO POR_COLECTORA.Usuarios(Usuario_Nombre,Usuario_Password) values (@username,HASHBYTES('SHA2_256', @password))
		set @resultado = 1
	END
	ELSE
	BEGIN
		set @resultado = 0
	END
END
GO

CREATE PROCEDURE POR_COLECTORA.sp_baja_usuario(
@username varchar(250)
)
AS
BEGIN
	
	update POR_COLECTORA.Usuarios
	set Usuario_Habilitado = 0
	where Usuario_Nombre = @username

END
GO


CREATE PROCEDURE POR_COLECTORA.sp_alta_cliente (
@username nvarchar(250),
@nombre nvarchar(250),
@apellido nvarchar(250),
@dni numeric (18,0),
@mail nvarchar(250),
@telefono numeric(18,0),
@direCalle nvarchar(250),
@nroPiso nvarchar(50),
@depto nvarchar(50),
@ciudad nvarchar(250),
@CP nvarchar(50),
@fechaNacimiento datetime
)
AS
BEGIN

	declare @user_id numeric
	set @user_id = (select Usuario_Id from Usuarios where Usuario_Nombre = @username)

	IF not exists (select 1 from POR_COLECTORA.Direcciones where Direccion_Calle = @direCalle and Direccion_Nro_Piso = @nroPiso and Direccion_Depto = @depto and Direccion_Ciudad = @ciudad) 
		BEGIN
			INSERT INTO POR_COLECTORA.Direcciones (Direccion_Calle,Direccion_Nro_Piso,Direccion_Depto, Direccion_Ciudad) VALUES (@direCalle,@nroPiso,@depto,@ciudad)
		END

	declare @dire_id numeric
	set @dire_id = (select Direccion_Id from Direcciones where Direccion_Calle = @direCalle and Direccion_Nro_Piso = @nroPiso and Direccion_Depto = @depto and Direccion_Ciudad = @ciudad)
	
	INSERT INTO POR_COLECTORA.Clientes (Clie_Nombre,Clie_Apellido,Clie_DNI,Clie_Mail,Clie_Telefono,Clie_Direccion,Clie_CP,Clie_Fecha_Nac, Clie_Usuario) 
	VALUES (@nombre,@apellido,@dni,@mail,@telefono,@dire_id,@CP,@fechaNacimiento,@user_id)

	INSERT INTO POR_COLECTORA.RolxUsuario(Id_Rol,Id_Usuario)
	VALUES (2,@user_id)
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
@nombre nvarchar(250),
@apellido nvarchar(250),
@dni numeric (18,0),
@mail nvarchar(250),
@telefono numeric(18,0),
@direCalle nvarchar(250),
@nroPiso nvarchar(50),
@depto nvarchar(50),
@ciudad nvarchar(250),
@CP nvarchar(50),
@fechaNacimiento datetime,
@habilitar bit
)
AS
BEGIN

	UPDATE POR_COLECTORA.Direcciones
	SET Direccion_Calle = @direCalle, Direccion_Nro_Piso = @nroPiso, Direccion_Depto = @depto, Direccion_Ciudad = @ciudad
	WHERE Direccion_Id = (select Clie_Direccion from Clientes where Clie_Id = @id_clie)

	UPDATE POR_COLECTORA.Clientes
	SET Clie_Nombre = @nombre, Clie_Apellido = @apellido, Clie_DNI = @dni, Clie_Mail = @mail, Clie_Telefono = @telefono, Clie_CP = @CP, Clie_Fecha_Nac = @fechaNacimiento, Clie_Habilitado = @habilitar
	WHERE Clie_Id = @id_clie;
	
END

GO

CREATE PROCEDURE POR_COLECTORA.sp_alta_proveedor (
@username varchar(250),
@razonSocial nvarchar(250),
@mail nvarchar(250),
@telefono numeric(18,0),
@direCalle nvarchar(250),
@nroPiso nvarchar(50),
@depto nvarchar(50),
@ciudad nvarchar(250),
@CP nvarchar(50),
@cuit nvarchar(13),
@nombreContacto nvarchar(250),
@rubro nvarchar(50)
)
AS
BEGIN

	declare @user_id numeric
	set @user_id = (select Usuario_Id from Usuarios where Usuario_Nombre = @username)

	IF not exists (select 1 from POR_COLECTORA.Direcciones where Direccion_Calle = @direCalle and Direccion_Nro_Piso = @nroPiso and Direccion_Depto = @depto and Direccion_Ciudad = @ciudad) 
		BEGIN
			INSERT INTO POR_COLECTORA.Direcciones (Direccion_Calle,Direccion_Nro_Piso,Direccion_Depto, Direccion_Ciudad) VALUES (@direCalle,@nroPiso,@depto,@ciudad)
		END

	declare @dire_id numeric
	set @dire_id = (select Direccion_Id from Direcciones where Direccion_Calle = @direCalle and Direccion_Nro_Piso = @nroPiso and Direccion_Depto = @depto and Direccion_Ciudad = @ciudad)
	
	declare @rubro_id numeric
	set @rubro_id = (select Rubro_Id from POR_COLECTORA.Rubros where Rubro_Detalle = @rubro) 

	INSERT INTO POR_COLECTORA.Proveedores(Provee_RS,Provee_Mail,Provee_Telefono,Provee_Direccion,Provee_CP,Provee_CUIT,Provee_Nombre_Contacto,Provee_Rubro,Provee_Usuario) 
	VALUES (@razonSocial,@mail,@telefono,@dire_id,@CP,@cuit,@nombreContacto,@rubro_id,@user_id)

	INSERT INTO POR_COLECTORA.RolxUsuario(Id_Rol,Id_Usuario)
	VALUES (3,@user_id)

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
@razonSocial nvarchar(250),
@mail nvarchar(250),
@telefono numeric(18,0),
@direCalle nvarchar(250),
@nroPiso nvarchar(50),
@depto nvarchar(50),
@ciudad nvarchar(250),
@CP nvarchar(50),
@cuit nvarchar(13),
@nombreContacto nvarchar(250),
@rubro_detalle nvarchar(50),
@habilitar bit
)
AS
BEGIN

	declare @rubro_id numeric
	set @rubro_id = (select Rubro_Id from POR_COLECTORA.Rubros where Rubro_Detalle = @rubro_detalle) 


	UPDATE POR_COLECTORA.Direcciones
	SET Direccion_Calle = @direCalle, Direccion_Nro_Piso = @nroPiso, Direccion_Depto = @depto, Direccion_Ciudad = @ciudad
	WHERE Direccion_Id = (select Provee_Direccion from Proveedores where Provee_Id = @id_prove)

	UPDATE POR_COLECTORA.Proveedores
	SET Provee_RS = @razonSocial, Provee_Mail = @mail, Provee_Telefono = @telefono, Provee_CP = @CP, Provee_CUIT = @cuit, Provee_Nombre_Contacto = @nombreContacto, Provee_Rubro = @rubro_id, Provee_Habilitado = @habilitar
	WHERE Provee_Id = @id_prove;
	
END

GO

CREATE PROCEDURE POR_COLECTORA.sp_carga_credito (
@id_cliente numeric,
@fecha_carga datetime, 
@monto numeric,
@tipo_tarjeta nvarchar(50),
@numero_tarjeta numeric,
@fecha_venc datetime
)

AS
BEGIN

	IF not exists (select 1 from POR_COLECTORA.Tarjetas where Tarjeta_Tipo = @tipo_tarjeta and Tarjeta_Fecha_Venc = @tipo_tarjeta and Tarjeta_Id_Cliente = @id_cliente) 
		BEGIN
			INSERT INTO POR_COLECTORA.Tarjetas (Tarjeta_Numero,Tarjeta_Tipo,Tarjeta_Fecha_Venc, Tarjeta_Id_Cliente) VALUES (@numero_tarjeta,@tipo_tarjeta,@fecha_venc,@id_cliente)
		END

	declare @id_tarjeta numeric
	set @id_tarjeta = (select Tarjeta_Id from Tarjetas where Tarjeta_Id_Cliente = @id_cliente and Tarjeta_Numero = @numero_tarjeta)

	
	INSERT INTO POR_COLECTORA.Cargas(Carga_Fecha,Carga_Id_Cliente,Carga_Monto,Carga_Tipo_Pago,Carga_Id_Tarjeta) 
	VALUES (@fecha_carga,@id_cliente,@monto,@tipo_tarjeta,@id_tarjeta)

	UPDATE POR_COLECTORA.Clientes
	SET Clie_Saldo = Clie_Saldo + @monto
	WHERE Clie_Id = @id_cliente;

END

GO

CREATE PROCEDURE POR_COLECTORA.sp_carga_credito_efectivo (
@id_cliente numeric,
@fecha_carga datetime, 
@monto numeric
)
AS
BEGIN

	
	INSERT INTO POR_COLECTORA.Cargas(Carga_Fecha,Carga_Id_Cliente,Carga_Monto,Carga_Tipo_Pago) 
	VALUES (@fecha_carga,@id_cliente,@monto,'Efectivo')

	UPDATE POR_COLECTORA.Clientes
	SET Clie_Saldo = Clie_Saldo + @monto
	WHERE Clie_Id = @id_cliente;

END

GO




--TOP 5 de proveedores con mayor porcentaje de descuento ofrecido en sus ofertas en forma descendente por monto
--La pantalla debe permitirnos seleccionar el semestre

CREATE PROCEDURE POR_COLECTORA.sp_prov_mas_descuento (@semestre int, @anio int)
AS
BEGIN

	SELECT TOP 5 Provee_RS AS RAZON_SOCIAL_PROVEEDOR, 
	(select Rubro_Detalle
	from Rubros
	where Rubro_Id = Provee_Rubro)
	 AS RUBRO, 
	AVG(Oferta_Precio_Ficticio - Oferta_Precio) AS PORCENTAJE_PROMEDIO_OFERTA
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
CREATE PROCEDURE POR_COLECTORA.sp_prov_mayor_facturacion (@semestre int, @anio int)
AS
BEGIN

	SELECT TOP 5 Provee_RS AS RAZON_SOCIAL_PROVEEDOR,
	 (select Rubro_Detalle
	from Rubros
	where Rubro_Id = Provee_Rubro) AS RUBRO,
	AVG(Fact_Importe) AS PROMEDIO_FACTURACION
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
@descripcion nvarchar(250), 
@fecha DateTime, 
@fecha_venc DateTime, 
@precio_oferta numeric, 
@precio_original numeric, 
@stock numeric, 
@max_compra numeric)


AS
BEGIN

	declare @oferta_codigo nvarchar(250)
	set @oferta_codigo = SUBSTRING(CONVERT(nvarchar(250), NEWID()), 0, 9)
	WHILE (SELECT COUNT(*) FROM Ofertas WHERE Oferta_Codigo = @oferta_codigo) = 1 --Este while checkearia si el string autogenerado no se repite
	BEGIN
	IF (SELECT COUNT(*) FROM Ofertas WHERE Oferta_Codigo = @oferta_codigo) = 0
		BREAK
	ELSE
		set @oferta_codigo = SUBSTRING(CONVERT(nvarchar(250), NEWID()), 0, 9)
	END
	
	INSERT INTO POR_COLECTORA.Ofertas(Oferta_Codigo,Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio, Oferta_Cantidad, Oferta_Restriccion_Compra, Oferta_Proveedor) 
	VALUES (@oferta_codigo,@descripcion, @fecha, @fecha_venc, @precio_oferta, @precio_original, @stock, @max_compra,@id_prove)

END

GO

--SP COMPRA OFERTA 

CREATE PROCEDURE POR_COLECTORA.sp_comprar_oferta(
@id_oferta numeric,
@id_cliente numeric,
@fecha_compra datetime,
@cantidad_compra numeric,
@resultado_compra varchar(250) output
)

AS
BEGIN
	
	declare @precio_oferta numeric
	set @precio_oferta = (select Oferta_Precio from Ofertas where Oferta_Id = @id_oferta)

	declare @cantidad_maxima numeric
	set @cantidad_maxima = (select isnull( Oferta_Restriccion_Compra, 100 ) from Ofertas where Oferta_Id = @id_oferta)

	declare @numero_compra numeric
	set @numero_compra = (SELECT TOP 1 Compra_Nro from Compras ORDER BY Compra_Nro DESC) + 1


	declare @numeroCupon numeric
	declare @cupon_codigo nvarchar(250)


	if((SELECT Clie_Saldo FROM Clientes WHERE Clie_Id = @id_cliente) < (@precio_oferta * @cantidad_compra))
	BEGIN
		set @resultado_compra = 1
	END

	if(((SELECT isnull( SUM(Compra_Cantidad), 0) FROM Compras WHERE Compra_Oferta = @id_oferta AND Compra_Cliente = @id_cliente) + @cantidad_compra) > @cantidad_maxima)
	BEGIN
		set @resultado_compra = 2
	END

	if( @cantidad_compra > (select Oferta_Cantidad from Ofertas where Oferta_Id = @id_oferta)  )
	BEGIN
		set @resultado_compra = 3
	END

	if ((SELECT Clie_Saldo FROM Clientes WHERE Clie_Id = @id_cliente) >= @precio_oferta * @cantidad_compra
		AND ((SELECT  isnull( SUM(Compra_Cantidad),0) FROM Compras WHERE Compra_Oferta = @id_oferta and Compra_Cliente = @id_cliente) + @cantidad_compra) <=  @cantidad_maxima
		AND @cantidad_compra <= (select Oferta_Cantidad from Ofertas where Oferta_Id = @id_oferta))
		begin
			INSERT INTO POR_COLECTORA.Compras(Compra_Fecha, Compra_Oferta, Compra_Cliente, Compra_Cantidad, Compra_Oferta_Precio) 
			VALUES (@fecha_compra,@id_oferta,@id_cliente,@cantidad_compra,@precio_oferta)

			DECLARE @i INT = 0;

			WHILE @i < @cantidad_compra
			BEGIN
				
				
				set @numeroCupon = (select count(*) from Cupones) + 1
						
				set @cupon_codigo = CONCAT((select Oferta_Codigo from Ofertas where Oferta_Id = @id_oferta), @numeroCupon)


				INSERT INTO POR_COLECTORA.Cupones(Cupon_Codigo,Cupon_Fecha_Venc,Cupon_Fecha_Consumo,Cupon_Nro_Compra,Cupon_Id_Cliente_Consumidor)
				VALUES (@cupon_codigo, dateadd(day,30, @fecha_compra), NULL, @numero_compra,@id_cliente)

				SET @i += 1
			END

			UPDATE Clientes
			set Clie_Saldo -= @precio_oferta * @cantidad_compra
			where Clie_Id = @id_cliente

			UPDATE Ofertas
			set Oferta_Cantidad -= @cantidad_compra
			where Oferta_Id = @id_oferta 

			set @resultado_compra = 0
		end	

	set @resultado_compra = convert(varchar(1),@resultado_compra) + ' ' + convert(varchar(248),@numero_compra) 
	

END

GO


--SP CONSUMO OFERTA 
CREATE PROCEDURE POR_COLECTORA.sp_consumir_oferta(
@codigo_cupon nvarchar(250),
@fecha_consumo datetime,
@id_proveedor numeric,
@id_cliente numeric,
@resultado int output
)

AS
BEGIN

	if( (select Cupon_Fecha_Venc from Cupones where Cupon_Codigo = @codigo_cupon) < @fecha_consumo )
	begin
		set @resultado = -1
	end

	if ( (select Cupon_Fecha_Consumo from Cupones where Cupon_Codigo = @codigo_cupon) IS  NOT NULL )
	BEGIN
		set @resultado = -2
	END

	if ( (select Provee_ID from Proveedores P
					JOIN Ofertas O
						ON P.Provee_id = O.Oferta_Proveedor
					JOIN Compras C
						ON O.Oferta_Id = C.Compra_Oferta
					JOIN Cupones CU
						ON C.Compra_Nro = CU.Cupon_Nro_Compra
					where CU.Cupon_Codigo = @codigo_cupon) <> @id_proveedor) 
	begin
		set @resultado = -3
	end
	

	if ( (select Cupon_Fecha_Venc from Cupones where Cupon_Codigo = @codigo_cupon) >= @fecha_consumo 
			and ( (select Cupon_Fecha_Consumo from Cupones where Cupon_Codigo = @codigo_cupon) IS NULL)
			and ( (select Provee_ID from Proveedores P
					JOIN Ofertas O
						ON P.Provee_id = O.Oferta_Proveedor
					JOIN Compras C
						ON O.Oferta_Id = C.Compra_Oferta
					JOIN Cupones CU
						ON C.Compra_Nro = CU.Cupon_Nro_Compra
					where CU.Cupon_Codigo = @codigo_cupon) = @id_proveedor) )
		begin
			UPDATE POR_COLECTORA.CUPONES SET Cupon_Fecha_Consumo = @fecha_consumo WHERE Cupon_codigo = @codigo_cupon
			UPDATE POR_COLECTORA.CUPONES SET Cupon_Id_Cliente_Consumidor = @id_cliente WHERE Cupon_codigo = @codigo_cupon

			set @resultado = 0
		end	

	 return @resultado
END

GO


--SP FACTURACION A PROVEEDOR
--Listado ofertas adquiridas por clientes
CREATE PROCEDURE POR_COLECTORA.sp_facturar_a_proveedor_listado(@fecha_inicio DateTime, @fecha_fin DateTime, @proveedor nvarchar(250))
AS
BEGIN

	SELECT DISTINCT(Compra_Oferta) AS OFERTA_CODIGO, Oferta_Descripcion AS OFERTA_DESCRIPCION 
	FROM POR_COLECTORA.Compras JOIN POR_COLECTORA.Ofertas ON Compra_Oferta = Oferta_Id JOIN POR_COLECTORA.Proveedores ON Oferta_Proveedor = Provee_Id
	WHERE Compra_Fecha >= @fecha_inicio AND Compra_Fecha <= @fecha_fin AND Provee_Id = (SELECT pr2.provee_id FROM POR_COLECTORA.Proveedores pr2 WHERE pr2.provee_RS = @proveedor)

END

GO

--SP FACTURACION A PROVEEDOR
--Importe factura y numero factura
CREATE PROCEDURE POR_COLECTORA.sp_facturar_a_proveedor(@fecha_inicio DateTime, @fecha_fin DateTime, @proveedor nvarchar(250),@resultado varchar(250) output)
AS
BEGIN
	--Importe factura
	declare @importe_total numeric
	set @importe_total = (SELECT SUM(Compra_Oferta_Precio * Compra_Cantidad)
						FROM POR_COLECTORA.Compras JOIN POR_COLECTORA.Ofertas ON (Compra_Oferta = Oferta_Id) JOIN POR_COLECTORA.Proveedores ON (Oferta_Proveedor = Provee_Id)
						WHERE Compra_Fecha >= @fecha_inicio AND Compra_Fecha <= @fecha_fin AND Provee_Id = (SELECT pr2.provee_id FROM POR_COLECTORA.Proveedores pr2 WHERE pr2.provee_RS = @proveedor)) 
 
	
	declare @fact_numero numeric
	set @fact_numero = (SELECT TOP 1 fact_numero
						FROM Facturas
						ORDER BY fact_numero DESC) + 1

	declare @prove_id numeric
	set @prove_id = (select Provee_Id
					from Proveedores
					where Provee_RS = @proveedor)

	declare @prove_cuit nvarchar(13)
	set @prove_cuit = (select Provee_CUIT
					from Proveedores
					where Provee_RS = @proveedor)

	insert into POR_COLECTORA.Facturas(Fact_Numero,Fact_Fecha_Desde,Fact_Fecha_Hasta,Fact_Importe,Fact_Proveedor_ID,Fact_Proveedor_RS,Fact_Proveedor_CUIT)
	values (@fact_numero,@fecha_inicio,@fecha_fin,@importe_total,@prove_id,@proveedor,@prove_cuit)
	
	set @resultado = convert(varchar(18),@importe_total) + ' ' + convert(varchar(18),@fact_numero)
	
	update Compras
	set Compra_Id_Factura = (select Fact_Id from Facturas where Fact_Numero = @fact_numero)
	where Compra_Nro in (select c2.Compra_Nro FROM Compras c2 JOIN Ofertas ON c2.Compra_Oferta = Oferta_Id JOIN Proveedores ON Oferta_Proveedor = Provee_Id
						WHERE c2.Compra_Fecha >= @fecha_inicio AND c2.Compra_Fecha <= @fecha_fin AND Provee_Id = (SELECT pr2.provee_id FROM POR_COLECTORA.Proveedores pr2 WHERE pr2.provee_RS = @proveedor)) 


END
GO

--SP FILTRO CLIENTES
CREATE PROCEDURE POR_COLECTORA.sp_filtrar_clientes(
@nombre NVARCHAR(250),
@apellido NVARCHAR(250),
@dni Numeric(18, 0),
@mail NVARCHAR(250)
)
AS 
BEGIN

SELECT Clie_Id,Clie_Nombre,Clie_Apellido,Clie_DNI,Clie_Mail,Clie_Telefono,
		(select Direccion_Calle from Direcciones where Direccion_Id = Clie_Direccion) as 'Clie_Direccion',
		(select Direccion_Nro_Piso from Direcciones where Direccion_Id = Clie_Direccion) as 'Clie_Nro_Piso',
		(select Direccion_Depto from Direcciones where Direccion_Id = Clie_Direccion) as 'Clie_Depto',
		(select Direccion_Ciudad from Direcciones where Direccion_Id = Clie_Direccion) as 'Clie_Ciudad',
		Clie_CP as 'Clie_CP',
		Clie_Fecha_Nac,
		Clie_Habilitado
from POR_COLECTORA.Clientes
where (Clie_nombre LIKE '%' + @nombre + '%' OR @nombre LIKE '')
AND (Clie_apellido LIKE '%' + @apellido + '%' OR @apellido LIKE '')
AND ((@dni = 0) OR Clie_dni = @dni)
AND (Clie_Mail LIKE '%' + @mail + '%' OR @mail LIKE '')
END
GO

--SP ALTA ROL
CREATE PROCEDURE POR_COLECTORA.sp_alta_rol(@nombre NVARCHAR(50))
AS 
BEGIN
	
	INSERT INTO POR_COLECTORA.Roles (Rol_Nombre)
	VALUES (@nombre)
	
END
GO

--SP ALTA ROL
CREATE PROCEDURE POR_COLECTORA.sp_mostrar_usuarios
AS 
BEGIN
	
	SELECT Usuario_Id,Usuario_Nombre,Usuario_Habilitado
	FROM POR_COLECTORA.Usuarios
	
END
GO

--SP AGREGAR FUNCIONALIDAD A ROL (FUNCIONALIDADxROL)
CREATE PROCEDURE POR_COLECTORA.sp_agregar_funcionalidad_a_rol(@id_rol numeric, @id_funcionalidad numeric)
AS 
BEGIN
	
	INSERT INTO POR_COLECTORA.FuncionalidadxRol (Id_Rol, Id_Func) --Contemplar caso donde ya tenga la funcionalidad?
	VALUES (@id_rol, @id_funcionalidad)
	
END
GO

--SP OFERTAS VIGENTES
CREATE PROCEDURE POR_COLECTORA.sp_ofertas_vigentes(@fecha DateTime)
AS
BEGIN
	SELECT oferta_descripcion AS Descripcion, oferta_id AS Codigo, Oferta_Precio AS Precio_Original, Oferta_Precio_Ficticio AS Precio_Oferta
	FROM POR_COLECTORA.Ofertas
	WHERE @fecha <= Oferta_Fecha_Venc AND Oferta_Cantidad > 0

END
GO

--SP FILTRO PROVEEDORES
CREATE PROCEDURE POR_COLECTORA.sp_filtrar_proveedores(
@razonSocial NVARCHAR(250),
@cuit nvarchar(13),
@mail NVARCHAR(250)
)
AS 
BEGIN

SELECT Provee_Id,Provee_RS,Provee_Mail,Provee_Telefono,Provee_CUIT,
		(select Direccion_Calle from Direcciones where Direccion_Id = Provee_Direccion) as 'Provee_Direccion',
		(select Direccion_Nro_Piso from Direcciones where Direccion_Id = Provee_Direccion) as 'Provee_Nro_Piso',
		(select Direccion_Depto from Direcciones where Direccion_Id = Provee_Direccion) as 'Provee_Depto',
		(select Direccion_Ciudad from Direcciones where Direccion_Id = Provee_Direccion) as 'Provee_Ciudad',
		Provee_CP,
		(select Rubro_Detalle from Rubros where Rubro_Id = Provee_Rubro) as 'Provee_Rubro',
		Provee_Nombre_Contacto,
		Provee_Habilitado
from POR_COLECTORA.Proveedores
where (Provee_RS LIKE '%' + @razonSocial + '%' OR @razonSocial LIKE '')
AND ((@cuit = '') OR Provee_CUIT = @cuit)
AND (Provee_Mail LIKE '%' + @mail + '%' OR @mail LIKE '')
END
GO

--SP BAJA ROL
--Marca el rol como inhabilitado
CREATE PROCEDURE POR_COLECTORA.sp_baja_rol(@rol numeric)
AS
BEGIN
	UPDATE POR_COLECTORA.Roles set rol_habilitado = 0
			WHERE rol_id = @rol

END
GO

--SP QUITAR ROL A USUARIOS ASIGNADOS
CREATE PROCEDURE POR_COLECTORA.sp_quitar_rol_a_usuarios(@rol numeric)
AS
BEGIN
	DELETE FROM POR_COLECTORA.RolxUsuario
			WHERE id_rol = @rol

END
GO

--SP MODIFICAR NOMBRE ROL
CREATE PROCEDURE POR_COLECTORA.sp_modificar_nombre_rol(@rol numeric, @nuevo_nombre varchar(50))
AS
BEGIN
	UPDATE POR_COLECTORA.Roles set rol_nombre = @nuevo_nombre
			WHERE rol_id = @rol --y rol habilitado? O lo dejo cambiar el nombre a un rol deshabilitado? 

END
GO

--SP ELIMINAR FUNCIONALIDAD A ROL
CREATE PROCEDURE POR_COLECTORA.sp_eliminar_funcionalidad_rol(@rol numeric, @funcionalidad numeric)
AS
BEGIN
	DELETE FROM POR_COLECTORA.FuncionalidadxRol 
			WHERE id_func = @funcionalidad AND id_rol = @rol

END
GO

--SP HABILITAR ROL 
CREATE PROCEDURE POR_COLECTORA.sp_habilitar_rol(@rol numeric)
AS
BEGIN
	UPDATE POR_COLECTORA.Roles set rol_habilitado = 1
			WHERE rol_id = @rol

END
GO

--SP OBTENER ID USER
CREATE PROCEDURE POR_COLECTORA.sp_obtener_id_user(@user varchar(250), @idUser numeric output)
AS
BEGIN

	set @idUser = (SELECT Usuario_Id
				FROM POR_COLECTORA.Usuarios
				WHERE Usuario_Nombre = @user)
	
	RETURN @idUser

END
GO



--SP OBTENER ID CLIENTE
CREATE PROCEDURE POR_COLECTORA.sp_obtener_id_cliente(@user varchar(250), @resultado int output)
AS
BEGIN
	declare @idUser numeric
	set @idUser = (SELECT Usuario_Id
				FROM POR_COLECTORA.Usuarios
				WHERE Usuario_Nombre = @user)
	
	declare @idCliente numeric

	set @idCliente = (SELECT Clie_Id
				FROM POR_COLECTORA.Clientes
				WHERE Clie_Usuario = @idUser)
    set @resultado = @idCliente
	RETURN @idCliente

END
GO

--SP OBTENER ID PROVEEDOR
CREATE PROCEDURE POR_COLECTORA.sp_obtener_id_proveedor(@user varchar(250), @resultado int output)
AS
BEGIN
	declare @idUser numeric
	set @idUser = (SELECT Usuario_Id
				FROM POR_COLECTORA.Usuarios
				WHERE Usuario_Nombre = @user)
	
	declare @idProveedor numeric

	set @idProveedor = (SELECT Provee_Id
				FROM POR_COLECTORA.Proveedores
				WHERE Provee_Usuario = @idUser)
    set @resultado = @idProveedor
	RETURN @idProveedor

END
GO

--SP MOSTRAR ROLES (PARA BMROL)
CREATE PROCEDURE POR_COLECTORA.sp_mostrar_roles
AS
BEGIN

	SELECT Rol_Id AS ID, Rol_Nombre AS ROL, Rol_Habilitado AS ESTADO
	FROM POR_COLECTORA.Roles
	ORDER BY Rol_Nombre ASC

END
GO

--SP MOSTRAR FUNCIONALIDADES DE UN ROL
CREATE PROCEDURE POR_COLECTORA.sp_mostrar_funcionalidades_rol(@rol numeric)
AS
BEGIN

	SELECT func_id, func_descripcion
	FROM POR_COLECTORA.FuncionalidadxRol JOIN POR_COLECTORA.Funcionalidades ON id_func = func_id
	WHERE Id_Rol = @rol
	ORDER BY Func_Descripcion ASC

END
GO

CREATE PROCEDURE POR_COLECTORA.sp_rol_posee_funcionalidad(@rol numeric,@func_descrip nvarchar(250) ,@resultado bit output)
AS
BEGIN

	if ( @func_descrip in (select Func_Descripcion from FuncionalidadxRol join Funcionalidades on (Id_Func = Func_Id) where Id_Rol = @rol))
	begin
		set @resultado = 1
	end

	else
	begin
		set @resultado = 0
	end

	return @resultado
							

END
GO


CREATE PROCEDURE POR_COLECTORA.sp_existe_proveedor(@idProvee numeric ,@resultado bit output)
AS
BEGIN

	if ( @idProvee in (select Provee_Id from POR_COLECTORA.Proveedores))
	begin
		set @resultado = 1
	end

	else
	begin
		set @resultado = 0
	end

	return @resultado
							

END
GO

CREATE PROCEDURE POR_COLECTORA.sp_cliente_esta_habilitado(@idCliente numeric, @resultado bit output)
AS
BEGIN

	if ( (select Clie_Habilitado from POR_COLECTORA.Clientes where Clie_Id = @idCliente ) = 1)
	begin
		set @resultado = 1
	end

	else
	begin
		set @resultado = 0
	end

	return @resultado
							

END
GO

CREATE PROCEDURE POR_COLECTORA.sp_proveedor_esta_habilitado(@idProveedor numeric, @resultado bit output)
AS
BEGIN

	if ( (select Provee_Habilitado from POR_COLECTORA.Proveedores where Provee_Id = @idProveedor ) = 1)
	begin
		set @resultado = 1
	end

	else
	begin
		set @resultado = 0
	end

	return @resultado
							

END
GO

CREATE PROCEDURE POR_COLECTORA.sp_user_es_admin(@idUsuario numeric,@resultado bit output)
AS
BEGIN

	if ( 1 in (select Id_Rol from RolxUsuario where Id_Usuario = @idUsuario ))
	begin
		set @resultado = 1
	end

	else
	begin
		set @resultado = 0
	end

	return @resultado
							

END
GO

CREATE PROCEDURE POR_COLECTORA.sp_user_posee_rol_cliente(@idUsuario numeric,@resultado bit output)
AS
BEGIN

	if ( 2 in (select Id_Rol from RolxUsuario where Id_Usuario = @idUsuario ))
	begin
		set @resultado = 1
	end

	else
	begin
		set @resultado = 0
	end

	return @resultado
							

END
GO

CREATE PROCEDURE POR_COLECTORA.sp_user_posee_rol_proveedor(@idUsuario numeric,@resultado bit output)
AS
BEGIN

	if ( 3 in (select Id_Rol from RolxUsuario where Id_Usuario = @idUsuario ))
	begin
		set @resultado = 1
	end

	else
	begin
		set @resultado = 0
	end

	return @resultado
							

END
GO


CREATE PROCEDURE POR_COLECTORA.sp_login(@user nvarchar(250) , @pass varchar(250), @resultado int output)
AS
BEGIN
	
	DECLARE @hash_pass_almacenada varchar(250)
	SET @hash_pass_almacenada = 
	(SELECT Usuario_Password
	FROM POR_COLECTORA.Usuarios
	WHERE Usuario_Nombre = @user)

	DECLARE @hash_pass_ingresada varchar(250)
	SET @hash_pass_ingresada = HASHBYTES('SHA2_256',@pass)

	IF @hash_pass_almacenada IS NULL
		BEGIN
			SET @resultado = 1 -- El usuario no existe 
		END
	ELSE IF @hash_pass_almacenada <> @hash_pass_ingresada
		BEGIN	
			SET @resultado = 2 -- El usuario existe pero la contraseña es incorrecta
			UPDATE POR_COLECTORA.Usuarios
			SET Usuario_Intentos = Usuario_Intentos + 1
			WHERE Usuario_Nombre = @user
		END
	ELSE -- El usuario existe y la contraseña es correcta 
		IF(	
			-- Chequeo que el usuario esté habilitado 
			(SELECT Usuario_Habilitado 
			FROM POR_COLECTORA.Usuarios	
			WHERE Usuario_Nombre = @user) = 0
		)
			BEGIN
				-- El usuario está inhabilitado
				SET @resultado = 3 	
			END
		ELSE
			BEGIN
				-- El usuario está habilitado
				SET @resultado = 4 	
				UPDATE POR_COLECTORA.Usuarios
				SET Usuario_Intentos = 0 -- Reseteo la cantidad de intentos fallidos a 0
				WHERE Usuario_Nombre = @user
			END 
END
GO


CREATE TRIGGER POR_COLECTORA.tr_inhabilitar_intentos_fallidos
ON POR_COLECTORA.Usuarios
FOR UPDATE
AS
BEGIN
	-- Cuando la cantidad de intentos de login incorrectos es 3, inhabilitamos 
	-- al usuario 
	UPDATE POR_COLECTORA.Usuarios
	SET Usuario_Habilitado = 0, Usuario_Intentos = 0
	WHERE Usuario_Nombre IN (
					SELECT Usuario_Nombre
					FROM inserted -- Apunta a una tabla usuarios virtual 
					WHERE Usuario_Intentos = 3
					)
	-- Como ya deshabilitamos al usuario, le reseteamos la cantidad de intentos fallidos

END
GO


CREATE TRIGGER POR_COLECTORA.tr_quitar_rol_inhabilitado_a_usuarios
ON POR_COLECTORA.Roles
FOR UPDATE
AS
BEGIN

	DELETE POR_COLECTORA.RolxUsuario	
	WHERE Id_Rol IN (
					SELECT Rol_Id
					FROM inserted )



END
GO


CREATE PROCEDURE POR_COLECTORA.sp_cambiar_contraseña_user(@id_user numeric,@new_pass varchar(250))
AS
BEGIN
	
	declare @new_hash_pass 	BINARY(32)
	set @new_hash_pass = HASHBYTES('SHA2_256', @new_pass)

	update POR_COLECTORA.Usuarios
	set Usuario_Password = @new_hash_pass
	where Usuario_Id = @id_user
							
END
GO