-- =============================================
-- Script para insertar datos de ejemplo en la base de datos Agraria
-- =============================================

USE Agraria;
GO

-- Insertar datos de ejemplo en Usuarios_Tipo
INSERT INTO Usuarios_Tipo (Tipo, Descripcion) VALUES 
(1, 'Administrador'),
(2, 'Vendedor'),
(3, 'Comprador');
GO

-- Insertar datos de ejemplo en Usuarios
INSERT INTO Usuarios (DNI, Nombre, Apellido, Tel, Mail, Id_Tipo) VALUES 
('12345678', 'Juan', 'Pérez', '123456789', 'juan.perez@email.com', 1),
('23456789', 'María', 'González', '234567890', 'maria.gonzalez@email.com', 2),
('34567890', 'Carlos', 'López', '345678901', 'carlos.lopez@email.com', 3);
GO

-- Insertar datos de ejemplo en Categorias
INSERT INTO Categorias (Categoria) VALUES 
('Semillas'),
('Fertilizantes'),
('Herramientas'),
('Maquinaria');
GO

-- Insertar datos de ejemplo en Subcategoria
INSERT INTO Subcategoria (Id_Categoria, Sub_Categoria) VALUES 
(1, 'Semillas de maíz'),
(1, 'Semillas de trigo'),
(2, 'Fertilizantes nitrogenados'),
(2, 'Fertilizantes fosfóricos'),
(3, 'Herramientas manuales'),
(3, 'Herramientas eléctricas');
GO

-- Insertar datos de ejemplo en Proveedores
INSERT INTO Proveedores (CUIT, Proveedor, Nombre, Tel, Email) VALUES 
('30-12345678-9', 'AgroSuministros S.A.', 'Pedro Martínez', '456789012', 'pedro@agrosuministros.com'),
('31-23456789-0', 'CampoProductivo S.R.L.', 'Ana Rodríguez', '567890123', 'ana@campoproductivo.com');
GO

-- Insertar datos de ejemplo en Clientes
INSERT INTO Clientes (CUIT, Entidad, Nombre, Tel, Mail) VALUES 
('20-12345678-9', 'Estancia Santa Fe', 'Roberto Sánchez', '678901234', 'roberto@estanciasantafe.com'),
('21-23456789-0', 'AgroGanadera S.A.', 'Laura Fernández', '789012345', 'laura@agroganadera.com');
GO

-- Insertar datos de ejemplo en Articulos
INSERT INTO Articulos (Cod_Articulo, Art_Desc, Cod_Categoria, Cod_Subcat, Id_Proveedor) VALUES 
('ART001', 'Semillas de maíz híbrido', 1, 1, 1),
('ART002', 'Fertilizante NPK 15-15-15', 2, 3, 2),
('ART003', 'Pala con mango de madera', 3, 5, 1);
GO

-- Insertar datos de ejemplo en Stock
INSERT INTO Stock (Cod_Articulo, Cantidad, Costo, Ganancia) VALUES 
('ART001', 1000, 500, 200),
('ART002', 500, 800, 300),
('ART003', 50, 1200, 500);
GO

-- Insertar datos de ejemplo en H_Ventas
INSERT INTO H_Ventas (Cod_Usuario, Fecha_Hora, Id_Cliente, Subtotal, Descu, Total) VALUES 
(2, GETDATE(), 1, 1500, 100, 1400),
(2, DATEADD(DAY, -1, GETDATE()), 2, 2000, 0, 2000);
GO

-- Insertar datos de ejemplo en H_Ventas_Detalle
INSERT INTO H_Ventas_Detalle (Id_Remito, Cod_Art, Descr, P_Unit, Cant, P_X_Cant) VALUES 
(1, 'ART001', 'Semillas de maíz híbrido', 700, 2, 1400),
(2, 'ART002', 'Fertilizante NPK 15-15-15', 1000, 2, 2000);
GO

-- Insertar datos de ejemplo en H_Compras
INSERT INTO H_Compras (Cod_Usuario, Fecha_Hora, Id_Proveedor, Subtotal, Descu, Total) VALUES 
(3, GETDATE(), 1, 2500, 0, 2500),
(3, DATEADD(DAY, -2, GETDATE()), 2, 3000, 200, 2800);
GO

-- Insertar datos de ejemplo en H_Compras_Detalle
INSERT INTO H_Compras_Detalle (Id_Remito, Cod_Art, Descr, P_Unit, Cant, P_X_Cant) VALUES 
(1, 'ART001', 'Semillas de maíz híbrido', 500, 5, 2500),
(2, 'ART003', 'Pala con mango de madera', 1200, 3, 3600);
GO

-- Insertar datos de ejemplo en H_Movimientos
INSERT INTO H_Movimientos (Fecha_Hora, Id_Usuario, Tipo_Movimiento, Reg_Antes, Reg_Despues) VALUES 
(GETDATE(), 1, 1, 'Usuario: Juan Pérez, Tipo: Vendedor', 'Usuario: Juan Pérez, Tipo: Administrador'),
(DATEADD(DAY, -3, GETDATE()), 2, 2, 'Stock: 800 unidades ART001', 'Stock: 1000 unidades ART001');
GO

-- Insertar datos de ejemplo en In_Out_Varios
INSERT INTO In_Out_Varios (Cod_Usuario, Fecha, Tipo, Detalle, Monto) VALUES 
(1, CONVERT(NVARCHAR, GETDATE(), 23), 'Ingreso', 'Venta contado cliente Estancia Santa Fe', '1400'),
(2, CONVERT(NVARCHAR, DATEADD(DAY, -1, GETDATE()), 23), 'Egreso', 'Compra insumos', '2500');
GO

PRINT 'Datos de ejemplo insertados exitosamente.';