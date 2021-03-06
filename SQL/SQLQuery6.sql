--SET DATABASE BABEL;

Create table CLIENTES(
		IDCLIENTE INT NOT NULL PRIMARY KEY,
		NOMBRE VARCHAR(50),
		APPATERNO VARCHAR(50),
		APMATERNO VARCHAR(50),
		BORRADO BIT,
		FECHAMOD DATETIME
		);
CREATE TABLE PLANES (
		IDPLAN INT NOT NULL PRIMARY KEY,
		DESCRIPCION VARCHAR(50),
		FECHAMOD DATETIME
);

CREATE TABLE COBERTURA (
		IDCOBERTURA INT NOT NULL PRIMARY KEY,
		DESCRIPCION VARCHAR(50),
		FECHAMOD DATETIME
);

CREATE TABLE REL_CLIENTE_PLAN(
	IDCP INT NOT NULL PRIMARY KEY,
	IDCLIENTE INT NOT NULL  FOREIGN KEY REFERENCES CLIENTES(IDCLIENTE),
	IDPLAN INT NOT NULL  FOREIGN KEY REFERENCES PLANES(IDPLAN),
	FECHAMOD DATETIME
);


CREATE TABLE REL_PLAN_COBER(
	IDpc INT NOT NULL PRIMARY KEY,
	IDPLAN INT NOT NULL  FOREIGN KEY REFERENCES PLANES(IDPLAN),
	IDCOBER INT NOT NULL  FOREIGN KEY REFERENCES COBERTURA(IDCOBERTURA)
);
