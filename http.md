# Principais protocolos de comunicação da internet

fator de qualsidade no head do http?
tunelamento no metodo connect

http é statelles e cliente/server -> não armazena estados do cliente

connection: close ->  conexão não persistente
Metodos seguros: GET, OPTION, POST 

entity header
campo: Accept -> define os tipos de midia que vai ser aceito
       Content

Cookies e cache
cookies são pequenos pedaços de dados onde são armazenados as informações do cliente e armazenados no servidor para persistir os dados do cliente

fica na header file

cookies de sessão
cookies persistentes

caching
intermediario 

http 2.0
HOL - head of line blocking -> bloquear a conexão até que a resposta chegue no 1.1
    -> Multiplexação: cria uma conexão continua para cada requisição até que chegue a resposta
    -> Prioziração de recursos
    -> Segmentação - Streaming : segmenta a resposta

Push 
    -> Envia varias respostas a partir de uma unica requisição
    -> Não é habilitado por default
    -> O cliente tambem deve ter suporte para o mesmo

Unica conexão persistente
Compressão de header
Server push
https por padrão
negocieação no handshake

servidores/sistemas de aplicação
APACHE
XAMPP -> É para teste
NGINX

HTTPS

Conceitos basicos
    criptografia por chave -> sifra : Assimetrica (chave privada e chave publica), simetrica (chave única privada)
    Certificado digital
    Entidade certificadora -> CA ->  garante a autenticidade
        Papeis: verificação de identidade e emissão de certificados

SSL
    Segurança para conexões TCP
    Autenticidade entra end-points

Operações do ssl
    handshake
        Estabelece a conexão TCP
        Verifica autenticidade (ssl hello)
        Evia a master secret key
    
    key derivation
        deriva a MS

    data transfer
        tranferencia efetiva de dados
        envia REecord + Mac

https
    http + ssl
    usa  aporta 443 para veificação de autenticidade


Protocolo de comunicação WebSocket
    Aplicaçõa baseadas em web
    conexão princial
    chamadas http

    Ex: twitter, trello
    Estabelece uma unica conexão bidirecional
    é encapsulado no http, é um upgrade
    
Como funciona?
    handshake
    data transfer

    Modelo origin base security (restringe as paginas web que vão estar nele)
    So aceita JSON
    frchamento ->  envia uma mensagem da sequencia de encerramento e recebe a confirmação de encerramento

Como funciona a comunicação na internet
    envia o pacote ao dns (envia o dominio e recebe o ip)
    Pode se conectar ao server
    inicia a conexão e recebe um SOCKET TCP

    load balancer - distribuição de carga, multiplexação


