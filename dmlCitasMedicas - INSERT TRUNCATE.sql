USE dbCitasMedicas;

-- tblSeguro INSERT
INSERT INTO tblSeguro (nombreSeguro) VALUES ('ARS Humano');
INSERT INTO tblSeguro (nombreSeguro) VALUES ('ARS Universal');
INSERT INTO tblSeguro (nombreSeguro) VALUES ('ARS Palic Salud');
INSERT INTO tblSeguro (nombreSeguro) VALUES ('ARS SeNaSa');
INSERT INTO tblSeguro (nombreSeguro) VALUES ('Medicard');
INSERT INTO tblSeguro (nombreSeguro) VALUES ('ARS Renacer');
INSERT INTO tblSeguro (nombreSeguro) VALUES ('ARS Monumental');
INSERT INTO tblSeguro (nombreSeguro) VALUES ('Serena Salud');
INSERT INTO tblSeguro (nombreSeguro) VALUES ('Pladent');
INSERT INTO tblSeguro (nombreSeguro) VALUES ('ARS MetaSalud');


-- tblEstadoCita INSERT
INSERT INTO tblEstadoCita (nombreEstado) VALUES ('En Agenda');
INSERT INTO tblEstadoCita (nombreEstado) VALUES ('En Curso');
INSERT INTO tblEstadoCita (nombreEstado) VALUES ('Validado');
INSERT INTO tblEstadoCita (nombreEstado) VALUES ('Pendiente');

-- tblEspecialidad INSERT
INSERT INTO tblEspecialidad (nombreEspecialidad) VALUES ('Cardiologia');
INSERT INTO tblEspecialidad (nombreEspecialidad) VALUES ('Neumologia');
INSERT INTO tblEspecialidad (nombreEspecialidad) VALUES ('Oftalmologia');
INSERT INTO tblEspecialidad (nombreEspecialidad) VALUES ('Pediatria');
INSERT INTO tblEspecialidad (nombreEspecialidad) VALUES ('Psiquiatria');
INSERT INTO tblEspecialidad (nombreEspecialidad) VALUES ('Urologia');
INSERT INTO tblEspecialidad (nombreEspecialidad) VALUES ('Neurocirugia');
INSERT INTO tblEspecialidad (nombreEspecialidad) VALUES ('Ginecologia');
INSERT INTO tblEspecialidad (nombreEspecialidad) VALUES ('Dermatologia');

-- tblCentroMedico INSERT
INSERT INTO tblCentroMedico (nombreCentro, telefonoCentro , direccionCentro , paginaWebCentro) VALUES ('Hospital Dr Darío Contreras' , '809-596-3686', 'Av Las Américas 1, Alma Rosa, Santo Domingo', 'http://www.dariocontreras.gob.do/');
INSERT INTO tblCentroMedico (nombreCentro, telefonoCentro , direccionCentro , paginaWebCentro) VALUES ('Servicio Nacional De Salud' , '809-221-3637', 'Av. Leopoldo Navarro esq. César Nicolás Penson, Gascue, Santo Domingo', 'http://sns.gob.do/');
INSERT INTO tblCentroMedico (nombreCentro, telefonoCentro , direccionCentro , paginaWebCentro) VALUES ('Hospiten Santo Domingo' , '809-541-3000', 'Alma Máter, Esq. Bolivar, La Julia, Santo Domingo', 'http://hospiten.com/');
INSERT INTO tblCentroMedico (nombreCentro, telefonoCentro , direccionCentro , paginaWebCentro) VALUES ('Centro Médico Moderno' , '809-548-3131', 'Av. Charles Summer Esq. José López #5, Los Prados, Santo Domingo', 'http://cmm.do/');
INSERT INTO tblCentroMedico (nombreCentro, telefonoCentro , direccionCentro , paginaWebCentro) VALUES ('Medicalnet' , '809-540-9775', 'Calle Rafael Augusto Sánchez 45 Piantini, Santo Domingo', 'http://www.medicalnet.net.do/');

-- tblDoctor INSERT
INSERT INTO tblDoctor (idEspecialidad, nombreDoctor, cedulaDoctor, fechaNacimientoDoctor, correoDoctor, telefonoDoctor, direccionDoctor) VALUES ('1' , 'Angel Contreras', '001-7852546-9', '1976-01-22', 'angelC@hotmail.com', '809-567-1529', 'Av. John F. Kennedy 10, Miraflores, Santo Domingo');
INSERT INTO tblDoctor (idEspecialidad, nombreDoctor, cedulaDoctor, fechaNacimientoDoctor, correoDoctor, telefonoDoctor, direccionDoctor) VALUES ('3' , 'Dionisio Charran Castillo', '012-7851456-7', '1980-05-12', 'charanCastillo@hotmail.com', '809-541-9092', 'Av. Gustavo M. Ricart 106, Piantini, Santo Domingo');
INSERT INTO tblDoctor (idEspecialidad, nombreDoctor, cedulaDoctor, fechaNacimientoDoctor, correoDoctor, telefonoDoctor, direccionDoctor) VALUES ('6' , 'Amado A. Baez', '003-4571298-5', '1978-07-19', 'drAmado@gmail.com', '809-378-1962', 'Av. Abraham Lincoln 1069, Piantini, Santo Domingo');
INSERT INTO tblDoctor (idEspecialidad, nombreDoctor, cedulaDoctor, fechaNacimientoDoctor, correoDoctor, telefonoDoctor, direccionDoctor) VALUES ('4' , 'Arturo Aquino', '102-7845963-6', '1983-11-25', 'arturoAquino@gmail.com', '809-732-9988', 'Av. Pedro H. Ureña 157, La Esperilla, Santo Domingo');
INSERT INTO tblDoctor (idEspecialidad, nombreDoctor, cedulaDoctor, fechaNacimientoDoctor, correoDoctor, telefonoDoctor, direccionDoctor) VALUES ('2' , 'Branche Ortiz Pou', '001-2356741-5', '1973-09-30', 'drOrtizP@hotmail.com', '809-540-9108', 'Av. R. Betancourt 2170, Renacimiento, Edf Bolivar, Santo Domingo');
INSERT INTO tblDoctor (idEspecialidad, nombreDoctor, cedulaDoctor, fechaNacimientoDoctor, correoDoctor, telefonoDoctor, direccionDoctor) VALUES ('5' , 'Cesar Mella', '003-5689369-8', '1979-10-01', 'drMella@hotmail.com', '809-540-6740', 'Av. John F. Kennedy 64, La Fe, esq Tiradentes, Santo Domingo ');

-- tblPaciente INSERT
INSERT INTO tblPaciente (idSeguro, nombrePaciente, cedulaPaciente, fechaNacimientoPaciente, correoPaciente, telefonoPaciente, direccionPaciente) VALUES ('3' , 'Francis Contreras', '402-7845195-9', '1998-01-22', 'francisC@hotmail.com', '809-784-1529', 'Av. John F. Kennedy 110, Tainos, Santo Domingo');
INSERT INTO tblPaciente (idSeguro, nombrePaciente, cedulaPaciente, fechaNacimientoPaciente, correoPaciente, telefonoPaciente, direccionPaciente) VALUES ('1' , 'Oliver Acosta', '402-1237548-9', '1996-11-02', 'oliverA@hotmail.com', '809-372-4211', 'Av. R. Betancourt 7845, Renacimiento, Santo Domingo');
INSERT INTO tblPaciente (idSeguro, nombrePaciente, cedulaPaciente, fechaNacimientoPaciente, correoPaciente, telefonoPaciente, direccionPaciente) VALUES ('5' , 'Lady Calderon', '102-9635157-5', '1990-01-11', 'lady@gmail.com', '809-487-9685', 'Av. Sarasota 9 C, Santo Domingo ');
INSERT INTO tblPaciente (idSeguro, nombrePaciente, cedulaPaciente, fechaNacimientoPaciente, correoPaciente, telefonoPaciente, direccionPaciente) VALUES ('3' , 'Enmanuel Lopez', '403-1458753-2', '1995-07-21', 'enmaLopez@hotmail.com', '809-741-2536', 'Av. Nicolas De Ovando 109, Gascue, Santo Domingo ');
INSERT INTO tblPaciente (idSeguro, nombrePaciente, cedulaPaciente, fechaNacimientoPaciente, correoPaciente, telefonoPaciente, direccionPaciente) VALUES ('6' , 'Nicolas Martinez', '401-7586951-4', '1996-04-01', 'nicoMartinez@hotmail.com', '809-951-2323', 'Av. Jacinto Moya 5, La Julia, Santo Domingo');
INSERT INTO tblPaciente (idSeguro, nombrePaciente, cedulaPaciente, fechaNacimientoPaciente, correoPaciente, telefonoPaciente, direccionPaciente) VALUES ('5' , 'Adrian Reyes', '001-3645852-1', '1996-04-11', 'adrianR@gmail.com', '809-147-1515', 'Av. Lope de Vega 29, Piantini, Santo Domingo');

-- tblCita INSERT
INSERT INTO tblCita(idDoctor , idPaciente, idCentroMedico, idEstadoCita, fechaCita, horaCita) VALUES ('2', '3', '2', '1', '2019-06-30', '18:00:00' );
INSERT INTO tblCita(idDoctor , idPaciente, idCentroMedico, idEstadoCita, fechaCita, horaCita) VALUES ('1', '1', '1', '1', '2019-07-01', '14:30:00' );
INSERT INTO tblCita(idDoctor , idPaciente, idCentroMedico, idEstadoCita, fechaCita, horaCita) VALUES ('3', '5', '3', '1', '2019-07-03', '19:00:00' );
INSERT INTO tblCita(idDoctor , idPaciente, idCentroMedico, idEstadoCita, fechaCita, horaCita) VALUES ('1', '4', '4', '1', '2019-07-05', '10:45:00' );
INSERT INTO tblCita(idDoctor , idPaciente, idCentroMedico, idEstadoCita, fechaCita, horaCita) VALUES ('6', '2', '3', '1', '2019-07-07', '16:00:00' );
INSERT INTO tblCita(idDoctor , idPaciente, idCentroMedico, idEstadoCita, fechaCita, horaCita) VALUES ('1', '1', '5', '4', '2019-07-09', '18:15:00' );


--SELECT
SELECT * FROM tblCita;
SELECT * FROM tblPaciente;
SELECT * FROM tblDoctor;
SELECT * FROM tblCentroMedico;
SELECT * FROM tblEspecialidad;
SELECT * FROM tblEstadoCita;
SELECT * FROM tblSeguro;


--TRUNCATE

-- tblCita TRUNCATE 
TRUNCATE TABLE tblCita

-- tblPaciente TRUNCATE 
ALTER TABLE tblCita 	DROP CONSTRAINT FK_PacienteCita
TRUNCATE TABLE tblPaciente
ALTER TABLE tblCita		ADD CONSTRAINT FK_PacienteCita
		FOREIGN KEY (idPaciente) 	REFERENCES tblPaciente(idPaciente);

-- tblDoctor TRUNCATE
ALTER TABLE tblCita 	DROP CONSTRAINT FK_DoctorCita
TRUNCATE TABLE tblDoctor
ALTER TABLE tblCita 	ADD CONSTRAINT FK_DoctorCita
	FOREIGN KEY (idDoctor) 	REFERENCES tblDoctor(idDoctor);

-- tblCentroMedico TRUNCATE
ALTER TABLE 	tblCita 	DROP CONSTRAINT FK_CentroMedicoCita
TRUNCATE TABLE tblCentroMedico
ALTER TABLE 	tblCita 	ADD CONSTRAINT FK_CentroMedicoCita
	FOREIGN KEY (idCentroMedico) 	REFERENCES tblCentroMedico(idCentroMedico);

-- tblEspecialidad TRUNCATE
ALTER TABLE tblDoctor 	DROP CONSTRAINT FK_EspecialidadDoctor
TRUNCATE TABLE tblEspecialidad
ALTER TABLE tblDoctor 	ADD CONSTRAINT FK_EspecialidadDoctor
	FOREIGN KEY (idEspecialidad) 	REFERENCES tblEspecialidad (idEspecialidad)

-- tblEstadoCita TRUNCATE 
ALTER TABLE tblCita 		DROP CONSTRAINT FK_EstadoC_Cita
TRUNCATE TABLE tblEstadoCita
ALTER TABLE tblCita 		ADD CONSTRAINT FK_EstadoC_Cita
	FOREIGN KEY (idEstadoCita) 	REFERENCES tblEstadoCita (idEstado)

-- tblSeguro TRUNCATE
ALTER TABLE tblPaciente DROP CONSTRAINT FK_SeguroPaciente
TRUNCATE TABLE tblSeguro
ALTER TABLE tblPaciente ADD CONSTRAINT	FK_SeguroPaciente
	FOREIGN KEY (idSeguro) REFERENCES tblSeguro (idSeguro)