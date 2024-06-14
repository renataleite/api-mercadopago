# Projeto de Integração com MercadoPago

Este projeto é uma API desenvolvida em .NET 7 que facilita a integração com a API do MercadoPago para processamento de pagamentos.

## Funcionalidades

- **Processamento de Pagamentos**: Permite criar preferências de pagamento e redirecionar os usuários para o checkout do MercadoPago.
- **Documentação da API**: Geração automática da documentação da API com Swagger.

## Tecnologias Utilizadas

- .NET 7.0
- ASP.NET Core
- MercadoPago SDK
- Swagger (Swashbuckle)

## Configuração

### Pré-requisitos

- .NET 7.0 SDK
- IDE de sua escolha (Recomendado: Visual Studio, VSCode)
- Conta de desenvolvedor no MercadoPago

### Configuração do Ambiente

Clone o repositório:
```bash
 git clone <url-do-repositorio>
```

Navegue até o diretório do projeto e restaure as dependências:
```bash
cd <nome-do-projeto>
dotnet restore

```

Configure o token de acesso do MercadoPago no arquivo de configurações ou diretamente no código:
```bash
MercadoPagoConfig.AccessToken = "SEU_ACCESS_TOKEN";

```

### Uso
Execute o projeto localmente:
```bash
dotnet run
```
Acesse a documentação da API via Swagger em [http://localhost:<port>/swagger](http://localhost:<port>/swagger).

O endpoint disponível será:

- **POST** `/redirect-mercadopago`: Endpoint para criar uma preferência de pagamento e retornar o URL de redirecionamento para o checkout do MercadoPago.

## Segurança

**Importante:** Nunca exponha chaves de API ou tokens sensíveis em seu código quando estiver em produção. Utilize variáveis de ambiente ou serviços seguros de gerenciamento de configurações.

## Contribuição

Contribuições são sempre bem-vindas! Sinta-se à vontade para forkar o projeto e submeter suas pull requests.
