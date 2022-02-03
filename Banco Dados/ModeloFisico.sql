CREATE TABLE Proprietario (
    IdProprietario INTEGER PRIMARY KEY,
    NomeProprietario CHAR,
    CadastroProprietario CHAR,
    EnderecoProprietarioCidade CHAR,
    EnderecoProprietarioBairro CHAR,
    EnderecoProprietarioLogradouro CHAR,
    EnderecoProprietarioComplemento CHAR,
    EnderecoProprietarioNumero INTEGER,
    EmailProprietario CHAR,
    TelefoneProprietario CHAR,
    UNIQUE (IdProprietario, CadastroProprietario, EmailProprietario, TelefoneProprietario)
);

CREATE TABLE Veículo (
    IdVeiculo INTEGER PRIMARY KEY,
    ChassiVeiculo CHAR,
    ModeloVeiculo CHAR,
    AnoVeiculo INTEGER,
    CorVeiculo CHAR,
    ValorVeiculo DECIMAL,
    KmVeiculo INTEGER,
    AcessoriosVeiculo CHAR,
    VersaoSistVeiculo DECIMAL,
    IdProprietario INTEGER,
    UNIQUE (IdVeiculo, ChassiVeiculo)
);

CREATE TABLE Vendedor (
    MatriculaVendedor INTEGER PRIMARY KEY,
    NomeVendedor CHAR,
    CpfVendedor CHAR,
    EmailVendedor CHAR,
    TelefoneVendedor CHAR,
    AdmissaoVendedor DATE,
    VendasMesVendedor INTEGER,
    VendasTotalVendedor INTEGER,
    SalarioVendedor DECIMAL,
    UNIQUE (MatriculaVendedor, CpfVendedor, EmailVendedor, TelefoneVendedor)
);

CREATE TABLE Vendas (
    IdVendas INTEGER PRIMARY KEY UNIQUE,
    MatriculaVendedor INTEGER,
    IdVeiculo INTEGER,
    QuantidadeVendas INTEGER,
    DataVendas CHAR,
    IdProprietario INTEGER
);
 
ALTER TABLE Veículo ADD CONSTRAINT FK_Veículo_3
    FOREIGN KEY (IdProprietario???)
    REFERENCES ??? (???);
 
ALTER TABLE Vendas ADD CONSTRAINT FK_Vendas_3
    FOREIGN KEY (MatriculaVendedor???, IdVeiculo???, IdProprietario???)
    REFERENCES ??? (???);
 
ALTER TABLE Vendas ADD CONSTRAINT FK_Vendas_4
    FOREIGN KEY (DataVendas, ???)
    REFERENCES Proprietario (TelefoneProprietario, ???);
