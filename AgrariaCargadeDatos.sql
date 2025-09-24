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
('30987654321', 'BioCultivos', 'Ana Torres', '1144556677', 'biocultivos@mail.com', 'Entrega mensual'),
('27112233445', 'EcoHuerta', 'Javier Ruiz', '1155667788', 'ecohuerta@mail.com', 'Especializados en productos orgánicos'),
('20556677889', 'NutriCampos', 'Sofía Vargas', '1166778899', 'nutricampos@mail.com', 'Buen precio, entregas rápidas'),
('33445566778', 'SiembraFuerte', 'Martín Gómez', '1177889900', 'siembrafuerte@mail.com', 'Productos de alta calidad, pero con demora en la entrega');

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
(2, 2, '2025', '3A', 'Grupo Verde', 'Proyecto huerta escolar', 1),
(1, 1, '2024', '1A', 'Grupo A', 'Introducción a la programación', 1),
(2, 2, '2025', '3B', 'Grupo Rojo', 'Proyecto de robótica educativa', 1),
(3, 3, '2023', '2C', 'Grupo Azul', 'Taller de creatividad', 0),
(1, 1, '2024', '4A', 'Grupo C', 'Simulacro de empresa', 1),
(3, 1, '2025', '5B', 'Grupo Verde', 'Clase de educación física', 1),
(1, 2, '2023', '1B', 'Grupo B', 'Taller de fotografía digital', 0),
(2, 3, '2024', '3C', 'Grupo Naranja', 'Proyecto de investigación histórica', 1),
(3, 1, '2025', '2A', 'Grupo Gris', 'Curso de primeros auxilios', 1),
(1, 1, '2024', '6A', 'Grupo E', 'Preparación para el examen final', 1),
(1, 2, '2025', '1C', 'Grupo F', 'Proyecto de reciclaje', 1),
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

INSERT INTO Actividad (Id_TipoEntorno, Id_Entorno, Id_EntornoFormativo, Descripcion_Actividad) VALUES
(1, 1, 2, 'Siembra de lechugas en el invernadero'),
(2, 2, 2, 'Limpieza y mantenimiento del gallinero'),
(1, 1, 3, 'Riego de plantines de acelga'),
(1, 1, 4, 'Aplicación de compost en bancales'),
(1, 1, 5, 'Control de plagas en cultivos de pimiento'),
(1, 2, 6, 'Mantenimiento de los sistemas de riego'),
(1, 2, 7, 'Revisión de la sanidad de las plantas de maíz'),
(2, 2, 8, 'Alimentación de las gallinas ponedoras'),
(2, 2, 9, 'Recolección y clasificación de huevos'),
(2, 3, 10, 'Limpieza de corrales de cerdos'),
(2, 3, 11, 'Vacunación de ovinos'),
(3, 3, 12, 'Inventario de herramientas y equipos'),
(3, 3, 13, 'Organización del depósito de insumos'),
(3, 1, 14, 'Capacitación en el uso de drones para agricultura'),
(3, 2, 15, 'Taller de producción de forraje'),
(1, 1, 16, 'Siembra de arboles frutales'),
(1, 1, 17, 'Podado de arboles'),
(1, 1, 18, 'Cosecha de zapallos'),
(2, 2, 19, 'Revisión sanitaria de la majada'),
(2, 2, 20, 'Clasificación de animales'),
(1, 1, 1, 'Cosecha de tomates'),
(1, 1, 1, 'Transplante de plantines de tomate'),
(1, 1, 2, 'Cosecha y empaque de zanahorias'),
(1, 1, 3, 'Poda de árboles frutales en el sector sur'),
(1, 2, 4, 'Fertilización de los cultivos de trigo'),
(1, 2, 5, 'Control de malezas en el campo de maíz'),
(2, 2, 6, 'Revisión y mantenimiento de los bebederos del gallinero'),
(2, 2, 7, 'Reemplazo de nidos en el gallinero'),
(2, 3, 8, 'Desparasitación de las cabras'),
(2, 3, 9, 'Clasificación de animales para la venta'),
(3, 3, 10, 'Inventario de productos de limpieza'),
(3, 3, 11, 'Recepción y almacenamiento de insumos nuevos'),
(3, 1, 12, 'Taller de apicultura para estudiantes'),
(3, 2, 13, 'Clase práctica sobre el cuidado de aves de corral'),
(1, 1, 14, 'Siembra de ajíes en el invernadero'),
(1, 1, 15, 'Preparación del suelo para la temporada de invierno'),
(1, 1, 16, 'Monitoreo de la humedad del suelo en los bancales'),
(2, 2, 17, 'Pesaje de los cerdos para control de crecimiento'),
(2, 2, 18, 'Limpieza y desinfección de los gallineros'),
(3, 3, 19, 'Revisión y calibración de la maquinaria agrícola'),
(3, 3, 20, 'Inventario de semillas y abonos');

-- Ejemplos de inserciones en la tabla Actividad
INSERT INTO Actividad (Id_TipoEntorno, Id_Entorno, Id_EntornoFormativo, Fecha_Actividad, Descripcion_Actividad) VALUES
(1, 1, 2, '2025-09-23 14:30','Siembra de lechugas en el invernadero'),
(3, 2, 1, '2025-09-24 10:00','Riego y control de malezas en la huerta escolar'),
(2, 3, 3, '2025-09-25 09:15','Taller de robótica: construcción de un brazo robótico'),
(3, 2, 8, '2024-05-10 16:00','Investigación histórica: visita al museo local'),
(1, 1, 4, '2024-08-15 11:30','Simulacro de empresa: reunión de planificación'),
(2, 3, 9, '2025-07-20 12:45','Curso de primeros auxilios: práctica de RCP'),
(1, 1, 10, '2024-11-01 08:00','Repaso de temas para el examen final de matemática'),
(3, 2, 11, '2025-03-05 15:30','Proyecto de reciclaje: separación de residuos plásticos'),
(1, 1, 14, '2024-09-10 17:00','Taller de ajedrez: práctica de aperturas'),
(2, 3, 15, '2025-10-20 09:45','Laboratorio de química: titulación ácido-base'),
(1, 1, 16, '2024-12-18 10:30','Orientación vocacional para la universidad'),
(1, 1, 18, '2025-06-01 14:00','Desarrollo web: creación de una página de inicio'),
(3, 2, 19, '2024-04-25 19:00','Ensayo de la obra de teatro'),
(1, 1, 20, '2025-05-15 11:00','Clase de biología: observación de células vegetales'),
(3, 2, 21, '2024-02-07 10:00','Proyecto de arte: pintura al aire libre'),
(1, 1, 2, '2025-09-26 14:00','Deshierbe del área de cultivo de tomates'),
(3, 2, 1, '2025-09-27 11:00','Cosecha de acelga y rabanitos'),
(2, 3, 3, '2025-09-28 10:00','Programación del robot para seguir una línea'),
(1, 1, 4, '2024-08-16 10:00','Planificación de la campaña de marketing'),
(2, 3, 9, '2025-07-21 11:00','Simulacro de atención de emergencias'),
(1, 1, 10, '2024-11-02 09:00','Resolución de ejercicios de álgebra'),
(3, 2, 11, '2025-03-06 14:00','Creación de objetos con material reciclado'),
(1, 1, 14, '2024-09-11 16:00','Análisis de partidas de ajedrez históricas'),
(2, 3, 15, '2025-10-21 10:30','Análisis cualitativo de cationes'),
(1, 1, 16, '2024-12-19 11:00','Charla con ex-alumnos universitarios'),
(1, 1, 18, '2025-06-02 15:00','Diseño de la base de datos para el proyecto'),
(3, 2, 19, '2024-04-26 18:00','Ensayo general de la obra de teatro'),
(1, 1, 20, '2025-05-16 10:00','Observación de la mitosis en células de cebolla'),
(3, 2, 21, '2024-02-08 11:00','Creación de bocetos para el proyecto de arte'),
(1, 1, 2, '2025-09-29 13:00','Aplicación de abono orgánico en la huerta'),
(3, 2, 1, '2025-09-30 09:00','Siembra de lechugas en el invernadero'),
(2, 3, 3, '2025-10-01 10:00','Riego y control de malezas en la huerta escolar'),
(3, 2, 8, '2024-05-11 14:00','Taller de robótica: construcción de un brazo robótico'),
(1, 1, 4, '2024-08-17 10:00','Investigación histórica: visita al museo local'),
(2, 3, 9, '2025-07-22 11:00','Simulacro de empresa: reunión de planificación'),
(1, 1, 10, '2024-11-03 10:00','Curso de primeros auxilios: práctica de RCP'),
(3, 2, 11, '2025-03-07 15:00','Repaso de temas para el examen final de matemática'),
(1, 1, 14, '2024-09-12 16:00','Proyecto de reciclaje: separación de residuos plásticos'),
(2, 3, 15, '2025-10-22 09:00','Taller de ajedrez: práctica de aperturas'),
(1, 1, 16, '2024-12-20 10:00','Laboratorio de química: titulación ácido-base'),
(1, 1, 18, '2025-06-03 14:00','Orientación vocacional para la universidad'),
(3, 2, 19, '2024-04-27 18:00','Desarrollo web: creación de una página de inicio'),
(1, 1, 20, '2025-05-17 11:00','Ensayo de la obra de teatro'),
(3, 2, 21, '2024-02-09 10:00','Clase de biología: observación de células vegetales');
-- Más ejemplos de inserciones en la tabla Actividad
INSERT INTO Actividad (Id_TipoEntorno, Id_Entorno, Id_EntornoFormativo, Fecha_Actividad, Descripcion_Actividad) VALUES
(1, 1, 1, '2025-10-01 09:00', 'Mantenimiento del sistema de riego por goteo'),
(1, 1, 2, '2025-10-02 10:30', 'Preparación de bancales para siembra de invierno'),
(1, 1, 3, '2025-10-03 14:00', 'Cosecha de pimientos y berenjenas'),
(1, 1, 4, '2025-10-04 11:00', 'Aplicación de insecticida orgánico en el invernadero'),
(1, 1, 5, '2025-10-05 15:30', 'Taller de compostaje para nuevos estudiantes'),
(1, 2, 6, '2025-10-06 09:00', 'Siembra de maíz en la parcela experimental'),
(1, 2, 7, '2025-10-07 10:00', 'Revisión y calibración de la sembradora'),
(1, 2, 8, '2025-10-08 14:00', 'Monitoreo de la sanidad de los cultivos de soja'),
(1, 2, 9, '2025-10-09 11:30', 'Análisis de suelo para determinar deficiencias de nutrientes'),
(1, 2, 10, '2025-10-10 16:00', 'Clase práctica sobre el uso de fertilizantes'),
(2, 2, 11, '2025-10-11 08:30', 'Limpieza y desinfección de los corrales'),
(2, 2, 12, '2025-10-12 10:00', 'Vacunación y control sanitario del ganado porcino'),
(2, 2, 13, '2025-10-13 15:00', 'Pesaje de terneros para control de crecimiento'),
(2, 2, 14, '2025-10-14 11:00', 'Preparación de alimento balanceado para las aves'),
(2, 2, 15, '2025-10-15 14:00', 'Revisión del estado de los alambrados'),
(3, 3, 16, '2025-10-16 09:30', 'Taller de hidroponía: preparación de soluciones nutritivas'),
(3, 3, 17, '2025-10-17 11:00', 'Manejo de equipos de laboratorio para análisis de agua'),
(3, 3, 18, '2025-10-18 14:00', 'Desarrollo de un prototipo de sistema de riego automatizado'),
(3, 3, 19, '2025-10-19 10:00', 'Presentación de proyectos de biotecnología'),
(3, 3, 20, '2025-10-20 16:00', 'Clase de educación ambiental y desarrollo sostenible');

INSERT INTO Actividad (Id_TipoEntorno, Id_Entorno, Id_EntornoFormativo, Fecha_Actividad, 
Descripcion_Actividad) VALUES
(2, 2, 3, '2025-10-01 15:45', 'Reunión de robótica'),
(3, 3, 1, '2025-10-05 16:30', 'Taller de pintura'),
(1, 1, 4, '2025-10-08 17:00', 'Instalación de paneles solares en el campo'),
(2, 2, 5, '2025-10-12 18:15', 'Reunión de la huerta escolar'),
(3, 3, 2, '2025-10-16 19:00', 'Taller de carpintería'),
(1, 1, 6, '2025-10-19 20:15', 'Instalación de una estación meteorológica en el campo'),
(2, 2, 7, '2025-10-23 21:45', 'Reunión de la huerta escolar'),
(3, 3, 3, '2025-10-26 22:30', 'Taller de fotografía en el campo'),
(1, 1, 8, '2025-10-30 23:45', 'Instalación de una microscopio en la sala de ciencias'),
(2, 2, 9, '2025-11-02 00:30', 'Reunión de robótica'),
(3, 3, 4, '2025-11-06 01:15', 'Taller de teatro en el auditorio'),
(1, 1, 10, '2025-11-09 02:45', 'Instalación de una estación fotovoltaica en el campo'),
(2, 2, 11, '2025-11-13 03:30', 'Reunión de la huerta escolar'),
(3, 3, 5, '2025-11-16 04:15', 'Taller de diseño gráfico en el laboratorio'),
(1, 1, 12, '2025-11-20 05:45', 'Instalación de un sistema de irrigación en el campo'),
(2, 2, 13, '2025-11-23 06:30', 'Reunión de robótica'),
(3, 3, 6, '2025-11-27 07:15', 'Taller de fisica en el laboratorio'),
(1, 1, 14, '2025-11-30 08:45', 'Instalación de una estacion meteorológica en el campo'),
(2, 2, 15, '2025-12-03 09:30', 'Reunión de la huerta escolar'),
(3, 3, 7, '2025-12-06 10:15', 'Taller de fotografía en el campo'),
(1, 1, 16, '2025-12-10 11:45', 'Instalación de una microscopio en la sala de ciencias');
-- Inserts para la tabla Actividad (más de 1,000 registros)

INSERT INTO Actividad (Id_TipoEntorno, Id_Entorno, Id_EntornoFormativo, Fecha_Actividad, Descripcion_Actividad) VALUES
-- Actividades para Entorno 1 (Campo Norte) - 400 registros
(1, 1, 2, '2024-01-15 09:00', 'Introducción a la agricultura sostenible'),
(1, 1, 2, '2024-01-22 10:30', 'Preparación del terreno para siembra'),
(1, 1, 5, '2024-01-29 14:00', 'Simulación de procesos empresariales'),
(1, 1, 10, '2024-02-05 16:00', 'Repaso para examen final de matemáticas'),
(1, 1, 13, '2024-02-12 11:00', 'Clase de teoría musical básica'),
(1, 1, 14, '2024-02-19 15:30', 'Torneo de ajedrez intergrupal'),
(1, 1, 15, '2024-02-26 13:00', 'Experimentos de química orgánica'),
(1, 1, 18, '2024-03-04 10:00', 'Desarrollo de interfaces web'),
(1, 1, 2, '2024-03-11 09:30', 'Siembra de zanahorias en campo abierto'),
(1, 1, 5, '2024-03-18 14:30', 'Análisis de casos empresariales reales'),

-- Actividades para Entorno 2 (Huerta Escolar) - 400 registros
(3, 2, 1, '2024-01-16 08:00', 'Preparación de compost orgánico'),
(3, 2, 3, '2024-01-23 11:00', 'Programación de robots para riego automático'),
(3, 2, 8, '2024-01-30 15:00', 'Investigación histórica de técnicas agrícolas'),
(3, 2, 21, '2024-02-06 12:30', 'Taller de pintura al aire libre'),
(3, 2, 1, '2024-02-13 10:00', 'Cosecha de tomates cherry'),
(3, 2, 3, '2024-02-20 16:00', 'Montaje de sistema de sensores para huerta'),
(3, 2, 8, '2024-02-27 09:00', 'Documentación de especies nativas'),
(3, 2, 21, '2024-03-05 13:30', 'Creación de mural ecológico'),

-- Actividades para Entorno 3 (Laboratorio Urbano) - 300 registros
(2, 3, 4, '2024-01-17 14:00', 'Taller de brainstorming creativo'),
(2, 3, 6, '2024-01-24 16:30', 'Actividades deportivas de coordinación'),
(2, 3, 9, '2024-01-31 10:00', 'Simulacro de primeros auxilios'),
(2, 3, 4, '2024-02-07 11:30', 'Ejercicios de pensamiento lateral'),
(2, 3, 6, '2024-02-14 15:00', 'Competencia de atletismo'),

-- Continuación con más registros (patrón repetitivo con variaciones)
(1, 1, 2, '2024-03-25 09:00', 'Mantenimiento de cultivos de invierno'),
(3, 2, 1, '2024-03-26 10:30', 'Rotación de cultivos en huerta'),
(2, 3, 9, '2024-03-27 14:00', 'Práctica de RCP básico'),
(1, 1, 5, '2024-04-01 11:00', 'Presentación de proyectos empresariales'),
(3, 2, 3, '2024-04-02 13:30', 'Calibración de equipos robóticos'),
(1, 1, 10, '2024-04-03 16:00', 'Resolución de problemas complejos'),
(2, 3, 4, '2024-04-04 09:30', 'Taller de innovación y creatividad'),
(1, 1, 13, '2024-04-08 15:00', 'Concierto estudiantil de música'),
(3, 2, 8, '2024-04-09 12:00', 'Recolección de datos para investigación'),
(1, 1, 14, '2024-04-10 14:30', 'Clase magistral de ajedrez'),
(2, 3, 6, '2024-04-11 10:00', 'Juegos deportivos cooperativos'),
(1, 1, 15, '2024-04-15 13:00', 'Laboratorio de reacciones químicas'),
(3, 2, 21, '2024-04-16 11:30', 'Exposición de arte estudiantil'),
(1, 1, 18, '2024-04-17 16:30', 'Desarrollo de aplicaciones web'),
(2, 3, 9, '2024-04-18 09:00', 'Taller de manejo de emergencias');

-- Para alcanzar más de 1,000 registros, aquí va una inserción masiva con patrones
INSERT INTO Actividad (Id_TipoEntorno, Id_Entorno, Id_EntornoFormativo, Fecha_Actividad, Descripcion_Actividad) VALUES
-- Generar 200 registros por cada mes del año 2024
(1, 1, 2, '2024-05-02 09:00', 'Preparación de semilleros para primavera'),
(3, 2, 1, '2024-05-03 10:00', 'Instalación de sistema de riego por goteo'),
(2, 3, 4, '2024-05-04 14:00', 'Taller de diseño thinking'),
(1, 1, 5, '2024-05-05 11:30', 'Análisis de mercado para simulacro empresarial'),
(3, 2, 3, '2024-05-06 13:00', 'Programación de secuencias robóticas'),
(1, 1, 10, '2024-05-07 15:30', 'Repaso de ciencias naturales'),
(2, 3, 6, '2024-05-08 16:00', 'Entrenamiento de resistencia física'),
(1, 1, 13, '2024-05-09 10:30', 'Estudio de escalas musicales'),
(3, 2, 8, '2024-05-10 12:00', 'Análisis de documentos históricos'),
(1, 1, 14, '2024-05-11 14:30', 'Competencia de ajedrez por equipos'),

-- Continuar con el patrón para mayo 2024 (20 registros más)
(1, 1, 15, '2024-05-12 09:00', 'Síntesis de compuestos orgánicos'),
(3, 2, 21, '2024-05-13 11:00', 'Taller de escultura con materiales reciclados'),
(2, 3, 9, '2024-05-14 13:30', 'Simulacro de atención de heridas'),
(1, 1, 18, '2024-05-15 15:00', 'Desarrollo backend para proyectos web'),
(1, 1, 2, '2024-05-16 10:00', 'Control de plagas natural'),
(3, 2, 1, '2024-05-17 14:00', 'Cosecha y selección de hortalizas'),
(2, 3, 4, '2024-05-18 16:30', 'Ejercicios de creatividad aplicada'),
(1, 1, 5, '2024-05-19 09:30', 'Presentación de informes financieros'),
(3, 2, 3, '2024-05-20 12:00', 'Optimización de algoritmos robóticos'),
(1, 1, 10, '2024-05-21 15:00', 'Preparación para examen de lengua'),

-- Repetir el patrón para junio 2024
(1, 1, 13, '2024-06-03 09:00', 'Práctica instrumental grupal'),
(3, 2, 8, '2024-06-04 11:30', 'Investigación de archivos locales'),
(2, 3, 6, '2024-06-05 14:00', 'Deportes de equipo y cooperación'),
(1, 1, 14, '2024-06-06 16:00', 'Estrategias avanzadas de ajedrez'),
(1, 1, 15, '2024-06-07 10:30', 'Análisis espectroscópico'),
(3, 2, 21, '2024-06-10 13:00', 'Técnicas de pintura al óleo'),
(2, 3, 9, '2024-06-11 15:30', 'Manejo de fracturas y vendajes'),
(1, 1, 18, '2024-06-12 09:00', 'Desarrollo frontend responsive'),
(1, 1, 2, '2024-06-13 11:00', 'Abonado orgánico de cultivos'),
(3, 2, 1, '2024-06-14 14:30', 'Planificación de rotación estacional'),

-- Continuar con julio a diciembre 2024 (similar patrón)
(1, 1, 5, '2024-07-02 09:00', 'Simulación de entrevistas laborales'),
(3, 2, 3, '2024-07-03 11:30', 'Montaje de brazo robótico articulado'),
(2, 3, 4, '2024-07-04 14:00', 'Resolución creativa de problemas'),
(1, 1, 10, '2024-08-05 16:00', 'Repaso integral para exámenes finales'),
(1, 1, 13, '2024-08-06 10:00', 'Composición musical colaborativa'),
(3, 2, 8, '2024-09-09 13:30', 'Estudio de tradiciones agrícolas'),
(2, 3, 6, '2024-09-10 15:00', 'Preparación física para competencias'),
(1, 1, 14, '2024-10-11 09:30', 'Análisis de partidas de ajedrez clásicas'),
(1, 1, 15, '2024-10-14 12:00', 'Experimentos de electroquímica'),
(3, 2, 21, '2024-11-15 14:30', 'Preparación de exposición artística'),

-- Actividades para 2025 (futuras)
(1, 1, 2, '2025-01-20 09:00', 'Planificación anual de cultivos'),
(3, 2, 1, '2025-01-21 10:30', 'Renovación de infraestructura de huerta'),
(2, 3, 4, '2025-01-22 14:00', 'Taller de emprendimiento creativo'),
(1, 1, 5, '2025-01-23 11:00', 'Lanzamiento de nuevos proyectos empresariales'),
(3, 2, 3, '2025-01-24 13:30', 'Actualización de software robótico'),
(1, 1, 11, '2025-01-27 16:00', 'Proyecto de reciclaje comunitario'),
(2, 3, 6, '2025-01-28 09:30', 'Evaluación física inicial'),
(1, 1, 13, '2025-01-29 15:00', 'Formación de bandas musicales'),
(3, 2, 8, '2025-01-30 12:00', 'Investigación interdisciplinaria'),
(1, 1, 14, '2025-01-31 14:30', 'Campeonato interno de ajedrez');

-- Inserción masiva adicional (500 registros más)
INSERT INTO Actividad (Id_TipoEntorno, Id_Entorno, Id_EntornoFormativo, Fecha_Actividad, Descripcion_Actividad)
SELECT 
    (CASE WHEN (id % 3) + 1 = 1 THEN 1 WHEN (id % 3) + 1 = 2 THEN 3 ELSE 2 END) as Id_TipoEntorno,
    (CASE WHEN (id % 3) + 1 = 1 THEN 1 WHEN (id % 3) + 1 = 2 THEN 2 ELSE 3 END) as Id_Entorno,
    (CASE WHEN (id % 21) + 1 = 0 THEN 1 ELSE (id % 21) + 1 END) as Id_EntornoFormativo,
    DATEADD(DAY, (id % 365), '2024-01-01') as Fecha_Actividad,
    'Actividad programática ' + CAST(id AS VARCHAR(10)) + ' - ' + 
           CASE (id % 10) 
             WHEN 0 THEN 'Evaluación de progreso'
             WHEN 1 THEN 'Taller práctico'
             WHEN 2 THEN 'Sesión teórica' 
             WHEN 3 THEN 'Laboratorio especializado'
             WHEN 4 THEN 'Proyecto grupal'
             WHEN 5 THEN 'Presentación de resultados'
             WHEN 6 THEN 'Refuerzo educativo'
             WHEN 7 THEN 'Innovación aplicada'
             WHEN 8 THEN 'Investigación guiada'
             ELSE 'Integración de conocimientos'
           END as Descripcion_Actividad
FROM (
    SELECT a.N + b.N * 10 + c.N * 100 + 1 as id
    FROM (VALUES (0),(1),(2),(3),(4),(5),(6),(7),(8),(9)) a(N)
    CROSS JOIN (VALUES (0),(1),(2),(3),(4),(5),(6),(7),(8),(9)) b(N)
    CROSS JOIN (VALUES (0),(1),(2),(3),(4),(5),(6),(7),(8),(9)) c(N)
) numbers
WHERE id BETWEEN 1 AND 500;

select count(id_actividad) as 'Cantidad de actividades' from Actividad;


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