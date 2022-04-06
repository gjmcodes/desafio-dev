# Sobre o projeto

Este projeto utiliza as seguintes tecnologias:
- Flutter (web)
- .NET6 (rest api)
- MySQL
- Docker Compose



# Pré-requisitos

- Ter instalado docker e docker compose 
- Ter o arquivo CNAB.txt (versionado juntamente com este projeto)

# Como executar

- Abrir o terminal dentro do diretório "src/", onde se encontra o arquivo **docker-compose.yaml** (src/docker-compose.yaml)
- Executar o comando *docker-compose up*

# API
###### Endereço local: localhost:8080/

###### swagger: localhost:8080/swagger/index.html

| verbo             | endpoint            | descrição                            |
| ----------------  | -------------       | -------------                        |
| GET               | api/transaction     | lista todas transações               |
| POST              | api/transaction     | realiza upload de transações         |
| GET               | api/transaction/{id} | busca por um registro de transação  |
| DELETE            | api/transaction/{id} | remove por um registro de transação |
| GET               | api/cnab            | lista todos cnabs                    |
| GET               | api/cnab/{id}       | busca por um registro de cnab        |

# Web App
###### Endereço local: localhost:8081

# Banco de dados:
###### Endereço local: localhost:3307

######  user: root

######  password: root
