# DIO-NET-SQL
 Modulo de banco de dados relacionais em .NET
- DDL - Definition
- DML - Manipulation
- DQL - Query

SQL server configuration management para parar e rodar o banco de dados quando necessario 

- SELECT

Retorna todos os dados da tabela
> SELECT * FROM Table ;

Ordenar os dados
> ORDER BY Nome DESC
> ORDER BY Nome, Cor

Especificando colunas
> SELECT Coluna1, Coluna2 FROM Table ;

Colocado condições
logo após o select...
> WHERE Cor = 'Preto' AND Tamanho = 'G' OR Tamanho = 'M' AND Cor = 'Preto'

Outras condições
> WHERE Nome LIKE 'W%' //Nome começa com W
> WHERE Nome LIKE '%W%' //Nome tem que ter W
