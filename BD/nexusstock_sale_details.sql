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
-- Table structure for table `sale_details`
--

DROP TABLE IF EXISTS `sale_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sale_details` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SaleId` int NOT NULL,
  `ProductId` int NOT NULL,
  `Quantity` int NOT NULL,
  `UnitPrice` decimal(13,2) NOT NULL,
  `Subtotal` decimal(13,2) GENERATED ALWAYS AS ((`Quantity` * `UnitPrice`)) STORED,
  PRIMARY KEY (`Id`),
  KEY `fk_sale_details_sales` (`SaleId`),
  KEY `fk_sale_details_products` (`ProductId`),
  CONSTRAINT `fk_sale_details_products` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`),
  CONSTRAINT `fk_sale_details_sales` FOREIGN KEY (`SaleId`) REFERENCES `sales` (`Id`),
  CONSTRAINT `chk_sale_price` CHECK ((`UnitPrice` >= 0)),
  CONSTRAINT `chk_sale_quantity` CHECK ((`Quantity` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sale_details`
--

LOCK TABLES `sale_details` WRITE;
/*!40000 ALTER TABLE `sale_details` DISABLE KEYS */;
INSERT INTO `sale_details` (`Id`, `SaleId`, `ProductId`, `Quantity`, `UnitPrice`) VALUES (1,1,1,3,159999.99),(2,2,1,2,159999.99),(3,3,4,5,139999.99),(4,4,5,3,59999.99),(5,5,4,3,139999.99),(6,6,4,2,139999.99),(7,7,5,5,59999.99),(8,7,4,2,139999.99),(9,8,5,2,59999.99),(10,9,5,3,59999.99),(13,12,5,2,59999.99),(16,15,4,1,150000.00),(19,18,4,1,150000.00),(27,24,4,4,150000.00),(28,25,3,8,449999.99),(29,26,2,3,179999.99),(30,27,2,1,179999.99);
/*!40000 ALTER TABLE `sale_details` ENABLE KEYS */;
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
