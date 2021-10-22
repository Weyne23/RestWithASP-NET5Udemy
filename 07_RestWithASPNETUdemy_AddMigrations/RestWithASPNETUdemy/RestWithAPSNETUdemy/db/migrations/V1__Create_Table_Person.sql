CREATE TABLE IF NOT EXISTS `person` (
    `CD_Pessoa` bigint(20) NOT NULL AUTO_INCREMENT,
    `CH_FirstName` varchar(80) NOT NULL,
    `CH_LastName` varchar(80) NOT NULL,
    `CH_Address` varchar(100) NOT NULL,
    `CH_Gender` varchar(6) NOT NULL,
    PRIMARY KEY (`CD_Pessoa`)
)
