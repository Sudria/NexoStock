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
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clients` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Surname` varchar(50) NOT NULL,
  `Dni` varchar(15) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Tel` varchar(13) NOT NULL,
  `State` tinyint(1) DEFAULT '1',
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Dni` (`Dni`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1,'Juan','Perez','30123456','juan.perez@example.com','3794001001',1,'2026-01-15 10:30:00'),(2,'Maria','Gomez','32456789','maria.gomez@example.com','3794001002',1,'2026-02-10 11:15:00'),(3,'Carlos','Rodriguez','28765432','carlos.rodriguez@example.com','3794001003',1,'2026-03-05 09:00:00'),(4,'Lucia','Fernandez','35678901','lucia.fernandez@example.com','3794001004',0,'2026-03-20 14:45:00'),(5,'Martin','Lopez','29876543','martin.lopez@example.com','3794001005',1,'2026-04-12 16:20:00'),(6,'Sofia','Martinez','36789012','sofia.martinez@example.com','3794001006',1,'2026-05-08 12:00:00'),(7,'Diego','Gonzalez','31234567','diego.gonzalez@example.com','3794001007',0,'2026-06-17 08:30:00'),(8,'Valentina','Diaz','38901234','valentina.diaz@example.com','3794001008',1,'2026-07-03 13:10:00'),(9,'Federico','Torres','33456789','federico.torres@example.com','3794001009',1,'2026-08-22 15:00:00'),(10,'Camila','Ramirez','37890123','camila.ramirez@example.com','5493794001010',1,'2026-09-14 10:00:00');
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-11-11  8:39:16
