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
SELECT @@SERVERNAME;


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
('001', 'Fertilizante Orgánico', 1, 1, 1, 'Litros', 1),
('002', 'Semillas de Tomate', 3, 2, 2, 'Gramos', 1);

-- Poblar ArticulosGral
INSERT INTO ArticulosGral (Art_Cod, Art_Nombre, Art_Unidad_Medida, Art_Precio, Art_Descripcion, Art_Stock) VALUES
('001', 'Pala', 'Unidad', 1500.00, 'Herramienta de jardinería', 10),
('002', 'Regadera', 'Unidad', 800.00, 'Para riego manual', 5);

-- Poblar Stock
INSERT INTO Stock (Cod_Producto, Cantidad, Costo, Ganancia) VALUES
('001', 100, 500.00, 200.00),
('002', 200, 300.00, 150.00);

-- Poblar H_Ventas
INSERT INTO H_Ventas (Descripcion, Cod_Usuario, Fecha_Hora, Subtotal, Descu, Total) VALUES
('Venta fertilizante', 1, '2025-09-22 10:00:00', 5000.00, 500.00, 4500.00);

-- Poblar H_Ventas_Detalle
INSERT INTO H_Ventas_Detalle (Id_Remito, Cod_Producto, Descr, P_Unit, Cant, P_X_Cant) VALUES
(1, '001', 'Fertilizante Orgánico', 500.00, 10, 5000.00);

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
(2, 2, '2025', '3°A', 'Grupo Verde', 'Proyecto huerta escolar', 1);

-- Poblar HRemitoProduccion
INSERT INTO HRemitoProduccion (Descripcion, Cod_Usuario, Fecha_Hora, Subtotal, Descu, Total) VALUES
('Producción de herramientas', 1, '2025-09-21 14:30:00', 3000.00, 300.00, 2700.00);

-- Poblar HRemitoDetalleProduccion
INSERT INTO HRemitoDetalleProduccion (Id_Remito, Art_Cod, Descr, P_Unit, Cant, P_X_Cant) VALUES
(1, '001', 'Pala', 1500.00, 2, 3000.00);

DECLARE @i INT = 1;

WHILE @i <= 1000
BEGIN
    INSERT INTO Herramientas (Nombre, Descripcion, Cantidad)
    VALUES (
        CONCAT('Herramienta_', @i),
        CONCAT('Descripción de la herramienta número ', @i),
        (RAND() * 10 + 1) -- cantidad aleatoria entre 1 y 10
    );

    SET @i = @i + 1;
END;

DECLARE @p INT = 1;

WHILE @p <= 1000
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

WHILE @u <= 1000
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