

-- Cambia a la base de datos maestra para realizar la operaci�n
USE master;
GO
-- Eliminar la base de datos si ya existe
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Agraria')
BEGIN
    ALTER DATABASE Agraria SET SINGLE_USER WITH ROLLBACK IMMEDIATE; -- Cierra todas las conexiones a la base de datos y la pone en modo de usuario �nico
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

-- Tabla TipoEntorno
CREATE TABLE TipoEntorno (
    Id_TipoEntorno INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(255) UNIQUE
);
GO

-- Tabla Entorno
CREATE TABLE Entorno (
    Id_Entorno INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255) UNIQUE,
    Id_TipoEntorno INT NOT NULL,
    CONSTRAINT FK_Entorno_TipoEntorno FOREIGN KEY (Id_TipoEntorno) REFERENCES TipoEntorno(Id_TipoEntorno)
);
GO

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
    DNI NVARCHAR(255) UNIQUE,
    Nombre NVARCHAR(255) NOT NULL,
    Apellido NVARCHAR(255) NOT NULL,
    Tel NVARCHAR(255),
    Mail NVARCHAR(255),
    Contra NVARCHAR(255),
    Respues NVARCHAR(255),
    Id_Pregunta INT NOT NULL,
    Id_Tipo INT NOT NULL,
	Activo BIT DEFAULT 1,
    CONSTRAINT FK_Usuarios_UsuariosTipo FOREIGN KEY (Id_Tipo) REFERENCES Usuarios_Tipo(Id_Usuario_Tipo),
    CONSTRAINT FK_Usuarios_PreguntaSegu FOREIGN KEY (Id_Pregunta) REFERENCES Preguntas_Seguridad(Id_Pregunta)
);
GO

-- Tabla Proveedores
CREATE TABLE Proveedores (
    Id_Proveedor INT IDENTITY(1,1) PRIMARY KEY,
    CUIT NVARCHAR(255) UNIQUE,
    Proveedor NVARCHAR(255) NOT NULL,
    Nombre NVARCHAR(255) NOT NULL,
    Tel NVARCHAR(255),
    Email NVARCHAR(255),
    Observacion NVARCHAR(255)
);
GO


-- Tabla Articulos Cambiar nombre por 'Productos'
CREATE TABLE Productos (
    Id_Producto INT IDENTITY(1,1) PRIMARY KEY,
    Cod_Producto NVARCHAR(25) NOT NULL UNIQUE,
    Producto_Desc NVARCHAR(255),
    Id_TipoEntorno INT NOT NULL,
    Id_Entorno INT NOT NULL,
    Id_Proveedor INT NOT NULL,
    Unidad_Medida NVARCHAR(255),
    En_Venta BIT DEFAULT 1,
    CONSTRAINT FK_Productos_Tipo_Entorno FOREIGN KEY (Id_TipoEntorno) REFERENCES TipoEntorno(Id_TipoEntorno),
    CONSTRAINT FK_Productos_Entorno FOREIGN KEY (Id_Entorno) REFERENCES Entorno(Id_Entorno),
    CONSTRAINT FK_Productos_Proveedores FOREIGN KEY (Id_Proveedor) REFERENCES Proveedores(Id_Proveedor)
);
GO

-- Tabla ArticulosGral
CREATE TABLE ArticulosGral (
    Art_Id INT IDENTITY(1,1) PRIMARY KEY,
    Art_Cod NVARCHAR(25) NOT NULL UNIQUE,
    Art_Nombre NVARCHAR(255),
    Art_Unidad_Medida INT NOT NULL,
    Art_Precio DECIMAL(18,2) NOT NULL,
    Art_Descripcion NVARCHAR(255),
    Art_Stock DECIMAL(18,2) NOT NULL,
	Id_Proveedor INT NOT NULL,
	CONSTRAINT FK_ArticulosGral_Proveedor FOREIGN KEY (Id_Proveedor) REFERENCES Proveedores (Id_Proveedor)
);
GO

-- Tabla Stock
CREATE TABLE Stock (
    Cod_Producto NVARCHAR(25) NOT NULL UNIQUE,
    Cantidad DECIMAL(18,2) NOT NULL,
    Costo DECIMAL(18,2) NOT NULL,
    Ganancia DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_Stock_Cod_Producto FOREIGN KEY (Cod_Producto) REFERENCES Productos(Cod_Producto)
);
GO

-- Tabla H_Ventas
CREATE TABLE H_Ventas (
    Id_Remito INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(255),
    Cod_Usuario INT NOT NULL,
    Fecha_Hora DATETIME2(7) DEFAULT SYSDATETIME(),
    Subtotal DECIMAL(18,2) NOT NULL,
    Descu DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_HVentas_Usuarios FOREIGN KEY (Cod_Usuario) REFERENCES Usuarios(Id_Usuario)
);
GO

-- Tabla H_Ventas_Detalle
CREATE TABLE H_Ventas_Detalle (
    Id_Det_Remito INT IDENTITY(1,1) PRIMARY KEY,
    Id_Remito INT NOT NULL,
    Cod_Producto NVARCHAR(25),
    Descr NVARCHAR(255),
    P_Unit DECIMAL(18,2) NOT NULL,
    Cant DECIMAL(18,2) NOT NULL,
    P_X_Cant DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_HVentasDetalle_HVentas FOREIGN KEY (Id_Remito) REFERENCES H_Ventas(Id_Remito),
    CONSTRAINT FK_HVentasDetalle_Cod_Producto FOREIGN KEY (Cod_Producto) REFERENCES Productos(Cod_Producto)
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
    Numero INT NOT NULL UNIQUE,
    Tipo_Animal INT NOT NULL,
    Sexo INT NOT NULL,
    Fecha_Nacimiento DATE,
    Peso DECIMAL(18,2) NOT NULL,
    Estado_Salud NVARCHAR(255),
    Activo BIT DEFAULT 1,
	Observaciones NVARCHAR(255)

);
GO



-- Tabla EntornoFormativo
CREATE TABLE EntornoFormativo (
    Id_EntornoFormativo INT IDENTITY(1,1) PRIMARY KEY,
    Id_Entorno INT NOT NULL,
    Id_Usuario INT NOT NULL,
    Curso_Anio NVARCHAR(255),
    Curso_Division NVARCHAR(255),
    Curso_Grupo NVARCHAR(255),
    Observaciones NVARCHAR(255),
    Activo BIT DEFAULT 1,
    CONSTRAINT FK_EntornoFormativo_Entorno FOREIGN KEY (Id_Entorno) REFERENCES Entorno(Id_Entorno),
    CONSTRAINT FK_EntornoFormativo_Usuarios FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);
GO

-- Tabla Actividad
CREATE TABLE Actividad (
	Id_Actividad INT IDENTITY(1,1) PRIMARY KEY,
	Id_TipoEntorno INT NOT NULL,
	Id_Entorno INT NOT NULL,
	Id_EntornoFormativo INT NOT NULL,
	Fecha_Actividad DATETIME2(7) DEFAULT SYSDATETIME(),
	Descripcion_Actividad NVARCHAR(255) NOT NULL,
	CONSTRAINT FK_Actividad_TipoEntorno FOREIGN KEY (Id_TipoEntorno) REFERENCES TipoEntorno(Id_TipoEntorno),
	CONSTRAINT FK_Actividad_Entorno FOREIGN KEY (Id_Entorno) REFERENCES Entorno (Id_Entorno),
	CONSTRAINT FK_Actividad_Entornoformativo FOREIGN KEY (Id_EntornoFormativo) REFERENCES EntornoFormativo(Id_EntornoFormativo)
);
GO

-- Tabla HRemitoProduccion
CREATE TABLE HRemitoProduccion (
    Id_Remito INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(255),
    Cod_Usuario INT NOT NULL,
    Fecha_Hora DATETIME2(7) DEFAULT SYSDATETIME(),
    Subtotal DECIMAL(18,2) NOT NULL,
    Descu DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_HRemitoProduccion_Usuarios FOREIGN KEY (Cod_Usuario) REFERENCES Usuarios(Id_Usuario),

);
GO

-- Tabla HRemitoDetalleProduccion
CREATE TABLE HRemitoDetalleProduccion (
    Id_Det_Remito INT IDENTITY(1,1) PRIMARY KEY,
    Id_Remito INT NOT NULL,
    Art_Cod NVARCHAR(25),
    Descr NVARCHAR(255),
    P_Unit DECIMAL(18,2) NOT NULL,
    Cant DECIMAL(18,2) NOT NULL,
    P_X_Cant DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_HRemitoDetalleProduccion_HRemitoProduccion FOREIGN KEY (Id_Remito) REFERENCES HRemitoProduccion(Id_Remito),
    CONSTRAINT FK_HRemitoDetalleProduccion_ArticulosGral FOREIGN KEY (Art_Cod) REFERENCES ArticulosGral(Art_Cod)
);
GO

-- Poblar Usuarios_Tipo
INSERT INTO Usuarios_Tipo (Tipo, Descripcion) VALUES
(1, 'Director'),
(2, 'Jefe de Area'),
(3, 'Docente'),
(4, 'Cooperadora');
GO

-- Poblar Preguntas_Seguridad
INSERT INTO Preguntas_Seguridad (Pregunta) VALUES
('¿Nombre de tu primera mascota?'),
('¿Ciudad donde naciste?'),
('¿Comida favorita?');
GO

-- Poblar Usuarios
INSERT INTO Usuarios (DNI, Nombre, Apellido, Tel, Mail, Contra, Respues, Id_Pregunta, Id_Tipo) VALUES
('11111111','Director','Dire','11111111','director@agraria.com','@Director1234','director',1,1),
('22222222','Jefe de','Area','22222222','jefedearea@agraria.com','@Jefedearea1234','jefe de area',1,1),
('33333333','Docente','Dire','33333333','docente@agraria.com','@Docente1234','docente',1,1),
('44444444', 'Cooperadora', 'Cooperadora', '44444444', 'cooperadora@agraria.com', '@Cooperadora1234', 'venta', 1, 1);
GO

-- Insertar un proveedor por defecto 'Sin Proveedor'
INSERT INTO Proveedores (CUIT, Proveedor, Nombre, Tel, Email, Observacion) VALUES
('00000000001', 'Sin Proveedor', 'Sin Proveedor', '0000000000', 'sinproveedor@example.com', 'Sin Proveedor para productos sin proveedor asignado');
GO

-- Poblar TipoEntorno
INSERT INTO TipoEntorno (Descripcion) VALUES
('Vegetal'),
('Animal'),
('Industria');
GO

-- Poblar Entorno
INSERT INTO Entorno (Nombre, Id_TipoEntorno) VALUES
('Invernadero 1', 1), -- Vegetal
('Corral 1', 2),      -- Animal
('Taller Mecanico', 3); -- Industria
GO
