
--Criando um BD para a aula de DALPPII
--Aula 23/08/2016

CREATE DATABASE BDAulaDALPPII
GO

USE BDAulaDALPPII
GO

--Criando tabela Pessoas
CREATE TABLE Pessoas
(
 CdPessoa int PRIMARY KEY IDENTITY,
 NmPessoa varchar(60) NOT NULL,
 NrCPF varchar(20) NOT NULL,
 DtNascimento date NOT NULL,
 DsLogradouro varchar(200) NOT NULL,
 DsCidade varchar(60) NOT NULL,
 DsUF varchar(20) NOT NULL
)
GO
--Criando tabela Produtos
CREATE TABLE Produtos
(
 Cdproduto int PRIMARY KEY IDENTITY,
 NmProduto varchar(60) NOT NULL,
 DsProduto varchar(60) NOT NULL,
 VlProduto decimal(16,2) NOT NULL
)
GO

SELECT * FROM Pessoas
SELECT * FROM Produtos

