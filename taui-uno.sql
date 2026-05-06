-- Tabla Proveedores
CREATE TABLE Proveedores (
    Id_Proveedor INT IDENTITY(1,1) PRIMARY KEY,
    CUIT CHAR(11) UNIQUE,
    Proveedor NVARCHAR(255) NOT NULL,
    Nombre NVARCHAR(255) NOT NULL,
    Tel NVARCHAR(255),
    Email NVARCHAR(255),
    Observacion NVARCHAR(255)
);
GO

-- Tabla TipoEntorno
CREATE TABLE Categorias (
    Id_Categoria INT IDENTITY(1,1) PRIMARY KEY,
    Categoria NVARCHAR(255) UNIQUE
);
GO

-- Tabla Entorno
CREATE TABLE Sub_Categorias (
    Id_Sub_Categoria INT IDENTITY(1,1) PRIMARY KEY,
    Sub_Categoria NVARCHAR(255) UNIQUE,
    Id_Categoria INT NOT NULL,
    CONSTRAINT FK_Sub_Categoria_Categoria FOREIGN KEY (Id_Categoria) REFERENCES Categorias(Id_Categoria)
);
GO
-- Tabla Articulos 
CREATE TABLE Articulos (
    Id_Articulo INT IDENTITY(1,1) PRIMARY KEY,
	Articulo VARCHAR(50) NOT NULL UNIQUE,
    Cod_Articulo NVARCHAR(25) NOT NULL UNIQUE,
    Id_Sub_Categoria INT NOT NULL,
    Id_Proveedor INT NOT NULL,
    CONSTRAINT FK_Articulos_Sub_Categoria FOREIGN KEY (Id_Sub_Categoria) REFERENCES TipoEntorno(Id_Sub_Categoria)
    CONSTRAINT FK_Articulos_Proveedores FOREIGN KEY (Id_Proveedor) REFERENCES Proveedores(Id_Proveedor)
);
GO

-- Tabla Stock
CREATE TABLE Stock (
    Id_Stock INT IDENTITY(1,1) PRIMARY KEY,
    Id_Articulo NVARCHAR(25) NOT NULL,
    Cantidad DECIMAL(18,2) NOT NULL,
    Costo DECIMAL(18,2) NOT NULL,
    Ganancia DECIMAL(18,2) NOT NULL,
    Fecha_Modificacion DATETIME2(7) DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Stock_Articulo FOREIGN KEY (Id_Articulo) REFERENCES Articulos(Id_Articulo)
);
GO

-- Tabla H_Ventas
CREATE TABLE H_Ventas (
    Id_Venta INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(255),
    Id_Usuario INT NOT NULL,
    Fecha_Hora DATETIME2(7) DEFAULT SYSDATETIME(),
	Descuento DECIMAL(10,2, NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
	estado NVARCHAR(50) DEFAULT 'completada' CHECK(estado IN ('completada', 'anulada', 'pendiente')),
    CONSTRAINT FK_HVentas_Usuarios FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);
GO

-- Tabla H_Ventas_Detalle
CREATE TABLE H_Ventas_Detalle (
    Id_Det_Venta INT IDENTITY(1,1) PRIMARY KEY,
    Id_HVenta INT NOT NULL,
    Id_Articulo NVARCHAR(25),
    Precio_Unitario DECIMAL(10,2) NOT NULL,
    Cantidad DECIMAL(10,2) NOT NULL,
    Precio_X_Cantidad DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_HVentasDetalle_HVentas FOREIGN KEY (Id_Remito) REFERENCES H_Ventas(Id_Remito),
    CONSTRAINT FK_HVentasDetalle_Articulo FOREIGN KEY (Id_Articulo) REFERENCES Articulos(Id_Articulo)
);
GO


-- Tipos de pago
CREATE TABLE tipo_pago (
    id_tipo_pago INTEGER PRIMARY KEY AUTOINCREMENT,
    nombre TEXT NOT NULL UNIQUE,
    activo INTEGER DEFAULT 1
);

-- Pagos (múltiples formas por venta)
CREATE TABLE pago (
    id_pago INTEGER PRIMARY KEY AUTOINCREMENT,
    Id_Venta INTEGER NOT NULL,
    id_tipo_pago INTEGER NOT NULL,
    monto DECIMAL(10,2) NOT NULL,
    cuotas INTEGER DEFAULT 1, -- para pagos con tarjeta en cuotas
    fecha_pago DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (Id_Venta) REFERENCES H_Ventas(Id_Venta),
    FOREIGN KEY (id_tipo_pago) REFERENCES tipo_pago(id_tipo_pago)
);

-- Insertar tipos de pago comunes
INSERT INTO tipo_pago (nombre) VALUES 
    ('efectivo'),
    ('tarjeta débito'),
    ('tarjeta crédito'),
    ('transferencia bancaria');