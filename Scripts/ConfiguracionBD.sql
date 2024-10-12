--Creo una base de datos para un sistema de citas con su respectivo paciente y medico
CREATE TABLE Medicos (
    MedicoID SERIAL PRIMARY KEY,    
    Nombre VARCHAR(100) NOT NULL,            
    Especialidad VARCHAR(100) NOT NULL,    
    FechaIngreso DATE NOT NULL DEFAULT CURRENT_DATE, 
    CONSTRAINT UQ_Medico_Especialidad UNIQUE ( Especialidad)  ---Limito que me pueda existir 2 medicos de la misma especialidad
);


CREATE TABLE Pacientes (
    PacienteID SERIAL PRIMARY KEY,          
    Nombre VARCHAR(100) NOT NULL,            
    FechaNacimiento DATE NOT NULL,           
    MedicoID INT NOT NULL,                    
    FechaRegistro DATE NOT NULL DEFAULT CURRENT_DATE,  
    CONSTRAINT FK_Paciente_Medico FOREIGN KEY (MedicoID) REFERENCES Medicos(MedicoID) ---Hago la llave foranea para que su paciente tenga su respectivo medico
);


CREATE TABLE CitasMedicas (
    CitaID SERIAL PRIMARY KEY,               
    PacienteID INT NOT NULL,            
    MedicoID INT NOT NULL,                   
    FechaCita TIMESTAMP NOT NULL,         
    MotivoConsulta VARCHAR(255) NOT NULL,    
    CONSTRAINT FK_Cita_Paciente FOREIGN KEY (PacienteID) REFERENCES Pacientes(PacienteID)  
        ON DELETE CASCADE,   ----Configuro para que cuando se elimine el paciente se borren sus registros                  
    CONSTRAINT FK_Cita_Medico FOREIGN KEY (MedicoID) REFERENCES Medicos(MedicoID)    
        ON DELETE CASCADE,      ---Configuro para que cuando se elimine el doctor se eliminen sus citas             
    CONSTRAINT UQ_Cita_Fecha_Medico_Paciente UNIQUE (PacienteID, MedicoID, FechaCita) 
);