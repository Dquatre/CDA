DROP DATABASE IF EXISTS Faute;
CREATE DATABASE Faute DEFAULT CHARACTER SET utf8;
Use Faute;

CREATE TABLE categories(
   idCategories INT AUTO_INCREMENT PRIMARY KEY,
   libelle VARCHAR(50) NOT NULL,
   description VARCHAR(50),
   idCategories_1 INT
)ENGINE=InnoDB;

CREATE TABLE modele(
   idModele INT AUTO_INCREMENT PRIMARY KEY,
   codeModele VARCHAR(8) NOT NULL,
   nom VARCHAR(50) NOT NULL,
   dateMiseSurMarche VARCHAR(50) NOT NULL

)ENGINE=InnoDB;

CREATE TABLE produit(
   idProduit INT AUTO_INCREMENT PRIMARY KEY,
   numSerie VARCHAR(6) NOT NULL,
   numProduit VARCHAR(4) NOT NULL,
   idModele INT NOT NULL

)ENGINE=InnoDB;

CREATE TABLE faute(
   idFaute INT AUTO_INCREMENT PRIMARY KEY,
   titre VARCHAR(50) NOT NULL,
   dateDetection DATE NOT NULL,
   commentaire VARCHAR(50) NOT NULL,
   dateReparation DATE,
   idProduit INT NOT NULL
)ENGINE=InnoDB;

CREATE TABLE faute_categories(
    id_Faute_categories INT AUTO_INCREMENT PRIMARY KEY,
   idFaute INT ,
   idCategories INT

)ENGINE=InnoDB;

ALTER TABLE modele ADD CONSTRAINT UNIQUE(codeModele)
ALTER TABLE categories ADD CONSTRAINT FK_categories_categories FOREIGN KEY(idCategories_1) REFERENCES catégories(idCategories)
ALTER TABLE produit 
    ADD CONSTRAINT FK_produit_modele FOREIGN KEY(idModele) REFERENCES modele(idModele)
ALTER TABLE faute
   ADD CONSTRAINT FK_faute_produit FOREIGN KEY(idProduit) REFERENCES produit(idProduit)
ALTER TABLE faute_categories
   ADD CONSTRAINT FK_faute_categories_faute FOREIGN KEY(idFaute) REFERENCES faute(idFaute),
   ADD CONSTRAINT FK_faute_categories_categories FOREIGN KEY(idCategories) REFERENCES catégories(idCategories)