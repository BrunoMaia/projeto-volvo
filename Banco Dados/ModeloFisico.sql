CREATE DATABASE Rede_Concessionaria;
USE Rede_Concessionaria;

CREATE TABLE Proprietario (
    IdProprietario INT IDENTITY(1,1) PRIMARY KEY,
    NomeProprietario VARCHAR(45) NOT NULL,
    CadastroProprietario VARCHAR(14) NOT NULL,
    EnderecoProprietarioCidade VARCHAR(45),
    EnderecoProprietarioBairro VARCHAR(45),
    EnderecoProprietarioLogradouro VARCHAR(45),
    EnderecoProprietarioComplemento VARCHAR(45),
    EnderecoProprietarioNumero INT,
    EmailProprietario VARCHAR(45),
    TelefoneProprietario VARCHAR(20),
    UNIQUE (CadastroProprietario, EmailProprietario, TelefoneProprietario)
);

CREATE TABLE Veiculo (
    IdVeiculo INT IDENTITY(1,1) PRIMARY KEY,
    ChassiVeiculo VARCHAR(17) NOT NULL,
    ModeloVeiculo VARCHAR(45),
    AnoVeiculo INT,
    CorVeiculo VARCHAR(45),
    ValorVeiculo DECIMAL(20,2),
    KmVeiculo INT NOT NULL,
    AcessoriosVeiculo VARCHAR(90),
    VersaoSistVeiculo DECIMAL(5,3) NOT NULL,
    UNIQUE (ChassiVeiculo)
);

CREATE TABLE Vendedor (
    MatriculaVendedor INT IDENTITY(1,1) PRIMARY KEY,
    NomeVendedor VARCHAR(45),
    CpfVendedor VARCHAR(13) NOT NULL ,
    EmailVendedor VARCHAR(45)NOT NULL,
    TelefoneVendedor VARCHAR(20) NOT NULL,
    AdmissaoVendedor DATE,
    VendasMesVendedor INT,
    VendasTotalVendedor INT,
    SalarioVendedor DECIMAL(20,2),
    UNIQUE (MatriculaVendedor, CpfVendedor, EmailVendedor, TelefoneVendedor)
);

CREATE TABLE Vendas (
    IdVendas INT IDENTITY(1,1) PRIMARY KEY,
    MatriculaVendedor INT,
    IdVeiculo INT FOREIGN KEY REFERENCES Veiculo(IdVeiculo),
    QuantidadeVendas INT,
    DataVendas DATE,
    IdProprietario INT FOREIGN KEY REFERENCES Proprietario(IdProprietario)
);
