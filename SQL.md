# DIO-NET-SQL

### Tabelas e tipos de dados

 Modulo de banco de dados relacionais em .NET
- DDL - Definition
- DML - Manipulation
- DQL - Query

SQL server configuration management para parar e rodar o banco de dados quando necessario 

- SELECT

- Retorna todos os dados da tabela
> SELECT * FROM Table ;

- Ordenar os dados
> ORDER BY Nome DESC
> ORDER BY Nome, Cor

- Especificando colunas
> SELECT Coluna1, Coluna2 FROM Table ;

- Colocado condições
logo após o select...
> WHERE Cor = 'Preto' AND Tamanho = 'G' OR Tamanho = 'M' AND Cor = 'Preto'

- Outras condições
> WHERE Nome LIKE 'W%' //Nome começa com W

> WHERE Nome LIKE '%W%' //Nome tem que ter W

- Atualizando registros
UPDATE Produtos
SET Tamanho = 'M',
	Genero = 'F'
WHERE Id = 2

Muito cuidado no Where, nunca esquecer dele ou vai atualizar tudo

- Delecão
> DELETE Produtos

> WHERE Id = 2

BEGIN TRAN 
faz a transação
ROLLBACK

- Criação de uma tabela 

char(# exato de caracteres)
varchar(# max de caracteres)
bit -> (0,1, null)
int
decimal(digitos, casa decimal)
datetime2

NOT NULL -> Obrigatorio
NULL -> pode ser null
IDENTITY(inicio, incremento) -> o campo vai se incrementando

CREATE TABLE Trecos (
    NomeDoCampo TipoDoCampo,
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nome varchar(255) NOT NULL,
	Cor varchar(50) NULL,
	Preco decimal(13, 2) NOT NULL,
	Tamanho varchar(5) NULL,
	Genero char(1) NULL
)


### Mamipulação de dados  

- Contar o numero de linhas
> SELECT COUNT(*) QuantidadeProdutos FROM Produtos WHERE Tamanho = 'M'

- Somar os valores de todas as linhas da coluna
> SELECT SUM(Preco) PrecoTotalTamanhoM FROM Produtos WHERE Tamanho = 'M'

- Valor maximo
> SELECT MAX(Preco) FROM Produtos WHERE Tamanho = 'M'

- Valor minimo
> SELECT MIN(Preco) FROM Produtos WHERE Tamanho = 'M'

- Media
> SELECT AVG(Preco) FROM Produtos

- Concatenando colunas
> SELECT Nome + ' - ' + Cor FROM Produtos

- Maiusculas e minusculas
```
    SELECT Nome + ' - ' + Cor NomePRodutoCompleto,
        UPPER(Nome),
        LOWER(Cor)
    FROM Produtos
```

- Adicionando uma nova coluna
> Tabela -> dbo.Table -> Design

>ALTER TABLE Produtos ADD DataCadastro DATETIME2

- Formatando uma data
> SELECT FORMAT(DataCadastro, 'dd/MM/yyyy') FROM Produtos

- Agrupando
```

SELECT
	Tamanho,
	COUNT(*) Quantidade
FROM Produtos
WHERE Tamanho <> ''  --Diferente de vazio 
GROUP BY Tamanho
ORDER BY Quantidade DESC
```

- Primary key
A chave unica que identifica cada registro na tabela

- Foreign key
Chave que identifica um registro existente em outra tabela
É tipo a referencia para outra tabela

Como relacionar as tabelas

```
CREATE TABLE Enderecos(
	Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdCliente int NULL,
	Rua varchar(255) NULL,
	Bairro varchar(255) NULL,
	Cidade varchar(255) NULL,
	Estado char(2) NULL,

	CONSTRAINT FK_Enderecos_Clientes FOREIGN KEY (IdCliente)
	REFERENCES Clientes(Id)

```

Juntando tabelas
> SELECT * FROM Clientes INNER JOIN Enderecos ON Clientes.Id = Enderecos.IdCliente


### Constrains, funções e procedures

- Constrains
Regas que são seguidas para permitir uma inserção em uma tabela
Alt + F1 no nome da tabela para ver as regras da mesma
	
	- NOT NULL
		Valor não pode ser null

	- UNIQUE
		Garante que um valor de uma coluna seja unica na tabela
		ADD UNIQUE(Nome)
	- CHECK
		Verifica determinada condição
		> ADD CHECK(Genero = 'U' OR Genero = 'F')

	- DEFAULT
		Assume um valor padrão caso não se passe nenhum valor
		> ADD DEFAULT GETDATE() FOR DataCadastro


- Alterando uma constrain 
```
ALTER TABLE Produtos
ADD CONSTRAINT NomeDaConstraint UNIQUE(Nome)
```

- Apagando uma Constraint
Alt+F1 no nome da tabela -> Pega o constraint_name ->
> DROP CONSTRAINT constraint_name

- Stored Procedure
Codigos sql que você pode salvar diretamente no banco de dados

```
CREATE PROCEDURE InserirNovoProduto 
@Nome varchar(255),
@Cor varchar(50),
@Preco decimal,
@Tamanho varchar(5),
@Genero char(1)

AS

INSERT INTO Produtos (Nome, Cor, Preco, Tamanho, Genero)
VALUES (@Nome, @Cor, @Preco, @Tamanho, @Genero)
```

```
EXEC InserirNovoProduto
'NOVO NOME',
'AMARELO',
23,
'G',
'U'
```

- Functions
Codigos SQL que você pode salvar diretamente no banco de dados
Tem que retornar um valor

```
CREATE FUNCTION CalcularDesconto(@Preco decimal(13,2), @Porcentagem int)
RETURNS DECIMAL(13,2)

BEGIN
	RETURN	@Preco - @Preco / 100 * @Porcentagem
END
```
