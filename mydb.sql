-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 25, 2016 at 11:31 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `mydb`
--

-- --------------------------------------------------------

--
-- Table structure for table `baza_znanja`
--

CREATE TABLE IF NOT EXISTS `baza_znanja` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `naziv_incidenta` varchar(50) NOT NULL,
  `rjesenje` varchar(500) NOT NULL,
  `id_k` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_k` (`id_k`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `baza_znanja`
--

INSERT INTO `baza_znanja` (`id`, `naziv_incidenta`, `rjesenje`, `id_k`) VALUES
(1, 'Incident 1', 'rj 1', 1),
(2, 'Incident 2', 'rj 2', 1),
(3, 'Incident 3', 'rj 3', 2);

-- --------------------------------------------------------

--
-- Table structure for table `edukacija`
--

CREATE TABLE IF NOT EXISTS `edukacija` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `naziv` varchar(50) DEFAULT NULL,
  `opis` varchar(150) DEFAULT NULL,
  `kategorija` varchar(50) DEFAULT NULL,
  `trajanje` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `edukacija`
--

INSERT INTO `edukacija` (`id`, `naziv`, `opis`, `kategorija`, `trajanje`) VALUES
(1, 'Edukacija 1', '...', NULL, '14 dana'),
(2, 'Edukacija 2', '...', NULL, '1 sedmica');

-- --------------------------------------------------------

--
-- Table structure for table `incident`
--

CREATE TABLE IF NOT EXISTS `incident` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `vrijemePrijave` datetime DEFAULT NULL,
  `naziv` varchar(45) DEFAULT NULL,
  `opis` varchar(45) DEFAULT NULL,
  `Kategorija_id` int(11) DEFAULT NULL,
  `prioritet` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `Korisnik_id` int(11) NOT NULL,
  `Napomena-M` varchar(50) DEFAULT NULL,
  `Napomena-K` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Incident_Korisnik1_idx` (`Korisnik_id`),
  KEY `fk_Incident_Kategorija1_idx` (`Kategorija_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `incident`
--

INSERT INTO `incident` (`id`, `vrijemePrijave`, `naziv`, `opis`, `Kategorija_id`, `prioritet`, `status`, `Korisnik_id`, `Napomena-M`, `Napomena-K`) VALUES
(3, NULL, 'Prvi incident', 'Opis prvog incidenta', 1, 'Nizak', 'Otvoren', 1, 'Ceka potvrdu korisnika', NULL),
(4, NULL, 'Drugi incident', '...', 1, 'Visok', 'Zatvoren', 1, '/', NULL),
(5, '2016-03-08 20:07:14', 'novi', 'novi', 1, NULL, 'Otvoren', 1, '/', NULL),
(6, '2016-03-30 23:34:13', 'Incident 5', '/', 1, 'Srednji', 'Zatvoren', 1, '/', NULL),
(7, '2016-03-31 00:02:44', 'proba', 'proba', 1, 'Nizak', 'Zatvoren', 1, 'Ceka potvrdu korisnika', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `kategorija`
--

CREATE TABLE IF NOT EXISTS `kategorija` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `naziv` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `kategorija`
--

INSERT INTO `kategorija` (`id`, `naziv`) VALUES
(1, 'Kategorija 1'),
(2, 'Kategorija 2');

-- --------------------------------------------------------

--
-- Table structure for table `korisnik`
--

CREATE TABLE IF NOT EXISTS `korisnik` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `ime` varchar(45) DEFAULT NULL,
  `prezime` varchar(45) DEFAULT NULL,
  `Tip_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username_UNIQUE` (`username`),
  KEY `fk_Korisnik_Tip_idx` (`Tip_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `korisnik`
--

INSERT INTO `korisnik` (`id`, `username`, `password`, `ime`, `prezime`, `Tip_id`) VALUES
(1, 'dahmic', 'dahmic', 'Dina', 'Ahmić', 1),
(2, 'amina', 'amina', 'Amina', 'Kadrispahić', 2),
(3, 'ilma', 'ilma', 'Ilma', 'Kurtović', 3),
(4, 'azra', 'azra', 'Azra', 'Delić', 4),
(5, 'denis', 'denis', 'Denis', 'Hadžialić', 5);

-- --------------------------------------------------------

--
-- Table structure for table `korisnikxedukacija`
--

CREATE TABLE IF NOT EXISTS `korisnikxedukacija` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_k` int(11) DEFAULT NULL,
  `id_e` int(11) DEFAULT NULL,
  `odobreno` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_k` (`id_k`),
  KEY `id_e` (`id_e`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `korisnikxedukacija`
--

INSERT INTO `korisnikxedukacija` (`id`, `id_k`, `id_e`, `odobreno`) VALUES
(1, 2, 1, 1),
(2, 5, 2, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tip`
--

CREATE TABLE IF NOT EXISTS `tip` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `naziv` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `tip`
--

INSERT INTO `tip` (`id`, `naziv`) VALUES
(1, 'admin'),
(2, 'incidentM'),
(3, 'knowledgeM'),
(4, 'continuityM'),
(5, 'korisnik');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `baza_znanja`
--
ALTER TABLE `baza_znanja`
  ADD CONSTRAINT `baza_znanja_ibfk_1` FOREIGN KEY (`id_k`) REFERENCES `kategorija` (`id`);

--
-- Constraints for table `incident`
--
ALTER TABLE `incident`
  ADD CONSTRAINT `fk_Incident_Kategorija1` FOREIGN KEY (`Kategorija_id`) REFERENCES `kategorija` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Incident_Korisnik1` FOREIGN KEY (`Korisnik_id`) REFERENCES `korisnik` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `korisnik`
--
ALTER TABLE `korisnik`
  ADD CONSTRAINT `fk_Korisnik_Tip` FOREIGN KEY (`Tip_id`) REFERENCES `tip` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `korisnikxedukacija`
--
ALTER TABLE `korisnikxedukacija`
  ADD CONSTRAINT `id_e` FOREIGN KEY (`id_e`) REFERENCES `edukacija` (`id`),
  ADD CONSTRAINT `id_k` FOREIGN KEY (`id_k`) REFERENCES `korisnik` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
