-- MySQL dump 10.16  Distrib 10.1.36-MariaDB, for Linux (x86_64)
--
-- Host: localhost    Database: projet
-- ------------------------------------------------------
-- Server version	10.1.36-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `model_ingredient`
--

DROP TABLE IF EXISTS `model_ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `model_ingredient` (
  `id_model_ingr` int(11) NOT NULL,
  `nom_ingr` varchar(255) NOT NULL,
  `inventory-size` int(10) NOT NULL,
  `id_mod_stock` int(11) NOT NULL,
  PRIMARY KEY (`id_model_ingr`),
  KEY `model_ingredient_model_stockage_FK` (`id_mod_stock`),
  CONSTRAINT `model_ingredient_model_stockage_FK` FOREIGN KEY (`id_mod_stock`) REFERENCES `model_stockage` (`id_mod_stock`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `model_ingredient`
--

LOCK TABLES `model_ingredient` WRITE;
/*!40000 ALTER TABLE `model_ingredient` DISABLE KEYS */;
INSERT INTO `model_ingredient` VALUES (1,'carrot',1,2),(2,'tomato',1,2),(3,'onion',1,2),(4,'pork',2,0),(5,'potato',1,2),(6,'meat',2,0),(7,'egg',1,0),(8,'butter',1,0);
/*!40000 ALTER TABLE `model_ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `model_stockage`
--

DROP TABLE IF EXISTS `model_stockage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `model_stockage` (
  `id_mod_stock` int(11) NOT NULL,
  `nom` varchar(255) NOT NULL,
  `time_to_live` int(15) NOT NULL,
  PRIMARY KEY (`id_mod_stock`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `model_stockage`
--

LOCK TABLES `model_stockage` WRITE;
/*!40000 ALTER TABLE `model_stockage` DISABLE KEYS */;
INSERT INTO `model_stockage` VALUES (0,'frigo',259200),(1,'congélateur',604800),(2,'stock',2592000);
/*!40000 ALTER TABLE `model_stockage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock_ingredient`
--

DROP TABLE IF EXISTS `stock_ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stock_ingredient` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `quantite` int(11) NOT NULL,
  `id_model_ingr` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `stock_ingredient_UN` (`id_model_ingr`),
  KEY `stock_ingredient_model_ingredient_FK` (`id_model_ingr`),
  CONSTRAINT `stock_ingredient_model_ingredient_FK` FOREIGN KEY (`id_model_ingr`) REFERENCES `model_ingredient` (`id_model_ingr`)
) ENGINE=InnoDB AUTO_INCREMENT=167 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock_ingredient`
--

LOCK TABLES `stock_ingredient` WRITE;
/*!40000 ALTER TABLE `stock_ingredient` DISABLE KEYS */;
INSERT INTO `stock_ingredient` VALUES (84,43,1),(88,40,2);
/*!40000 ALTER TABLE `stock_ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'projet'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-12-15 14:50:16
