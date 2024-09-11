-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: vconfig
-- ------------------------------------------------------
-- Server version	8.0.36

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
-- Table structure for table `components`
--

DROP TABLE IF EXISTS `components`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `components` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `comp_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=182 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `components`
--

LOCK TABLES `components` WRITE;
/*!40000 ALTER TABLE `components` DISABLE KEYS */;
INSERT INTO `components` VALUES (101,'Standard Engine'),(102,'All Season Tyres'),(103,'Music System'),(104,'Color-White'),(105,'AC '),(106,'Speedometer'),(107,'Baisc-Alloy Wheels'),(108,'Duplicate Key'),(109,'Car Cover'),(110,'Universal Car Charger'),(111,'Tyre Pressure Gauge'),(112,'Air Freshner'),(113,'JVC'),(114,'Phillips'),(115,'JBL'),(116,'Digital Speedometer'),(117,'Black'),(118,'Red'),(119,'Silver'),(120,'Metallic Alloy Wheel'),(121,'Matt alloy Wheel'),(162,'Navigation System'),(163,'Heated Seats'),(164,'Sunroof'),(165,'Bluetooth Connectivity'),(166,'Rearview Camera'),(167,'Cruise Control'),(168,'Lane Departure Warning'),(169,'Blind Spot Monitoring'),(170,'Leather Seats'),(171,'Keyless Entry'),(172,'Push Button Start'),(173,'Remote Start'),(174,'Dual-zone Climate Control'),(175,'Power Windows'),(176,'Power Locks'),(177,'Fog Lights'),(178,'LED Headlights'),(179,'Adaptive Headlights'),(180,'Alloy Wheels'),(181,'Backup Sensors');
/*!40000 ALTER TABLE `components` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-08-29 21:24:55
