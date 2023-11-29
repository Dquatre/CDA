-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mar. 28 nov. 2023 à 15:51
-- Version du serveur : 5.7.36
-- Version de PHP : 8.1.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `platformdb`
--

-- --------------------------------------------------------

--
-- Structure de la table `games`
--

DROP TABLE IF EXISTS `games`;
CREATE TABLE IF NOT EXISTS `games` (
  `idGame` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(50) NOT NULL,
  `subTitle` varchar(50) DEFAULT NULL,
  `releaseYear` int(11) DEFAULT NULL,
  `idSerie` int(11) DEFAULT NULL,
  PRIMARY KEY (`idGame`),
  KEY `FK_game_serie` (`idSerie`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `games`
--

INSERT INTO `games` (`idGame`, `title`, `subTitle`, `releaseYear`, `idSerie`) VALUES
(1, 'Zelda no Densetsu', NULL, 1986, 1);

-- --------------------------------------------------------

--
-- Structure de la table `games_platforms`
--

DROP TABLE IF EXISTS `games_platforms`;
CREATE TABLE IF NOT EXISTS `games_platforms` (
  `idGame_Platform` int(11) NOT NULL AUTO_INCREMENT,
  `idGame` int(11) DEFAULT NULL,
  `idPlatform` int(11) DEFAULT NULL,
  PRIMARY KEY (`idGame_Platform`),
  KEY `FK_games_games_platforms` (`idGame`),
  KEY `FK_platforms_games_platforms` (`idPlatform`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `games_platforms`
--

INSERT INTO `games_platforms` (`idGame_Platform`, `idGame`, `idPlatform`) VALUES
(1, 1, 1),
(2, 1, 2);

-- --------------------------------------------------------

--
-- Structure de la table `platforms`
--

DROP TABLE IF EXISTS `platforms`;
CREATE TABLE IF NOT EXISTS `platforms` (
  `idPlatform` int(11) NOT NULL AUTO_INCREMENT,
  `platformName` varchar(50) NOT NULL,
  `constructor` varchar(50) NOT NULL,
  PRIMARY KEY (`idPlatform`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `platforms`
--

INSERT INTO `platforms` (`idPlatform`, `platformName`, `constructor`) VALUES
(1, 'Family Computer', 'Nintendo'),
(2, 'Famicom Disk System', 'Nintendo');

-- --------------------------------------------------------

--
-- Structure de la table `series`
--

DROP TABLE IF EXISTS `series`;
CREATE TABLE IF NOT EXISTS `series` (
  `idSerie` int(11) NOT NULL AUTO_INCREMENT,
  `serieName` varchar(50) NOT NULL,
  PRIMARY KEY (`idSerie`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `series`
--

INSERT INTO `series` (`idSerie`, `serieName`) VALUES
(1, 'Zelda no Densetsu');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `games`
--
ALTER TABLE `games`
  ADD CONSTRAINT `FK_game_serie` FOREIGN KEY (`idSerie`) REFERENCES `series` (`idSerie`);

--
-- Contraintes pour la table `games_platforms`
--
ALTER TABLE `games_platforms`
  ADD CONSTRAINT `FK_games_games_platforms` FOREIGN KEY (`idGame`) REFERENCES `games` (`idGame`),
  ADD CONSTRAINT `FK_platforms_games_platforms` FOREIGN KEY (`idPlatform`) REFERENCES `platforms` (`idPlatform`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
