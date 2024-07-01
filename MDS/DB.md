# DB
## Criar DB
```sql
CREATE DATABASE bibliotechDB
```

## Criar tabelas
```sql
USE bibliotechDB;

CREATE TABLE `Multa` (
    `id_Multa` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `valor_dia_atraso` FLOAT(53) NOT NULL,
    `valor_final` BIGINT NOT NULL,
    `dias_atraso` INT NOT NULL
);

CREATE TABLE `Leitores` (
    `id_leitor` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nome` TEXT NOT NULL,
    `idade` INT NOT NULL,
    `data_nascimento` DATE NOT NULL,
    `cpf` INT NOT NULL
);

CREATE TABLE `Livros` (
    `id_Livros` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nome` TEXT NOT NULL,
    `autor` TEXT NOT NULL,
    `genero` TEXT NOT NULL,
    `qtd_paginas` INT NOT NULL
);

CREATE TABLE `Emprestimos` (
    `id_emprestimos` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `id_locatario` INT NOT NULL,
    `id_multa` INT NOT NULL,
    `data_emprestimoint` DATE NOT NULL,
    `data_prazo` DATE NOT NULL,
    `data_devolucao` DATE NOT NULL,
    `horario` DATETIME NOT NULL,
    FOREIGN KEY (`id_locatario`) REFERENCES `Leitores`(`id_leitor`),
    FOREIGN KEY (`id_multa`) REFERENCES `Multa`(`id_Multa`)
);

CREATE TABLE `Emprestimos_livros` (
    `id_emprestimos_livros` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `id_livros` INT NOT NULL,
    `id_emprestimo` INT UNSIGNED NOT NULL,
    FOREIGN KEY (`id_livros`) REFERENCES `Livros`(`id_Livros`),
    FOREIGN KEY (`id_emprestimo`) REFERENCES `Emprestimos`(`id_emprestimos`)
);

CREATE TABLE `Funcionarios` (
    `id_funcionarios` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nome` TEXT NOT NULL,
    `funcao` TEXT NOT NULL,
    `id_Livros` INT NOT NULL,
    FOREIGN KEY (`id_Livros`) REFERENCES `Livros`(`id_Livros`)
);
```

## código para conectar no BD 

```c#
public static void InitConexao(){
            string info = "server=localhost;database=bibliotechDB;user id=root;password=''";
            conexao = new MySqlConnection(info);
            try {
                conexao.Open();
            } catch {
                MessageBox.Show("Não deu, foi mal");
            }
        }
        public static void CloseConexao() {
            conexao.Close();
        }
```