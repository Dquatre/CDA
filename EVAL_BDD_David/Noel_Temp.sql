
DROP DATABASE IF EXISTS noel;
CREATE DATABASE noel;
USE noel;

CREATE TABLE addresse(
   idAddresse INT,
   numero VARCHAR(50) NOT NULL,
   rue VARCHAR(50) NOT NULL,
   complement VARCHAR(50),
   ville VARCHAR(50) NOT NULL,
   codePostal VARCHAR(50) NOT NULL,
   pays VARCHAR(50) NOT NULL,
   PRIMARY KEY(idAddresse)
)ENGINE=innoDB  DEFAULT CHARSET=utf8;

CREATE TABLE lutin(
   numLutin INT,
   nomLutin VARCHAR(50) NOT NULL,
   prenomLutin VARCHAR(50) NOT NULL,
   PRIMARY KEY(numLutin)
)ENGINE=innoDB  DEFAULT CHARSET=utf8;

CREATE TABLE traineau(
   numTraineau INT,
   tailleTraineau INT NOT NULL,
   dateServiceTraineau DATE NOT NULL,
   dateRevisionTraineau DATE,
   PRIMARY KEY(numTraineau)
)ENGINE=innoDB  DEFAULT CHARSET=utf8;

CREATE TABLE tournee(
   numTournee INT,
   heureDebutTournee TIME NOT NULL,
   numLutin INT NOT NULL,
   numTraineau INT NOT NULL,
   PRIMARY KEY(numTournee),
   FOREIGN KEY(numLutin) REFERENCES lutin(numLutin),
   FOREIGN KEY(numTraineau) REFERENCES traineau(numTraineau)
);

CREATE TABLE renne(
   idRenne INT,
   sexeRenne VARCHAR(1) NOT NULL,
   dateNaissanceRenne DATE,
   nomRenne VARCHAR(50),
   PRIMARY KEY(idRenne),
   UNIQUE(nomRenne)
)ENGINE=innoDB  DEFAULT CHARSET=utf8;

CREATE TABLE enfant(
   numEnfant INT,
   nomEnfant VARCHAR(50) NOT NULL,
   prenomEnfant VARCHAR(50) NOT NULL,
   sexe VARCHAR(1) NOT NULL,
   voeuEnfant VARCHAR(255),
   sagesseEnfant DECIMAL(3,2) NOT NULL,
   idAddresse INT NOT NULL,
   PRIMARY KEY(numEnfant),
   FOREIGN KEY(idAddresse) REFERENCES addresse(idAddresse)
)ENGINE=innoDB  DEFAULT CHARSET=utf8;

CREATE TABLE cadeau(
   numCadeau INT,
   designationCadeau VARCHAR(50) NOT NULL,
   numTournee INT NOT NULL,
   numEnfant INT NOT NULL,
   PRIMARY KEY(numCadeau),
   FOREIGN KEY(numTournee) REFERENCES tournee(numTournee),
   FOREIGN KEY(numEnfant) REFERENCES enfant(numEnfant)
)ENGINE=innoDB  DEFAULT CHARSET=utf8;

CREATE TABLE traineau_lutin(
   numLutin INT,
   numTraineau INT,
   datePriseResp DATE NOT NULL,
   PRIMARY KEY(numLutin, numTraineau),
   FOREIGN KEY(numLutin) REFERENCES lutin(numLutin),
   FOREIGN KEY(numTraineau) REFERENCES traineau(numTraineau)
)ENGINE=innoDB  DEFAULT CHARSET=utf8;

CREATE TABLE renne_tournee(
   numTournee INT,
   idRenne INT,
   PRIMARY KEY(numTournee, idRenne),
   FOREIGN KEY(numTournee) REFERENCES tournee(numTournee),
   FOREIGN KEY(idRenne) REFERENCES renne(idRenne)
)ENGINE=innoDB  DEFAULT CHARSET=utf8;

