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

-- Insertar datos de ejemplo en Preguntas_Seguridad
INSERT INTO Preguntas_Seguridad (Pregunta) VALUES 
('¿Nombre de tu mascota?'),
('¿Apodo de la niñez?'),
('¿Ciudad de Nacimiento?');
GO

-- Insertar datos de ejemplo en Usuarios
INSERT INTO Usuarios (DNI, Nombre, Apellido, Tel, Mail, Contra, Respues, Id_Pregunta, Id_Tipo) VALUES 
('12345678', 'Juan', 'Pérez', '123456789', 'juan.perez@email.com', 'password123', 'Firulais', 1, 1),
('23456789', 'María', 'González', '234567890', 'maria.gonzalez@email.com', 'password456', 'Mavi', 2, 2),
('34567890', 'Carlos', 'López', '345678901', 'carlos.lopez@email.com', 'password789', 'Buenos Aires', 3, 3);
GO


-- Insertar datos de ejemplo en Proveedores
INSERT INTO Proveedores (CUIT, Proveedor, Nombre, Tel, Email, Observacion) VALUES 
('30-12345678-9', 'AgroSuministros S.A.', 'Pedro Martínez', '456789012', 'pedro@agrosuministros.com', 'Proveedor principal de insumos'),
('31-23456789-0', 'CampoProductivo S.R.L.', 'Ana Rodríguez', '567890123', 'ana@campoproductivo.com', 'Proveedor secundario');
GO


-- Insertar datos de ejemplo en Articulos
INSERT INTO Articulos (Cod_Articulo, Art_Desc, Cod_Categoria, Cod_Subcat, Id_Proveedor, Unidad_Medida, En_Venta) VALUES 
('ART001', 'Semillas de maíz híbrido', 1, 1, 1, 'Kg', 1),
('ART002', 'Fertilizante NPK 15-15-15', 2, 3, 2, 'Kg', 1),
('ART003', 'Pala con mango de madera', 3, 5, 1, 'Unidad', 1);
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

-- Insertar datos de ejemplo en Herramientas
INSERT INTO Herramientas (Nombre, Descripcion, Cantidad) VALUES 
('Motobomba', 'Bomba de agua a gasolina', 5),
('Cortadora de césped', 'Cortadora a nafta', 3);
GO

-- Insertar datos de ejemplo en Entorno
INSERT INTO Entorno (Nombre, Descripcion) VALUES 
('Invernadero', 'Área protegida para cultivo'),
('Campo', 'Área abierta para cultivo');
GO

-- Insertar datos de ejemplo en TipoEntorno
INSERT INTO TipoEntorno (Descripcion) VALUES 
('Cultivo'),
('Producción'),
('Almacenamiento');
GO

-- Insertar datos de ejemplo en EntornoFormativo
INSERT INTO EntornoFormativo (Id_Entorno, Nombre, Descripcion) VALUES 
(1, 'Invernadero 1', 'Invernadero para hortalizas'),
(2, 'Campo 1', 'Campo para cultivo extensivo');
GO

-- Insertar datos de ejemplo en HojadeVida
INSERT INTO HojadeVida (Titulo, Descripcion, Fecha_Creacion, Fecha_Modificacion) VALUES 
('Proyecto de cultivo de tomates', 'Plan de cultivo para producción de tomates cherry', GETDATE(), GETDATE()),
('Plan de fertilización', 'Plan de fertilización orgánica para hortalizas', GETDATE(), GETDATE());
GO

-- Insertar datos de ejemplo en HRemitoProduccion
INSERT INTO HRemitoProduccion (Cod_Usuario, Fecha_Hora, Id_Cliente, Subtotal, Descu, Total) VALUES 
(2, GETDATE(), 1, 1200, 0, 1200),
(2, DATEADD(DAY, -1, GETDATE()), 2, 1800, 100, 1700);
GO

-- Insertar datos de ejemplo en HRemitoDetalleProduccion
INSERT INTO HRemitoDetalleProduccion (Id_Remito, Cod_Art, Descr, P_Unit, Cant, P_X_Cant) VALUES 
(1, 'ART001', 'Semillas de maíz híbrido', 600, 2, 1200),
(2, 'ART002', 'Fertilizante NPK 15-15-15', 900, 2, 1800);
GO

