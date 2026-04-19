# NfeValidator API (.NET 10)

Esta é uma API para validação de lotes de documentos fiscais, desenvolvida com **.NET 10**, como desafio técnico no 
processo de seleção para vaga de **Senior Software Engineer** na **InvoiSys Sistemas**. A aplicação processa lotes de documentos, realiza verificações de integridade e duplicidade, e retorna um relatório detalhado de status.

As decisões técnicas para implementação desse projeto foram pautadas pela escalabilidade, testabilidade, desacoplamento (fazendo uso de injeção de dependências) e em boas práticas de arquitetura de projetos (feature by package) e do ecossistema .Net. 

## 🚀 Tecnologias Utilizadas

* **Runtime:** .NET 10.0
* **Biblioteca de Validação:** FluentValidation 12.1.1
* **Testes:** xUnit & Moq

## 📋 Regras de Negócio Importantes

1.  **Tipo de Documento:** A API aceita **exclusivamente** documentos do tipo `"NFE"`. Qualquer outro tipo será marcado como `INVALIDO`.
2.  **Duplicidade:** Não é permitido o envio de documentos duplicados no mesmo lote. A duplicidade é verificada pela combinação de: `Tipo`, `CnpjEmitente`, `Serie` e `Numero`.
3.  **Campos Obrigatórios:** Tipo, CNPJ do emitente (14 dígitos), Número, Série, Valor (maior que zero) e Data de Emissão.

## 🛠️ Como Executar a Aplicação

### Pré-requisitos
* [SDK do .NET 10](https://dotnet.microsoft.com/download/dotnet/10.0) instalado.

### Passo a Passo
1.  **Clone o repositório** e navegue até a pasta do projeto.
2.  **Restaure as dependências:**
    ```bash
    dotnet restore
    ```
3.  **Instale os certificados de desenvolvimento (HTTPS):**
    ```bash
    dotnet dev-certs https --trust
    ```
4.  **Execute a aplicação:**
    ```bash
    dotnet run --project NfeValidator
    ```
---

## 🧪 Como Executar os Testes Unitários

O projeto de testes utiliza **xUnit** e cobre validadores e serviços.

1.  **Navegue até a pasta do projeto NfeValidatorTest ou raiz da solução:**
2.  **Execute o comando:**
    ```bash
    dotnet test
    ```
3.  **Para ver detalhes da cobertura no console:**
    ```bash
    dotnet test --logger:"console;verbosity=detailed"
    ```

---

## 📑 Documentação da API

### Endpoint
* **URL:** `POST http://localhost:5052/api/v1/documentos`
* **Content-Type:** `application/json`

### Contrato de Requisição (Request)
```json
{
  "loteId": "string",
  "documentos": [
    {
      "id": "string",
      "tipo": "string", // Obrigatório: "NFE"
      "numero": "string",
      "serie": "string",
      "valor": 0.00,
      "cnpjEmitente": "string", // 14 dígitos
      "cnpjDestinatario": "string", // Opcional
      "dataEmissao": "ISO-8601 DateTime"
    }
  ]
}
```
### Resposta da Requisição (Response)

```json
{
  "loteId": "string",
  "totalDocumentos": 0,
  "validos": 0,
  "invalidos": 0,
  "documentos": [
    {
      "id": "string",
      "status": "VALIDO | INVALIDO",
      "erros": [
        "string"
      ]
    }
  ]
}
```