-- MySQL dump 10.13  Distrib 8.0.46, for Win64 (x86_64)
--
-- Host: localhost    Database: nexusstock
-- ------------------------------------------------------
-- Server version	8.0.46

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `providers`
--

DROP TABLE IF EXISTS `providers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `providers` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Surname` varchar(50) NOT NULL,
  `Cuit` varchar(15) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Tel` varchar(13) NOT NULL,
  `State` tinyint(1) DEFAULT '1',
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Cuit` (`Cuit`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `providers`
--

LOCK TABLES `providers` WRITE;
/*!40000 ALTER TABLE `providers` DISABLE KEYS */;
INSERT INTO `providers` VALUES (1,'Juan','Gomez','30-71234567-1','juan.gomez@techsupply.com','3624123456',1,'2026-10-07 07:08:40'),(2,'Martin','Lopez','30-72345678-2','martin.lopez@hardware.com','3624234567',1,'2026-10-07 07:08:40'),(3,'Lucas','Fernandez','30-73456789-3','lucas.fernandez@compumarket.com','3624345678',1,'2026-10-07 07:08:40'),(4,'Nicolas','Martinez','30-74567890-4','nicolas.martinez@digitalworld.com','3624456789',1,'2026-10-07 07:08:40'),(5,'Diego','Rodriguez','30-75678901-5','diego.rodriguez@megatech.com','3624567890',1,'2026-10-07 07:08:40'),(6,'Santiago','Gonzalez','30-76789012-6','santiago.gonzalez@hardtech.com','3624678901',1,'2026-10-07 07:08:40'),(7,'Federico','Diaz','30-77890123-7','federico.diaz@pcstore.com','3624789012',1,'2026-10-07 07:08:40'),(8,'Agustin','Sanchez','30-78901234-8','agustin.sanchez@globalcomponents.com','3624890123',1,'2026-10-07 07:08:40'),(9,'Pablo','Romero','30-79012345-9','pablo.romero@byteSolutions.com','3624901234',1,'2026-10-07 07:08:40'),(10,'Matias','Torres','30701234560','matias.torres@importadoradelta.com','5493624012345',0,'2026-10-07 07:08:40'),(11,'Gonzalo','Sudria','20400495646','sudria@gmail.com','5493794403693',0,'2026-11-03 03:14:41'),(13,'gggggggg','sdsadsadsad','26345123738','asdasd@gmail.com','5493794403693',1,'2026-11-03 18:56:48');
/*!40000 ALTER TABLE `providers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-11-11  8:39:17
