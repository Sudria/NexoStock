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

CREATE TABLE product_images (
    Id INT NOT NULL AUTO_INCREMENT,
    ProductId INT NOT NULL,
    ImagePath VARCHAR(255) NOT NULL,

    PRIMARY KEY (Id),

    CONSTRAINT fk_product_images_products
        FOREIGN KEY (ProductId)
        REFERENCES products(Id)
        ON DELETE CASCADE,

    CONSTRAINT uq_product_image_path
        UNIQUE (ProductId, ImagePath),

    INDEX idx_product_images_product (ProductId)
);

CREATE TABLE sales (
    Id INT NOT NULL AUTO_INCREMENT,
    UserId INT NOT NULL,
    ClientId INT NOT NULL,
    SaleDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    State TINYINT(1) DEFAULT TRUE,
    Total DECIMAL(13,2) NOT NULL DEFAULT 0,

    PRIMARY KEY (Id),

    CONSTRAINT fk_sales_users
        FOREIGN KEY (UserId)
        REFERENCES users(Id),

    CONSTRAINT fk_sales_clients
        FOREIGN KEY (ClientId)
        REFERENCES clients(Id)
);


CREATE TABLE sale_details (
    Id INT NOT NULL AUTO_INCREMENT,
    SaleId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(13,2) NOT NULL,
    Subtotal DECIMAL(13,2)
        GENERATED ALWAYS AS (Quantity * UnitPrice) STORED,

    PRIMARY KEY (Id),

    CONSTRAINT fk_sale_details_sales
        FOREIGN KEY (SaleId)
        REFERENCES sales(Id),

    CONSTRAINT fk_sale_details_products
        FOREIGN KEY (ProductId)
        REFERENCES products(Id),

    CONSTRAINT chk_sale_quantity
        CHECK (Quantity > 0),

    CONSTRAINT chk_sale_price
        CHECK (UnitPrice >= 0)
);


CREATE TABLE purchases (
    Id INT NOT NULL AUTO_INCREMENT,
    ProviderId INT NOT NULL,
    UserId INT NOT NULL,
    PurchaseDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Total DECIMAL(13,2) NOT NULL DEFAULT 0,

    PRIMARY KEY (Id),

    CONSTRAINT fk_purchases_providers
        FOREIGN KEY (ProviderId)
        REFERENCES providers(Id),

    CONSTRAINT fk_purchases_users
        FOREIGN KEY (UserId)
        REFERENCES users(Id),

    INDEX idx_purchases_date (PurchaseDate)
);


CREATE TABLE purchase_details (
    Id INT NOT NULL AUTO_INCREMENT,
    PurchaseId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    PurchasePrice DECIMAL(13,2) NOT NULL,

    Subtotal DECIMAL(13,2)
        GENERATED ALWAYS AS (Quantity * PurchasePrice) STORED,

    PRIMARY KEY (Id),

    CONSTRAINT fk_purchase_details_purchases
        FOREIGN KEY (PurchaseId)
        REFERENCES purchases(Id),

    CONSTRAINT fk_purchase_details_products
        FOREIGN KEY (ProductId)
        REFERENCES products(Id),

    CONSTRAINT chk_purchase_details_quantity
        CHECK (Quantity > 0),

    CONSTRAINT chk_purchase_details_price
        CHECK (PurchasePrice >= 0),

    INDEX idx_purchase_details_product (ProductId),
    INDEX idx_purchase_details_purchase (PurchaseId)
);




CREATE TABLE clients (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`Name` VARCHAR(50) NOT NULL,
	`Surname`    VARCHAR(50)  NOT NULL,
	`Dni`        VARCHAR(15)  NOT NULL,
	`Email`      VARCHAR(100)  NOT NULL,
    `Tel`        VARCHAR(13)  NOT NULL,
	`State`      TINYINT(1) DEFAULT TRUE ,
	`CreatedDate` DATETIME DEFAULT NOW(),


PRIMARY KEY (`Id`),
UNIQUE KEY `Dni` (`Dni`),
UNIQUE KEY `Email` (`Email`)
);


CREATE TABLE product_movements (
    Id INT NOT NULL AUTO_INCREMENT,
    ProductId INT NOT NULL,
    UserId INT NOT NULL,
    Type VARCHAR(20) NOT NULL,
    ReferenceId INT NOT NULL,
    Quantity INT NOT NULL,
    PreviousStock INT NOT NULL,
    NewStock INT NOT NULL,
    MovementDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

    PRIMARY KEY (Id),

    CONSTRAINT fk_movements_products
        FOREIGN KEY (ProductId) REFERENCES products(Id),

    CONSTRAINT fk_movements_users
        FOREIGN KEY (UserId) REFERENCES users(Id),

    INDEX idx_movements_type (Type),
    INDEX idx_movements_reference (ReferenceId),
    INDEX idx_movements_date (MovementDate)
);







-- Triggers
DELIMITER //



CREATE TRIGGER trg_purchase_detail_movement
AFTER INSERT ON purchase_details
FOR EACH ROW
BEGIN
    DECLARE v_previous_stock INT;
    DECLARE v_new_stock INT;
    DECLARE v_user_id INT;

    -- Obtener stock actual y bloquear el producto
    SELECT Stock
    INTO v_previous_stock
    FROM products
    WHERE Id = NEW.ProductId
    FOR UPDATE;

    -- Obtener usuario responsable
    SELECT UserId
    INTO v_user_id
    FROM purchases
    WHERE Id = NEW.PurchaseId;

    -- Calcular nuevo stock
    SET v_new_stock = v_previous_stock + NEW.Quantity;

    -- Actualizar stock
    UPDATE products
    SET Stock = v_new_stock
    WHERE Id = NEW.ProductId;

    -- Registrar movimiento
    INSERT INTO product_movements
    (
        ProductId,
        UserId,
        Type,
        ReferenceId,
        Quantity,
        PreviousStock,
        NewStock
    )
    VALUES
    (
        NEW.ProductId,
        v_user_id,
        'COMPRA',
        NEW.PurchaseId,
        NEW.Quantity,
        v_previous_stock,
        v_new_stock
    );
END //


CREATE TRIGGER trg_sale_detail_movement
AFTER INSERT ON sale_details
FOR EACH ROW
BEGIN
    DECLARE v_previous_stock INT;
    DECLARE v_new_stock INT;
    DECLARE v_user_id INT;

    SELECT Stock
    INTO v_previous_stock
    FROM products
    WHERE Id = NEW.ProductId
    FOR UPDATE;

    IF v_previous_stock < NEW.Quantity THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Stock insuficiente para realizar la venta';
    END IF;

    SELECT UserId
    INTO v_user_id
    FROM sales
    WHERE Id = NEW.SaleId;

    SET v_new_stock = v_previous_stock - NEW.Quantity;

    UPDATE products
    SET Stock = v_new_stock
    WHERE Id = NEW.ProductId;

    INSERT INTO product_movements
    (
        ProductId,
        UserId,
        Type,
        ReferenceId,
        Quantity,
        PreviousStock,
        NewStock
    )
    VALUES
    (
        NEW.ProductId,
        v_user_id,
        'VENTA',
        NEW.SaleId,
        NEW.Quantity,
        v_previous_stock,
        v_new_stock
    );
END //

DELIMITER ;


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

('Kingston Fury 16GB', 'RAMKF16DDR4', 'Memoria RAM Kingston Fury de 16GB DDR4 3200MHz', 59999.99, 20, 5, TRUE, 9, 4, 5),

-- PROCESADORES (CategoryId = 1)
('Ryzen 5 5500', 'CPUAMD5500', 'Procesador AMD Ryzen 5 5500 de 6 nucleos y 12 hilos', 125000, 12, 4, TRUE, 1, 1, 1),
('Ryzen 7 5700X', 'CPUAMD5700X', 'Procesador AMD Ryzen 7 5700X de 8 nucleos y 16 hilos', 235000, 8, 3, TRUE, 1, 1, 2),
('Ryzen 7 5800X', 'CPUAMD5800X', 'Procesador AMD Ryzen 7 5800X de 8 nucleos y 16 hilos', 280000, 6, 2, TRUE, 1, 1, 3),
('Ryzen 9 5900X', 'CPUAMD5900X', 'Procesador AMD Ryzen 9 5900X de 12 nucleos y 24 hilos', 390000, 4, 2, TRUE, 1, 1, 4),
('Core i3 12100F', 'CPUINT12100F', 'Procesador Intel Core i3 12100F de 4 nucleos y 8 hilos', 110000, 14, 4, TRUE, 2, 1, 5),
('Core i5 13400F', 'CPUINT13400F', 'Procesador Intel Core i5 13400F de 10 nucleos y 16 hilos', 250000, 9, 3, TRUE, 2, 1, 6),

-- PLACAS DE VIDEO (CategoryId = 2)
('GTX 1650 4GB', 'GPU-N1650-4', 'Placa de video NVIDIA GeForce GTX 1650 de 4GB', 220000, 7, 2, TRUE, 3, 2, 3),
('RTX 3060 12GB', 'GPU-N3060-12', 'Placa de video NVIDIA GeForce RTX 3060 de 12GB', 380000, 9, 3, TRUE, 3, 2, 4),
('RTX 4060 Ti 8GB', 'GPU-N4060TI-8', 'Placa de video NVIDIA GeForce RTX 4060 Ti de 8GB', 550000, 5, 2, TRUE, 3, 2, 5),
('RTX 4070 12GB', 'GPU-N4070-12', 'Placa de video NVIDIA GeForce RTX 4070 de 12GB', 850000, 4, 1, TRUE, 3, 2, 6),
('Radeon RX 6600 8GB', 'GPU-AMD6600-8', 'Placa de video AMD Radeon RX 6600 de 8GB', 300000, 8, 3, TRUE, 1, 2, 7),
('Radeon RX 7600 8GB', 'GPU-AMD7600-8', 'Placa de video AMD Radeon RX 7600 de 8GB', 420000, 6, 2, TRUE, 1, 2, 8),

-- MOTHERBOARDS (CategoryId = 3)
('A520M-K', 'MBAUS-A520MK', 'Motherboard ASUS A520M-K compatible con procesadores AMD Ryzen', 95000, 10, 3, TRUE, 4, 3, 1),
('B450M DS3H', 'MBGIG-B450DS', 'Motherboard Gigabyte B450M DS3H para procesadores AMD Ryzen', 110000, 8, 3, TRUE, 6, 3, 2),
('B550 Gaming Plus', 'MBMSI-B550GP', 'Motherboard MSI B550 Gaming Plus para procesadores AMD Ryzen', 210000, 7, 2, TRUE, 5, 3, 3),
('H610M-H', 'MBGIG-H610MH', 'Motherboard Gigabyte H610M-H compatible con Intel de 12va generacion', 105000, 9, 3, TRUE, 6, 3, 4),
('B760M DS3H', 'MBGIG-B760DS', 'Motherboard Gigabyte B760M DS3H compatible con Intel', 185000, 5, 2, TRUE, 6, 3, 5),

-- MEMORIAS RAM (CategoryId = 4)
('Kingston Fury 8GB', 'RAMKF8DDR4', 'Memoria RAM Kingston Fury de 8GB DDR4 3200MHz', 35000, 25, 6, TRUE, 9, 4, 6),
('Kingston Fury 32GB', 'RAMKF32DDR4', 'Memoria RAM Kingston Fury de 32GB DDR4 3200MHz', 115000, 12, 4, TRUE, 9, 4, 7),
('Corsair Vengeance 16GB', 'RAMCV16DDR4', 'Memoria RAM Corsair Vengeance de 16GB DDR4 3200MHz', 65000, 18, 5, TRUE, 8, 4, 8),
('Corsair Vengeance 32GB', 'RAMCV32DDR4', 'Memoria RAM Corsair Vengeance de 32GB DDR4 3600MHz', 125000, 10, 3, TRUE, 8, 4, 9),
('Kingston Fury 16GB DDR5', 'RAMKF16DDR5', 'Memoria RAM Kingston Fury de 16GB DDR5 5200MHz', 85000, 14, 4, TRUE, 9, 4, 1),

-- DISCOS HDD (CategoryId = 5)
('HDD 500GB', 'HDD500GB001', 'Disco rigido de 500GB SATA para almacenamiento', 55000, 10, 3, TRUE, 9, 5, 2),
('HDD 1TB', 'HDD1TB0001', 'Disco rigido de 1TB SATA para computadoras de escritorio', 85000, 12, 4, TRUE, 9, 5, 3),
('HDD 2TB', 'HDD2TB0001', 'Disco rigido de 2TB SATA para almacenamiento de datos', 115000, 7, 2, TRUE, 9, 5, 4),

-- DISCOS SSD (CategoryId = 6)
('Kingston NV2 500GB', 'SSD-KNV2500', 'Disco SSD Kingston NV2 NVMe de 500GB', 65000, 16, 5, TRUE, 9, 6, 5),
('Kingston NV2 1TB', 'SSD-KNV21000', 'Disco SSD Kingston NV2 NVMe de 1TB', 105000, 12, 4, TRUE, 9, 6, 6),
('Kingston A400 480GB', 'SSD-KA400480', 'Disco SSD Kingston A400 SATA de 480GB', 60000, 15, 5, TRUE, 9, 6, 7),
('Corsair MP600 1TB', 'SSD-CMP6001T', 'Disco SSD Corsair MP600 NVMe de 1TB', 155000, 6, 2, TRUE, 8, 6, 8),

-- FUENTES (CategoryId = 7)
('Corsair CV550', 'PSU-CORCV550', 'Fuente Corsair CV550 de 550W certificacion 80 Plus Bronze', 95000, 8, 3, TRUE, 8, 7, 9),
('Corsair CV650', 'PSU-CORCV650', 'Fuente Corsair CV650 de 650W certificacion 80 Plus Bronze', 120000, 9, 3, TRUE, 8, 7, 1),
('Gigabyte P650B', 'PSU-GIGP650', 'Fuente Gigabyte P650B de 650W certificacion 80 Plus Bronze', 110000, 6, 2, TRUE, 6, 7, 2),
('MSI MAG A750BN', 'PSU-MSI750BN', 'Fuente MSI MAG A750BN de 750W certificacion 80 Plus Bronze', 145000, 5, 2, TRUE, 5, 7, 3),

-- GABINETES (CategoryId = 8)
('ASUS Prime AP201', 'CASE-ASAP201', 'Gabinete ASUS Prime AP201 Micro ATX', 150000, 7, 2, TRUE, 4, 8, 4),
('MSI MAG Forge 100R', 'CASE-MSI100R', 'Gabinete MSI MAG Forge 100R con panel lateral de vidrio', 135000, 6, 2, TRUE, 5, 8, 5),
('Gigabyte C200 Glass', 'CASE-GIGC200', 'Gabinete Gigabyte C200 Glass con panel lateral transparente', 115000, 8, 3, TRUE, 6, 8, 6),
('ASRock Gaming Case', 'CASE-ASROCK01', 'Gabinete ASRock para PC gamer con ventilacion frontal', 105000, 4, 2, TRUE, 7, 8, 7),

-- COOLERS (CategoryId = 9)
('Corsair H100 RGB', 'COOL-CORH100', 'Refrigeracion liquida Corsair H100 RGB de 240mm', 220000, 4, 1, TRUE, 8, 9, 8),
('Corsair SP120 RGB', 'FAN-CORSP120', 'Ventilador Corsair SP120 RGB de 120mm', 35000, 15, 4, TRUE, 8, 9, 9),
('ASUS TUF Gaming LC 240', 'COOL-ASUSTUF240', 'Refrigeracion liquida ASUS TUF Gaming LC 240 de 240mm', 195000, 5, 2, TRUE, 4, 9, 1),
('MSI MAG CoreLiquid 240R', 'COOL-MSICL240', 'Refrigeracion liquida MSI MAG CoreLiquid de 240mm', 185000, 3, 1, TRUE, 5, 9, 2),

-- MONITORES (CategoryId = 10, categoria actualmente inactiva)
('ASUS TUF VG249Q1A', 'MON-ASVG249', 'Monitor ASUS TUF de 24 pulgadas Full HD 165Hz', 320000, 5, 2, TRUE, 4, 10, 3),
('MSI G2412', 'MON-MSIG2412', 'Monitor gamer MSI G2412 de 24 pulgadas Full HD 170Hz', 340000, 4, 1, TRUE, 5, 10, 4),
('Gigabyte G27F', 'MON-GIGG27F', 'Monitor gamer Gigabyte G27F de 27 pulgadas Full HD 144Hz', 390000, 3, 1, TRUE, 6, 10, 5),
('ASRock PG27Q15R2A', 'MON-ASPG27Q', 'Monitor ASRock de 27 pulgadas QHD 165Hz', 450000, 2, 1, TRUE, 7, 10, 6);


UPDATE products
SET Stock = 0
WHERE Cod IN (
    'CPUAMD5500', 'CPUAMD5700X', 'CPUAMD5800X', 'CPUAMD5900X',
    'CPUINT12100F', 'CPUINT13400F',
    'GPU-N1650-4', 'GPU-N3060-12', 'GPU-N4060TI-8', 'GPU-N4070-12',
    'GPU-AMD6600-8', 'GPU-AMD7600-8',
    'MBAUS-A520MK', 'MBGIG-B450DS', 'MBMSI-B550GP', 'MBGIG-H610MH',
    'MBGIG-B760DS',
    'RAMKF8DDR4', 'RAMKF32DDR4', 'RAMCV16DDR4', 'RAMCV32DDR4',
    'RAMKF16DDR5',
    'HDD500GB001', 'HDD1TB0001', 'HDD2TB0001',
    'SSD-KNV2500', 'SSD-KNV21000', 'SSD-KA400480', 'SSD-CMP6001T',
    'PSU-CORCV550', 'PSU-CORCV650', 'PSU-GIGP650', 'PSU-MSI750BN',
    'CASE-ASAP201', 'CASE-MSI100R', 'CASE-GIGC200', 'CASE-ASROCK01',
    'COOL-CORH100', 'FAN-CORSP120', 'COOL-ASUSTUF240', 'COOL-MSICL240',
    'MON-ASVG249', 'MON-MSIG2412', 'MON-GIGG27F', 'MON-ASPG27Q'
);


INSERT INTO clients
    (`Name`, `Surname`, `Dni`, `Email`, `Tel`, `State`, `CreatedDate`)
VALUES
    ('Juan', 'Perez', '30123456', 'juan.perez@example.com', '3794001001', 1, '2026-01-15 10:30:00'),
    ('Maria', 'Gomez', '32456789', 'maria.gomez@example.com', '3794001002', 1, '2026-02-10 11:15:00'),
    ('Carlos', 'Rodriguez', '28765432', 'carlos.rodriguez@example.com', '3794001003', 1, '2026-03-05 09:00:00'),
    ('Lucia', 'Fernandez', '35678901', 'lucia.fernandez@example.com', '3794001004', 0, '2026-03-20 14:45:00'),
    ('Martin', 'Lopez', '29876543', 'martin.lopez@example.com', '3794001005', 1, '2026-04-12 16:20:00'),
    ('Sofia', 'Martinez', '36789012', 'sofia.martinez@example.com', '3794001006', 1, '2026-05-08 12:00:00'),
    ('Diego', 'Gonzalez', '31234567', 'diego.gonzalez@example.com', '3794001007', 0, '2026-06-17 08:30:00'),
    ('Valentina', 'Diaz', '38901234', 'valentina.diaz@example.com', '3794001008', 1, '2026-07-03 13:10:00'),
    ('Federico', 'Torres', '33456789', 'federico.torres@example.com', '3794001009', 1, '2026-08-22 15:00:00'),
    ('Camila', 'Ramirez', '37890123', 'camila.ramirez@example.com', '3794001010', 0, '2026-09-14 10:00:00');


DROP TRIGGER IF EXISTS trg_purchase_details_after_insert;


START TRANSACTION;

-- =====================================================
-- 1. OBTENER LOS ID DE LOS REPOSITORES
-- =====================================================

SET @u1 = (SELECT Id FROM users WHERE Username = 'bgimenez' AND rol = 'Repositor' LIMIT 1);
SET @u2 = (SELECT Id FROM users WHERE Username = 'vcastro' AND rol = 'Repositor' LIMIT 1);
SET @u3 = (SELECT Id FROM users WHERE Username = 'tsilva' AND rol = 'Repositor' LIMIT 1);
SET @u4 = (SELECT Id FROM users WHERE Username = 'crios' AND rol = 'Repositor' LIMIT 1);
SET @u5 = (SELECT Id FROM users WHERE Username = 'macosta' AND rol = 'Repositor' LIMIT 1);


-- =====================================================
-- 2. OBTENER LOS ID DE LOS PROVEEDORES ACTIVOS
-- =====================================================

SET @pr1 = (SELECT Id FROM providers WHERE Cuit = '30-71234567-1' AND State = 1 LIMIT 1);
SET @pr2 = (SELECT Id FROM providers WHERE Cuit = '30-72345678-2' AND State = 1 LIMIT 1);
SET @pr3 = (SELECT Id FROM providers WHERE Cuit = '30-73456789-3' AND State = 1 LIMIT 1);
SET @pr4 = (SELECT Id FROM providers WHERE Cuit = '30-74567890-4' AND State = 1 LIMIT 1);
SET @pr5 = (SELECT Id FROM providers WHERE Cuit = '30-75678901-5' AND State = 1 LIMIT 1);
SET @pr6 = (SELECT Id FROM providers WHERE Cuit = '30-76789012-6' AND State = 1 LIMIT 1);
SET @pr7 = (SELECT Id FROM providers WHERE Cuit = '30-77890123-7' AND State = 1 LIMIT 1);
SET @pr8 = (SELECT Id FROM providers WHERE Cuit = '30-78901234-8' AND State = 1 LIMIT 1);
SET @pr9 = (SELECT Id FROM providers WHERE Cuit = '30-79012345-9' AND State = 1 LIMIT 1);


-- =====================================================
-- 3. OBTENER LOS ID DE LOS PRODUCTOS
-- =====================================================

SET @CPUAMD5500 = (SELECT Id FROM products WHERE Cod = 'CPUAMD5500' LIMIT 1);
SET @CPUAMD5700X = (SELECT Id FROM products WHERE Cod = 'CPUAMD5700X' LIMIT 1);
SET @CPUAMD5800X = (SELECT Id FROM products WHERE Cod = 'CPUAMD5800X' LIMIT 1);
SET @CPUAMD5900X = (SELECT Id FROM products WHERE Cod = 'CPUAMD5900X' LIMIT 1);

SET @CPUINT12100F = (SELECT Id FROM products WHERE Cod = 'CPUINT12100F' LIMIT 1);
SET @CPUINT13400F = (SELECT Id FROM products WHERE Cod = 'CPUINT13400F' LIMIT 1);

SET @GPU_N1650_4 = (SELECT Id FROM products WHERE Cod = 'GPU-N1650-4' LIMIT 1);
SET @GPU_N3060_12 = (SELECT Id FROM products WHERE Cod = 'GPU-N3060-12' LIMIT 1);
SET @GPU_N4060TI_8 = (SELECT Id FROM products WHERE Cod = 'GPU-N4060TI-8' LIMIT 1);
SET @GPU_N4070_12 = (SELECT Id FROM products WHERE Cod = 'GPU-N4070-12' LIMIT 1);

SET @GPU_AMD6600_8 = (SELECT Id FROM products WHERE Cod = 'GPU-AMD6600-8' LIMIT 1);
SET @GPU_AMD7600_8 = (SELECT Id FROM products WHERE Cod = 'GPU-AMD7600-8' LIMIT 1);

SET @MBAUS_A520MK = (SELECT Id FROM products WHERE Cod = 'MBAUS-A520MK' LIMIT 1);
SET @MBGIG_B450DS = (SELECT Id FROM products WHERE Cod = 'MBGIG-B450DS' LIMIT 1);
SET @MBMSI_B550GP = (SELECT Id FROM products WHERE Cod = 'MBMSI-B550GP' LIMIT 1);
SET @MBGIG_B760DS = (SELECT Id FROM products WHERE Cod = 'MBGIG-B760DS' LIMIT 1);

SET @RAMKF8DDR4 = (SELECT Id FROM products WHERE Cod = 'RAMKF8DDR4' LIMIT 1);
SET @RAMKF32DDR4 = (SELECT Id FROM products WHERE Cod = 'RAMKF32DDR4' LIMIT 1);
SET @RAMKF16DDR5 = (SELECT Id FROM products WHERE Cod = 'RAMKF16DDR5' LIMIT 1);
SET @RAMCV16DDR4 = (SELECT Id FROM products WHERE Cod = 'RAMCV16DDR4' LIMIT 1);
SET @RAMCV32DDR4 = (SELECT Id FROM products WHERE Cod = 'RAMCV32DDR4' LIMIT 1);

SET @HDD500GB001 = (SELECT Id FROM products WHERE Cod = 'HDD500GB001' LIMIT 1);
SET @HDD1TB0001 = (SELECT Id FROM products WHERE Cod = 'HDD1TB0001' LIMIT 1);
SET @HDD2TB0001 = (SELECT Id FROM products WHERE Cod = 'HDD2TB0001' LIMIT 1);

SET @SSD_KNV2500 = (SELECT Id FROM products WHERE Cod = 'SSD-KNV2500' LIMIT 1);
SET @SSD_KNV21000 = (SELECT Id FROM products WHERE Cod = 'SSD-KNV21000' LIMIT 1);
SET @SSD_KA400480 = (SELECT Id FROM products WHERE Cod = 'SSD-KA400480' LIMIT 1);
SET @SSD_CMP6001T = (SELECT Id FROM products WHERE Cod = 'SSD-CMP6001T' LIMIT 1);

SET @PSU_CORCV550 = (SELECT Id FROM products WHERE Cod = 'PSU-CORCV550' LIMIT 1);
SET @PSU_CORCV650 = (SELECT Id FROM products WHERE Cod = 'PSU-CORCV650' LIMIT 1);
SET @PSU_GIGP650 = (SELECT Id FROM products WHERE Cod = 'PSU-GIGP650' LIMIT 1);
SET @PSU_MSI750BN = (SELECT Id FROM products WHERE Cod = 'PSU-MSI750BN' LIMIT 1);

SET @CASE_ASAP201 = (SELECT Id FROM products WHERE Cod = 'CASE-ASAP201' LIMIT 1);
SET @CASE_MSI100R = (SELECT Id FROM products WHERE Cod = 'CASE-MSI100R' LIMIT 1);
SET @CASE_GIGC200 = (SELECT Id FROM products WHERE Cod = 'CASE-GIGC200' LIMIT 1);
SET @CASE_ASROCK01 = (SELECT Id FROM products WHERE Cod = 'CASE-ASROCK01' LIMIT 1);

SET @COOL_CORH100 = (SELECT Id FROM products WHERE Cod = 'COOL-CORH100' LIMIT 1);
SET @FAN_CORSP120 = (SELECT Id FROM products WHERE Cod = 'FAN-CORSP120' LIMIT 1);
SET @COOL_ASUSTUF240 = (SELECT Id FROM products WHERE Cod = 'COOL-ASUSTUF240' LIMIT 1);
SET @COOL_MSICL240 = (SELECT Id FROM products WHERE Cod = 'COOL-MSICL240' LIMIT 1);

SET @MON_ASVG249 = (SELECT Id FROM products WHERE Cod = 'MON-ASVG249' LIMIT 1);
SET @MON_MSIG2412 = (SELECT Id FROM products WHERE Cod = 'MON-MSIG2412' LIMIT 1);


-- =====================================================
-- 4. VALIDAR QUE EXISTAN LOS USUARIOS Y PROVEEDORES
-- =====================================================

SELECT
    @u1 IS NOT NULL AND @u2 IS NOT NULL AND
    @u3 IS NOT NULL AND @u4 IS NOT NULL AND
    @u5 IS NOT NULL AS RepositoresCorrectos,
    @pr1 IS NOT NULL AND @pr2 IS NOT NULL AND
    @pr3 IS NOT NULL AND @pr4 IS NOT NULL AND
    @pr5 IS NOT NULL AND @pr6 IS NOT NULL AND
    @pr7 IS NOT NULL AND @pr8 IS NOT NULL AND
    @pr9 IS NOT NULL AS ProveedoresCorrectos;


-- =====================================================
-- 5. VALIDAR QUE NO FALTEN PRODUCTOS
-- =====================================================

SELECT
    (
        @CPUAMD5500 IS NULL OR @CPUAMD5700X IS NULL OR
        @CPUAMD5800X IS NULL OR @CPUAMD5900X IS NULL OR
        @CPUINT12100F IS NULL OR @CPUINT13400F IS NULL OR
        @GPU_N1650_4 IS NULL OR @GPU_N3060_12 IS NULL OR
        @GPU_N4060TI_8 IS NULL OR @GPU_N4070_12 IS NULL OR
        @GPU_AMD6600_8 IS NULL OR @GPU_AMD7600_8 IS NULL OR
        @MBAUS_A520MK IS NULL OR @MBGIG_B450DS IS NULL OR
        @MBMSI_B550GP IS NULL OR @MBGIG_B760DS IS NULL OR
        @RAMKF8DDR4 IS NULL OR @RAMKF32DDR4 IS NULL OR
        @RAMKF16DDR5 IS NULL OR @RAMCV16DDR4 IS NULL OR
        @RAMCV32DDR4 IS NULL OR
        @HDD500GB001 IS NULL OR @HDD1TB0001 IS NULL OR
        @HDD2TB0001 IS NULL OR
        @SSD_KNV2500 IS NULL OR @SSD_KNV21000 IS NULL OR
        @SSD_KA400480 IS NULL OR @SSD_CMP6001T IS NULL OR
        @PSU_CORCV550 IS NULL OR @PSU_CORCV650 IS NULL OR
        @PSU_GIGP650 IS NULL OR @PSU_MSI750BN IS NULL OR
        @CASE_ASAP201 IS NULL OR @CASE_MSI100R IS NULL OR
        @CASE_GIGC200 IS NULL OR @CASE_ASROCK01 IS NULL OR
        @COOL_CORH100 IS NULL OR @FAN_CORSP120 IS NULL OR
        @COOL_ASUSTUF240 IS NULL OR @COOL_MSICL240 IS NULL OR
        @MON_ASVG249 IS NULL OR @MON_MSIG2412 IS NULL
    ) AS HayProductosSinEncontrar;


-- =====================================================
-- 6. CREAR LAS 30 CABECERAS DE COMPRAS
-- =====================================================

INSERT INTO purchases (ProviderId, UserId, PurchaseDate, Total) VALUES
(@pr1, @u1, '2026-08-03', 0),
(@pr2, @u2, '2026-08-07', 0),
(@pr3, @u3, '2026-08-11', 0),
(@pr4, @u4, '2026-08-14', 0),
(@pr5, @u5, '2026-08-18', 0),
(@pr6, @u1, '2026-08-22', 0),
(@pr7, @u2, '2026-08-26', 0),
(@pr8, @u3, '2026-08-29', 0),
(@pr2, @u4, '2026-09-02', 0),
(@pr3, @u5, '2026-09-05', 0),
(@pr4, @u1, '2026-09-09', 0),
(@pr5, @u2, '2026-09-12', 0),
(@pr6, @u3, '2026-09-16', 0),
(@pr7, @u4, '2026-09-19', 0),
(@pr8, @u5, '2026-09-23', 0),
(@pr9, @u1, '2026-09-27', 0),
(@pr1, @u2, '2026-10-01', 0),
(@pr3, @u3, '2026-10-04', 0),
(@pr5, @u4, '2026-10-08', 0),
(@pr7, @u5, '2026-10-11', 0),
(@pr9, @u1, '2026-10-14', 0),
(@pr2, @u2, '2026-10-17', 0),
(@pr4, @u3, '2026-10-21', 0),
(@pr6, @u4, '2026-10-25', 0),
(@pr8, @u5, '2026-11-01', 0),
(@pr1, @u1, '2026-11-03', 0),
(@pr3, @u2, '2026-11-05', 0),
(@pr5, @u3, '2026-11-07', 0),
(@pr7, @u4, '2026-11-09', 0),
(@pr9, @u5, '2026-11-11', 0);


-- =====================================================
-- 7. OBTENER LOS ID DE LAS CABECERAS RECIÉN CREADAS
-- =====================================================

SET @p1 = LAST_INSERT_ID();

-- El INSERT anterior genera IDs consecutivos.
-- Recuperamos el primer ID mediante LAST_INSERT_ID()
-- y asignamos el resto.

SET @p2 = @p1 + 1;
SET @p3 = @p1 + 2;
SET @p4 = @p1 + 3;
SET @p5 = @p1 + 4;
SET @p6 = @p1 + 5;
SET @p7 = @p1 + 6;
SET @p8 = @p1 + 7;
SET @p9 = @p1 + 8;
SET @p10 = @p1 + 9;
SET @p11 = @p1 + 10;
SET @p12 = @p1 + 11;
SET @p13 = @p1 + 12;
SET @p14 = @p1 + 13;
SET @p15 = @p1 + 14;
SET @p16 = @p1 + 15;
SET @p17 = @p1 + 16;
SET @p18 = @p1 + 17;
SET @p19 = @p1 + 18;
SET @p20 = @p1 + 19;
SET @p21 = @p1 + 20;
SET @p22 = @p1 + 21;
SET @p23 = @p1 + 22;
SET @p24 = @p1 + 23;
SET @p25 = @p1 + 24;
SET @p26 = @p1 + 25;
SET @p27 = @p1 + 26;
SET @p28 = @p1 + 27;
SET @p29 = @p1 + 28;
SET @p30 = @p1 + 29;


-- =====================================================
-- 8. INSERTAR LOS 60 DETALLES
-- =====================================================

INSERT INTO purchase_details
    (PurchaseId, ProductId, Quantity, PurchasePrice)
VALUES

-- AGOSTO
(@p1, @CPUAMD5500, 5, 95000),
(@p1, @CPUAMD5700X, 3, 185000),

(@p2, @GPU_N3060_12, 2, 290000),
(@p2, @GPU_N4060TI_8, 1, 420000),

(@p3, @MBMSI_B550GP, 4, 155000),
(@p3, @MBAUS_A520MK, 5, 70000),

(@p4, @RAMKF8DDR4, 10, 25000),
(@p4, @RAMKF32DDR4, 5, 85000),

(@p5, @SSD_KNV2500, 8, 45000),
(@p5, @SSD_KNV21000, 5, 75000),

(@p6, @PSU_CORCV550, 5, 70000),
(@p6, @PSU_CORCV650, 4, 90000),

(@p7, @CASE_ASAP201, 3, 110000),
(@p7, @CASE_MSI100R, 4, 95000),

(@p8, @COOL_CORH100, 2, 165000),
(@p8, @FAN_CORSP120, 10, 22000),

-- SEPTIEMBRE
(@p9, @CPUINT12100F, 6, 80000),
(@p9, @CPUINT13400F, 3, 190000),

(@p10, @GPU_AMD6600_8, 3, 230000),
(@p10, @GPU_AMD7600_8, 2, 320000),

(@p11, @MBGIG_B450DS, 5, 80000),
(@p11, @MBGIG_B760DS, 3, 140000),

(@p12, @RAMCV16DDR4, 8, 48000),
(@p12, @RAMCV32DDR4, 5, 95000),

(@p13, @HDD500GB001, 6, 40000),
(@p13, @HDD1TB0001, 8, 62000),

(@p14, @SSD_KA400480, 10, 42000),
(@p14, @SSD_CMP6001T, 3, 115000),

(@p15, @PSU_GIGP650, 5, 80000),
(@p15, @PSU_MSI750BN, 4, 105000),

(@p16, @CASE_GIGC200, 5, 85000),
(@p16, @CASE_ASROCK01, 4, 75000),

-- OCTUBRE
(@p17, @CPUAMD5800X, 3, 220000),
(@p17, @CPUAMD5900X, 2, 310000),

(@p18, @GPU_N1650_4, 4, 165000),
(@p18, @GPU_N4070_12, 1, 680000),

(@p19, @RAMKF16DDR5, 8, 62000),
(@p19, @RAMKF32DDR4, 6, 85000),

(@p20, @HDD2TB0001, 5, 85000),
(@p20, @SSD_KNV21000, 6, 75000),

(@p21, @PSU_CORCV550, 4, 70000),
(@p21, @PSU_CORCV650, 5, 90000),

(@p22, @MBAUS_A520MK, 4, 70000),
(@p22, @MBMSI_B550GP, 3, 155000),

(@p23, @COOL_ASUSTUF240, 3, 145000),
(@p23, @COOL_MSICL240, 3, 135000),

(@p24, @MON_ASVG249, 2, 245000),
(@p24, @MON_MSIG2412, 2, 260000),

-- NOVIEMBRE
(@p25, @CPUAMD5500, 4, 95000),
(@p25, @CPUINT13400F, 2, 190000),

(@p26, @GPU_N3060_12, 3, 290000),
(@p26, @GPU_AMD7600_8, 2, 320000),

(@p27, @RAMKF8DDR4, 12, 25000),
(@p27, @RAMCV16DDR4, 8, 48000),

(@p28, @SSD_KNV2500, 10, 45000),
(@p28, @SSD_KNV21000, 8, 75000),

(@p29, @PSU_GIGP650, 4, 80000),
(@p29, @PSU_MSI750BN, 3, 105000),

(@p30, @CASE_ASAP201, 3, 110000),
(@p30, @COOL_CORH100, 2, 165000);


-- =====================================================
-- 9. ACTUALIZAR LOS TOTALES DE LAS COMPRAS
-- =====================================================

UPDATE purchases p
SET p.Total = (
    SELECT COALESCE(SUM(pd.Quantity * pd.PurchasePrice), 0)
    FROM purchase_details pd
    WHERE pd.PurchaseId = p.Id
)
WHERE p.Id BETWEEN @p1 AND @p30;


-- =====================================================
-- 10. ACTUALIZAR LOS PRECIOS DE VENTA (+20%)
-- =====================================================

UPDATE products p
INNER JOIN (
    SELECT pd.ProductId, MAX(pd.Id) AS LastDetailId
    FROM purchase_details pd
    WHERE pd.PurchaseId BETWEEN @p1 AND @p30
    GROUP BY pd.ProductId
) latest ON latest.ProductId = p.Id
INNER JOIN purchase_details pd ON pd.Id = latest.LastDetailId
SET p.SalePrice = ROUND(pd.PurchasePrice * 1.20, 2);


-- =====================================================
-- 11. CONFIRMAR TRANSACCIÓN
-- =====================================================

COMMIT;

