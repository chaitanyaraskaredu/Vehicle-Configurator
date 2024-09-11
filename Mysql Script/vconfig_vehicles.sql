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
-- Table structure for table `vehicles`
--

DROP TABLE IF EXISTS `vehicles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vehicles` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `comp_type` enum('A','E','I','S') NOT NULL,
  `is_configurable` enum('N','Y') NOT NULL,
  `comp_id` bigint NOT NULL,
  `mod_id` bigint NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FKl73vrifij29mf60p025y6uykp` (`comp_id`),
  KEY `FKsrd84yon700o6fgng107lhnjq` (`mod_id`),
  CONSTRAINT `FKl73vrifij29mf60p025y6uykp` FOREIGN KEY (`comp_id`) REFERENCES `components` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FKsrd84yon700o6fgng107lhnjq` FOREIGN KEY (`mod_id`) REFERENCES `models` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=258 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehicles`
--

LOCK TABLES `vehicles` WRITE;
/*!40000 ALTER TABLE `vehicles` DISABLE KEYS */;
INSERT INTO `vehicles` VALUES (1,'S','N',101,1),(2,'E','N',102,1),(3,'I','Y',103,1),(4,'E','Y',104,1),(5,'I','N',105,1),(6,'I','Y',106,1),(7,'E','Y',107,1),(8,'A','Y',108,1),(9,'A','Y',109,1),(10,'A','Y',110,1),(11,'A','Y',111,1),(159,'S','N',101,2),(160,'E','N',102,2),(161,'I','Y',103,2),(162,'E','Y',104,2),(163,'I','N',105,2),(164,'I','Y',106,2),(165,'E','Y',107,2),(166,'A','Y',108,2),(167,'A','Y',109,2),(168,'A','Y',110,2),(169,'A','Y',111,2),(170,'S','N',101,3),(171,'E','N',102,3),(172,'I','Y',103,3),(173,'E','Y',104,3),(174,'I','N',105,3),(175,'I','Y',106,3),(176,'E','Y',107,3),(177,'A','Y',108,3),(178,'A','Y',109,3),(179,'A','Y',110,3),(180,'A','Y',111,3),(181,'S','N',101,4),(182,'E','N',102,4),(183,'I','Y',103,4),(184,'E','Y',104,4),(185,'I','N',105,4),(186,'I','Y',106,4),(187,'E','Y',107,4),(188,'A','Y',108,4),(189,'A','Y',109,4),(190,'A','Y',110,4),(191,'A','Y',111,4),(192,'S','N',101,5),(193,'E','N',102,5),(194,'I','Y',103,5),(195,'E','Y',104,5),(196,'I','N',105,5),(197,'I','Y',106,5),(198,'E','Y',107,5),(199,'A','Y',108,5),(200,'A','Y',109,5),(201,'A','Y',110,5),(202,'A','Y',111,5),(203,'S','N',101,6),(204,'E','N',102,6),(205,'I','Y',103,6),(206,'E','Y',104,6),(207,'I','N',105,6),(208,'I','Y',106,6),(209,'E','Y',107,6),(210,'A','Y',108,6),(211,'A','Y',109,6),(212,'A','Y',110,6),(213,'A','Y',111,6),(214,'S','N',101,7),(215,'E','N',102,7),(216,'I','Y',103,7),(217,'E','Y',104,7),(218,'I','N',105,7),(219,'I','Y',106,7),(220,'E','Y',107,7),(221,'A','Y',108,7),(222,'A','Y',109,7),(223,'A','Y',110,7),(224,'A','Y',111,7),(225,'S','N',101,8),(226,'E','N',102,8),(227,'I','Y',103,8),(228,'E','Y',104,8),(229,'I','N',105,8),(230,'I','Y',106,8),(231,'E','Y',107,8),(232,'A','Y',108,8),(233,'A','Y',109,8),(234,'A','Y',110,8),(235,'A','Y',111,8),(236,'S','N',101,9),(237,'E','N',102,9),(238,'I','Y',103,9),(239,'E','Y',104,9),(240,'I','N',105,9),(241,'I','Y',106,9),(242,'E','Y',107,9),(243,'A','Y',108,9),(244,'A','Y',109,9),(245,'A','Y',110,9),(246,'A','Y',111,9),(247,'S','N',101,10),(248,'E','N',102,10),(249,'I','Y',103,10),(250,'E','Y',104,10),(251,'I','N',105,10),(252,'I','Y',106,10),(253,'E','Y',107,10),(254,'A','Y',108,10),(255,'A','Y',109,10),(256,'A','Y',110,10),(257,'A','Y',111,10);
/*!40000 ALTER TABLE `vehicles` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-08-29 21:24:56
