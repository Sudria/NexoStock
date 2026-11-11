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


CREATE TRIGGER trg_purchase_details_after_insert
AFTER INSERT ON purchase_details
FOR EACH ROW
BEGIN
    UPDATE products
    SET Stock = Stock + NEW.Quantity
    WHERE Id = NEW.ProductId;
END //


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



