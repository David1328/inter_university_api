-------------------------------------Script para crear los docentes--------------------------------
INSERT INTO [dbo].[teachers] (NameSubjet, numCredits, TeacherId) VALUES 
-- Profesor 1
('Programación I', 3, 1002345678),
('Desarrollo Web', 3, 1002345678),

-- Profesor 2
('Estructuras de Datos', 3, 1009876543),
('Matemáticas Discretas', 3, 1009876543),

-- Profesor 3
('Bases de Datos', 3, 1011234567),
('Algoritmos', 3, 1011234567),

-- Profesor 4
('Ingeniería de Software', 3, 1018765432),
('Sistemas Operativos', 3, 1018765432),

-- Profesor 5
('Redes de Computadores', 3, 1023456789),
('Arquitectura de Computadores', 3, 1023456789);
-------------------------------------Script para crear los clases--------------------------------

INSERT INTO [dbo].[Subjects] (NameSubjet, numCredits, TeacherId) VALUES 
('Programación I', 3, 1002345678),
('Estructuras de Datos', 4, 1009876543),
('Bases de Datos', 3, 1011234567),
('Ingeniería de Software', 4, 1018765432),
('Sistemas Operativos', 3, 1023456789),
('Redes de Computadores', 3, 1029876543),
('Arquitectura de Computadores', 4, 1034567890),
('Desarrollo Web', 3, 1039876543),
('Matemáticas Discretas', 3, 1041234567),
('Algoritmos', 4, 1048765432);