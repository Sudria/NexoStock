 CREATE DATABASE nexusstock;
USE nexusstock;

CREATE TABLE `users` (
  `Id`     INT NOT NULL AUTO_INCREMENT,
  `Surname`    VARCHAR(50)  ,
  `Name`  VARCHAR(50)  ,
  `Dni`        VARCHAR(8)  ,
  `Email`      VARCHAR(100)  ,
  `Tel`        VARCHAR(13)  ,
  `Username`   VARCHAR(50)  ,
  `Password`       VARCHAR(50)  ,
  `Rol`        VARCHAR(50)  ,
  `State`      TINYINT(1)  ,
  `CreatedDate` DATETIME DEFAULT NOW(),
  
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Dni` (`Dni`),
  UNIQUE KEY `Email` (`Email`),
  UNIQUE KEY `Tel` (`Tel`),
  UNIQUE KEY `Username` (`Username`)
);


CREATE TABLE providers(
`Id` INT NOT NULL AUTO_INCREMENT,
`Name` VARCHAR(50) NOT NULL,
`Surname`    VARCHAR(50)  NOT NULL,
  `Cuit`        VARCHAR(15)  NOT NULL,
  `Email`      VARCHAR(100)  NOT NULL,
    `Tel`        VARCHAR(13)  NOT NULL,
  `State`      TINYINT(1) DEFAULT TRUE ,
  `CreatedDate` DATETIME DEFAULT NOW(),


PRIMARY KEY (`Id`),
UNIQUE KEY `Cuit` (`Cuit`),
UNIQUE KEY `Email` (`Email`)
);

CREATE TABLE brands(
`Id` INT NOT NULL AUTO_INCREMENT,
`Name` VARCHAR(50) NOT NULL,
  `State`      TINYINT(1) DEFAULT TRUE ,


PRIMARY KEY (`Id`),
UNIQUE KEY `Name` (`Name`)
);

CREATE TABLE categorys(
`Id` INT NOT NULL AUTO_INCREMENT,
`Name` VARCHAR(50) NOT NULL,
  `State`      TINYINT(1) DEFAULT TRUE ,


PRIMARY KEY (`Id`),
UNIQUE KEY `Name` (`Name`)
);


CREATE TABLE `products` (
  `Id`     INT NOT NULL AUTO_INCREMENT,
  `Name`  VARCHAR(50) DEFAULT NULL,
  `Cod`        VARCHAR(20) DEFAULT NULL,
  `Description`      VARCHAR(255) DEFAULT NULL,
  `SalePrice`        DECIMAL(13,2) DEFAULT 0,
  `Stock`   		INT(7) DEFAULT 0,
  `StockMin`        INT(7) DEFAULT 0,
  `State`      TINYINT(1) DEFAULT TRUE,
  `BrandId` INT DEFAULT 0,
  `CategoryId` INT DEFAULT 0,
  `ProviderId` INT DEFAULT 0,


  CONSTRAINT fk_brands
  FOREIGN KEY (BrandId)
  REFERENCES brands(Id),

  CONSTRAINT fk_providers
  FOREIGN KEY (ProviderId)
  REFERENCES providers(Id),
  
  CONSTRAINT fk_categorys
  FOREIGN KEY (CategoryId)
  REFERENCES categorys(Id),

  PRIMARY KEY (`Id`),
  UNIQUE KEY `Cod` (`Cod`)
);


-- Usuarios de prueba randoms

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


-- Usuarios con username y contraseña igual

INSERT INTO users (Surname, Name, Dni, Email, Tel, Username, Password, Rol, State, CreatedDate)
VALUES
('Ortega', 'Mariano', '38472910', 'mariano.ortega@mail.com', '1155998822', 'administrador', 'administrador', 'Administrador', 1, NOW()),
('Mendoza', 'Beatriz', '29481039', 'beatriz.mendoza@mail.com', '3414887766', 'encargado', 'encargado', 'Encargado', 1, NOW()),
('Peralta', 'Ezequiel', '41029384', 'ezequiel.peralta@mail.com', '2613994455', 'vendedor', 'vendedor', 'Vendedor', 1, NOW()),
('Vega', 'Natalia', '35920194', 'natalia.vega@mail.com', '3516223344', 'repositor', 'repositor', 'Repositor', 1, NOW());

-- Proveedores de prueba
INSERT INTO providers
(`Name`, `Surname`, `Cuit`, `Email`, `Tel`, `State`)
VALUES
('Juan', 'Gomez', '30-71234567-1', 'juan.gomez@techsupply.com', '3624123456', TRUE),
('Martin', 'Lopez', '30-72345678-2', 'martin.lopez@hardware.com', '3624234567', TRUE),
('Lucas', 'Fernandez', '30-73456789-3', 'lucas.fernandez@compumarket.com', '3624345678', TRUE),
('Nicolas', 'Martinez', '30-74567890-4', 'nicolas.martinez@digitalworld.com', '3624456789', TRUE),
('Diego', 'Rodriguez', '30-75678901-5', 'diego.rodriguez@megatech.com', '3624567890', TRUE),
('Santiago', 'Gonzalez', '30-76789012-6', 'santiago.gonzalez@hardtech.com', '3624678901', TRUE),
('Federico', 'Diaz', '30-77890123-7', 'federico.diaz@pcstore.com', '3624789012', TRUE),
('Agustin', 'Sanchez', '30-78901234-8', 'agustin.sanchez@globalcomponents.com', '3624890123', TRUE),
('Pablo', 'Romero', '30-79012345-9', 'pablo.romero@byteSolutions.com', '3624901234', TRUE),
('Matias', 'Torres', '30-70123456-0', 'matias.torres@importadoradelta.com', '3624012345', FALSE);

-- Marcas de prueba
INSERT INTO brands
(`Name`, `State`)
VALUES
('AMD', TRUE),
('Intel', TRUE),
('NVIDIA', TRUE),
('ASUS', TRUE),
('MSI', TRUE),
('Gigabyte', TRUE),
('ASRock', TRUE),
('Corsair', TRUE),
('Kingston', TRUE),
('Logitech', FALSE);

-- Categorias de prueba
INSERT INTO categorys
(`Name`, `State`)
VALUES
('Procesadores', TRUE),
('Placas de Video', TRUE),
('Motherboards', TRUE),
('Memorias RAM', TRUE),
('Discos HDD', TRUE),
('Discos SSD', TRUE),
('Fuentes', TRUE),
('Gabinetes', TRUE),
('Coolers', TRUE),
('Monitores', FALSE);

-- Productos de prueba
INSERT INTO products
(`Name`, `Cod`, `Description`, `SalePrice`, `Stock`, `StockMin`, `State`, `BrandId`, `CategoryId`, `ProviderId`)
VALUES
('Ryzen 5 5600', 'CPUAMD5600', 'Procesador AMD Ryzen 5 5600 de 6 nucleos y 12 hilos', 159999.99, 15, 5, TRUE, 1, 1, 1),

('Core i5 12400F', 'CPUINT12400F', 'Procesador Intel Core i5 12400F de 6 nucleos y 12 hilos', 179999.99, 10, 3, TRUE, 2, 1, 2),

('RTX 4060 8GB', 'GPU-N4060-8', 'Placa de video NVIDIA GeForce RTX 4060 de 8GB', 449999.99, 8, 2, TRUE, 3, 2, 3),

('B550M Gaming', 'MBMSIB550M', 'Motherboard MSI B550M compatible con procesadores AMD Ryzen', 139999.99, 12, 4, TRUE, 5, 3, 4),

('Kingston Fury 16GB', 'RAMKF16DDR4', 'Memoria RAM Kingston Fury de 16GB DDR4 3200MHz', 59999.99, 20, 5, TRUE, 9, 4, 5);

SELECT * FROM products;

SELECT 
    p.Name AS Producto,
    b.Name AS Marca,
    c.Name AS Categoria,
    pr.Name AS Proveedor,
    p.SalePrice AS Precio,
    p.Stock
FROM products p
JOIN brands b ON p.BrandId = b.Id
JOIN categorys c ON p.CategoryId = c.Id
JOIN providers pr ON p.ProviderId = pr.Id;





