CREATE DATABASE dbCitasMedicas
GO

-- DROP TABLE tblCita, tblEstadoCita, tblPaciente, tblDoctor, tblEspecialidad, tblSeguro, tblCentroMedico;

USE dbCitasMedicas
GO


CREATE TABLE tblCentroMedico(

	idCentroMedico INT NOT NULL IDENTITY,
	nombreCentro varchar(50) NOT NULL,
	telefonoCentro varchar(15) NOT NULL,
	direccionCentro varchar(100) NOT NULL,
	paginaWebCentro varchar(50)

	--PRIMARY KEYS
	PRIMARY KEY (idCentroMedico)
	--FOREIGN KEYS

);


CREATE TABLE tblSeguro(
	
	idSeguro INT NOT NULL IDENTITY,
	nombreSeguro varchar(20)

	--PRIMARY KEYS
	PRIMARY KEY (idSeguro)
	--FOREIGN KEYS

);


CREATE TABLE tblEspecialidad(
	
	idEspecialidad INT NOT NULL IDENTITY,
	nombreEspecialidad varchar(20)

	--PRIMARY KEYS
	PRIMARY KEY (idEspecialidad)
	--FOREIGN KEYS

);


CREATE TABLE tblDoctor (

	idDoctor INT NOT NULL IDENTITY,
	idEspecialidad INT NOT NULL,
	nombreDoctor varchar(30) NOT NULL,
	cedulaDoctor char(15) UNIQUE NOT NULL,
	fechaNacimientoDoctor date,
	correoDoctor varchar(30),
	telefonoDoctor varchar(15),
	direccionDoctor varchar(100),

	--PRIMARY KEY
	PRIMARY KEY (idDoctor),
	--FOREIGN KEYS
	CONSTRAINT FK_EspecialidadDoctor FOREIGN KEY (idEspecialidad) REFERENCES tblEspecialidad(idEspecialidad)

);


CREATE TABLE tblPaciente (

	idPaciente INT NOT NULL IDENTITY,
	idSeguro INT NOT NULL,
	nombrePaciente varchar(30) NOT NULL,
	cedulaPaciente char(15) UNIQUE NOT NULL,
	fechaNacimientoPaciente date,
	correoPaciente varchar(30),
	telefonoPaciente varchar(15),
	direccionPaciente varchar(100),

	--PRIMARY KEY
	PRIMARY KEY (idPaciente),
	--FOREIGN KEYS
	CONSTRAINT FK_SeguroPaciente FOREIGN KEY (idSeguro) REFERENCES tblSeguro(idSeguro)

);


CREATE TABLE tblEstadoCita(
	
	idEstado INT NOT NULL IDENTITY,
	nombreEstado varchar(20)

	--PRIMARY KEYS
	PRIMARY KEY (idEstado)
	--FOREIGN KEYS

);


CREATE TABLE tblCita(
	idCita INT NOT NULL IDENTITY,
	idDoctor INT NOT NULL,
	idPaciente INT NOT NULL,
	idCentroMedico INT NOT NULL,
	idEstadoCita INT NOT NULL,
	fechaCita date NOT NULL,
	horaCita time NOT NULL,

	--PRIMARY KEYS
	PRIMARY KEY (idCita),
	--FOREIGN KEYS
	CONSTRAINT FK_DoctorCita FOREIGN KEY (idDoctor) REFERENCES tblDoctor(idDoctor),
	CONSTRAINT FK_PacienteCita FOREIGN KEY (idPaciente) REFERENCES tblPaciente(idPaciente),
	CONSTRAINT FK_CentroMedicoCita FOREIGN KEY (idCentroMedico) REFERENCES tblCentroMedico(idCentroMedico),
	CONSTRAINT FK_EstadoC_Cita FOREIGN KEY (idEstadoCita) REFERENCES tblEstadoCita(idEstado),

);



