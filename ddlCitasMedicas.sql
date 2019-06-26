CREATE DATABASE dbCitasMedicas
GO

USE dbCitasMedicas
GO


CREATE TABLE tblCentroMedico(

	idCentroMedico INT NOT NULL,
	nombreCentro varchar(50) NOT NULL,
	telefonoCentro varchar(15)NOT NULL,
	direccionCentro varchar(50)NOT NULL,
	paginaWebCentro varchar(25)

--PRIMARY KEYS
	PRIMARY KEY (idCentroMedico)
--FOREIGN KEYS

);


CREATE TABLE tblSeguro(
	
	idSeguro INT,
	nombreSeguro varchar(20) NOT NULL

	--PRIMARY KEYS
	PRIMARY KEY (idSeguro)
	--FOREIGN KEYS

);


CREATE TABLE tblEspecialidad(
	
	idEspecialidad INT,
	nombreEspecialidad varchar(20) NOT NULL

	--PRIMARY KEYS
	PRIMARY KEY (idEspecialidad)
	--FOREIGN KEYS

);




CREATE TABLE tblDoctor (

	idDoctor INT NOT NULL,
	idEspecialidad int NOT NULL,
	nombreDoctor varchar(20) NOT NULL,
	cedulaDoctor char(11) UNIQUE NOT NULL,
	fechaNacimientoDoctor date,
	correoDoctor varchar(30),
	telefonoDoctor varchar(15),
	direccionDoctor varchar(50),

--PRIMARY KEY
	PRIMARY KEY (idDoctor),
--FOREIGN KEYS
	FOREIGN KEY (idEspecialidad) REFERENCES tblEspecialidad(idEspecialidad)

);


CREATE TABLE tblPaciente (

	idPaciente INT NOT NULL,
	idSeguro int NOT NULL,
	nombrePaciente varchar(20) NOT NULL,
	cedulaPaciente char(11) UNIQUE NOT NULL,
	fechaNacimientoPaciente date,
	correoPaciente varchar(30),
	telefonoPaciente varchar(15),
	direccionPaciente varchar(50),

--PRIMARY KEY
	PRIMARY KEY (idPaciente),
--FOREIGN KEYS
	FOREIGN KEY (idSeguro) REFERENCES tblSeguro(idSeguro)

);









CREATE TABLE tblEstadoCita(
	
	idEstado INT,
	nombreEstado varchar(15)

	--PRIMARY KEYS
	PRIMARY KEY (idEstado)
	--FOREIGN KEYS

);


CREATE TABLE tblCita(
	idCita INT,
	idDoctor int,
	idPaciente int,
	idCentroMedico int,
	idEstadoCita int,
	fechaCita date NOT NULL,
	horaCita time NOT NULL,
	

	

	--PRIMARY KEYS
	PRIMARY KEY (idCita),
	--FOREIGN KEYS
	FOREIGN KEY (idDoctor) REFERENCES tblDoctor(idDoctor),
	FOREIGN KEY (idPaciente) REFERENCES tblPaciente(idPaciente),
	FOREIGN KEY (idCentroMedico) REFERENCES tblCentroMedico(idCentroMedico),
	FOREIGN KEY (idEstadoCita) REFERENCES tblEstadoCita(idEstado),

);



