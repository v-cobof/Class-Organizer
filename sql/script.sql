CREATE DATABASE ClassOrganizerDb;
GO

-- Usando o banco de dados criado
USE ClassOrganizerDb;
GO

-- Criando a tabela 'aluno'
CREATE TABLE aluno (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    usuario VARCHAR(45) NOT NULL,
    senha CHAR(60) NOT NULL
);
GO

-- Criando a tabela 'turma'
CREATE TABLE turma (
    id INT IDENTITY(1,1) PRIMARY KEY,
    curso_id INT NOT NULL,
    turma VARCHAR(45) NOT NULL,
    ano INT NOT NULL
);
GO

-- Criando a tabela 'aluno_turma' para a relação muitos-para-muitos
CREATE TABLE aluno_turma (
    aluno_id INT NOT NULL,
    turma_id INT NOT NULL,
    PRIMARY KEY (aluno_id, turma_id),
    FOREIGN KEY (aluno_id) REFERENCES aluno(id),
    FOREIGN KEY (turma_id) REFERENCES turma(id)
);
GO