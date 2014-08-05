/*
SQLyog Ultimate v9.63 
MySQL - 5.5.28 : Database - test
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`test` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `test`;

/*Table structure for table `roles` */

DROP TABLE IF EXISTS `roles`;

CREATE TABLE `roles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(100) DEFAULT NULL,
  `tipo` int(11) DEFAULT NULL,
  `estado` int(1) DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `tipo` (`tipo`),
  CONSTRAINT `roles_ibfk_1` FOREIGN KEY (`tipo`) REFERENCES `tipo_roles` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `roles` */

insert  into `roles`(`id`,`Descripcion`,`tipo`,`estado`) values (1,'ADMIN',1,1),(2,'CLIENT',2,1),(3,'FUNCTION',2,1),(4,'EXTERNAL',2,1),(5,'Public',2,1);

/*Table structure for table `roles_users` */

DROP TABLE IF EXISTS `roles_users`;

CREATE TABLE `roles_users` (
  `id_user` int(11) DEFAULT NULL,
  `id_rol` int(11) DEFAULT NULL,
  KEY `id_user` (`id_user`),
  KEY `id_rol` (`id_rol`),
  CONSTRAINT `roles_users_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `user` (`id`),
  CONSTRAINT `roles_users_ibfk_2` FOREIGN KEY (`id_rol`) REFERENCES `roles` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `roles_users` */

insert  into `roles_users`(`id_user`,`id_rol`) values (6,1),(9,4),(10,3);

/*Table structure for table `tipo_roles` */

DROP TABLE IF EXISTS `tipo_roles`;

CREATE TABLE `tipo_roles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(100) DEFAULT NULL,
  `estado` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `tipo_roles` */

insert  into `tipo_roles`(`id`,`Descripcion`,`estado`) values (1,'Administrator',1),(2,'Enduser',1);

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `name` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(200) DEFAULT NULL,
  `estado` int(1) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

/*Data for the table `user` */

insert  into `user`(`name`,`password`,`id`,`email`,`estado`) values ('Humberto','123',6,NULL,1),('Sandra','123',9,'storrecilla@qwerty.com',1),('Roger','123',10,'rdemoya@energiasolarsa.com',1),('Fabio','123',12,'fpena@gmail.com',1);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
