CREATE DATABASE PetSpa
GO
USE PetSpa
GO
CREATE TABLE Historico (
MatriculaDoFuncionario INTEGER,
CodigoAtendimento INTEGER,
CodigoServico INTEGER
);
GO
CREATE TABLE Servico (
CodigoServico INTEGER IDENTITY(1,1) PRIMARY KEY,
NomeServico VARCHAR(100),
DescricaoServico VARCHAR(100)
);
GO
CREATE TABLE Funcao (
CodigoFuncao INTEGER IDENTITY(1,1) PRIMARY KEY,
NomeFuncao VARCHAR(100),
DescricaoFuncao VARCHAR(300)
);
GO
CREATE TABLE Animal (
CodigoAnimal INTEGER IDENTITY(1,1) PRIMARY KEY,
NomeDoAnimal VARCHAR(100),
Peso VARCHAR(10),
Idade VARCHAR(10),
CPF VARCHAR(11),
CodigoRaca INTEGER
);
GO
CREATE TABLE Agenda (
CodigoAgenda INTEGER IDENTITY(1,1) PRIMARY KEY,
Hora VARCHAR(5),
Data VARCHAR(10),
Encaixe VARCHAR(3),
CodigoAnimal INTEGER,
CPF VARCHAR(11),
CodigoServico INTEGER,
FOREIGN KEY(CodigoAnimal) REFERENCES Animal (CodigoAnimal)
);
GO
CREATE TABLE Atendimento (
CodigoAtendimento INTEGER IDENTITY(1,1) PRIMARY KEY,
Descricao VARCHAR(100),
Status VARCHAR(100),
CodigoAgenda INTEGER,
CodigoMatricula INTEGER,
FOREIGN KEY(CodigoAgenda) REFERENCES Agenda (CodigoAgenda)
);
GO
CREATE TABLE Funcionario (
CodigoMatricula INTEGER IDENTITY(1,1) PRIMARY KEY,
NomeDoFuncionario VARCHAR(50),
SobreNome VARCHAR(50),
CodigoFuncao INTEGER,
FOREIGN KEY(CodigoFuncao) REFERENCES Funcao (CodigoFuncao)
);
GO
CREATE TABLE Tipo (
CodigoTipo INTEGER IDENTITY(1,1) PRIMARY KEY,
NomeTipo VARCHAR(50)
);
GO
CREATE TABLE Raca (
CodigoRaca INTEGER IDENTITY(1,1) PRIMARY KEY,
NomeRaca VARCHAR(100 ),
DescricaoRaca VARCHAR(300),
CodigoTipo INTEGER
);
GO
CREATE TABLE Cliente (
CPF VARCHAR(11) PRIMARY KEY,
Nome VARCHAR(50),
SobreNome VARCHAR(50),
Telefone VARCHAR(11)
);
GO
CREATE TABLE Endereco (
CodigoEndereco INTEGER IDENTITY(1,1) PRIMARY KEY,
Logradouro VARCHAR(200),
Complemento VARCHAR(100),
Bairro VARCHAR(100),
Estado VARCHAR(2),
CEP VARCHAR(8),
Numero VARCHAR(10),
Cidade VARCHAR(100),
CPF VARCHAR(11),
FOREIGN KEY(CPF) REFERENCES Cliente (CPF)
);
GO
ALTER TABLE Historico ADD FOREIGN KEY(MatriculaDoFuncionario) REFERENCES Funcionario (CodigoMatricula);
GO
ALTER TABLE Historico ADD FOREIGN KEY(CodigoAtendimento) REFERENCES Atendimento (CodigoAtendimento);
GO
ALTER TABLE Historico ADD FOREIGN KEY(CodigoServico) REFERENCES Servico (CodigoServico);
GO
ALTER TABLE Animal ADD FOREIGN KEY(CPF) REFERENCES Cliente (CPF);
GO
ALTER TABLE Animal ADD FOREIGN KEY(CodigoRaca) REFERENCES Raca (CodigoRaca);
GO
ALTER TABLE Agenda ADD FOREIGN KEY(CPF) REFERENCES Cliente (CPF);
GO
ALTER TABLE Agenda ADD FOREIGN KEY(CodigoServico) REFERENCES Servico (CodigoServico);
GO
ALTER TABLE Atendimento ADD FOREIGN KEY(CodigoMatricula) REFERENCES Funcionario (CodigoMatricula);
GO
ALTER TABLE Raca ADD FOREIGN KEY(CodigoTipo) REFERENCES Raca (CodigoRaca);
