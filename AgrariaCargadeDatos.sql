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
('87654321', 'Martín', 'Martinez', '1199887766', 'martin@mail.com', 'pass456', 'Buenos Aires', 2, 3),
('11111181','Director','Dire','11111111','director@director.com','@Director123','director',1,1),
('22222222', 'Ana', 'Pérez', '1155443322', 'ana.perez@mail.com', 'AnaPass789', 'El Sol', 3, 2),
('33353333', 'Carlos', 'López', '1177665544', 'carlos.lopez@mail.com', 'carlos_pass', 'Verano', 3, 3),
('44444444', 'Sofía', 'Ramírez', '1122998877', 'sofia.ramirez@mail.com', 'Sofia@987', 'Gato', 1, 2),
('55555555', 'Diego', 'Hernández', '1133445566', 'diego.h@mail.com', 'DiegoPass', 'Azul', 2, 3),
('66666666', 'Valeria', 'Díaz', '1188776655', 'valeria.d@mail.com', 'Valeria123', 'Luna', 3, 2),
('77777777', 'Pablo', 'Sánchez', '1144556677', 'pablo.s@mail.com', 'Pablo_Pass', 'Marte', 3, 3),
('88888888', 'Laura', 'Torres', '1166778899', 'laura.t@mail.com', 'LauraPass', 'Playa', 1, 2),
('99999999', 'Manuel', 'Ruiz', '1100998877', 'manuel.r@mail.com', 'Manuel_1', 'Cielo', 2, 3),
('10101010', 'Andrea', 'Flores', '1122113344', 'andrea.f@mail.com', 'Andrea_2', 'Montaña', 3, 2),
('12121212', 'Felipe', 'Guerra', '1144332211', 'felipe.g@mail.com', 'Felipe3', 'Nieve', 3, 3),
('13131313', 'Silvia', 'Cruz', '1155667788', 'silvia.c@mail.com', 'Silvia_4', 'Río', 1, 2),
('14141414', 'Javier', 'Reyes', '1199887766', 'javier.r@mail.com', 'Javier_5', 'Perro', 2, 3),
('15151515', 'Marina', 'Ortiz', '1133557799', 'marina.o@mail.com', 'Marina_6', 'Gato', 3, 2),
('16161616', 'Raúl', 'Castro', '1122446688', 'raul.c@mail.com', 'Raul_7', 'Elefante', 3, 3),
('17171717', 'Natalia', 'Paz', '1155887744', 'natalia.p@mail.com', 'Natalia_8', 'León', 1, 2),
('18181818', 'Pedro', 'Molina', '1133669922', 'pedro.m@mail.com', 'Pedro_9', 'Tigre', 2, 3),
('19191919', 'Carla', 'Morales', '1177558833', 'carla.m@mail.com', 'Carla_10', 'Zorro', 3, 2),
('20202020', 'Alejandro', 'Silva', '1199447711', 'alejandro.s@mail.com', 'Alejandro11', 'Oso', 3, 3),
('21212121', 'Daniela', 'Vargas', '1166339922', 'daniela.v@mail.com', 'Daniela12', 'Mono', 1, 2),
('22224222', 'Ricardo', 'Juarez', '1188552211', 'ricardo.j@mail.com', 'Ricardo13', 'Cebra', 2, 3),
('23232323', 'Gabriela', 'Lara', '1177441188', 'gabriela.l@mail.com', 'Gabriela14', 'Jirafa', 3, 2),
('24242424', 'Fernando', 'Mena', '1199223344', 'fernando.m@mail.com', 'Fernando15', 'Pato', 3, 3),
('25252525', 'Rocio', 'Velasquez', '1155331166', 'rocio.v@mail.com', 'Rocio16', 'Búho', 1, 2),
('26262626', 'José', 'Arias', '1122884455', 'jose.a@mail.com', 'Jose17', 'Halcón', 2, 3),
('27272727', 'Veronica', 'Ortega', '1133775566', 'veronica.o@mail.com', 'Veronica18', 'Cuervo', 3, 2),
('28282828', 'Marcos', 'Peralta', '1144991122', 'marcos.p@mail.com', 'Marcos19', 'Paloma', 3, 3),
('29292929', 'Esther', 'Romero', '1188229933', 'esther.r@mail.com', 'Esther20', 'Gaviota', 1, 2),
('30303030', 'Miguel', 'García', '1166554477', 'miguel.g@mail.com', 'Miguel21', 'Golondrina', 2, 3),
('31313131', 'Julia', 'Herrera', '1155223344', 'julia.h@mail.com', 'Julia22', 'Cisne', 3, 2),
('32323232', 'David', 'Jiménez', '1188449966', 'david.j@mail.com', 'David23', 'Pinguino', 3, 3),
('33333333', 'Elena', 'Ruiz', '1177665522', 'elena.r@mail.com', 'Elena24', 'Loro', 1, 2),
('34343434', 'Jorge', 'Soto', '1199332211', 'jorge.s@mail.com', 'Jorge25', 'Canario', 2, 3),
('35353535', 'Adriana', 'Castañeda', '1144228877', 'adriana.c@mail.com', 'Adriana26', 'Colibrí', 3, 2),
('36363636', 'Guillermo', 'Luna', '1188665544', 'guillermo.l@mail.com', 'Guillermo27', 'Faisán', 3, 3),
('37373737', 'Brenda', 'Fuentes', '1199221155', 'brenda.f@mail.com', 'Brenda28', 'Búfalo', 1, 2),
('38383838', 'Kevin', 'Mendoza', '1155773322', 'kevin.m@mail.com', 'Kevin29', 'Cabra', 2, 3),
('39393939', 'Luciana', 'Mora', '1122998844', 'luciana.m@mail.com', 'Luciana30', 'Oveja', 3, 2),
('40404040', 'Francisco', 'Ramos', '1133445588', 'francisco.r@mail.com', 'Francisco31', 'Vaca', 3, 3),
('41414141', 'Sofia', 'Vega', '1166778822', 'sofia.v@mail.com', 'Sofia32', 'Caballo', 1, 2),
('42424242', 'Iván', 'León', '1199225588', 'ivan.l@mail.com', 'Ivan33', 'Cerdo', 2, 3),
('43434343', 'Diana', 'Navarro', '1188447733', 'diana.n@mail.com', 'Diana34', 'Gallina', 3, 2),
('44464444', 'Héctor', 'Quiroz', '1122336699', 'hector.q@mail.com', 'Hector35', 'Gallo', 3, 3),
('45454545', 'Susana', 'Cortes', '1144558822', 'susana.c@mail.com', 'Susana36', 'Pato', 1, 2),
('46464646', 'Arturo', 'Mora', '1155669988', 'arturo.m@mail.com', 'Arturo37', 'Ganso', 2, 3),
('47474747', 'Cristina', 'Valdez', '1133221188', 'cristina.v@mail.com', 'Cristina38', 'Pavo', 3, 2),
('48484848', 'Rodrigo', 'Soto', '1122998811', 'rodrigo.s@mail.com', 'Rodrigo39', 'Pavo Real', 3, 3),
('49494949', 'Paola', 'González', '1177665599', 'paola.g@mail.com', 'Paola40', 'Fénix', 1, 2);


-- Poblar Proveedores
INSERT INTO Proveedores (CUIT, Proveedor, Nombre, Tel, Email, Observacion) VALUES
('30123456789', 'AgroSur', 'Carlos López', '1133445566', 'agrosur@mail.com', 'Proveedor confiable'),
('30987654321', 'BioCultivos', 'Ana Torres', '1144556677', 'biocultivos@mail.com', 'Entrega mensual');

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
('A0000001', 'Pala', 1, 1500.00, 'Herramienta de jardinería', 10),
('A0000002', 'Regadera', 1, 800.00, 'Para riego manual', 5);

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
INSERT INTO HojadeVida (Nombre, Tipo_Animal, Sexo, Fecha_Nacimiento, Peso, Estado_Salud, Activo, Observaciones) VALUES
('Lola', 1, 2, '2023-03-15', 250.00, 'Saludable', 1, 'Observacion'),
('Toby', 2, 1, '2022-11-10', 180.00, 'En tratamiento', 1, 'Observacion');

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
(1, 'A0000001', 'Pala', 1500.00, 2, 3000.00);
/*
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
*/

/*
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
*/

/*
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
*/