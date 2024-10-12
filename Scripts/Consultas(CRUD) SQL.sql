INSERT INTO public.medico(
	 "Nombre", "Especialidad", "FechaIngreso")
	VALUES
	('Dr. Juan Pérez', 'Cardiología', '2020-01-15'),
('Dra. María López', 'Pediatría', '2019-05-20'),
('Dr. Carlos Rodríguez', 'Neurología', '2021-03-10'),
('Dra. Ana Martínez', 'Dermatología', '2018-11-30'),
('Dr. Luis Sánchez', 'Oftalmología', '2022-02-05'),
('Dra. Elena Gómez', 'Ginecología', '2020-09-22'),
('Dr. Miguel Fernández', 'Traumatología', '2019-07-14'),
('Dra. Isabel Torres', 'Psiquiatría', '2021-06-18'),
('Dr. Roberto Díaz', 'Endocrinología', '2020-04-03'),
('Dra. Carmen Ruiz', 'Oncología', '2022-01-07');

INSERT INTO public.paciente(
	 "Nombre", "FechaNacimiento", "MedicoID", "FechaRegistro")
	VALUES 
	('María López', '1985-02-12', 1, '2023-06-21'),
('Pedro González', '1990-07-19', 2, '2023-07-10'),
('Luisa Fernández', '1975-10-05', 3, '2023-06-15'),
('Ricardo Torres', '1982-03-09', 4, '2023-05-25'),
('Ana García', '1995-11-21', 5, '2023-04-12'),
('José Castillo', '2000-06-14', 6, '2023-03-08'),
('Laura Hernández', '1988-01-17', 7, '2023-02-18'),
('Carlos Morales', '1979-04-26', 8, '2023-07-05'),
('Lucía Rodríguez', '1998-08-30', 9, '2023-06-01'),
('Andrés Vázquez', '1970-12-05', 10, '2023-05-20');

INSERT INTO public."citaMedica"(
	 "PacienteID", "MedicoID", "FechaCita", "MotivoConsulta")
	VALUES 
(1, 1, '2023-07-01 09:30:00', 'Revision cardiologica'),
(2, 2, '2023-07-11 10:00:00', 'Consulta de la piel'),
(3, 3, '2023-06-20 11:15:00', 'Chequeo general pediatrico'),
(4, 4, '2023-06-01 14:00:00', 'Consulta ginecológica de rutina'),
(5, 5, '2023-04-15 12:30:00', 'Consulta por migrañas'),
(6, 6, '2023-03-10 09:45:00', 'Revision oncológica'),
(7, 7, '2023-02-20 16:00:00', 'Problemas de vision'),
(8, 8, '2023-07-06 13:30:00', 'Revision de tiroides'),
(9, 9, '2023-06-03 11:00:00', 'Consulta urologica'),
(10, 10, '2023-05-25 15:30:00', 'Dolores articulares en las manos');

-- Obtener las citas médicas con los nombres de los pacientes y los médicos y su respectiva patología
SELECT 
    cm."FechaCita", 
    p."Nombre" AS Paciente, 
    m."Nombre" AS Medico, 
    cm."MotivoConsulta"
FROM 
    public."citaMedica" cm
INNER JOIN 
    public.paciente p ON cm."PacienteID" = p."PacienteID"
INNER JOIN 
    public.medico m ON cm."MedicoID" = m."MedicoID"
ORDER BY 
    cm."FechaCita";

-- Obtener una lista de tanto médicos como pacientes y el tipo ya sea paciente o médico
SELECT 
    "Nombre", 
    'Medico' AS Tipo
FROM 
    public.medico
UNION
SELECT 
    "Nombre", 
    'Paciente' AS Tipo
FROM 
    public.paciente;

-- Clasificar los pacientes dependiendo de su año de nacimiento como señor, adulto o joven adulto
SELECT 
    "Nombre", 
    "FechaNacimiento",
    CASE
        WHEN EXTRACT(YEAR FROM "FechaNacimiento") < 1980 THEN 'Senior'
        WHEN EXTRACT(YEAR FROM "FechaNacimiento") BETWEEN 1980 AND 2000 THEN 'Adult'
        ELSE 'Young Adult'
    END AS ClasificacionEdad
FROM 
    public.paciente;

-- Actualizar las citas médicas que no especifiquen su motivo de consulta y poner "Revisión general"
UPDATE 
    public."citaMedica"
SET 
    "MotivoConsulta" = 
    CASE 
        WHEN "MotivoConsulta" IS NULL OR "MotivoConsulta" = '' THEN 'Revisión general'
        ELSE "MotivoConsulta"
    END
WHERE 
    "MotivoConsulta" IS NULL OR "MotivoConsulta" = '';

-- Eliminar citas médicas para pacientes que no están en el sistema
DELETE FROM 
    public."citaMedica"
WHERE 
    "PacienteID" NOT IN (SELECT "PacienteID" FROM public.paciente);