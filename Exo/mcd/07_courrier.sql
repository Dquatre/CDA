CREATE TABLE typeCorrier(
   idTypeCourrier INT,
   libelle VARCHAR(50) NOT NULL,
   PRIMARY KEY(idTypeCourrier)
);

CREATE TABLE courrier(
   idCorrier INT,
   typeCourrier VARCHAR(50) NOT NULL,
   idTypeCourrier INT NOT NULL,
   PRIMARY KEY(idCorrier),
   FOREIGN KEY(idTypeCourrier) REFERENCES typeCorrier(idTypeCourrier)
);

CREATE TABLE bureauPoste(
   idPoste INT,
   cp VARCHAR(5) NOT NULL,
   PRIMARY KEY(idPoste)
);

CREATE TABLE centreTri(
   idCentreTri INT,
   PRIMARY KEY(idCentreTri)
);

CREATE TABLE typeTransport(
   idTypeTransport INT,
   libelleTransport VARCHAR(50) NOT NULL,
   taxeCarbon INT NOT NULL,
   PRIMARY KEY(idTypeTransport)
);

CREATE TABLE est_gerer(
   idCorrier INT,
   idPoste INT,
   DateEnvoi DATE,
   dateRecevoir DATE,
   PRIMARY KEY(idCorrier, idPoste),
   FOREIGN KEY(idCorrier) REFERENCES courrier(idCorrier),
   FOREIGN KEY(idPoste) REFERENCES bureauPoste(idPoste)
);

CREATE TABLE transit(
   idPoste INT,
   idCentreTri INT,
   idTypeTransport INT,
   PRIMARY KEY(idPoste, idCentreTri, idTypeTransport),
   FOREIGN KEY(idPoste) REFERENCES bureauPoste(idPoste),
   FOREIGN KEY(idCentreTri) REFERENCES centreTri(idCentreTri),
   FOREIGN KEY(idTypeTransport) REFERENCES typeTransport(idTypeTransport)
)ENGINE=InnoDB;
