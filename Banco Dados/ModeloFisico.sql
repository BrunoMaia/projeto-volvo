CREATE DATABASE Rede_Concessionaria;

USE Rede_Concessionaria;

DROP TABLE Cliente;

CREATE TABLE Cliente (
    IdCliente INTEGER IDENTITY (1,1),
    NomeCliente VARCHAR(45) NOT NULL,
    CadastroCliente VARCHAR(14) UNIQUE NOT NULL,
    EmailCliente VARCHAR(45) UNIQUE NOT NULL,
    TelefoneCliente VARCHAR(45) UNIQUE NOT NULL,
    EnderecoClienteCidade VARCHAR(45) NOT NULL,
    EnderecoClienteBairro VARCHAR(45) NOT NULL,
    EnderecoClienteLogradouro VARCHAR(45) NOT NULL,
    EnderecoClienteNumero INTEGER NOT NULL,
    EnderecoClienteComplemento VARCHAR(45),
	PRIMARY KEY (IdCliente)
);

CREATE TABLE Veiculo (
    IdVeiculo INTEGER IDENTITY (1,1),
    ChassiVeiculo VARCHAR(45) UNIQUE NOT NULL,
    ModeloVeiculo VARCHAR(45) NOT NULL,
    AnoVeiculo INTEGER NOT NULL,
    CorVeiculo VARCHAR(45) NOT NULL,
    ValorVeiculo DECIMAL (8,2) NOT NULL,
    KmVeiculo INTEGER NOT NULL,
    AcessoriosVeiculo VARCHAR(200),
    VersaoSistVeiculo DECIMAL (5,5) NOT NULL,
	PRIMARY KEY (IdVeiculo)
);

CREATE TABLE Vendedor (
    MatriculaVendedor INTEGER IDENTITY (1,1),
    NomeVendedor VARCHAR(45) NOT NULL,
    CpfVendedor VARCHAR(11) UNIQUE NOT NULL,
    EmailVendedor VARCHAR(45) UNIQUE NOT NULL,
    TelefoneVendedor VARCHAR(45) UNIQUE NOT NULL,
    AdmissaoVendedor DATE NOT NULL,
    VendasMesVendedor INTEGER NOT NULL,
    VendasTotalVendedor INTEGER NOT NULL,
    SalarioVendedor DECIMAL (8,2) NOT NULL,
	PRIMARY KEY (MatriculaVendedor)
);

CREATE TABLE Venda (
    IdVendas INTEGER IDENTITY (1,1),
    MatriculaVendedor INTEGER NOT NULL,
    IdVeiculo INTEGER NOT NULL,
    IdCliente INTEGER NOT NULL,
    DataVenda DATE NOT NULL,
	PRIMARY KEY (IdVendas),
	FOREIGN KEY (MatriculaVendedor) REFERENCES Vendedor(MatriculaVendedor),
	FOREIGN KEY (IdVeiculo) REFERENCES Veiculo(idVeiculo),
	FOREIGN KEY (IdCliente) REFERENCES Cliente(idCliente)
);
 