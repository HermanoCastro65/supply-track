> Projeto desenvolvido como parte de um case técnico para vaga de estágio em tecnologia.

# SupplyTrack

Sistema web para controle de mercadorias e movimentações de estoque (entrada e saída), desenvolvido com ASP.NET Core MVC.

O objetivo do projeto é demonstrar a construção de uma aplicação completa, com boas práticas de organização, persistência de dados e visualização de informações.

---

## Funcionalidades

* Cadastro de mercadorias (CRUD)
* Registro de movimentações (entrada e saída)
* Relacionamento entre entidades
* Dashboard com visualização de dados (Chart.js)
* Exportação de relatórios em CSV
* Interface responsiva com Bootstrap

---

## Tecnologias Utilizadas

* **.NET 10 (ASP.NET Core MVC)**
* **Entity Framework Core**
* **SQLite**
* **Bootstrap 5**
* **Chart.js**
* **Docker**

---

## Como rodar o projeto

### Pré-requisitos

* .NET 10 SDK instalado
* Docker instalado (opcional)

---

## Rodando localmente

```bash
# Restaurar dependências
dotnet restore

# Executar aplicação
dotnet run
```

Acesse no navegador:

```
http://localhost:5000
```

---

## Rodando com Docker

### 1. Build da imagem

```bash
docker build -t supplytrack .
```

### 2. Executar o container

```bash
docker run -p 8080:8080 supplytrack
```

Acesse:

```
http://localhost:8080
```

---

## Decisões de Arquitetura

### ASP.NET Core MVC

Foi utilizado o padrão MVC para garantir separação clara de responsabilidades entre:

* **Model** → dados e regras de negócio
* **View** → interface com o usuário
* **Controller** → controle do fluxo da aplicação

Essa abordagem facilita manutenção, organização e escalabilidade.

---

### Entity Framework Core

Escolhido para simplificar o acesso ao banco de dados através de ORM, reduzindo a necessidade de escrita manual de SQL e aumentando a produtividade.

---

### SQLite

Utilizado por ser um banco de dados leve, de fácil configuração e ideal para aplicações de demonstração e prototipagem, sem necessidade de infraestrutura externa.

---

### Bootstrap

Adotado para acelerar o desenvolvimento da interface, garantindo responsividade e padronização visual sem necessidade de estilização complexa.

---

### Docker

Utilizado para padronizar o ambiente de execução da aplicação, garantindo que o projeto rode de forma consistente em qualquer máquina.

---

## Estrutura do Projeto

```
Controllers/   → Lógica da aplicação
Models/        → Entidades e regras de negócio
Views/         → Interface do usuário
Data/          → Contexto do banco de dados
wwwroot/       → Arquivos estáticos (CSS, JS)
```
---

