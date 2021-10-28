CREATE TABLE `books` (
  `CD_boock` INT(10) AUTO_INCREMENT PRIMARY KEY,
  `CH_author` longtext,
  `DT_launch_date` datetime(6) NOT NULL,
  `VR_price` decimal(65,2) NOT NULL,
  `CH_title` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
