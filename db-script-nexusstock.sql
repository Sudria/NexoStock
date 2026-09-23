 -- CREATE DATABASE nexusstock;
 -- USE nexusstock;
/* 
CREATE TABLE `users` (
  `Id`     INT NOT NULL AUTO_INCREMENT,
  `Surname`    VARCHAR(50) DEFAULT NULL,
  `Name`  VARCHAR(50) DEFAULT NULL,
  `Dni`        VARCHAR(8) DEFAULT NULL,
  `Email`      VARCHAR(100) DEFAULT NULL,
  `Tel`        VARCHAR(13) DEFAULT NULL,
  `Username`   VARCHAR(50) DEFAULT NULL,
  `Password`       VARCHAR(50) DEFAULT NULL,
  `Rol`        VARCHAR(50) DEFAULT NULL,
  `State`      TINYINT(1) DEFAULT NULL,
  `CreatedDate` DATETIME DEFAULT NULL,
  
  PRIMARY KEY (`UserId`),
  UNIQUE KEY `Dni` (`Dni`),
  UNIQUE KEY `Email` (`Email`),
  UNIQUE KEY `Tel` (`Tel`),
  UNIQUE KEY `Username` (`Username`)
);
*/


-- Usuarios de prueba randoms
/*
INSERT INTO users (Surname, Name, Dni, Email, Tel, Username, Password, Rol, State, CreatedDate)
VALUES
-- Roles de Administrador
('Gomez', 'Carlos', '11111111', 'carlos.gomez@mail.com', '1122334455', 'cgomez', 'admin123', 'Administrador', 1, NOW()),
('Lopez', 'Ana', '22222222', 'ana.lopez@mail.com', '2233445566', 'alopez', 'admin456', 'Administrador', 1, NOW()),
('Diaz', 'Luis', '33333333', 'luis.diaz@mail.com', '3344556677', 'ldiaz', 'admin789', 'Administrador', 1, NOW()),
('Perez', 'Maria', '44444444', 'maria.perez@mail.com', '4455667788', 'mperez', 'adminabc', 'Administrador', 1, NOW()),
('Rodriguez', 'Juan', '55555555', 'juan.rodriguez@mail.com', '5566778899', 'jrodriguez', 'adminxyz', 'Administrador', 1, NOW()),

-- Roles de Encargado
('Martinez', 'Laura', '66666666', 'laura.martinez@mail.com', '6677889900', 'lmartinez', 'encargado1', 'Encargado', 1, NOW()),
('Sanchez', 'Pedro', '77777777', 'pedro.sanchez@mail.com', '7788990011', 'psanchez', 'encargado2', 'Encargado', 1, NOW()),
('Romero', 'Sofia', '88888888', 'sofia.romero@mail.com', '8899001122', 'sromero', 'encargado3', 'Encargado', 1, NOW()),
('Fernandez', 'Diego', '99999999', 'diego.fernandez@mail.com', '9900112233', 'dfernandez', 'encargado4', 'Encargado', 1, NOW()),
('Torres', 'Elena', '12345678', 'elena.torres@mail.com', '1234567890', 'etorres', 'encargado5', 'Encargado', 1, NOW()),

-- Roles de Vendedor
('Alvarez', 'Javier', '23456789', 'javier.alvarez@mail.com', '2345678901', 'jalvarez', 'vendedor1', 'Vendedor', 1, NOW()),
('Ruiz', 'Lucia', '34567890', 'lucia.ruiz@mail.com', '3456789012', 'lruiz', 'vendedor2', 'Vendedor', 1, NOW()),
('Suarez', 'Marcos', '45678901', 'marcos.suarez@mail.com', '4567890123', 'msuarez', 'vendedor3', 'Vendedor', 1, NOW()),
('Benitez', 'Clara', '56789012', 'clara.benitez@mail.com', '5678901234', 'cbenitez', 'vendedor4', 'Vendedor', 1, NOW()),
('Herrera', 'Hugo', '67890123', 'hugo.herrera@mail.com', '6789012345', 'hherrera', 'vendedor5', 'Vendedor', 1, NOW()),

-- Roles de Repositor
('Gimenez', 'Bruno', '78901234', 'bruno.gimenez@mail.com', '7890123456', 'bgimenez', 'repositor1', 'Repositor', 1, NOW()),
('Castro', 'Valeria', '89012345', 'valeria.castro@mail.com', '8901234567', 'vcastro', 'repositor2', 'Repositor', 1, NOW()),
('Silva', 'Tomas', '90123456', 'tomas.silva@mail.com', '9012345678', 'tsilva', 'repositor3', 'Repositor', 1, NOW()),
('Rios', 'Camila', '01234567', 'camila.rios@mail.com', '0123456789', 'crios', 'repositor4', 'Repositor', 1, NOW()),
('Acosta', 'Martin', '11224455', 'martin.acosta@mail.com', '1122445566', 'macosta', 'repositor5', 'Repositor', 1, NOW());
*/

-- Usuarios con username y contraseña igual
/*
INSERT INTO users (Surname, Name, Dni, Email, Tel, Username, Password, Rol, State, CreatedDate)
VALUES
('Ortega', 'Mariano', '38472910', 'mariano.ortega@mail.com', '1155998822', 'administrador', 'administrador', 'Administrador', 1, NOW()),
('Mendoza', 'Beatriz', '29481039', 'beatriz.mendoza@mail.com', '3414887766', 'encargado', 'encargado', 'Encargado', 1, NOW()),
('Peralta', 'Ezequiel', '41029384', 'ezequiel.peralta@mail.com', '2613994455', 'vendedor', 'vendedor', 'Vendedor', 1, NOW()),
('Vega', 'Natalia', '35920194', 'natalia.vega@mail.com', '3516223344', 'repositor', 'repositor', 'Repositor', 1, NOW());
*/

