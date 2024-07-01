# PJP_ProjetoIntegrador
# DB
## Criar DB
```sql
CREATE DATABASE bibliotechDB
```

## Criar tabelas
```sql
use bibliotechDB;
CREATE TABLE `Emprestimos`(
    `id_emprestimos` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `id_locatario` INT NOT NULL,
    `id_multa` INT NOT NULL,
    `data_emprestimoint` DATE NOT NULL,
    `data_prazo` DATE NOT NULL,
    `data_devolucao` DATE NOT NULL,
    `horario` DATETIME NOT NULL
);
CREATE TABLE `Multa`(
    `id_Multa` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `valor_dia_atraso` FLOAT(53) NOT NULL,
    `valor_final` BIGINT NOT NULL,
    `dias_atraso` INT NOT NULL
);
CREATE TABLE `Emprestimos_livros`(
    `id_emprestimos_livros` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `id_livros` INT NOT NULL,
    `id_emprestimo` BIGINT NOT NULL
);
CREATE TABLE `Funcionários`(
    `id_funcionarios` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nome` TEXT NOT NULL,
    `funcao` TEXT NOT NULL,
    `id_Livros` BIGINT NOT NULL
);
CREATE TABLE `Leitores`(
    `id_Leitor` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nome` TEXT NOT NULL,
    `idade` INT NOT NULL,
    `data_nascimento` DATE NOT NULL,
    `cpf` INT NOT NULL
);
CREATE TABLE `Livros`(
    `id_Livros` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nome` TEXT NOT NULL,
    `autor` TEXT NOT NULL,
    `genero` TEXT NOT NULL,
    `qtd_paginas` INT NOT NULL
);
ALTER TABLE
    `Emprestimos_livros` ADD CONSTRAINT `emprestimos_livros_id_livros_foreign` FOREIGN KEY(`id_livros`) REFERENCES `Livros`(`id_Livros`);
ALTER TABLE
    `Emprestimos` ADD CONSTRAINT `emprestimos_id_emprestimos_foreign` FOREIGN KEY(`id_emprestimos`) REFERENCES `Locatário`(`id_usuarios`);
ALTER TABLE
    `Funcionários` ADD CONSTRAINT `funcionários_id_livros_foreign` FOREIGN KEY(`id_Livros`) REFERENCES `Livros`(`id_Livros`);
ALTER TABLE
    `Emprestimos` ADD CONSTRAINT `emprestimos_id_multa_foreign` FOREIGN KEY(`id_multa`) REFERENCES `Multa`(`id_Multa`);
ALTER TABLE
    `Emprestimos_livros` ADD CONSTRAINT `emprestimos_livros_id_emprestimo_foreign` FOREIGN KEY(`id_emprestimo`) REFERENCES `Emprestimos`(`id_emprestimos`);
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