USE Agraria;
-- Poblar Productos
INSERT INTO Productos (Cod_Producto, Producto_Desc, Id_TipoEntorno, Id_Entorno, Id_Proveedor, Unidad_Medida, En_Venta) VALUES
('PROD001', 'Tomate Cherry', 1, 1, 1, 'Kg', 1),
('PROD002', 'Lechuga Mantecosa', 1, 1, 1, 'Unidad', 1),
('PROD003', 'Conejo Nueva Zelanda', 2, 2, 1, 'Kg', 1),
('PROD004', 'Piel de Conejo', 2, 2, 1, 'Unidad', 1),
('PROD005', 'Aceite de Girasol', 3, 3, 1, 'Litro', 1),
('PROD006', 'Miel Pura', 3, 3, 1, 'Kg', 1),
('PROD007', 'Albahaca', 1, 1, 1, 'Planta', 1),
('PROD008', 'Conejo California', 2, 2, 1, 'Kg', 1),
('PROD009', 'Jabón Artesanal', 3, 3, 1, 'Unidad', 1),
('PROD010', 'Rúcula', 1, 1, 1, 'Atado', 1);
GO

-- Poblar ArticulosGral
INSERT INTO ArticulosGral (Art_Cod, Art_Nombre, Art_Unidad_Medida, Art_Precio, Art_Descripcion, Art_Stock, Id_Proveedor) VALUES
('ART001', 'Fertilizante Universal', 1, 1500.50, 'Fertilizante para todo tipo de plantas', 100.00, 1),
('ART002', 'Alimento Balanceado Conejos', 2, 3200.75, 'Alimento premium para conejos', 250.50, 1),
('ART003', 'Semillas Tomate', 3, 800.25, 'Semillas de tomate orgánico', 50.00, 1),
('ART004', 'Jaula Conejos', 4, 18500.00, 'Jaula metálica para conejos', 15.00, 1),
('ART005', 'Manguera Riego', 5, 4500.80, 'Manguera de riego 20 metros', 30.00, 1),
('ART006', 'Bebedero Automático', 6, 2800.40, 'Bebedero automático para animales', 45.00, 1),
('ART007', 'Sustrato Tierra', 7, 1200.00, 'Sustrato para plantación', 200.00, 1),
('ART008', 'Vitaminas Animales', 8, 5600.90, 'Complejo vitamínico para animales', 60.00, 1),
('ART009', 'Herramienta Jardín', 9, 8900.00, 'Kit completo herramientas jardín', 25.00, 1),
('ART010', 'Incubadora Huevos', 10, 45000.00, 'Incubadora automática para huevos', 8.00, 1);
GO

-- Poblar Stock
INSERT INTO Stock (Cod_Producto, Cantidad, Costo, Ganancia) VALUES
('PROD001', 50.00, 200.00, 100.00),
('PROD002', 30.00, 150.00, 80.00),
('PROD003', 15.00, 800.00, 400.00),
('PROD004', 25.00, 300.00, 200.00),
('PROD005', 40.00, 500.00, 250.00),
('PROD006', 20.00, 700.00, 350.00),
('PROD007', 60.00, 100.00, 50.00),
('PROD008', 12.00, 900.00, 450.00),
('PROD009', 35.00, 250.00, 150.00),
('PROD010', 45.00, 120.00, 60.00);
GO

-- Poblar H_Ventas
INSERT INTO H_Ventas (Descripcion, Cod_Usuario, Fecha_Hora, Subtotal, Descu, Total) VALUES
('Venta productos hortícolas', 3, '2024-01-15 10:30:00', 8500.00, 500.00, 8000.00),
('Venta productos animales', 3, '2024-01-16 11:45:00', 12000.00, 0.00, 12000.00),
('Venta productos industria', 4, '2024-01-17 09:15:00', 6800.00, 300.00, 6500.00),
('Venta mixta', 3, '2024-01-18 16:20:00', 15300.00, 800.00, 14500.00),
('Venta mayorista', 4, '2024-01-19 14:00:00', 25000.00, 1500.00, 23500.00);
GO

-- Poblar H_Ventas_Detalle
INSERT INTO H_Ventas_Detalle (Id_Remito, Cod_Producto, Descr, P_Unit, Cant, P_X_Cant) VALUES
(1, 'PROD001', 'Tomate Cherry', 300.00, 5.00, 1500.00),
(1, 'PROD002', 'Lechuga Mantecosa', 250.00, 8.00, 2000.00),
(1, 'PROD007', 'Albahaca', 200.00, 5.00, 1000.00),
(2, 'PROD003', 'Conejo Nueva Zelanda', 1200.00, 3.00, 3600.00),
(2, 'PROD004', 'Piel de Conejo', 500.00, 4.00, 2000.00),
(3, 'PROD005', 'Aceite de Girasol', 800.00, 5.00, 4000.00),
(3, 'PROD006', 'Miel Pura', 700.00, 4.00, 2800.00),
(4, 'PROD001', 'Tomate Cherry', 300.00, 10.00, 3000.00),
(4, 'PROD003', 'Conejo Nueva Zelanda', 1200.00, 5.00, 6000.00),
(4, 'PROD009', 'Jabón Artesanal', 400.00, 8.00, 3200.00);
GO

-- Poblar Herramientas
INSERT INTO Herramientas (Nombre, Descripcion, Cantidad) VALUES
('Pala', 'Pala de mango largo para jardinería', 10),
('Rastrillo', 'Rastrillo metálico para hojas', 8),
('Tijera Podar', 'Tijera profesional para poda', 15),
('Carretilla', 'Carretilla de obra 100L', 5),
('Manguera', 'Manguera de riego 25 metros', 12),
('Regadera', 'Regadera plástica 10L', 20),
('Guantes', 'Guantes de jardinería cuero', 25),
('Tractor', 'Tractor pequeño para huerta', 2),
('Sistema Riego', 'Sistema de riego por goteo', 3),
('Incubadora', 'Incubadora para huevos automática', 4);
GO

-- Poblar HojadeVida
INSERT INTO HojadeVida (Numero, Tipo_Animal, Sexo, Fecha_Nacimiento, Peso, Estado_Salud, Activo, Observaciones) VALUES
(1001, 1, 1, '2023-05-15', 3.5, 'Excelente', 1, 'Conejo reproductor principal'),
(1002, 1, 2, '2023-06-20', 3.2, 'Bueno', 1, 'Coneja madre'),
(1003, 1, 1, '2023-08-10', 2.8, 'Regular', 1, 'En observación'),
(1004, 1, 2, '2023-07-05', 3.4, 'Excelente', 1, 'Coneja joven'),
(1005, 1, 1, '2023-09-12', 2.5, 'Bueno', 1, 'Destete reciente'),
(1006, 2, 1, '2023-04-18', 4.2, 'Excelente', 1, 'Conejo de exposición'),
(1007, 2, 2, '2023-05-22', 3.8, 'Bueno', 1, 'Preñada'),
(1008, 1, 1, '2023-10-01', 2.3, 'Regular', 1, 'Tratamiento vitamínico'),
(1009, 1, 2, '2023-06-15', 3.6, 'Excelente', 1, 'Lista para reproducción'),
(1010, 2, 1, '2023-03-20', 4.5, 'Excelente', 1, 'Semental principal');
GO

-- Poblar EntornoFormativo
INSERT INTO EntornoFormativo (Id_Entorno, Id_Usuario, Curso_Anio, Curso_Division, Curso_Grupo, Observaciones, Activo) VALUES
(1, 3, '4to', 'A', 'Grupo 1', 'Grupo avanzado en horticultura', 1),
(2, 3, '5to', 'B', 'Grupo 2', 'Grupo especializado en cunicultura', 1),
(3, 3, '6to', 'A', 'Grupo 3', 'Grupo industria alimentaria', 1),
(1, 3, '4to', 'B', 'Grupo 4', 'Grupo principiante horticultura', 1),
(2, 3, '5to', 'A', 'Grupo 5', 'Grupo reproducción animal', 1),
(3, 3, '6to', 'B', 'Grupo 6', 'Grupo procesamiento alimentos', 1),
(1, 3, '5to', 'C', 'Grupo 7', 'Grupo mixto producción', 1),
(2, 3, '4to', 'C', 'Grupo 8', 'Grupo sanidad animal', 1),
(3, 3, '6to', 'C', 'Grupo 9', 'Grupo control calidad', 1),
(1, 3, '4to', 'D', 'Grupo 10', 'Grupo cultivos orgánicos', 1);
GO

-- Poblar Actividad
INSERT INTO Actividad (Id_TipoEntorno, Id_Entorno, Id_EntornoFormativo, Fecha_Actividad, Descripcion_Actividad) VALUES
(1, 1, 1, '2024-01-10 08:00:00', 'Siembra de tomates en invernadero'),
(1, 1, 1, '2024-01-12 09:30:00', 'Trasplante de lechugas'),
(2, 2, 2, '2024-01-11 10:00:00', 'Control sanitario conejos'),
(2, 2, 2, '2024-01-13 11:00:00', 'Reproducción controlada'),
(3, 3, 3, '2024-01-14 14:00:00', 'Elaboración de aceite'),
(3, 3, 3, '2024-01-15 15:30:00', 'Envasado de miel'),
(1, 1, 4, '2024-01-16 08:30:00', 'Preparación de sustratos'),
(2, 2, 5, '2024-01-17 09:00:00', 'Destete de gazapos'),
(3, 3, 6, '2024-01-18 13:00:00', 'Control calidad productos'),
(1, 1, 7, '2024-01-19 10:30:00', 'Cosecha de hortalizas');
GO

-- Poblar HRemitoProduccion
INSERT INTO HRemitoProduccion (Descripcion, Cod_Usuario, Fecha_Hora, Subtotal, Descu, Total) VALUES
('Producción aceite girasol', 3, '2024-01-20 10:00:00', 15000.00, 0.00, 15000.00),
('Producción miel', 3, '2024-01-21 11:30:00', 12000.00, 500.00, 11500.00),
('Producción conservas', 3, '2024-01-22 09:45:00', 18000.00, 1000.00, 17000.00),
('Producción lácteos', 3, '2024-01-23 14:20:00', 22000.00, 1500.00, 20500.00),
('Producción cárnicos', 3, '2024-01-24 16:00:00', 25000.00, 2000.00, 23000.00);
GO

-- Poblar HRemitoDetalleProduccion
INSERT INTO HRemitoDetalleProduccion (Id_Remito, Art_Cod, Descr, P_Unit, Cant, P_X_Cant) VALUES
(1, 'ART001', 'Fertilizante Universal', 1500.50, 5.00, 7502.50),
(1, 'ART005', 'Manguera Riego', 4500.80, 2.00, 9001.60),
(2, 'ART002', 'Alimento Balanceado', 3200.75, 3.00, 9602.25),
(2, 'ART006', 'Bebedero Automático', 2800.40, 1.00, 2800.40),
(3, 'ART003', 'Semillas Tomate', 800.25, 10.00, 8002.50),
(3, 'ART007', 'Sustrato Tierra', 1200.00, 8.00, 9600.00),
(4, 'ART004', 'Jaula Conejos', 18500.00, 1.00, 18500.00),
(4, 'ART008', 'Vitaminas Animales', 5600.90, 2.00, 11201.80),
(5, 'ART009', 'Herramienta Jardín', 8900.00, 2.00, 17800.00),
(5, 'ART010', 'Incubadora Huevos', 45000.00, 1.00, 45000.00);
GO
