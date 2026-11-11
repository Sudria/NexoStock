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
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Cod` varchar(20) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `SalePrice` decimal(13,2) DEFAULT '0.00',
  `Stock` int DEFAULT '0',
  `StockMin` int DEFAULT '0',
  `State` tinyint(1) DEFAULT '1',
  `BrandId` int DEFAULT '0',
  `CategoryId` int DEFAULT '0',
  `ProviderId` int DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Cod` (`Cod`),
  KEY `fk_brands` (`BrandId`),
  KEY `fk_providers` (`ProviderId`),
  KEY `fk_categorys` (`CategoryId`),
  CONSTRAINT `fk_brands` FOREIGN KEY (`BrandId`) REFERENCES `brands` (`Id`),
  CONSTRAINT `fk_categorys` FOREIGN KEY (`CategoryId`) REFERENCES `categorys` (`Id`),
  CONSTRAINT `fk_providers` FOREIGN KEY (`ProviderId`) REFERENCES `providers` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Ryzen 5 5600','CPUAMD5600','Procesador AMD Ryzen 5 5600 de 6 nucleos y 12 hilos',160000.00,0,5,0,1,1,1),(2,'Core i5 12400F','CPUINT12400F','Procesador Intel Core i5 12400F de 6 nucleos y 12 hilos',179999.99,6,3,1,2,1,2),(3,'RTX 4060 8GB','GPU-N4060-8','Placa de video NVIDIA GeForce RTX 4060 de 8GB',449999.99,0,2,1,3,2,3),(4,'B550M Gaming','MBMSIB550M','Motherboard MSI B550M compatible con procesadores AMD Ryzen',150000.00,0,4,1,5,3,4),(5,'Kingston Fury 16GB','RAMKF16DDR4','Memoria RAM Kingston Fury de 16GB DDR4 3200MHz',240000.00,20,5,1,9,4,5),(13,'Ryzen 5 5500','CPUAMD5500','Procesador AMD Ryzen 5 5500 de 6 nucleos y 12 hilos',114000.00,9,4,1,1,1,1),(14,'Ryzen 7 5700X','CPUAMD5700X','Procesador AMD Ryzen 7 5700X de 8 nucleos y 16 hilos',222000.00,3,3,1,1,1,2),(15,'Ryzen 7 5800X','CPUAMD5800X','Procesador AMD Ryzen 7 5800X de 8 nucleos y 16 hilos',264000.00,3,2,1,1,1,3),(16,'Ryzen 9 5900X','CPUAMD5900X','Procesador AMD Ryzen 9 5900X de 12 nucleos y 24 hilos',372000.00,2,2,1,1,1,4),(17,'Core i3 12100F','CPUINT12100F','Procesador Intel Core i3 12100F de 4 nucleos y 8 hilos',96000.00,6,4,1,2,1,5),(18,'Core i5 13400F','CPUINT13400F','Procesador Intel Core i5 13400F de 10 nucleos y 16 hilos',228000.00,5,3,1,2,1,6),(19,'GTX 1650 4GB','GPU-N1650-4','Placa de video NVIDIA GeForce GTX 1650 de 4GB',198000.00,4,2,1,3,2,3),(20,'RTX 3060 12GB','GPU-N3060-12','Placa de video NVIDIA GeForce RTX 3060 de 12GB',348000.00,5,3,1,3,2,4),(21,'RTX 4060 Ti 8GB','GPU-N4060TI-8','Placa de video NVIDIA GeForce RTX 4060 Ti de 8GB',504000.00,1,2,1,3,2,5),(22,'RTX 4070 12GB','GPU-N4070-12','Placa de video NVIDIA GeForce RTX 4070 de 12GB',816000.00,1,1,1,3,2,6),(23,'Radeon RX 6600 8GB','GPU-AMD6600-8','Placa de video AMD Radeon RX 6600 de 8GB',276000.00,3,3,1,1,2,7),(24,'Radeon RX 7600 8GB','GPU-AMD7600-8','Placa de video AMD Radeon RX 7600 de 8GB',384000.00,4,2,1,1,2,8),(25,'A520M-K','MBAUS-A520MK','Motherboard ASUS A520M-K compatible con procesadores AMD Ryzen',84000.00,9,3,1,4,3,1),(26,'B450M DS3H','MBGIG-B450DS','Motherboard Gigabyte B450M DS3H para procesadores AMD Ryzen',96000.00,5,3,1,6,3,2),(27,'B550 Gaming Plus','MBMSI-B550GP','Motherboard MSI B550 Gaming Plus para procesadores AMD Ryzen',186000.00,7,2,1,5,3,3),(28,'H610M-H','MBGIG-H610MH','Motherboard Gigabyte H610M-H compatible con Intel de 12va generacion',105000.00,0,3,1,6,3,4),(29,'B760M DS3H','MBGIG-B760DS','Motherboard Gigabyte B760M DS3H compatible con Intel',168000.00,3,2,1,6,3,5),(30,'Kingston Fury 8GB','RAMKF8DDR4','Memoria RAM Kingston Fury de 8GB DDR4 3200MHz',30000.00,22,6,1,9,4,6),(31,'Kingston Fury 32GB','RAMKF32DDR4','Memoria RAM Kingston Fury de 32GB DDR4 3200MHz',102000.00,11,4,1,9,4,7),(32,'Corsair Vengeance 16GB','RAMCV16DDR4','Memoria RAM Corsair Vengeance de 16GB DDR4 3200MHz',57600.00,22,5,1,8,4,8),(33,'Corsair Vengeance 32GB','RAMCV32DDR4','Memoria RAM Corsair Vengeance de 32GB DDR4 3600MHz',114000.00,5,3,1,8,4,9),(34,'Kingston Fury 16GB DDR5','RAMKF16DDR5','Memoria RAM Kingston Fury de 16GB DDR5 5200MHz',74400.00,8,4,1,9,4,1),(35,'HDD 500GB','HDD500GB001','Disco rigido de 500GB SATA para almacenamiento',48000.00,6,3,1,9,5,2),(36,'HDD 1TB','HDD1TB0001','Disco rigido de 1TB SATA para computadoras de escritorio',74400.00,8,4,1,9,5,3),(37,'HDD 2TB','HDD2TB0001','Disco rigido de 2TB SATA para almacenamiento de datos',102000.00,5,2,1,9,5,4),(38,'Kingston NV2 500GB','SSD-KNV2500','Disco SSD Kingston NV2 NVMe de 500GB',54000.00,18,5,1,9,6,5),(39,'Kingston NV2 1TB','SSD-KNV21000','Disco SSD Kingston NV2 NVMe de 1TB',90000.00,19,4,1,9,6,6),(40,'Kingston A400 480GB','SSD-KA400480','Disco SSD Kingston A400 SATA de 480GB',50400.00,10,5,1,9,6,7),(41,'Corsair MP600 1TB','SSD-CMP6001T','Disco SSD Corsair MP600 NVMe de 1TB',138000.00,3,2,1,8,6,8),(42,'Corsair CV550','PSU-CORCV550','Fuente Corsair CV550 de 550W certificacion 80 Plus Bronze',84000.00,9,3,1,8,7,9),(43,'Corsair CV650','PSU-CORCV650','Fuente Corsair CV650 de 650W certificacion 80 Plus Bronze',108000.00,9,3,1,8,7,1),(44,'Gigabyte P650B','PSU-GIGP650','Fuente Gigabyte P650B de 650W certificacion 80 Plus Bronze',96000.00,9,2,1,6,7,2),(45,'MSI MAG A750BN','PSU-MSI750BN','Fuente MSI MAG A750BN de 750W certificacion 80 Plus Bronze',126000.00,7,2,1,5,7,3),(46,'ASUS Prime AP201','CASE-ASAP201','Gabinete ASUS Prime AP201 Micro ATX',132000.00,6,2,1,4,8,4),(47,'MSI MAG Forge 100R','CASE-MSI100R','Gabinete MSI MAG Forge 100R con panel lateral de vidrio',114000.00,24,2,1,5,8,5),(48,'Gigabyte C200 Glass','CASE-GIGC200','Gabinete Gigabyte C200 Glass con panel lateral transparente',102000.00,5,3,1,6,8,6),(49,'ASRock Gaming Case','CASE-ASROCK01','Gabinete ASRock para PC gamer con ventilacion frontal',90000.00,4,2,1,7,8,7),(50,'Corsair H100 RGB','COOL-CORH100','Refrigeracion liquida Corsair H100 RGB de 240mm',198000.00,4,1,1,8,9,8),(51,'Corsair SP120 RGB','FAN-CORSP120','Ventilador Corsair SP120 RGB de 120mm',26400.00,10,4,1,8,9,9),(52,'ASUS TUF Gaming LC 240','COOL-ASUSTUF240','Refrigeracion liquida ASUS TUF Gaming LC 240 de 240mm',174000.00,3,2,1,4,9,1),(53,'MSI MAG CoreLiquid 240R','COOL-MSICL240','Refrigeracion liquida MSI MAG CoreLiquid de 240mm',162000.00,11,1,1,5,9,2),(54,'ASUS TUF VG249Q1A','MON-ASVG249','Monitor ASUS TUF de 24 pulgadas Full HD 165Hz',294000.00,2,2,1,4,10,3),(55,'MSI G2412','MON-MSIG2412','Monitor gamer MSI G2412 de 24 pulgadas Full HD 170Hz',312000.00,2,1,1,5,10,4),(56,'Gigabyte G27F','MON-GIGG27F','Monitor gamer Gigabyte G27F de 27 pulgadas Full HD 144Hz',168000.00,20,1,1,6,10,5),(57,'ASRock PG27Q15R2A','MON-ASPG27Q','Monitor ASRock de 27 pulgadas QHD 165Hz',450000.00,0,1,1,7,10,6);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
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
