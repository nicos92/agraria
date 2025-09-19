-- =============================================
-- Script para crear la base de datos Agraria en SQL Server
-- =============================================

-- Eliminar la base de datos si ya existe
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Agraria')
BEGIN
    ALTER DATABASE Agraria SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Agraria;
END
GO

-- Crear la base de datos
CREATE DATABASE Agraria;
GO

-- Usar la base de datos
USE Agraria;
GO

-- Crear las tablas
-- Tabla Usuarios_Tipo
CREATE TABLE Usuarios_Tipo (
    Id_Usuario_Tipo INT IDENTITY(1,1) PRIMARY KEY,
    Tipo INT NOT NULL,
    Descripcion NVARCHAR(255)
);
GO

-- Tabla Preguntas de seguridad
CREATE TABLE Preguntas_Seguridad (
Id_Pregunta INT IDENTITY(1,1) PRIMARY KEY,
Pregunta NVARCHAR(255)
);
GO

-- Tabla Usuarios
CREATE TABLE Usuarios (
    Id_Usuario INT IDENTITY(1,1) PRIMARY KEY,
    DNI NVARCHAR(255),
    Nombre NVARCHAR(255),
    Apellido NVARCHAR(255),
    Tel NVARCHAR(255),
    Mail NVARCHAR(255),
	Contra NVARCHAR(255),
	Respues NVARCHAR(255),
	Id_Pregunta INT NOT NULL,
    Id_Tipo INT NOT NULL,
    CONSTRAINT FK_Usuarios_UsuariosTipo FOREIGN KEY (Id_Tipo) REFERENCES Usuarios_Tipo(Id_Usuario_Tipo),
	CONSTRAINT FK_Usuarios_PreguntaSegu FOREIGN KEY (Id_Pregunta) REFERENCES Preguntas_Seguridad(Id_Pregunta)
);
GO

-- Tabla Categorias
CREATE TABLE Categorias (
    Id_Categoria INT IDENTITY(1,1) PRIMARY KEY,
    Categoria NVARCHAR(255)
);
GO

-- Tabla Subcategoria
CREATE TABLE Subcategoria (
    Id_Subcategoria INT IDENTITY(1,1) PRIMARY KEY,
    Id_Categoria INT NOT NULL,
    Sub_Categoria NVARCHAR(255),
    CONSTRAINT FK_Subcategoria_Categorias FOREIGN KEY (Id_Categoria) REFERENCES Categorias(Id_Categoria)
);
GO

-- Tabla Proveedores
CREATE TABLE Proveedores (
    Id_Proveedor INT IDENTITY(1,1) PRIMARY KEY,
    CUIT NVARCHAR(255),
    Proveedor NVARCHAR(255),
    Nombre NVARCHAR(255),
    Tel NVARCHAR(255),
    Email NVARCHAR(255),
	Observacion NVARCHAR(255)
);
GO

-- Tabla Clientes
CREATE TABLE Clientes (
    Id_Cliente INT IDENTITY(1,1) PRIMARY KEY,
    CUIT NVARCHAR(255),
    Entidad NVARCHAR(255),
    Nombre NVARCHAR(255),
    Tel NVARCHAR(255),
    Mail NVARCHAR(255)
);
GO

-- Tabla Articulos
CREATE TABLE Articulos (
    Id_Articulo INT IDENTITY(1,1) PRIMARY KEY,
    Cod_Articulo NVARCHAR(25) NOT NULL UNIQUE,
    Art_Desc NVARCHAR(255),
    Cod_Categoria INT NOT NULL,
    Cod_Subcat INT NOT NULL,
    Id_Proveedor INT NOT NULL,
	Unidad_Medida NVARCHAR(255),
	En_Venta BIT DEFAULT 1,
    CONSTRAINT FK_Articulos_Categorias FOREIGN KEY (Cod_Categoria) REFERENCES Categorias(Id_Categoria),
    CONSTRAINT FK_Articulos_Subcategoria FOREIGN KEY (Cod_Subcat) REFERENCES Subcategoria(Id_Subcategoria),
    CONSTRAINT FK_Articulos_Proveedores FOREIGN KEY (Id_Proveedor) REFERENCES Proveedores(Id_Proveedor)
);
GO

-- Tabla Stock
CREATE TABLE Stock (
    Id_Stock INT IDENTITY(1,1) PRIMARY KEY,
    Cod_Articulo NVARCHAR(25) NOT NULL,
    Cantidad DECIMAL(18,2) NOT NULL,
    Costo DECIMAL(18,2) NOT NULL,
    Ganancia DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_Stock_Articulos FOREIGN KEY (Cod_Articulo) REFERENCES Articulos(Cod_Articulo)
);
GO

-- Tabla H_Ventas
CREATE TABLE H_Ventas (
    Id_Remito INT IDENTITY(1,1) PRIMARY KEY,
    Cod_Usuario INT NOT NULL,
    Fecha_Hora DATETIME2 NOT NULL,
    Id_Cliente INT NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    Descu DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_HVentas_Usuarios FOREIGN KEY (Cod_Usuario) REFERENCES Usuarios(Id_Usuario),
    CONSTRAINT FK_HVentas_Clientes FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id_Cliente)
);
GO

-- Tabla H_Ventas_Detalle
CREATE TABLE H_Ventas_Detalle (
    Id_Det_Remito INT IDENTITY(1,1) PRIMARY KEY,
    Id_Remito INT NOT NULL,
    Cod_Art NVARCHAR(255),
    Descr NVARCHAR(255),
    P_Unit DECIMAL(18,2) NOT NULL,
    Cant INT NOT NULL,
    P_X_Cant DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_HVentasDetalle_HVentas FOREIGN KEY (Id_Remito) REFERENCES H_Ventas(Id_Remito)
);
GO

-- Tabla H_Compras
CREATE TABLE H_Compras (
    Id_Remito INT IDENTITY(1,1) PRIMARY KEY,
    Cod_Usuario INT NOT NULL,
    Fecha_Hora DATETIME2 NOT NULL,
    Id_Proveedor INT NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    Descu DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_HCompras_Usuarios FOREIGN KEY (Cod_Usuario) REFERENCES Usuarios(Id_Usuario),
    CONSTRAINT FK_HCompras_Proveedores FOREIGN KEY (Id_Proveedor) REFERENCES Proveedores(Id_Proveedor)
);
GO

-- Tabla H_Compras_Detalle
CREATE TABLE H_Compras_Detalle (
    Id_Det_Remito INT IDENTITY(1,1) PRIMARY KEY,
    Id_Remito INT NOT NULL,
    Cod_Art NVARCHAR(255),
    Descr NVARCHAR(255),
    P_Unit DECIMAL(18,2) NOT NULL,
    Cant INT NOT NULL,
    P_X_Cant DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_HComprasDetalle_HCompras FOREIGN KEY (Id_Remito) REFERENCES H_Compras(Id_Remito)
);
GO

-- Tabla H_Movimientos
CREATE TABLE H_Movimientos (
    Id_Historico INT IDENTITY(1,1) PRIMARY KEY,
    Fecha_Hora DATETIME2 NOT NULL,
    Id_Usuario INT NOT NULL,
    Tipo_Movimiento INT NOT NULL,
    Reg_Antes NVARCHAR(255),
    Reg_Despues NVARCHAR(255),
    CONSTRAINT FK_HMovimientos_Usuarios FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);
GO

-- Tabla In_Out_Varios
CREATE TABLE In_Out_Varios (
    Id_Movimiento INT IDENTITY(1,1) PRIMARY KEY,
    Cod_Usuario INT NOT NULL,
    Fecha NVARCHAR(255),
    Tipo NVARCHAR(255),
    Detalle NVARCHAR(255),
    Monto NVARCHAR(255),
    CONSTRAINT FK_InOutVarios_Usuarios FOREIGN KEY (Cod_Usuario) REFERENCES Usuarios(Id_Usuario)
);
GO

-- Crear índices para mejorar el rendimiento
CREATE INDEX IX_Articulos_CodArticulo ON Articulos(Cod_Articulo);
CREATE INDEX IX_Articulos_CodCategoria ON Articulos(Cod_Categoria);
CREATE INDEX IX_Articulos_CodSubcat ON Articulos(Cod_Subcat);
CREATE INDEX IX_Articulos_IdProveedor ON Articulos(Id_Proveedor);
CREATE INDEX IX_Stock_CodArticulo ON Stock(Cod_Articulo);
CREATE INDEX IX_HVentas_CodUsuario ON H_Ventas(Cod_Usuario);
CREATE INDEX IX_HVentas_IdCliente ON H_Ventas(Id_Cliente);
CREATE INDEX IX_HVentas_FechaHora ON H_Ventas(Fecha_Hora);
CREATE INDEX IX_HCompras_CodUsuario ON H_Compras(Cod_Usuario);
CREATE INDEX IX_HCompras_IdProveedor ON H_Compras(Id_Proveedor);
CREATE INDEX IX_HCompras_FechaHora ON H_Compras(Fecha_Hora);
GO

PRINT 'Base de datos Agraria creada exitosamente.';