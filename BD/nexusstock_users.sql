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
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Surname` varchar(50) DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Dni` varchar(8) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Tel` varchar(20) DEFAULT NULL,
  `Username` varchar(50) DEFAULT NULL,
  `Password` varchar(50) DEFAULT NULL,
  `Rol` varchar(50) DEFAULT NULL,
  `State` tinyint(1) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Dni` (`Dni`),
  UNIQUE KEY `Email` (`Email`),
  UNIQUE KEY `Tel` (`Tel`),
  UNIQUE KEY `Username` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (24,'Gomez','Carlos','11111111','carlos.gomez@mail.com','1122334455','cgomez','admin123','Administrador',1,'2026-09-23 00:35:49'),(25,'Lopez','Ana','22222222','ana.lopez@mail.com','2233445566','alopez','admin456','Administrador',1,'2026-09-23 00:35:49'),(26,'Diaz','Luis','33333333','luis.diaz@mail.com','3344556677','ldiaz','admin789','Administrador',1,'2026-09-23 00:35:49'),(27,'Perez','Maria','44444444','maria.perez@mail.com','5494455667788','mperez','adminabc','Encargado',1,'2026-09-23 00:35:49'),(28,'Rodriguez','Juan','55555555','juan.rodriguez@mail.com','5566778899','jrodriguez','adminxyz','Administrador',1,'2026-09-23 00:35:49'),(29,'Martinez','Laura','66666666','laura.martinez@mail.com','6677889900','lmartinez','encargado1','Encargado',1,'2026-09-23 00:35:49'),(30,'Sanchez','Pedro','77777777','pedro.sanchez@mail.com','7788990011','psanchez','encargado2','Encargado',1,'2026-09-23 00:35:49'),(31,'Romero','Sofia','88888888','sofia.romero@mail.com','8899001122','sromero','encargado3','Encargado',1,'2026-09-23 00:35:49'),(32,'Fernandez','Diego','99999999','diego.fernandez@mail.com','9900112233','dfernandez','encargado4','Encargado',1,'2026-09-23 00:35:49'),(33,'Torres','Elena','12345678','elena.torres@mail.com','1234567890','etorres','encargado5','Encargado',1,'2026-09-23 00:35:49'),(34,'Alvarez','Javier','23456789','javier.alvarez@mail.com','2345678901','jalvarez','vendedor1','Vendedor',1,'2026-09-23 00:35:49'),(35,'Ruiz','Lucia','34567890','lucia.ruiz@mail.com','3456789012','lruiz','vendedor2','Vendedor',1,'2026-09-23 00:35:49'),(36,'Suarez','Marcos','45678901','marcos.suarez@mail.com','4567890123','msuarez','vendedor3','Vendedor',1,'2026-09-23 00:35:49'),(37,'Benitez','Clara','56789012','clara.benitez@mail.com','5678901234','cbenitez','vendedor4','Vendedor',1,'2026-09-23 00:35:49'),(38,'Herrera','Hugo','67890123','hugo.herrera@mail.com','6789012345','hherrera','vendedor5','Vendedor',1,'2026-09-23 00:35:49'),(39,'Gimenez','Bruno','78901234','bruno.gimenez@mail.com','7890123456','bgimenez','repositor1','Repositor',1,'2026-09-23 00:35:49'),(40,'Castro','Valeria','89012345','valeria.castro@mail.com','8901234567','vcastro','repositor2','Repositor',1,'2026-09-23 00:35:49'),(41,'Silva','Tomas','90123456','tomas.silva@mail.com','9012345678','tsilva','repositor3','Repositor',1,'2026-09-23 00:35:49'),(42,'Rios','Camila','01234567','camila.rios@mail.com','0123456789','crios','repositor4','Repositor',1,'2026-09-23 00:35:49'),(43,'Acosta','Martin','11224455','martin.acosta@mail.com','1122445566','macosta','repositor5','Repositor',1,'2026-09-23 00:35:49'),(44,'Ortega','Mariano','38472910','mariano.ortega@mail.com','1155998822','administrador','administrador','Administrador',1,'2026-09-23 00:37:49'),(45,'Mendoza','Beatriz','29481039','beatriz.mendoza@mail.com','3414887766','encargado','encargado','Encargado',1,'2026-09-23 00:37:49'),(46,'Peralta','Ezequiel','41029384','ezequiel.peralta@mail.com','2613994455','vendedor','vendedor','Vendedor',1,'2026-09-23 00:37:49'),(47,'Vega','Natalia','35920194','natalia.vega@mail.com','3516223344','repositor','repositor','Repositor',1,'2026-09-23 00:37:49'),(61,'asdasdsada','sdasdsadasd','65448730','asdasds@gmail.com','54 9 3344343232','asdasdasd','1234512','Administrador',1,'2026-09-23 05:56:46');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
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
