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

-- Tabla Preguntas_Seguridad
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
    Cant DECIMAL(18,2) NOT NULL,
    P_X_Cant DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_HVentasDetalle_HVentas FOREIGN KEY (Id_Remito) REFERENCES H_Ventas(Id_Remito)
);
GO


-- Tabla Herramientas
CREATE TABLE Herramientas (
    Id_Herramienta INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255) NOT NULL,
    Descripcion NVARCHAR(255),
    Cantidad INT NOT NULL
);
GO

-- Tabla HojadeVida
CREATE TABLE HojadeVida (
    Id_HojaVida INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(255),
    Descripcion NVARCHAR(MAX),
    Fecha_Creacion DATETIME2 NOT NULL,
    Fecha_Modificacion DATETIME2 NOT NULL
);
GO

-- Tabla Entorno
CREATE TABLE Entorno (
    Id_Entorno INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255),
    Descripcion NVARCHAR(255)
);
GO

-- Tabla EntornoFormativo
CREATE TABLE EntornoFormativo (
    Id_EntornoFormativo INT IDENTITY(1,1) PRIMARY KEY,
    Id_Entorno INT NOT NULL,
    Nombre NVARCHAR(255),
    Descripcion NVARCHAR(255),
    CONSTRAINT FK_EntornoFormativo_Entorno FOREIGN KEY (Id_Entorno) REFERENCES Entorno(Id_Entorno)
);
GO

-- Tabla TipoEntorno
CREATE TABLE TipoEntorno (
    Id_TipoEntorno INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(255)
);
GO

-- Tabla HRemitoProduccion
CREATE TABLE HRemitoProduccion (
    Id_Remito INT IDENTITY(1,1) PRIMARY KEY,
    Cod_Usuario INT NOT NULL,
    Fecha_Hora DATETIME2 NOT NULL,
    Id_Cliente INT NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    Descu DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_HRemitoProduccion_Usuarios FOREIGN KEY (Cod_Usuario) REFERENCES Usuarios(Id_Usuario),
    CONSTRAINT FK_HRemitoProduccion_Clientes FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id_Cliente)
);
GO

-- Tabla HRemitoDetalleProduccion
CREATE TABLE HRemitoDetalleProduccion (
    Id_Det_Remito INT IDENTITY(1,1) PRIMARY KEY,
    Id_Remito INT NOT NULL,
    Cod_Art NVARCHAR(255),
    Descr NVARCHAR(255),
    P_Unit DECIMAL(18,2) NOT NULL,
    Cant DECIMAL(18,2) NOT NULL,
    P_X_Cant DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_HRemitoDetalleProduccion_HRemitoProduccion FOREIGN KEY (Id_Remito) REFERENCES HRemitoProduccion(Id_Remito)
);
GO
