USE PetSpa
INSERT INTO tipo (NomeTipo)
VALUES ('Gato'),
       ('Cachorro'),
       ('Papaguaio'),
       ('Periquito');
GO
INSERT INTO raca (NomeRaca,DescricaoRaca,CodiGOTipo)
VALUES		('Pastor Alemão','Cachorro grande, calmo e dócil',2),
		    ('Poodle','Os poodles são bem brincalhões, felizes e inteligentes',2),
		    ('Boxer','Os Boxers são cães que apresentam grande afeto com seus donos. Porém, com pessoas estranhas costumam agir com certa desconfiança.',2),
		    ('Pitbull','O pit bull é um cão ágil e com grande impulso muscular.',2);
GO
INSERT INTO Endereco (Logradouro,Complemento,Bairro,Estado,CEP,Numero,Cidade)
VALUES		('Av.Jadiel França','Avenida','Professores','PE',50000001,'0000000100','Recife'),
		('Av.Fabio Chicout','Avenida','Professores','PE',50000002,'0000000101','Recife'),
		('Av.Aldo Moura','Avenida','Professores','PE',50000003,'0000000102','Recife'),
		('Av.Fred Lucena','Avenida','Professores','PE',50000004,'0000000103','Recife');
GO
INSERT INTO Cliente(CPF,Nome,SobreNome,Telefone)
VALUES('22254569852','Jadiel','França','33556699'),
		('22254569853','Fabio','Chicout','36956699'),
		('22254569854','Aldo','Moura','69852325'),
		('22254569855','Fred','Lucena','58742365');
GO
INSERT INTO Animal(NomeDoAnimal,Peso,Idade,CPF,CodiGORaca)
VALUES('Jadialma',20,1,'22254569852',2),
		('Chicote',20,2,'22254569853',2),
		('Coca-Cola',20,3,'22254569854',2),
		('Fred',20,4,'22254569855',2);
GO
INSERT INTO Servico(NomeServico,DescricaoServico)
VALUES ('Creche com solário','O Pet Spa conta com uma ampla área com cobertura retrátil'),
	   ('Piscina','O Pet Spa também oferece piscina'),
	   ('Consultório Veterinário','Para garantir a saúde do seu melhor amiGO'),
	   ('Farmácia','O Pet Spa, dispõe de medicamentos para o tratamento completo');
GO
INSERT INTO funcao (NomeFuncao,Descricaofuncao)
VALUES		('Veterinário','Todos os serviços');
GO
INSERT INTO Funcionario(NomeDoFuncionario,SobreNome,CodiGOFuncao)
VALUES		('Ricardo',' Baudel',1),
			('Anderson','  Tenório',1),
			('Carmina','  Hissa',1),
			('Sinalzinho','narizinho' ,1);
INSERT INTO Agenda (Hora,Data,CodiGOAnimal,CodiGOServico,CPF)
VALUES
					('11:00','11/11/1111',1,1,22254569852)