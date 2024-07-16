CREATE DATABASE bibliotechDB;
USE bibliotechDB;

CREATE TABLE `Multa` (
    `id_multa` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `valor_dia_atraso` DECIMAL(10,2) NOT NULL,
    `valor_final` DECIMAL(10,2) NOT NULL,
    `dias_atraso` INT NOT NULL
);

CREATE TABLE `Usuarios` (
    `id_usuario` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nome` VARCHAR(255) NOT NULL,
    `cpf` INT NOT NULL,
    `data_nascimento` VARCHAR(10) NOT NULL
);

CREATE TABLE `Livros` (
    `id_livro` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nome` VARCHAR(255) NOT NULL,
    `autor` VARCHAR(255) NOT NULL,
    `genero` VARCHAR(255) NOT NULL,
    `qtd_paginas` INT NOT NULL
);

CREATE TABLE `Funcionarios` (
    `id_funcionario` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nome` VARCHAR(255) NOT NULL,
    `funcao` VARCHAR(255) NOT NULL,
    `id_livro` INT UNSIGNED NOT NULL,
    INDEX (`id_livro`),
    FOREIGN KEY (`id_livro`) REFERENCES `Livros`(`id_livro`)
);

CREATE TABLE `Emprestimos` (
    `id_emprestimo` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `data_emprestimo` VARCHAR(10) NOT NULL,
    `data_prazo` VARCHAR(10) NOT NULL,
    `data_devolucao` VARCHAR(10) NOT NULL,
    `horario` VARCHAR(8) NOT NULL,
    `id_multa` INT UNSIGNED,
    `id_usuario` INT UNSIGNED NOT NULL,
    `id_livro` INT UNSIGNED NOT NULL,
    INDEX (`id_multa`),
    INDEX (`id_usuario`),
    INDEX (`id_livro`),
    FOREIGN KEY (`id_multa`) REFERENCES `Multa`(`id_multa`),
    FOREIGN KEY (`id_usuario`) REFERENCES `Usuarios`(`id_usuario`),
    FOREIGN KEY (`id_livro`) REFERENCES `Livros`(`id_livro`)
);
