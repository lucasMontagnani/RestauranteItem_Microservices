# RestautanteItem_Microservices

Este projeto foi desenvolvido com base na formação da Alura em **Microsserviços e .NET 6: Implementando a Comunicação**. A proposta é trabalhar com dois serviços principais:

- **ItemService**: Responsável pelo cadastro de itens para os restaurantes.
- **RestauranteService**: Responsável por exibir informações dos restaurantes.

## 🛠️ Tecnologias e Ferramentas Utilizadas

- **.NET 6**
- **Docker** e **Docker Compose**
- **RabbitMQ** (mensageria)
- **MySQL** (banco de dados)

## 🔑 Pontos Principais

Durante a construção do projeto, os seguintes conceitos e práticas foram abordados:

### Comunicação e Serialização
- Como receber dados devidamente serializados entre diferentes aplicações.
- Configuração de requisições assíncronas para maior confiabilidade na comunicação entre microsserviços.

### Contêineres e Docker
- Criação e configuração de **Dockerfiles** para aplicações .NET.
- Implementação de **multi-stage builds** para reduzir custos de armazenamento de imagens.
- Deploy de containers **MySQL** e **RabbitMQ**.
- Configuração da rede do Docker para comunicação entre múltiplos containers.

### RabbitMQ
- Configuração do RabbitMQ como ferramenta de mensageria a nível de código.
- Consumo de dados de filas RabbitMQ através de uma aplicação .NET.
- Execução de serviços em segundo plano dentro de aplicações .NET.

### Validação do Fluxo
- Subida de múltiplos containers em uma mesma rede para validar o fluxo de comunicação esperado.
