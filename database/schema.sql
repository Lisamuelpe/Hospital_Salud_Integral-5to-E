-- =====================================================================
-- HOSPITAL SALUD INTEGRAL - ESQUEMA DE BASE DE DATOS
-- Motor: MySQL 8.0 / MariaDB
-- Codificación: utf8mb4 / utf8mb4_unicode_ci
-- =====================================================================

CREATE DATABASE IF NOT EXISTS `hospital_salud_integral` 
    DEFAULT CHARACTER SET utf8mb4 
    DEFAULT COLLATE utf8mb4_unicode_ci;

USE `hospital_salud_integral`;

-- 1. TABLA: departamentos
CREATE TABLE IF NOT EXISTS `departamentos` (
    `id_departamento` INT NOT NULL AUTO_INCREMENT,
    `nombre` VARCHAR(100) NOT NULL,
    `ubicacion` VARCHAR(150) NOT NULL,
    PRIMARY KEY (`id_departamento`),
    UNIQUE KEY `uk_departamentos_nombre` (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 2. TABLA: especialidades
CREATE TABLE IF NOT EXISTS `especialidades` (
    `id_especialidad` INT NOT NULL AUTO_INCREMENT,
    `id_departamento` INT NOT NULL,
    `nombre` VARCHAR(100) NOT NULL,
    PRIMARY KEY (`id_especialidad`),
    UNIQUE KEY `uk_especialidades_nombre` (`nombre`),
    CONSTRAINT `fk_especialidades_departamento` 
        FOREIGN KEY (`id_departamento`) 
        REFERENCES `departamentos` (`id_departamento`) 
        ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 3. TABLA: servicios
CREATE TABLE IF NOT EXISTS `servicios` (
    `id_servicio` INT NOT NULL AUTO_INCREMENT,
    `id_departamento` INT NOT NULL,
    `nombre` VARCHAR(100) NOT NULL,
    `costo` DECIMAL(10, 2) NOT NULL DEFAULT 0.00,
    PRIMARY KEY (`id_servicio`),
    CONSTRAINT `fk_servicios_departamento` 
        FOREIGN KEY (`id_departamento`) 
        REFERENCES `departamentos` (`id_departamento`) 
        ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 4. TABLA: medicos
CREATE TABLE IF NOT EXISTS `medicos` (
    `id_medico` INT NOT NULL AUTO_INCREMENT,
    `id_especialidad` INT NOT NULL,
    `nombre` VARCHAR(100) NOT NULL,
    `apellido` VARCHAR(100) NOT NULL,
    `licencia` VARCHAR(50) NOT NULL,
    `telefono` VARCHAR(20) DEFAULT NULL,
    PRIMARY KEY (`id_medico`),
    UNIQUE KEY `uk_medicos_licencia` (`licencia`),
    CONSTRAINT `fk_medicos_especialidad` 
        FOREIGN KEY (`id_especialidad`) 
        REFERENCES `especialidades` (`id_especialidad`) 
        ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 5. TABLA: usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
    `id_usuario` INT NOT NULL AUTO_INCREMENT,
    `username` VARCHAR(50) NOT NULL,
    `password_hash` VARCHAR(255) NOT NULL,
    `roles` VARCHAR(50) NOT NULL, -- 'Administración', 'Médico', 'Recepcionista'
    `id_medico` INT NULL DEFAULT NULL,
    `activo` TINYINT(1) NOT NULL DEFAULT 1,
    `ultimo_acceso` DATETIME NULL DEFAULT NULL,
    PRIMARY KEY (`id_usuario`),
    UNIQUE KEY `uk_usuarios_username` (`username`),
    CONSTRAINT `fk_usuarios_medico` 
        FOREIGN KEY (`id_medico`) 
        REFERENCES `medicos` (`id_medico`) 
        ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 6. TABLA: pacientes
CREATE TABLE IF NOT EXISTS `pacientes` (
    `id_paciente` INT NOT NULL AUTO_INCREMENT,
    `documento` VARCHAR(50) NOT NULL,
    `nombre` VARCHAR(100) NOT NULL,
    `apellido` VARCHAR(100) NOT NULL,
    `fecha_nacimiento` DATE NOT NULL,
    `sexo` CHAR(1) NOT NULL, -- 'M', 'F'
    `telefono` VARCHAR(20) DEFAULT NULL,
    PRIMARY KEY (`id_paciente`),
    UNIQUE KEY `uk_pacientes_documento` (`documento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 7. TABLA: citas
CREATE TABLE IF NOT EXISTS `citas` (
    `id_cita` INT NOT NULL AUTO_INCREMENT,
    `id_paciente` INT NOT NULL,
    `id_medico` INT NOT NULL,
    `id_servicio` INT NOT NULL,
    `fecha_hora` DATETIME NOT NULL,
    `estado` VARCHAR(30) NOT NULL DEFAULT 'Programada', -- 'Programada', 'Confirmada', 'Atendida', 'Cancelada', 'No asistió'
    `motivo_cancelacion` VARCHAR(255) NULL DEFAULT NULL,
    PRIMARY KEY (`id_cita`),
    CONSTRAINT `fk_citas_paciente` 
        FOREIGN KEY (`id_paciente`) 
        REFERENCES `pacientes` (`id_paciente`) 
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_citas_medico` 
        FOREIGN KEY (`id_medico`) 
        REFERENCES `medicos` (`id_medico`) 
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_citas_servicio` 
        FOREIGN KEY (`id_servicio`) 
        REFERENCES `servicios` (`id_servicio`) 
        ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 8. TABLA: consultas
CREATE TABLE IF NOT EXISTS `consultas` (
    `id_consulta` INT NOT NULL AUTO_INCREMENT,
    `id_cita` INT NOT NULL,
    `diagnostico` TEXT NOT NULL,
    `observaciones` TEXT NULL,
    `fecha_consulta` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (`id_consulta`),
    UNIQUE KEY `uk_consultas_cita` (`id_cita`),
    CONSTRAINT `fk_consultas_cita` 
        FOREIGN KEY (`id_cita`) 
        REFERENCES `citas` (`id_cita`) 
        ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 9. TABLA: medicamentos
CREATE TABLE IF NOT EXISTS `medicamentos` (
    `id_medicamento` INT NOT NULL AUTO_INCREMENT,
    `nombre` VARCHAR(100) NOT NULL,
    `presentacion` VARCHAR(100) NOT NULL,
    `stock` INT NOT NULL DEFAULT 0,
    PRIMARY KEY (`id_medicamento`),
    CONSTRAINT `chk_medicamentos_stock` CHECK (`stock` >= 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 10. TABLA: detalle_receta
CREATE TABLE IF NOT EXISTS `detalle_receta` (
    `id_consulta` INT NOT NULL,
    `id_medicamento` INT NOT NULL,
    `dosis` VARCHAR(100) NOT NULL,
    `duracion_dias` INT NOT NULL DEFAULT 1,
    `detalles` TEXT NULL,
    PRIMARY KEY (`id_consulta`, `id_medicamento`),
    CONSTRAINT `fk_detallereceta_consulta` 
        FOREIGN KEY (`id_consulta`) 
        REFERENCES `consultas` (`id_consulta`) 
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT `fk_detallereceta_medicamento` 
        FOREIGN KEY (`id_medicamento`) 
        REFERENCES `medicamentos` (`id_medicamento`) 
        ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================================
-- DATOS INICIALES (SEMILLA / ENTORNO DE PRUEBAS)
-- Contraseña por defecto para usuarios iniciales: 'Admin123*'
-- Hash SHA256 con Salt ('Admin123*'): se generará y validará mediante AuthService
-- =====================================================================

-- Departamentos iniciales
INSERT INTO `departamentos` (`id_departamento`, `nombre`, `ubicacion`) VALUES
(1, 'Medicina General y Preventiva', 'Edificio A, Planta 1'),
(2, 'Pediatría', 'Edificio B, Planta 2'),
(3, 'Cardiología', 'Edificio A, Planta 3'),
(4, 'Traumatología y Ortopedia', 'Edificio C, Planta 1')
ON DUPLICATE KEY UPDATE `ubicacion`=VALUES(`ubicacion`);

-- Especialidades
INSERT INTO `especialidades` (`id_especialidad`, `id_departamento`, `nombre`) VALUES
(1, 1, 'Medicina Familiar'),
(2, 2, 'Pediatría Integral'),
(3, 3, 'Cardiología Clínica'),
(4, 4, 'Ortopedia y Traumatología')
ON DUPLICATE KEY UPDATE `nombre`=VALUES(`nombre`);

-- Servicios
INSERT INTO `servicios` (`id_servicio`, `id_departamento`, `nombre`, `costo`) VALUES
(1, 1, 'Consulta Medicina General', 30.00),
(2, 2, 'Control Pediátrico', 40.00),
(3, 3, 'Consulta Cardiológica', 60.00),
(4, 3, 'Electrocardiograma (ECG)', 50.00),
(5, 4, 'Evaluación Traumatológica', 55.00)
ON DUPLICATE KEY UPDATE `costo`=VALUES(`costo`);

-- Médicos
INSERT INTO `medicos` (`id_medico`, `id_especialidad`, `nombre`, `apellido`, `licencia`, `telefono`) VALUES
(1, 1, 'Carlos', 'Gómez', 'MED-10492', '809-555-0101'),
(2, 2, 'Laura', 'Martínez', 'MED-20831', '809-555-0102'),
(3, 3, 'Roberto', 'Hernández', 'MED-30944', '809-555-0103'),
(4, 4, 'Patricia', 'Díaz', 'MED-40112', '809-555-0104')
ON DUPLICATE KEY UPDATE `telefono`=VALUES(`telefono`);

-- Pacientes de prueba
INSERT INTO `pacientes` (`id_paciente`, `documento`, `nombre`, `apellido`, `fecha_nacimiento`, `sexo`, `telefono`) VALUES
(1, '402-1234567-1', 'Juan', 'Pérez', '1988-04-12', 'M', '829-555-1101'),
(2, '402-2345678-2', 'María', 'Rodríguez', '1995-08-25', 'F', '829-555-1102'),
(3, '402-3456789-3', 'Lucas', 'Fernández', '2016-11-10', 'M', '829-555-1103')
ON DUPLICATE KEY UPDATE `telefono`=VALUES(`telefono`);

-- Medicamentos iniciales
INSERT INTO `medicamentos` (`id_medicamento`, `nombre`, `presentacion`, `stock`) VALUES
(1, 'Paracetamol 500mg', 'Caja con 20 tabletas', 120),
(2, 'Ibuprofeno 400mg', 'Caja con 10 tabletas', 45),
(3, 'Amoxicilina 500mg', 'Caja con 15 cápsulas', 15), -- Stock bajo
(4, 'Loratadina 10mg', 'Caja con 10 tabletas', 80),
(5, 'Omeprazol 20mg', 'Caja con 28 cápsulas', 60),
(6, 'Losartán 50mg', 'Caja con 30 comprimidos', 8),  -- Stock bajo
(7, 'Salbutamol Inhalador 100mcg', 'Frasco spray 200 dosis', 0) -- Agotado
ON DUPLICATE KEY UPDATE `stock`=VALUES(`stock`);

-- Usuarios iniciales
-- Clave por defecto para todos: Admin123*
-- Hash SHA-256 de "Admin123*": e64205511b8163f972b9a7c369e5d4cb077d70c9ebba5f543e0d8b584a22ad39
INSERT INTO `usuarios` (`id_usuario`, `username`, `password_hash`, `roles`, `id_medico`, `activo`, `ultimo_acceso`) VALUES
(1, 'admin', 'e64205511b8163f972b9a7c369e5d4cb077d70c9ebba5f543e0d8b584a22ad39', 'Administración', NULL, 1, NOW()),
(2, 'drcarlos', 'e64205511b8163f972b9a7c369e5d4cb077d70c9ebba5f543e0d8b584a22ad39', 'Médico', 1, 1, NOW()),
(3, 'recepcion', 'e64205511b8163f972b9a7c369e5d4cb077d70c9ebba5f543e0d8b584a22ad39', 'Recepcionista', NULL, 1, NOW())
ON DUPLICATE KEY UPDATE `roles`=VALUES(`roles`);
