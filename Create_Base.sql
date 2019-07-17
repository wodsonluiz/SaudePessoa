use db_desenvolvimento;

Create table Pessoa(
Id int not NULL AUTO_INCREMENT,
Nome_Documento varchar(255),
Nome_Social varchar(255),
Sexo int,
Data_Nascimento Datetime,
Situacao_Familiar varchar(50),
Cor_Pele varchar(50),
Etinia varchar(50),
Religiao varchar(50),
Nome_Mae varchar(255),
Nome_Pai varchar(255),
Nome_Conjugue varchar(255),
Cpf varchar(50),
Rg varchar(50),
primary key(Id)); 

Create table Usuario(
Id int not NULL AUTO_INCREMENT,
Id_Pessoa int references Pessoa(id),
email varchar(50),
senha varchar(10),
PRIMARY KEY (Id));


