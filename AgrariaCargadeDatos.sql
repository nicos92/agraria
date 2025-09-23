SELECT @@SERVERNAME;
USE Agraria;
-- Poblar TipoEntorno
INSERT INTO TipoEntorno (Descripcion) VALUES
('Rural'),
('Urbano'),
('Mixto');

-- Poblar Entorno
INSERT INTO Entorno (Nombre, Id_TipoEntorno) VALUES
('Campo Norte', 1),
('Huerta Escolar', 3),
('Laboratorio Urbano', 2);

-- Poblar Usuarios_Tipo
INSERT INTO Usuarios_Tipo (Tipo, Descripcion) VALUES
(1, 'Director'),
(2, 'Docente'),
(3, 'Jefe de Area');



-- Poblar Preguntas_Seguridad
INSERT INTO Preguntas_Seguridad (Pregunta) VALUES
('¿Nombre de tu primera mascota?'),
('¿Ciudad donde naciste?'),
('¿Comida favorita?');

-- Poblar Usuarios
INSERT INTO Usuarios (DNI, Nombre, Apellido, Tel, Mail, Contra, Respues, Id_Pregunta, Id_Tipo) VALUES
('12345678', 'Lucía', 'Gómez', '1122334455', 'lucia@mail.com', '@Pass123', 'Firulais', 1, 2),
('87654321', 'Martín', 'Pérez', '1199887766', 'martin@mail.com', 'pass456', 'Buenos Aires', 2, 3),
('11111111','Director','Dire','11111111','director@director.com','@Director123','director',1,1);


-- Poblar Proveedores
INSERT INTO Proveedores (CUIT, Proveedor, Nombre, Tel, Email, Observacion) VALUES
('30-12345678-9', 'AgroSur', 'Carlos López', '1133445566', 'agrosur@mail.com', 'Proveedor confiable'),
('30-98765432-1', 'BioCultivos', 'Ana Torres', '1144556677', 'biocultivos@mail.com', 'Entrega mensual');

-- Poblar Productos
INSERT INTO Productos (Cod_Producto, Producto_Desc, Id_TipoEntorno, Id_Entorno, Id_Proveedor, Unidad_Medida, En_Venta) VALUES
('P0000001', 'Fertilizante Orgánico', 1, 1, 1, 'Litros', 1),
('P0000002', 'Semillas de Tomate', 3, 2, 2, 'Gramos', 1);

--
-- Poblar la tabla 'Productos' con múltiples registros
--
INSERT INTO Productos (Cod_Producto, Producto_Desc, Id_TipoEntorno, Id_Entorno, Id_Proveedor, Unidad_Medida, En_Venta) VALUES
('P0000003', 'Tierra Fértil', 1, 1, 1, 'Kg', 1),
('P0000004', 'Manguera de Riego', 1, 1, 1, 'Metros', 1),
('P0000005', 'Kit de Herramientas de Jardinería', 1, 1, 1, 'Unidad', 1),
('P0000006', 'Malla Sombra', 1, 1, 1, 'Metros', 1),
('P0000007', 'Semillas de Lechuga', 3, 2, 2, 'Gramos', 1),
('P0000008', 'Semillas de Zanahoria', 3, 2, 2, 'Gramos', 1),
('P0000009', 'Abono Compuesto', 3, 2, 2, 'Kg', 1),
('P0000010', 'Atomizador Manual', 3, 2, 2, 'Litros', 1),
('P0000011', 'Tutor para Plantas', 1, 1, 1, 'Unidad', 1),
('P0000012', 'Pala Pequeña', 1, 1, 1, 'Unidad', 1),
('P0000013', 'Guantes de Jardinería', 1, 1, 1, 'Par', 1),
('P0000014', 'Regadera Metálica', 3, 2, 2, 'Litros', 1),
('P0000015', 'Tijeras de Poda', 3, 2, 2, 'Unidad', 1),
('P0000016', 'Semillas de Pepino', 3, 2, 2, 'Gramos', 1),
('P0000017', 'Kit de siembra en maceta', 1, 1, 1, 'Unidad', 1),
('P0000018', 'Insecticida orgánico', 3, 2, 2, 'Litros', 1),
('P0000019', 'Medidor de humedad del suelo', 1, 1, 1, 'Unidad', 0),
('P0000020', 'Etiquetas para plantas', 3, 2, 2, 'Paquete', 1);

-- Poblar ArticulosGral
INSERT INTO ArticulosGral (Art_Cod, Art_Nombre, Art_Unidad_Medida, Art_Precio, Art_Descripcion, Art_Stock) VALUES
('1', 'Pala', 'Unidad', 1500.00, 'Herramienta de jardinería', 10),
('2', 'Regadera', 'Unidad', 800.00, 'Para riego manual', 5);

-- Poblar Stock
INSERT INTO Stock (Cod_Producto, Cantidad, Costo, Ganancia) VALUES
('P0000001', 100, 500.00, 200.00),
('P0000002', 100, 500.00, 200.00),
('P0000003', 100, 500.00, 200.00),
('P0000004', 100, 500.00, 200.00),
('P0000005', 100, 500.00, 200.00),
('P0000006', 100, 500.00, 200.00),
('P0000007', 100, 500.00, 200.00),
('P0000008', 100, 500.00, 200.00),
('P0000009', 100, 500.00, 200.00),
('P0000010', 100, 500.00, 200.00),
('P0000011', 100, 500.00, 200.00),
('P0000012', 100, 500.00, 200.00),
('P0000013', 100, 500.00, 200.00),
('P0000014', 100, 500.00, 200.00),
('P0000015', 100, 500.00, 200.00),
('P0000016', 100, 500.00, 200.00),
('P0000017', 100, 500.00, 200.00),
('P0000018', 100, 500.00, 200.00),
('P0000019', 100, 500.00, 200.00),
('P0000020', 200, 300.00, 150.00);

-- Poblar H_Ventas
INSERT INTO H_Ventas (Descripcion, Cod_Usuario, Fecha_Hora, Subtotal, Descu, Total) VALUES
('Venta fertilizante', 1, '2025-09-22 10:00:00', 5000.00, 500.00, 4500.00);

-- Poblar H_Ventas_Detalle
INSERT INTO H_Ventas_Detalle (Id_Remito, Cod_Producto, Descr, P_Unit, Cant, P_X_Cant) VALUES
(1, 'P0000001', 'Fertilizante Orgánico', 500.00, 10, 5000.00);

-- Poblar Herramientas
INSERT INTO Herramientas (Nombre, Descripcion, Cantidad) VALUES
('Azada', 'Herramienta para remover tierra', 3),
('Tijera de podar', 'Para cortar ramas', 5);

-- Poblar HojadeVida
INSERT INTO HojadeVida (Nombre, Tipo_Animal, Sexo, Fecha_Nacimiento, Peso, Estado_Salud, Activo) VALUES
('Lola', 1, 2, '2023-03-15', 250.00, 'Saludable', 1),
('Toby', 2, 1, '2022-11-10', 180.00, 'En tratamiento', 1);

-- Poblar EntornoFormativo
INSERT INTO EntornoFormativo (Id_Entorno, Id_Usuario, Curso_Anio, Curso_Division, Curso_Grupo, Observaciones, Activo) VALUES
(2, 2, '2025', '3A', 'Grupo Verde', 'Proyecto huerta escolar', 1);
--
-- Poblar la tabla 'EntornoFormativo' con múltiples registros de ejemplo
--

INSERT INTO EntornoFormativo (Id_Entorno, Id_Usuario, Curso_Anio, Curso_Division, Curso_Grupo, Observaciones, Activo) VALUES
(1, 1, '2024', '1A', 'Grupo A', 'Introducción a la programación', 1),
(2, 2, '2025', '3B', 'Grupo Rojo', 'Proyecto de robótica educativa', 1),
(3, 3, '2023', '2C', 'Grupo Azul', 'Taller de creatividad', 0),
(1, 1, '2024', '4A', 'Grupo C', 'Simulacro de empresa', 1),
(3, 1, '2025', '5B', 'Grupo Verde', 'Clase de educación física', 1),
(1, 2, '2023', '1B', 'Grupo B', 'Taller de fotografía digital', 0),
(2, 3, '2024', '3C', 'Grupo Naranja', 'Proyecto de investigación histórica', 1),
(3, 1, '2025', '2A', 'Grupo Gris', 'Curso de primeros auxilios', 1),
(1, 1, '2024', '6A', 'Grupo E', 'Preparación para el examen final', 1),
(1,2, '2025', '1C', 'Grupo F', 'Proyecto de reciclaje', 1),
(1, 3, '2024', '4B', 'Grupo D', 'Taller de escritura creativa', 0),
(1, 1, '2025', '3D', 'Grupo Marrón', 'Clase de música', 1),
(1, 1, '2024', '2B', 'Grupo G', 'Taller de ajedrez', 1),
(1, 2, '2025', '5C', 'Grupo Blanco', 'Laboratorio de química', 1),
(1, 3, '2024', '6B', 'Grupo H', 'Preparación para la universidad', 1),
(1, 1, '2023', '1D', 'Grupo I', 'Introducción a la electrónica', 0),
(1, 1, '2025', '4C', 'Grupo J', 'Proyecto de desarrollo web', 1),
(1, 2, '2024', '3E', 'Grupo K', 'Taller de teatro', 1),
(1, 3, '2025', '2D', 'Grupo L', 'Clase de biología', 1),
(2, 1, '2024', '5D', 'Grupo M', 'Proyecto de arte', 1);

-- Poblar HRemitoProduccion
INSERT INTO HRemitoProduccion (Descripcion, Cod_Usuario, Fecha_Hora, Subtotal, Descu, Total) VALUES
('Producción de herramientas', 1, '2025-09-21 14:30:00', 3000.00, 300.00, 2700.00);

-- Poblar HRemitoDetalleProduccion
INSERT INTO HRemitoDetalleProduccion (Id_Remito, Art_Cod, Descr, P_Unit, Cant, P_X_Cant) VALUES
(1, '1', 'Pala', 1500.00, 2, 3000.00);

DECLARE @i INT = 1;

WHILE @i <= 1000
BEGIN
    INSERT INTO Herramientas (Nombre, Descripcion, Cantidad)
    VALUES (
        CONCAT('Herramienta', @i),
        CONCAT('Descripción de la herramienta número ', @i),
        (RAND() * 10 + 1) -- cantidad aleatoria entre 1 y 10
    );

    SET @i = @i + 1;
END;

DECLARE @p INT = 1;

WHILE @p <= 10
BEGIN
    INSERT INTO Proveedores (CUIT, Proveedor, Nombre, Tel, Email, Observacion)
    VALUES (
        CONCAT('30', FORMAT(@p, '00000000'), (@p % 9 + 1)), -- CUIT ficticio
        CONCAT('Proveedor', @p),
        CONCAT('Nombre', @p),
        CONCAT('11', FORMAT(@p, '00000000')), -- Teléfono ficticio
        CONCAT('proveedor', @p, '@mail.com'),
        CONCAT('Observación del proveedor número ', @p)
    );

    SET @p = @p + 1;
END;

DECLARE @u INT = 1;

WHILE @u <= 10
BEGIN
    INSERT INTO Usuarios (DNI, Nombre, Apellido, Tel, Mail, Contra, Respues, Id_Pregunta, Id_Tipo)
    VALUES (
        CONCAT('',FORMAT(@u, '00000000')), -- DNI ficticio
        CONCAT('Nombre', @u),
        CONCAT('Apellido', @u),
        CONCAT('11', FORMAT(@u, '00000000')), -- Teléfono ficticio
        CONCAT('usuario', @u, '@mail.com'),
        CONCAT('@Password', @u), -- Contraseña ficticia
        CONCAT('respuesta_', @u), -- Respuesta de seguridad
        ((@u - 1) % 3) + 1, -- Id_Pregunta entre 1 y 3
        ((@u - 1) % 3) + 1  -- Id_Tipo entre 1 y 3
    );

    SET @u = @u + 1;
END;